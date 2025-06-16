using System;
namespace DependencyInjection
{
    /// <summary>
    /// A service that “does work” by sending notifications.
    /// It depends only on the abstraction IMessageSender.
    /// </summary>
    public class NotificationService
	{
        public readonly IMessageSender _sender;

        // 1) Constructor injection: we require an IMessageSender to be passed in.

        public NotificationService(IMessageSender sender)
        {
            _sender = sender ?? throw new ArgumentNullException(nameof(sender));
        }

        // 2) Use the injected sender to send a formatted message.

        public void Notify(string user,string text)
        {
            _sender.Send($"To {user}: {text}");
        }
             
    }
}

