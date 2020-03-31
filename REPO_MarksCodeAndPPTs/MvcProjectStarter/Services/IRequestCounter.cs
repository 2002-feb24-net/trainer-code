namespace MvcProjectStarter.Services
{
    public interface IRequestCounter
    {
        int TotalRequestCount { get; }

        void IncrementRequestCount();
    }
}