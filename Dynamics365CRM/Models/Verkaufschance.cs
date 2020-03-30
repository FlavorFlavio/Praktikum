using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dynamics365CRM.Models
{
    public class Verkaufschance
    {
        public int Id { get; set; }
        public string Kontakt { get; set; }
        public string Kunde { get; set; }
        public int AuftragsvolumenNetto { get; set; }
        public int AuftragsvolumenBrutto { get; set; }
        public int Umsatzsteuer { get; set; }
        public int AuftragCount { get; set; }
        public int AngeboteCount { get; set; }



        public string Typ { get; set; }//  TERmIN / AUFGABE
        public string Betreff { get; set; }//Titel
        public string Beschreibung { get; set; }//Information
        [DataType(DataType.Date)]
        public DateTime Deadline { get; set; }



        public int isFree{ get; set; }// offen?
        public string Notiz { get; set; }// Notzien



    }
}
