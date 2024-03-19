using SignalF.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SignalF.Configuration.DataOutput;
using Iot.Device.CpuTemperature;
using Microsoft.Extensions.DependencyInjection;

namespace SignalF.DataOutput.Console
{
    public static class ConsoleExtensions
    {
        private const string ConsoleTemplateName = "ConsoleTemplate";
        private const string ConsoleDefinitionName = "ConsoleDefinition";
        private const string ConsoleDefaultName = "Console";

        public static IServiceCollection AddConsole(this IServiceCollection services)
        {
            return services.AddTransient<DataOutputSenderConsole>();
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
