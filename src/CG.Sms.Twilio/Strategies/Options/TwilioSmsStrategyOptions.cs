using CG.Sms.Options;

namespace CG.Sms.Strategies.Options
{
    /// <summary>
    /// This class contains configuration options for twilio sms strategy.
    /// </summary>
    public class TwilioSmsStrategyOptions : SmsStrategyOptionsBase
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains a Twilio account security id.
        /// </summary>
        public string AccountSid { get; set; }

        /// <summary>
        /// This property contains an authentication token.
        /// </summary>
        public string AuthToken { get; set; }

        /// <summary>
        /// This property contains the source phone number for SMS operations.
        /// </summary>
        public string FromPhone { get; set; }

        #endregion
    }
}
