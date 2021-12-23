using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Frontdesk6.Models.Frontdesk
{
    public class Appointment
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public string AppointmentID { get; set; }
        public string Nama { get; set; }
        public string Email { get; set; }
        [Display(Name = "Nomor Antrian")]
        public string NomorApp { get; set; }
        [Display(Name = "Tanggal")]
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy HH:mm:ss}")]
        public DateTime Tanggal { get; set; }

        public string Subject { get; set; }
        public string Deskripsi { get; set; }
        [Display(Name = "Nomor")]
        public string Tujuan { get; set; }
        public string NamaLayanan { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm}")]
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public DateTime ProcessDate { get; set; }
        public status StatusFrontdesk { get; set; }

        public enum status
        {
            mulai,
            proses,
            selesai
        }

        public LayananFrontdesk LayananFrontdesk { get; set; }
    }
}
