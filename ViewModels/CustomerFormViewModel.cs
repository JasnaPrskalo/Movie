using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MovieShop.Models;

namespace MovieShop.ViewModels
{
    public class CustomerFormViewModel
    {
        //IENumerable because we do not need any functionality that List<> provides, like add, remove.
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }

}