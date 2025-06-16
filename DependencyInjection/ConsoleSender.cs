using System;
namespace DependencyInjection
{
    /// <summary>
    /// A simple sender that writes messages to the console.
    /// Used for quick feedback in development.
    /// </summary>
    public class ConsoleSender: IMessageSender
	{
		public void Send(string message)
		{
            // Prefix so we know which sender is being used
            Console.WriteLine($"[ConsoleSender]{message}");
		}
	}
}

