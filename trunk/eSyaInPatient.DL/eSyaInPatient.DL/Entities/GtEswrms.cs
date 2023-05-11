﻿using System;
using System.Collections.Generic;

namespace eSyaInPatient.DL.Entities
{
    public partial class GtEswrms
    {
        public int WardId { get; set; }
        public string WardShortDesc { get; set; }
        public string WardDesc { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }
    }
}
