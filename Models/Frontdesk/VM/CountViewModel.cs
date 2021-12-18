using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Frontdesk6.Models.Frontdesk
{
    public class CountViewModel
    {
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? TotalHari { get; set; }

        public int DateCount { get; set; }
        public int yourlife { get; set; }
    }
}
