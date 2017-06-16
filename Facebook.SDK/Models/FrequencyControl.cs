using Facebook.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Models
{
    public class FrequencyControl
    {
        /// <summary>
        /// Event name, only IMPRESSIONS currently.
        /// </summary>
        /// 
        public Event Event { get; set; }
        /// <summary>
        /// Interval period in days, between 1 and 90 (inclusive)
        /// </summary>
        public int IntervalDays { get; set; }
        /// <summary>
        /// Interval period in days, between 1 and 90 (inclusive)
        /// </summary>
        public int MaxFrequency { get; set; }
    }
}
