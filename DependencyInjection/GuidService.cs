using System;
namespace DependencyInjection
{
    /// <summary>
  /// Used to demonstrate DI lifetimes.
  /// Each instance gets a new GUID when constructed.
  /// </summary>
    public class GuidService
    {
        // Readonly property set once at construction
        public Guid Id { get; } = Guid.NewGuid();
    }
}

