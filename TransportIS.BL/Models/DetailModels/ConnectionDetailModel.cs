using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class ConnectionDetailModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? ReservedSeats { get; set; }

        public int? EmptySeats { get; set; }

        public string? VehicleType  { get; set; }

        public Guid? VehicleId { get; set; }

        public string? CarrierName { get; set; }

        public Guid? CarrierId { get; set; }

        public ICollection<string?> PersonelNames { get; set; } = new List<string?>();
        
        public ICollection<Guid?> PersonelIds { get; set; } = new List<Guid?>();

        public ICollection<string?> NamesOfStops { get; set; } = new List<string?>();
        
        public ICollection<Guid?>   StopIds { get; set; } = new List<Guid?>();

        public ICollection<DateTime> TimeOfStops { get; set; } = new List<DateTime>();

        public ICollection<Guid?> TicketIds { get; set; } = new List<Guid?>();
    }
}
