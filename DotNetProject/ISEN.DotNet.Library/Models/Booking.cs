namespace ISEN.DotNet.Library.Models
{
    public class Booking: BaseEntity
    {
    	public int? VoyageId { get;set; }
        public Voyage Voyage { get;set; }

        public int? PassengerId { get;set; }
        public Passenger Passenger { get;set; }
        public string Comment { get; set; }
    }
}
