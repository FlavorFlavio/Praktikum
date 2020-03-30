using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dynamics365CRM.Models
{
    public class Firma
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Verkaufschancen { get; set; }
        public int Auftrag { get; set; }
        public int Angebote { get; set; }
        public string Adresse { get; set; }//  TERmIN / AUFGABE
        public int Telefonnummer { get; set; }

      
    }
}
