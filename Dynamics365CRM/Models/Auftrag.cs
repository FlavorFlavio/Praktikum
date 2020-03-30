using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dynamics365CRM.Models
{
    public class Auftrag
    {
        public int Id { get; set; }
        public string Kunde { get; set; }
        public string Ansprechpartner { get; set; }
        public string Verkaufschance { get; set; }
        public int isFree { get; set; }// offen?



    }
}
