using System;
using System.Collections.Generic;

#nullable disable

namespace FIASApi.Model.Entities
{
    public partial class VOffice
    {
        public string Roomid { get; set; }
        public string Roomguid { get; set; }
        public string Houseid { get; set; }
        public string Houseguid { get; set; }
        public string Flatnumber { get; set; }
        public double? Fltypeid { get; set; }
        public string Flattypename { get; set; }
        public string Flattypeshortname { get; set; }
        public string Postalcode { get; set; }
        public string Housenum { get; set; }
        public string Buildnum { get; set; }
        public string Strucnum { get; set; }
        public double? Statstatus { get; set; }
        public string Regioncode { get; set; }
        public string Regionname { get; set; }
        public string Areacode { get; set; }
        public string Areaname { get; set; }
        public string Placecode { get; set; }
        public string Placename { get; set; }
        public string Citycode { get; set; }
        public string Cityname { get; set; }
        public string Streetcode { get; set; }
        public string Streetname { get; set; }
    }
}
