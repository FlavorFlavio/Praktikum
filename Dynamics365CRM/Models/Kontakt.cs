using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dynamics365CRM.Models
{
    public class Kontakt
    {
        public int Id { get; set; }
        public string Vorname { get; set; }
        public string Nachname { get; set; }

        [DataType(DataType.Date)]
        public DateTime Geburtsdatum { get; set; }
        public int Telefonnummer { get; set; }
    }
}
