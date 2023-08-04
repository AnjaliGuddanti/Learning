using NotificationSystem.ConsoleApp.Model;

namespace NotificationSystem.ConsoleApp
{
    internal interface INotitificationAdapter
    {
        void Notify(NotificationModel notification);
    }
}
