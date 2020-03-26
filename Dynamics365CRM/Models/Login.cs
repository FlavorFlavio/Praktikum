using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Dynamics365CRM.Models
{
    public class Login
    {


        public int Id { get; set; }
        public string Benutzername { get; set; }

        public string Passwort { get; set; }
        public string BenutzerId { get; set; }
    }
    
}
