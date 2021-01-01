﻿using CG.Configuration;
using CG.Sms.Properties;
using CG.Sms.Strategies.Options;
using CG.Validations;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CG.Sms.Strategies.Twillio
{
    /// <summary>
    /// This class contains extension methods related to the <see cref="IServiceCollection"/>
    /// type.
    /// </summary>
    public static partial class ServiceCollectionExtensions
    {
        // *******************************************************************
        // Public methods.
        // *******************************************************************

        #region Public methods

        /// <summary>
        /// This method registers the <see cref="TwillioEmailStrategy"/> strategy
        /// with the specified service collection.
        /// </summary>
        /// <param name="serviceCollection">The service collection to use for
        /// the operation.</param>
        /// <param name="configuration">The configuration to use for the operation.</param>
        /// <returns>The value of the <paramref name="serviceCollection"/> 
        /// parameter, for chaining calls together.</returns>
        public static IServiceCollection AddTwillioStrategies(
            this IServiceCollection serviceCollection,
            IConfiguration configuration
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(serviceCollection, nameof(serviceCollection))
                .ThrowIfNull(configuration, nameof(configuration));

            // We should be pointed to the Twillio section, but, just in case,
            //   let's do one more check. We're doing this here because
            //   configuration bugs are difficult and frustrating to
            //   troubleshoot, so, we want to provide as much feedback
            //   as is practical to the caller.

            // Get the path.
            var path = configuration.GetPath();

            // Are we not pointed to smtp section?
            if (false == path.EndsWith("Twillio"))
            {
                // Panic!
                throw new ConfigurationException(
                    message: string.Format(
                        Resources.NotTwillioSection,
                        nameof(AddTwillioStrategies),
                        path
                        )
                    );
            }

            // Configure the strategy options.
            serviceCollection.ConfigureOptions<TwilioSmsStrategyOptions>(
                configuration
                );

            // Register the strategy.
            serviceCollection.AddSingleton<ISmsStrategy, TwilioSmsStrategy>();

            // Return the service collection.
            return serviceCollection;
        }

        #endregion
    }
}
