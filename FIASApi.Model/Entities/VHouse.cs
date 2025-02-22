﻿using System;
using System.Collections.Generic;

#nullable disable

namespace FIASApi.Model.Entities
{
    public partial class VHouse
    {
        public string Aoguid { get; set; }
        public string Houseguid { get; set; }
        public string Houseid { get; set; }
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
