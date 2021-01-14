using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using MovieShop.Models;
using System.Data.Entity;
using MovieShop.ViewModels;

namespace MovieStore.Controllers
{
    public class CustomersController : Controller
    {
        //1. declare a private fiels - by convention
        private ApplicationDbContext _context;

        //2.Initialize the field in the constructor
        public CustomersController()
        {
            _context = new ApplicationDbContext();
        }

        //3.properly dispose the object - to override the Dispose Method of the base controller class
        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        //action for creating a form for adding a new customer
        public ActionResult New()
        {
            //add membershipType dropdown list for new customer
            var membershipTyps = _context.MembershipTypes.ToList();
            var viewModel = new CustomerFormViewModel
            {
                //Initialize the customer, otherwise by default is null
                Customer =  new Customer(), //Now its properties will be initialized by their default values
                MembershipTypes = membershipTyps
            };
            return View("CustomerForm", viewModel);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        //Here is Customer type of a paramethar and not NewCutomerViewModel because in the view, every property is prefixed with .Customer
        public ActionResult Save(Customer customer)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CustomerFormViewModel
                {
                    Customer = customer,
                    MembershipTypes = _context.MembershipTypes.ToList()
                };
                return View("CustomerForm", viewModel);
            }
            if (customer.Id == 0)
                //add the new customer in the memory
                _context.Customers.Add(customer);
            else
            {
                //To update entety we need to get it from the DB firts, so the DbContectx can track changes in that entity
                var customerInDb = _context.Customers.Single(c => c.Id == customer.Id);

                //update its properties based on tha values in the form
                customerInDb.Name = customer.Name;
                customerInDb.Birthdate = customer.Birthdate;
                customerInDb.MembershipTypeId = customer.MembershipTypeId;
                customerInDb.IsSbscribedToNewsletter = customer.IsSbscribedToNewsletter;
            }

            //Save the changes to the DB
            _context.SaveChanges();
            //redirect the user back to the list of customers
            return RedirectToAction("Index", "Customers");
        }

        public ActionResult Index()
        {
            //4.Initialize the customers variable
          //  var customers = _context.Customers.Include(c => c.MembershipType).ToList();  //Do not need any more the list of customers because the DataTable will send an AJAX request to get them from cyustomers API
            //Get all the customers from the database
            //EF is not query the DB. Deferred execution
            return View();
        }
        public ActionResult Details(int id)
        {
            var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            return View(customer);
        }

        public ActionResult Edit(int id)
        {

            var customer = _context.Customers.SingleOrDefault(c => c.Id == id);
            if (customer == null)
                return HttpNotFound();

            //Because the typ behind the New view is NewCustomerViewModel
            var ViewModel = new CustomerFormViewModel
            {
                Customer = customer,
                MembershipTypes = _context.MembershipTypes.ToList()
            };
            //Overriding the MVC convention, and specify the view that will be returned, otherwise MVC will look for a view called EDIT
            return View("CustomerForm", ViewModel);
        }
    }
}
