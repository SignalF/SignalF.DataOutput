using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration;
using SignalF.Configuration.DataOutput;

namespace SignalF.DataOutput.Console;

public static class ConsoleExtensions
{
    private const string ConsoleDefaultName = "DataOutputSenderConsole";

    public static IServiceCollection AddDataOutputSenderConsole(this IServiceCollection services)
    {
        return services.AddTransient<IDataOutputSenderConsole, DataOutputSenderConsole>()
                       .AddTransient<IDataOutputSenderConfigurationBuilder<ConsoleDataOutputSenderOptions>, DataOutputSenderConfigurationBuilder<ConsoleDataOutputSenderOptions>>();
    }


    public static ISignalFConfiguration AddDataOutputSenderConsole(this ISignalFConfiguration configuration
        , Action<IDataOutputSenderConfigurationBuilder<ConsoleDataOutputSenderOptions>> builder)
    {
        return configuration
            .AddDataOutputSenderConfiguration<IDataOutputSenderConfigurationBuilder<ConsoleDataOutputSenderOptions>
                , ConsoleDataOutputSenderOptions, IDataOutputSenderConsole>(builder);
    }
}