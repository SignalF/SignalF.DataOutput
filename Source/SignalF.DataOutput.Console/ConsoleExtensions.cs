using SignalF.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalF.Configuration.DataOutput;
using Microsoft.Extensions.DependencyInjection;

namespace SignalF.DataOutput.Console
{
    public static class ConsoleExtensions
    {
        private const string ConsoleDefaultName = "DataOutputSenderConsole";

        public static IServiceCollection AddDataOutputSenderConsole(this IServiceCollection services)
        {
            return services.AddTransient<IDataOutputSenderConsole, DataOutputSenderConsole>();
        }


        public static ISignalFConfiguration AddDataOutputSenderConsole(this ISignalFConfiguration configuration
            , Action<IDataOutputSenderConfigurationBuilder<DataOutputSenderConsoleOptions>> builder)
        {
            return configuration
                .AddDataOutputSenderConfiguration<IDataOutputSenderConfigurationBuilder, DataOutputSenderConsoleOptions,
                    IDataOutputSenderConsole>(builder);
        }
    }
}