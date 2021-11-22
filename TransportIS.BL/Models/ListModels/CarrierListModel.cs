using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportIS.BL.Models.DetailModels
{
    public class CarrierListModel
    {
        public Guid Id { get; set; }

        public string? CarrierName { get; set;}

        public AddressListModel Address { get; set; } = new AddressListModel();

        public string? TelephoneNumber { get; set; }

        public string? PublicRelationsContact { get; set; }

        public ICollection<ConnectionListModel> Connections { get; set; } = new List<ConnectionListModel>();
    }
}
