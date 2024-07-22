namespace Time;

class ShortTimeService : ITimeService
{
    public string GetTime() => DateTime.Now.ToLongTimeString();
}