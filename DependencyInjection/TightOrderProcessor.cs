using System;
namespace DependencyInjection
{
    /// <summary>
    /// Demonstrates the anti-pattern: tight coupling.
    /// This class creates its own ConsoleSender internally,
    /// so you *cannot* swap in a different sender.
    /// </summary>
    public class TightOrderProcessor
	{
        // Instantiates ConsoleSender directly—no flexibility!
        private readonly ConsoleSender _logger = new();

        public void Process(int orderId)
        {
            _logger.Send($"Processing order {orderId}");
            _logger.Send("Done");
        }

    }
}

