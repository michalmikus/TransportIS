using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TransportIS.BL.Models.DetailModels
{
    public class TimeTableListModel
    {
        public Guid Id { get; set; }
        public StopListModel Stop { get; set; } = new StopListModel();

        public DateTime TimeOfDeparture { get; set; }
    }
}
