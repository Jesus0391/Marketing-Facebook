using Facebook.Models.Enums;
using JAM.Facebook.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
        [JsonProperty("adset_schedule")]
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
        [DefaultValue(1)]
        [JsonProperty("bid_Amount")]
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
        [JsonProperty("billing_event")]
        public BillingEvent BillingEvent { get; set; }
        /// <summary>
        /// The ad campaign you wish to add this ad set to.
        /// </summary>
        [JsonProperty("campaign_id")]
        public string CampaignId { get; set; }
        /// <summary>
        /// The daily budget defined in your account currency, allowed only for ad sets with a duration 
        /// (difference between end_time and start_time) longer than 24 hours. 
        /// Either daily_budget or lifetime_budget must be greater than 0.
        /// </summary>
        [JsonProperty("daily_budget")]
        public Int64 DailyBudget { get; set; }
        /// <summary>
        /// Daily impressions. Available only for campaigns with buying_type=FIXED_CPM
        /// </summary>
        [JsonProperty("daily_imps")]
        public Int64 DailyImpressions { get; set; }
        /// <summary>
        /// End time, required when lifetime_budget is specified.
        /// e.g. 2015-03-12 23:59:59-07:00 or 2015-03-12 23:59:59 PDT. 
        /// When creating a set with a daily budget, specify end_time=0 to set the set to be ongoing and have no end date. 
        /// UTC UNIX timestamp
        /// </summary>
        [JsonProperty("end_time")]
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
        [JsonProperty("execution_options")]
        public List<ExecutionOptions> ExecutionOptions { get; set; }
        /// <summary>
        /// An array of frequency control specs for this ad set.
        /// As there is only one event type supported currently, this array would have no more than one element. 
        /// Only available in ad sets of campaigns with BRAND_AWARENESS as objective and REACH as optimization_goal.
        /// These cannot be used in Reach & Frequency campaigns.
        /// </summary>
        [JsonProperty("frequency_control_specs")]
        public List<FrequencyControl> FrequencyControlSpecs { get; set; }
        /// <summary>
        /// If autobid is set. Either bid_amount or is_autobid is required except in Reach and Frequency ad sets.
        /// Cannot be used when using billing_event=APP_INSTALLS or MOBILE_APP_INSTALLS.
        /// </summary>
        [JsonProperty("is_autobid")]
        public bool IsAutoBid { get; set; }
        /// <summary>
        /// Flag used to determine whether average price pacing is enabled.
        /// Default value is false. More details can be found in this help document.
        /// </summary>
        [JsonProperty("is_average_price_pacing")]
        public bool IsAveragePricePacing { get; set; }
        /// <summary>
        /// Lifetime budget, defined in your account currency. If specified, you must also specify an end_time.
        /// Either daily_budget or lifetime_budget must be greater than 0.
        /// </summary>
        [JsonProperty("lifetime_budget")]
        public Int64 LifeTimeBudget { get; set; }
        /// <summary>
        /// Lifetime impressions. Available only for campaigns with buying_type=FIXED_CPM
        /// </summary>
        [JsonProperty("lifetime_imps")]
        public Int64 LifeTimeImpressions { get; set; }
        /// <summary>
        /// Ad set name, max length of 400 characters.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set;  }
        /// <summary>
        /// What the ad set is optimizing for. 
        /// APP_INSTALLS: Will optimize for people more likely to install your app.
        /// BRAND_AWARENESS: Optimize to reach the most users to spend at least a minimum amount of time on the image or video.You cannot set bid_amount, and is_autobid must be true if this goal is used.The optimization goal is not editable once set.
        /// CLICKS: Deprecated
        /// ENGAGED_USER: Will optimize for people more likely to take a particular action in your app
        /// EXTERNAL: FBX only
        /// EVENT_RESPONSES: Will optimize for people more likely to attend your event. 
        /// IMPRESSIONS: Will show the ads as many times as possible
        /// LINK_CLICKS: Will optimize for people more likely to click in the link of the ad. 
        /// OFFER_CLAIMS: Will optimize for people more likely to claim the offer. 
        /// OFFSITE_CONVERSION: Will optimize for people more likely to make a conversion in the site
        /// PAGE_LIKES: Will optimize for people more likely to like your page.
        /// PAGE_ENGAGEMENT: Will optimize for people more likely to engage with your page. 
        /// POST_ENGAGEMENT: Will optimize for people more likely toengage with your post. 
        /// REACH: Optimize to reach the most unique users of each day or interval specified in frequency_control_specs. 
        /// SOCIAL_IMPRESSIONS: Increase the number of impressions with social context. 
        /// I.e. with the names of one or more of the user's friends attached to the ad who have already liked the page or installed the app. 
        /// VIDEO_VIEWS: Will optimize for people more likely to watch videos.
        /// LEAD_GENERATION: Will optimize for people more likely to fill out a lead generation form.
        /// </summary>
        [JsonProperty("optimization_goal")]
        public OptimizationGoal OptimizationGoal { get; set; }
        /// <summary>
        /// Defines the pacing type, standard by default or using 
        /// </summary>
        [JsonProperty("pacing_type")]
        public List<string> PacingType { get; set; }
        [JsonProperty("promoted_object")]
        public PromotedObject PromotedObject { get; set; }
        /// <summary>
        /// Allows you to specify that you would like to retrieve all fields of the set in your response. Default value: false.
        /// </summary>
        [JsonProperty("redownload")]
        public bool Redownload { get; set; }
        /// <summary>
        /// Reach and frequency prediction ID
        /// </summary>
        [JsonProperty("rf_prediction_id")]
        public int RfPredictionId { get; set; }
        /// <summary>
        /// Whether this adset is using RTB or not
        /// </summary>
        [JsonProperty("rtb_flag")]
        public bool RFFlag { get; set; }
        /// <summary>
        /// The start time of the set, e.g. 2015-03-12 23:59:59-07:00 or 2015-03-12 23:59:59 PDT. UTC UNIX timestamp
        /// </summary>
        [JsonProperty("start_time")]
        public DateTime StartTime { get; set; }
        /// <summary>
        /// Only ACTIVE and PAUSED are valid for creation.
        /// The other statuses can be used for update. 
        /// If it is set to PAUSED, all its active ads will be paused and have an effective status ADSET_PAUSED.
        /// </summary>
        [JsonProperty("status")]
        public Status Status { get; set; }
        /// <summary>
        /// Pending Definition struct of Targeting (Locations, countries, etc....)
        /// </summary>
        [JsonProperty("targeting")]
        public object Targeting { get; set; }
        /// <summary>
        /// Specify ad creative that displays at custom date ranges in a campaign as an array.
        /// A list of Adgroup IDs. The list of ads to display for each time range in a given schedule. 
        /// For example display first ad in Adgroup for first date range, second ad for second date range, and so on. 
        /// You can display more than one ad per date range by providing more than one ad group ID per array. 
        /// For example set time_based_ad_rotation_id_blocks to [[1], [2, 3], [1, 4]].
        /// On the first date range show ad 1, on the second date range show ad 2 and ad 3 and on the last date range show ad 1 and ad 4. 
        /// Use with time_based_ad_rotation_intervals to specify date ranges.
        /// </summary>
        [JsonProperty("time_based_ad_rotation_id_blocks")]
        public List<List<Int64>> TimeBaseAdRotationIdBlocks { get; set; }
        /// <summary>
        /// Date range when specific ad creative displays during a campaign.
        /// Provide date ranges in an array of UNIX timestamps where each timestamp represents the start time for each date range. 
        /// For example a 3-day campaign from May 9 12am to May 11 11:59PM PST can have three date ranges,
        /// the first date range starts from May 9 12:00AM to May 9 11:59PM, second date range starts from May 10 12:00AM to
        /// May 10 11:59PM and last starts from May 11 12:00AM to May 11 11:59PM.
        /// The first timestamp should match the campaign start time. 
        /// The last timestamp should be at least 1 hour before the campaign end time.
        /// You must provide at least two date ranges.
        /// All date ranges must cover the whole campaign length, so any date range cannot exceed campaign length.
        /// Use with time_based_ad_rotation_id_blocks to specify ad creative for each date range.
        /// </summary>
        [JsonProperty("time_based_ad_rotation_intervals")]
        public List<Int64> TimeBaedAdRotationIntervals { get; set; }
    }
}
