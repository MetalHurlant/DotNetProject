using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ISEN.DotNet.Library.Models
{
    public class Driver : Person
    { 
 
        [NotMapped]
        public override string Display => $"Driver : {LastName} {FirstName}";

        public List<Voyage> VoyageCollection {get; set;} = new List<Voyage>();

        void propose(Voyage v){
        	VoyageCollection.Add(v);
        	v.Driver = this;
        }
    }
}
