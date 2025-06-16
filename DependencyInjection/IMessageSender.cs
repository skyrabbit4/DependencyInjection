using System;
namespace DependencyInjection
{
    /// <summary>
    /// Defines the abstraction for sending messages.
    /// Any implementation (console, SMTP, in-memory, etc.) must implement this.
    /// </summary>
    public interface IMessageSender
	{
		void Send(string message);
	}
}

