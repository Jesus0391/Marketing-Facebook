using Facebook.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Models
{
    public class AdSet
    {
        /// <summary>
        /// Ad set schedule, representing a delivery schedule for a single day
        /// </summary>
        public List<AdSetSchedule> Schedule { get; set; }
        /// <summary>
        /// Bid amount for this ad set, defined as your true value bid based on optimization_goal. 
        /// If an ad level bid_amount is specified, updating this value will overwrite the previous ad level bid. 
        /// Either bid_amount or is_autobid is required except in Reach and Frequency ad sets. 
        /// The bid amount's unit is cent for currencies like USD, EUR, and the basic unit for currencies like JPY, KRW. 
        /// The bid amount for ads with IMPRESSION, REACH as billing_event is per 1,000 occurrences, and has to be at least 2 US cents or more; 
        /// that for ads with other billing_event is for each occurrence, and has a minimum value 1 US cents. 
        /// The minimum bid amounts of other currencies are of similar value to the US Dollar values provided.
        /// </summary>
        public int BidAmount { get; set; }
        /// <summary>
        /// The billing event that this adset is using:
        /// APP_INSTALLS: Pay when people install your app.
        /// CLICKS: Deprecated.
        /// IMPRESSIONS: Pay when the ads are shown to people.
        /// LINK_CLICKS: Pay when people click on the link of the ad.
        /// OFFER_CLAIMS: Pay when people claim the offer.
        /// PAGE_LIKES: Pay when people like your page.
        /// POST_ENGAGEMENT: Pay when people engage with your post.
        /// VIDEO_VIEWS: Pay when people watch videos.
        /// </summary>
        public BillingEvent BillingEvent { get; set; }
        /// <summary>
        /// The ad campaign you wish to add this ad set to.
        /// </summary>
        public int CampaignId { get; set; }
        /// <summary>
        /// The daily budget defined in your account currency, allowed only for ad sets with a duration 
        /// (difference between end_time and start_time) longer than 24 hours. 
        /// Either daily_budget or lifetime_budget must be greater than 0.
        /// </summary>
        public Int64 DailyBudget { get; set; }
        /// <summary>
        /// Daily impressions. Available only for campaigns with buying_type=FIXED_CPM
        /// </summary>
        public Int64 DailyImpressions { get; set; }
        /// <summary>
        /// End time, required when lifetime_budget is specified.
        /// e.g. 2015-03-12 23:59:59-07:00 or 2015-03-12 23:59:59 PDT. 
        /// When creating a set with a daily budget, specify end_time=0 to set the set to be ongoing and have no end date. 
        /// UTC UNIX timestamp
        /// </summary>
        public DateTime EndTime { get; set; }
        /// <summary>
        /// Default value: Set
        ///An execution setting
        ///validate_only: when this option is specified, the API call will not perform the mutation but will run through the validation
        ///rules against values of each field. 
        ///include_recommendations: this option cannot be used by itself.
        ///When this option is used, recommendations for ad object's configuration will be included.
        ///A separate section recommendations will be included in the response, but only if recommendations for this specification exist.
        ///If the call passes validation or review, response will be {"success": true}. 
        ///If the call does not pass, an error will be returned with more details.
        ///These options can be used to improve any UI to display errors to the user much sooner, 
        ///e.g. as soon as a new value is typed into any field corresponding to this ad object, rather than at the upload/save stage, or after review.
        /// </summary>
        public List<ExecutionOptions> ExecutionOptions { get; set; }
    }
}
