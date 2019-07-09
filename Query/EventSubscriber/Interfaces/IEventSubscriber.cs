using EventSubscriber.Events;

namespace EventSubscriber.Interfaces
{
    public delegate void ProductAddedEventReceivedDelegate(NewProductEvent evt);

    public interface IEventSubscriber
    {
        void Subscribe();
        void Unsubscribe();

        event ProductAddedEventReceivedDelegate ProductAddedEventReceived;
    }
}
