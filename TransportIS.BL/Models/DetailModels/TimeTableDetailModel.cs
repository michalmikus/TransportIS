using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportIS.BL.Models.DetailModels
{
    public class TimeTableDetailModel
    {
        public Guid Id { get; set; }

        public StopDetailModel Stop { get; set; } = new StopDetailModel();

        public DateTime TimeOfDeparture { get; set; }
    }
}
