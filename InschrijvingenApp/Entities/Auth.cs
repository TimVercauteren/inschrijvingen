using DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InschrijvenPietieterken.Entities
{
    public class Auth : EntityBase
    {
        public string User { get; set; }
        public string Password { get; set; }
    }
}
