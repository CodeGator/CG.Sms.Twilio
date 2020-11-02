using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Sms.Strategies
{
    /// <summary>
    /// This class represents twilio SMS results.
    /// </summary>
    public class TwilioSendResult : SmsResult
    {
        // *******************************************************************
        // Properties.
        // *******************************************************************

        #region Properties

        /// <summary>
        /// This property contains the source phone.
        /// </summary>
        public string FromPhone { get; set; }

        /// <summary>
        /// This property contains the destination phone.
        /// </summary>
        public string ToPhone { get; set; }

        /// <summary>
        /// This property contains the outgoing security id.
        /// </summary>
        public string Sid { get; set; }

        /// <summary>
        /// This property contains the message.
        /// </summary>
        public string Message { get; set; }

        /// <summary>
        /// This property contains the status of the send operation.
        /// </summary>
        public string Status { get; set; }

        #endregion
    }
}
