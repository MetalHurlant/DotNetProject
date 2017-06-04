using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ISEN.DotNet.Library.Models
{
    public class Person : BaseEntity
    {
        public string FirstName { get;set; }
        public string LastName { get;set; }   
 		

        [NotMapped]
        public override string Display => $"{LastName} {FirstName}";
    }
}
