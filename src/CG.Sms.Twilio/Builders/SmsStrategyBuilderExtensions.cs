using CG.Sms.Strategies;
using CG.Sms.Strategies.Options;
using CG.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Text;

namespace CG.Sms.Builders
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IEmailStrategyBuilder"/>
    /// type.
    /// </summary>
    public static partial class SmsStrategyBuilderExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method registers a Twilio specific strategy for sending sms messages.
        /// </summary>
        /// <param name="smsStrategyBuilder">The builder to use for the operation.</param>
        /// <param name="configuration">The configuration to use for the operation.</param>
        /// <returns>The value of the <paramref name="smsStrategyBuilder"/>
        /// parameter, for chaining calls together.</returns>
        /// <exception cref="ArgumentException">This exception is thrown whenever
        /// a required argument is missing or invalid.</exception>
        public static ISmsStrategyBuilder AddTwilioStrategy(
            this ISmsStrategyBuilder smsStrategyBuilder,
            IConfiguration configuration
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(smsStrategyBuilder, nameof(smsStrategyBuilder))
                .ThrowIfNull(configuration, nameof(configuration));

            // Configure the strategy options.
            smsStrategyBuilder.Services.ConfigureOptions<TwilioSmsStrategyOptions>(
                configuration.GetSection("Twilio")
                );

            // Register the strategy.
            smsStrategyBuilder.Services.AddSingleton<ISmsStrategy, TwilioSmsStrategy>();

            // Return the strategy builder.
            return smsStrategyBuilder;
        }

        #endregion
    }
}
