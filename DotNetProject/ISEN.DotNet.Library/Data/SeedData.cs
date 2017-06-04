using System;
using System.Linq;
using ISEN.DotNet.Library.Models;
using ISEN.DotNet.Library.Repositories.Interfaces;
using Microsoft.Extensions.Logging;

namespace ISEN.DotNet.Library.Data
{
    public class SeedData
    {
        private readonly ApplicationDbContext _context;
        private readonly IPersonRepository _personRepository;
        private readonly IVoyageRepository _voyageRepository;
        private readonly IBookingRepository _bookingRepository;
        private readonly ILogger<SeedData> _logger;

        public SeedData(
            ApplicationDbContext context,
            IPersonRepository personRepository,
            IVoyageRepository voyageRepository,
            IBookingRepository bookingRepository,
            ILogger<SeedData> logger)
        {
            _context = context;
            _personRepository = personRepository;
            _voyageRepository = voyageRepository;
            _bookingRepository = bookingRepository;
            _logger = logger;
        }

        public void DropCreateDatabase() {           
            var deleted = _context.Database.EnsureDeleted();
            var deletedString = deleted ? "dropped" : "not dropped";
            _logger.LogWarning($"Database was {deletedString}");

            var created = _context.Database.EnsureCreated();
            var createdString = deleted ? "created" : "not created";
            _logger.LogWarning($"Database was {createdString}");
        }

        public void AddPersons() {
            if (_personRepository.GetAll().Any()) return;

            _logger.LogWarning("Persons added");

#region 5 persons random
            var p1 = new Driver()
            {
                LastName = "Simpson",
                FirstName = "Homer"
            };    
            var p2 = new Driver()
            {
                LastName = "Simpson",
                FirstName = "Marge"
            };
            var p3 = new Passenger()
            {
                LastName = "Simpson",
                FirstName = "Bart"
            };
            var p4 = new Passenger()
            {
                LastName = "Simpson",
                FirstName = "Maggie"
            };
            var p5 = new Passenger()
            {
                LastName = "Simpson",
                FirstName = "Abraham"
            };
#endregion

            _personRepository.UpdateRange(p1, p2, p3, p4, p5);
            _personRepository.Save();

            _logger.LogWarning("Persons added");
        }
         

        public void AddVoyages() {
            if (_voyageRepository.GetAll().Any()) return;
            var d1 = _personRepository.Single(p => p.FirstName == "Homer");
            var d2 = _personRepository.Single(p => p.FirstName == "Marge");
            _logger.LogWarning("Voyages added");

#region 3 voyages random
            var v1 = new Voyage() {
                StartPlace = "EverGreen Terrace",
                EndPlace = "School",
                Seat = 4,
                RemainingSeat = 2,
                Comment = "Let's Go",
                Driver = (Driver)d2,
                StartTime = DateTime.Now
            };
            var v2 = new Voyage() {
                StartPlace = "EverGreen Terrace",
                EndPlace = "Moe's'",
                Seat = 4,
                RemainingSeat = 0,
                Comment = "I love beer",
                Driver = (Driver)d1,
                StartTime = DateTime.Now.AddHours(2)
            };
            var v3 = new Voyage() {
                StartPlace = "Kwik e Mart",
                EndPlace = "EverGreen Terrace",
                Seat = 4,
                RemainingSeat = 3,
                Comment = "Let's buy a squishy",
                Driver = (Driver)d2,
                StartTime = DateTime.Now.AddDays(1)
            };
            var v4 = new Voyage() {
                StartPlace = "SpringField",
                EndPlace = "Ney-York",
                Seat = 4,
                RemainingSeat = 0,
                Comment = "The City of New York vs. Homer Simpson",
                Driver = (Driver)d2,
                StartTime = new DateTime(1997,9,21,12,12,00),
                Archived = true
            }; 
#endregion
            _voyageRepository.UpdateRange(v1, v2, v3);
            _voyageRepository.Save();

            _logger.LogWarning("Voyages added");
            
        }        

        public void AddBookings()
        {
               if (_bookingRepository.GetAll().Any()) return;

               var v1 = _voyageRepository.Single(v => v.EndPlace == "School");
               var v2 = _voyageRepository.Single(v => v.EndPlace == "EverGreenTerrace");
               var p1 = _personRepository.Single(p => p.FirstName == "Bart");
               var p2 = _personRepository.Single(p => p.FirstName == "Lisa");
               var p3 = _personRepository.Single(p => p.FirstName == "Maggie");

            _logger.LogWarning("Bookings Added");

#region 3 booking random
            var b1 = new Booking()
            {
                Comment = "I Hate School ",
                Voyage = v1,
                Passenger = (Passenger)p1       
            };
            var b2 = new Booking()
            {
                Comment = "I Love School",
                Voyage = v1,
                Passenger = (Passenger)p2  
            };
            var b3 = new Booking()
            {
                Comment = "Twig Twig",
                Voyage = v2,
                Passenger = (Passenger)p1  
            };    
#endregion
            _bookingRepository.UpdateRange(b1, b2, b3);
            _bookingRepository.Save();
            _logger.LogWarning("Booking added");
            
        }
    }
}
