using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public DateTime BookedTime { get; set; }
        public int ClientId { get; set; }
        public int CoachId { get; set; }
        public Client? Client { get; set; }
        public Coach? Coach { get; set; }
    }
}
