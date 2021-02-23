using System;
using System.Collections.Generic;

#nullable disable

namespace FIASApi.Model.Entities
{
    public partial class Room
    {
        public string Roomid { get; set; }
        public string Roomguid { get; set; }
        public string Houseguid { get; set; }
        public string Regioncode { get; set; }
        public string Flatnumber { get; set; }
        public double? Flattype { get; set; }
        public string Roomnumber { get; set; }
        public string Roomtype { get; set; }
        public string Cadnum { get; set; }
        public string Roomcadnum { get; set; }
        public string Postalcode { get; set; }
        public DateTime? Updatedate { get; set; }
        public string Previd { get; set; }
        public string Nextid { get; set; }
        public double? Operstatus { get; set; }
        public DateTime? Startdate { get; set; }
        public DateTime? Enddate { get; set; }
        public double? Livestatus { get; set; }
        public string Normdoc { get; set; }
    }
}
