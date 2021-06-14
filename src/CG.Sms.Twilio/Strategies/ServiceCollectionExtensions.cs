using CG.Configuration;
using CG.Sms.Properties;
using CG.Sms.Strategies.Options;
using CG.Validations;
using Microsoft.AspNetCore.DataProtection;
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
        /// This method registers the <see cref="TwilioSmsStrategy"/> strategy
        /// with the specified service collection.
        /// </summary>
        /// <param name="serviceCollection">The service collection to use for
        /// the operation.</param>
        /// <param name="configuration">The configuration to use for the operation.</param>
        /// <param name="serviceLifetime">The service lifetime to use for the operation.</param>
        /// <returns>The value of the <paramref name="serviceCollection"/> 
        /// parameter, for chaining calls together.</returns>
        public static IServiceCollection AddTwilioStrategies(
            this IServiceCollection serviceCollection,
            IConfiguration configuration,
            ServiceLifetime serviceLifetime
            )
        {
            // Validate the parameters before attempting to use them.
            Guard.Instance().ThrowIfNull(serviceCollection, nameof(serviceCollection))
                .ThrowIfNull(configuration, nameof(configuration));

            // Configure the strategy options.
            serviceCollection.ConfigureOptions<TwilioSmsStrategyOptions>(
                configuration
                );

            

            // Register the strategy.
            switch (serviceLifetime)
            {
                case ServiceLifetime.Scoped:
                    serviceCollection.AddScoped<ISmsStrategy, TwilioSmsStrategy>();
                    break;
                case ServiceLifetime.Singleton:
                    serviceCollection.AddSingleton<ISmsStrategy, TwilioSmsStrategy>();
                    break;
                case ServiceLifetime.Transient:
                    serviceCollection.AddTransient<ISmsStrategy, TwilioSmsStrategy>();
                    break;
            }

            // Return the service collection.
            return serviceCollection;
        }

        #endregion
    }
}
