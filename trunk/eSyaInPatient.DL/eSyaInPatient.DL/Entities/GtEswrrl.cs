using System;
using System.Collections.Generic;

namespace eSyaInPatient.DL.Entities
{
    public partial class GtEswrrl
    {
        public int BusinessKey { get; set; }
        public int WardId { get; set; }
        public int RoomId { get; set; }
        public int RateType { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public decimal Tariff { get; set; }
        public decimal DayCareTariff { get; set; }
        public DateTime? EffectiveTill { get; set; }
        public decimal ServiceChargePerc { get; set; }
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
