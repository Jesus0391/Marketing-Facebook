using System;
using System.Collections.Generic;
using System.Text;

namespace JAM.Facebook.Models.Enums
{
    /// <summary>
    /// Only ACTIVE and PAUSED are valid for creation. 
    /// The other statuses can be used for update. 
    /// </summary>
    public enum Status
    {
        ACTIVE,
        PAUSED,
        DELETED,
        ARCHIVED
    }
}
