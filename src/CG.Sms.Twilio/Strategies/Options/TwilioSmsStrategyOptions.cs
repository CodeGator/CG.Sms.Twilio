using CG.Business.Strategies.Options;
using CG.Options;
using CG.Sms.Options;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

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
        [ProtectedProperty]
        public string AccountSid { get; set; }

        /// <summary>
        /// This property contains an authentication token.
        /// </summary>
        [ProtectedProperty]
        public string AuthToken { get; set; }

        /// <summary>
        /// This property contains the source phone number for SMS operations.
        /// </summary>
        [ProtectedProperty]
        public string FromPhone { get; set; }

        #endregion
    }
}
