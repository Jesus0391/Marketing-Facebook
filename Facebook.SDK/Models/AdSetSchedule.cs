using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Models
{
    /// <summary>
    /// Ad set schedule, representing a delivery schedule for a single day
    /// </summary>
    public class AdSetSchedule
    {
        /// <summary>
        /// A 0 based minute of the day representing when the schedule starts (Required)
        /// </summary>
        public Int64 StartMinute { get; set; }
        /// <summary>
        /// A 0 based minute of the day representing when the schedule ends
        /// </summary>
        public Int64 EndMinute { get; set; }
        /// <summary>
        /// Array of ints representing which days the schedule is active. 
        /// Valid values are 0-6 with 0 representing Sunday, 1 representing Monday, ... and 6 representing Saturday.
        /// </summary>
        public List<Int64> Days { get; set; }

    }
}
