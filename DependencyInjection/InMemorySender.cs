using System;
namespace DependencyInjection
{
    /// <summary>
    /// A test‐only sender that keeps messages in memory.
    /// Useful in unit tests where you assert on Messages.
    /// </summary>
    public class InMemorySender:IMessageSender
    {
        // Captured messages for inspection
        public List<string> Messages { get; } = new();

        public void Send(string message)
        {
            Console.WriteLine($"[InMemorySender] Captured message");
        }

	}
}

