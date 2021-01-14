using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MovieShop.Models
{
    public class Genre
    {
        //Mapped to the primary key of the corresponding table in DB
        public int Id { get; set; }
        public string Name { get; set; }
    }
}