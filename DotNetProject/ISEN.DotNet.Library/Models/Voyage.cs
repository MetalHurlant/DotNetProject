using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;


namespace ISEN.DotNet.Library.Models
{
    // TODO : Coder la relation inverse des Personnes
    public class Voyage : ArchivableEntity
    {
        public string StartPlace { get; set; }
        public string EndPlace { get; set; }
        public DateTime StartTime {get; set;}
        public int Seat { get; set; }
        public int RemainingSeat { get; set; }
        public string Comment { get; set; }

        public int? DriverId { get;set; }

        public Driver Driver{ get; set; }

        [NotMapped]
        public List<Booking> BookingCollection { get; set; } = new List<Booking>();

        [NotMapped]
        public Passenger[] Passengers => BookingCollection
                    .Where(op => op.Passenger != null)
                    .Select(op => op.Passenger)
                    .ToArray();

        public bool Gone() {
            if (DateTime.Compare(DateTime.Now,StartTime)>0) {
                return true;
            }
            return false;
        }
        public bool Full() {
            if (RemainingSeat>0) {
                return false;
            }
            return true;
        }
        public void AddPerson(Passenger Passenger) {
            if (Passenger != null && !HasPerson(Passenger) && !Gone()) {
               BookingCollection.Add(
                    new Booking() {
                        Passenger = Passenger,
                        Voyage = this
                    }
                );
                RemainingSeat --; 
            }
                
        }
        public void AddPerson(Passenger Passenger, string comment) {
            if (Passenger != null && !HasPerson(Passenger) && !Gone()){
                BookingCollection.Add(
                    new Booking()
                    {
                        Passenger = Passenger,
                        Voyage = this,
                        Comment = comment
                    }
                );
                RemainingSeat --;
            }  
        }

        public bool HasPersons => BookingCollection.Count > 0;
        public bool HasPerson(Passenger Passenger) =>
            BookingCollection.Any(
                op => op.Passenger != null && op.Passenger.Id == Passenger.Id);        
    }
}
