using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Models.Enums
{
    /// <summary>
    /// The event from an App Event of a mobile app, or tag of an conversion pixel.
    /// </summary>
    public enum CustomEventType
    {
        COMPLETE_REGISTRATION,
        CONTENT_VIEW,
        SEARCH,
        RATE,
        TUTORIAL_COMPLETION,
        ADD_TO_CART,
        ADD_TO_WISHLIST,
        INITIATED_CHECKOUT,
        ADD_PAYMENT_INFO,
        PURCHASE,
        LEAD,
        LEVEL_ACHIEVED,
        ACHIEVEMENT_UNLOCKED,
        SPENT_CREDITS,
        OTHER
    }
}
