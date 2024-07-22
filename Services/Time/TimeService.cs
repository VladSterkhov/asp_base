namespace Time;

class TimeService : ITimeService
{
    public string GetTime() => DateTime.Now.ToShortTimeString();
}