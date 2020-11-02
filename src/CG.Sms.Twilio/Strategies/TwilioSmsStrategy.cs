using CG.Sms.Strategies.Options;
using CG.Validations;
using Microsoft.Extensions.Options;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Twilio;
using Twilio.Rest.Api.V2010.Account;
using Twilio.Types;

namespace CG.Sms.Strategies
{
    /// <summary>
    /// This class is a Twilio based implementation of the <see cref="ISmsStrategy{TOptions}"/>
    /// interface.
    /// </summary>
    public class TwilioSmsStrategy : 
        SmsStrategyBase<TwilioSmsStrategyOptions>, 
        ISmsStrategy<TwilioSmsStrategyOptions>
    {
        // *******************************************************************
        // Constructors.
        // *******************************************************************

        #region Constructors

        /// <summary>
        /// This constructor creates a new instance of the <see cref="TwilioSmsStrategy"/>
        /// class.
        /// </summary>
        /// <param name="options">The options to use with this strategy.</param>
        public TwilioSmsStrategy(
            IOptions<TwilioSmsStrategyOptions> options
            ) : base(options)
        {

        }

        #endregion

        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <inheritdoc />
        public override async Task<IEnumerable<SmsResult>> SendAsync(
            IEnumerable<string> toPhones, 
            string message, 
            CancellationToken token = default
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(toPhones, nameof(toPhones));

            // Initialize the twilio library.
            TwilioClient.Init(
                Options.Value.AccountSid,
                Options.Value.AuthToken
                );

            // Create the source phone number.
            var fromPhone = new PhoneNumber(
                Options.Value.FromPhone
                );

            var results = new List<TwilioSendResult>();

            // Loop through the phone numbers.
            foreach (var phone in toPhones)
            {
                // Create the destination phone.
                var toPhone = new PhoneNumber(phone);

                // Create the message.
                var msg = await MessageResource.CreateAsync(
                    body: message,
                    from: fromPhone,
                    to: toPhone
                    ).ConfigureAwait(false);

                // Create the results.
                var result = new TwilioSendResult()
                {
                    FromPhone = Options.Value.FromPhone,
                    ToPhone = phone,
                    Message = message,
                    Sid = msg.Sid,
                    Status = $"{msg.Status}"
                };

                // Add the results to the list.
                results.Add(result);
            }

            // Return the results.
            return results;
        }

        #endregion
    }
}
