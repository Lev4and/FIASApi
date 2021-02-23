using System;
using System.Collections.Generic;

#nullable disable

namespace FIASApi.Model.Entities
{
    public partial class Nordoc
    {
        public string Normdocid { get; set; }
        public string Docname { get; set; }
        public DateTime? Docdate { get; set; }
        public string Docnum { get; set; }
        public string Docimgid { get; set; }
    }
}
