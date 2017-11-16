using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace PatientBook.Model.Info
{
    public class Patient
    {

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        public int? PatientId { get; set; }
        public string PatientName { get; set; }
        public int? Age { get; set; }
        public string Sex { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string MaritalStatus { get; set; }

    }
}
