using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Frontdesk6.Models.Frontdesk
{
    public class LayananFrontdesk
    {
        public int LayananFrontdeskID { get; set; }

        public string NamaLayanan { get; set; }

        public ICollection<Appointment> Appointments { get; set; }

    }
}
