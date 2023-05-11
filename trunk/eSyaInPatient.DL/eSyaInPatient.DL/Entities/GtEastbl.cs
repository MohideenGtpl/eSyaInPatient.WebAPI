﻿using System;
using System.Collections.Generic;

namespace eSyaInPatient.DL.Entities
{
    public partial class GtEastbl
    {
        public int BusinessKey { get; set; }
        public int StoreCode { get; set; }
        public bool IsAccounting { get; set; }
        public bool IsCustodian { get; set; }
        public bool IsConsumption { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedTerminal { get; set; }
        public int? ModifiedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedTerminal { get; set; }

        public virtual GtEcbsln BusinessKeyNavigation { get; set; }
    }
}
