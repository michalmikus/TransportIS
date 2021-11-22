using TransportIS.DAL.Enums;

namespace TransportIS.BL.Models.DetailModels
{
    public class ConnectionListModel
    {
        public Guid Id { get; set; }

        public string? Name { get; set; }

        public string? Description { get; set; }

        public int? NumberOFSeats { get; set; }

        public int? ReservedSeats { get; set; }

        public VehicleType VehicleType { get; set; }

        public EmploeeDetailModel EmploeeDetailModel { get; set; } = new EmploeeDetailModel();

        public CarrierListModel Carrier { get; set; } = new CarrierListModel();

        public ICollection<StopDetailModel> Stops { get; set; } = new List<StopDetailModel>();
    }
}
