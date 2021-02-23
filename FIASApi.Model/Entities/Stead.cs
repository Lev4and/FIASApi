using System;
using System.Collections.Generic;

#nullable disable

namespace FIASApi.Model.Entities
{
    public partial class Stead
    {
        public string Steadguid { get; set; }
        public string Number { get; set; }
        public string Regioncode { get; set; }
        public string Postalcode { get; set; }
        public string Ifnsfl { get; set; }
        public string Terrifnsfl { get; set; }
        public string Ifnsul { get; set; }
        public string Terrifnsul { get; set; }
        public string Okato { get; set; }
        public DateTime? Updatedate { get; set; }
        public string Parentguid { get; set; }
        public string Steadid { get; set; }
        public string Previd { get; set; }
        public double? Operstatus { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public string Nextid { get; set; }
        public string Oktmo { get; set; }
        public double? Livestatus { get; set; }
        public string Cadnum { get; set; }
        public double? Divtype { get; set; }
        public double? Counter { get; set; }
        public string Normdoc { get; set; }
    }
}
