using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Models.Enums
{
    /// <summary>
    /// Preset date range used to aggregate insights metrics
    /// </summary>
    public enum DatePresent
    {
        today,
        yesterday,
        this_month,
        last_month,
        this_quarter,
        lifetime,
        last_3d,
        last_7d,
        last_14d,
        last_28d,
        last_30d,
        last_90d,
        last_week_mon_sun,
        last_week_sun_sat,
        last_quarter,
        last_year,
        this_week_mon_today,
        this_week_sun_today,
        this_year
    }
}
