using Microsoft.Extensions.DependencyInjection;
using SignalF.Configuration;
using SignalF.Configuration.DataOutput;

namespace SignalF.DataOutput.Console;

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
            .AddDataOutputSenderConfiguration<IDataOutputSenderConfigurationBuilder<DataOutputSenderConsoleOptions>
                , DataOutputSenderConsoleOptions, IDataOutputSenderConsole>(builder);
    }
}