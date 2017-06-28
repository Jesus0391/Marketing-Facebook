using System;
using System.Collections.Generic;
using System.Text;

namespace Facebook.Enums
{
    /// <summary>
    /// Deep link fallback behavior for dynamic product ads if the app is not installed.
    /// </summary>
    public enum LinkTreatment
    {
        deeplink_with_web_fallback,
        deeplink_with_appstore_fallback,
        web_only
    }
}
