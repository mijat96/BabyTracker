using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BabyTracker.Models
{
    public class BabyEvent
    {
        public int Id { get; set; }
        public DateTime EventTime { get; set; }
        public string EventName { get; set; }
        public BabyEventType EventType { get; set; }
    }

    public enum BabyEventType
    {
        BabyBreastFeeding,
        BabyBotleFeeding,
        BabySleeping,
        BabyNappy
    }
}
