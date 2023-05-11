using System;
using System.Collections.Generic;
using System.Text;

namespace eSyaInPatient.DO
{
    public class DO_WardRateLink
    {
        public int BusinessKey { get; set; }
        public int WardId { get; set; }
        public string WardDesc { get; set; }
        public int RoomId { get; set; }
        public string RoomDesc { get; set; }
        public int RateType { get; set; }
        public DateTime EffectiveFrom { get; set; }
        public DateTime? FromDate { get; set; }
        public decimal Tariff { get; set; }
        public decimal DayCareTariff { get; set; }
        public DateTime? EffectiveTill { get; set; }
        public decimal ServiceChargePerc { get; set; }
        public bool ActiveStatus { get; set; }
        public string FormId { get; set; }
        public int UserID { get; set; }
        public string TerminalID { get; set; }
    }
}
