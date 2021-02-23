using System;
using System.Collections.Generic;

#nullable disable

namespace FIASApi.Model.Entities
{
    public partial class House
    {
        public string Aoguid { get; set; }
        public string Buildnum { get; set; }
        public DateTime? Enddate { get; set; }
        public double? Eststatus { get; set; }
        public string Houseguid { get; set; }
        public string Houseid { get; set; }
        public string Housenum { get; set; }
        public double? Statstatus { get; set; }
        public string Ifnsfl { get; set; }
        public string Ifnsul { get; set; }
        public string Okato { get; set; }
        public string Oktmo { get; set; }
        public string Postalcode { get; set; }
        public DateTime? Startdate { get; set; }
        public string Strucnum { get; set; }
        public double? Strstatus { get; set; }
        public string Terrifnsfl { get; set; }
        public string Terrifnsul { get; set; }
        public DateTime? Updatedate { get; set; }
        public string Normdoc { get; set; }
        public double? Counter { get; set; }
        public string Cadnum { get; set; }
        public double? Divtype { get; set; }
    }
}
