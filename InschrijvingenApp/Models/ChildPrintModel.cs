﻿using InschrijvingPietieterken.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InschrijvingPietieterken.Models
{
    public class ChildPrintModel
    {
        public string Naam { get; set; }
        public string Voornaam { get; set; }
        public string Email { get; set; }
        public string TelefoonNummer { get; set; }
        public string Adres { get; set; }
        public string Postcode { get; set; }
        public string Gemeente { get; set; }
        public string GeboorteDatum { get; set; }
        public bool HeeftMaandAbonnement { get; set; }

    }

}
