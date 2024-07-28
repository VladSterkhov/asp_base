using Time;

namespace Extensions;

public static class TimeServiceExtensions
{
    public static void AddTimeService(this IServiceCollection services)
    {
        services.AddTransient<ITimeService, ShortTimeService>();
        services.AddTransient<TimeService>();
    }
}