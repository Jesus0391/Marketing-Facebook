using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Models.Enums
{
    /// <summary>
    /// Filter adsets by effective status
    /// </summary>
    public enum EffectiveStatus
    {
        ACTIVE,
        PAUSED,
        DELETED,
        PENDING_REVIEW,
        DISAPPROVED,
        PREAPPROVED,
        PENDING_BILLING_INFO,
        CAMPAIGN_PAUSED,
        ARCHIVED,
        ADSET_PAUSED
    }
}
