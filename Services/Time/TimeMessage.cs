namespace Time;

class TimeMessage
{
    ITimeService timeService;

    public TimeMessage(ITimeService timeService) => this.timeService = timeService;

    public string GetTime() => timeService.GetTime();
}