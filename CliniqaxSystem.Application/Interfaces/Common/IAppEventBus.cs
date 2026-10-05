namespace CliniqaxSystem.Application.Interfaces.Common
{
    public record AppointmentChangedEvent;
    public record CashSessionChangedEvent;
    public record PatientChangedEvent;

    public interface IAppEventBus
    {
        void Publish<T>(T message) where T : class;
        void Subscribe<T>(Action<T> action) where T : class;
        void Unsubscribe<T>(Action<T> action) where T : class;
    }
}
