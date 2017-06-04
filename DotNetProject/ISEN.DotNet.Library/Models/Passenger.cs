using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace ISEN.DotNet.Library.Models
{
    public class Passenger : Person
    { 
 
        [NotMapped]
        public override string Display => $"Passenger : {LastName} {FirstName}";

        public void reserve(Voyage v){
        	
        }
        [NotMapped]
        public List<Booking> BookingCollection { get; set; } = new List<Booking>();

        [NotMapped]
        public Voyage[] Voyages => BookingCollection
                    .Where(r => r.Voyage != null)
                    .Select(r => r.Voyage)
                    .ToArray();     

        public void AddVoyage(Voyage voyage)
        {
            if (voyage != null && !HasVoyage(voyage))
                BookingCollection.Add(
                    new Booking()
                    {
                        Passenger = this,
                        Voyage = voyage
                    }
                );
        }
        public bool HasVoyages => BookingCollection.Count > 0;
        public bool HasVoyage(Voyage voyage) =>
            BookingCollection.Any(
                r => r.Voyage != null 
                   && r.Voyage.Id == voyage.Id);
    }
}
