using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dynamics365CRM.Models
{
    public class Firmenwagen
    {
        public int Id { get; set; }
        public string Fahrzeughalter { get; set; }
        public string Fahrzeugname { get; set; }
        public string Fahrzeugmarke { get; set; }

        [DataType(DataType.Date)]
        public DateTime Zulassungsende { get; set; }
        public string Kennzeichen { get; set; }
    }
}
