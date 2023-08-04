// See https://aka.ms/new-console-template for more information
using NotificationSystem.ConsoleApp;
using NotificationSystem.ConsoleApp.Model;

Console.WriteLine("---------Welcome to our notification system---------");

bool quit =false;

while (!quit)
{
    Console.WriteLine("Enter a Channel Of Notification (Email or SMS) or type 'exit' to quit : ");
    string input = Console.ReadLine().ToLower();

    if (input.Equals("exit"))
    {
        quit = true;
        Console.WriteLine("Exiting the program...");
    }
    else if (Enum.TryParse(input, out NotificationType notificationChannel) && Enum.IsDefined(typeof(NotificationType), notificationChannel))
    {
        NotificationModel notification = new();
        Console.WriteLine($"You selected the channel: {notificationChannel}");
        notification.ChannelOfNotification = notificationChannel;
        Console.WriteLine("Enter Subject : ");
        notification.Subject = Console.ReadLine();
        Console.WriteLine("Enter Message Body : ");
        notification.MessageBody = Console.ReadLine();
        // Console.WriteLine(notification.Subject);
        // Console.WriteLine(notification.MessageBody);
        //Console.WriteLine(notification.ChannelOfNotification);
        INotitificationAdapter notificationAdapter = new NotificationAdapter();
        notificationAdapter.Notify(notification);
    }
    else
    {
        Console.WriteLine("OOPS!.....Enter a Channel Of Notification (Email or SMS) or type 'exit' to quit : ");
    }
}


