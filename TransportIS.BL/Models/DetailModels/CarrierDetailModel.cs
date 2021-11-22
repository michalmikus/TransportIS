using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportIS.BL.Models.DetailModels
{
    public class CarrierDetailModel
    {
        public Guid Id { get; set; }

        public string? CarrierName { get; set;}

        public string? Address { get; set;}

        public string? TaxNumber { get; set; }

        public string? TelephoneNumber { get; set; }

        public string? PublicRelationsContact { get; set; }

        public ICollection<ConnectionListModel> Connections { get; set; } = new List<ConnectionListModel>();

        public ICollection<EmploeeDetailModel> Emploees { get; set; } = new List<EmploeeDetailModel>();
    }
}
