using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrudUsingXamarin.Models
{
    public class User
    {
        [PrimaryKey]
        public int Id { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }

        public override string ToString()
        {
            return this.Name + "(" + this.LastName + ")";
        }
    }
}
