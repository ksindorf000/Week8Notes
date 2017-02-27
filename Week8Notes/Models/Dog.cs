using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Week8Notes.Models
{
    public class Dog
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool HasDay { get; set; }
        public int Age { get; set; }
    }

    public class DogContext : DbContext
    {
       public DbSet<Dog> Dogs { get; set; }
    }

}