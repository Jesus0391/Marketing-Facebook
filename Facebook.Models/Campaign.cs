using JAM.Facebook.Models.Enums;
using System;
using System.ComponentModel;

namespace JAM.Facebook.Models
{
    public class Campaign
    {
        /// <summary>
        /// Whether to automatically rebalance budgets daily for all the adsets under this campaign.
        /// </summary>
        public bool BudgetRebalance_Flag { get; set; }
        /// <summary>
        /// Default value: AUCTION
        ///This field will help Facebook make optimizations to delivery, pricing, and limits.All ad sets in this campaign must match the buying type.
        ///Possible values are: 
        ///AUCTION (default)
        ///RESERVED(for reach and frequency ads).
        /// </summary>
        [DefaultValue(BuyingType.AUCTION)]
        public BuyingType BuyingType { get; set; }
        /// <summary>
        /// Name for this campaign
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Campaign's objective. If it is specified the API will validate that any ad groups created under the campaign match that objective. 
        /// Currently, with BRAND_AWARENESS objective, all creatives should be either only images or only videos, not mixed.
        /// </summary>
        public Objective Objective { get; set; }
        /// <summary>
        /// A spend cap for the campaign, such that it will not spend more than this cap.
        /// Defined as integer value of subunit in your currency with a minimum value of $100 USD (or approximate local equivalent). 
        /// Set the value to 922337203685478 to remove the spend cap.
        /// Not available for Reach and Frequency or Premium Self Serve campaigns
        /// </summary>
        public Int64 SpendCap { get; set; }
        /// <summary>
        /// Only ACTIVE and PAUSED are valid during creation. Other statuses can be used for update. 
        /// If it is set to PAUSED, its active child objects will be paused and have an effective status CAMPAIGN_PAUSED.
        /// </summary>
        public Status Status { get; set; }

    }
}
