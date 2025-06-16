using System;
using DependencyInjection;
using Microsoft.Extensions.DependencyInjection;

namespace DependencyInjection
{
    class Program
    {
        static void Main()
        {
            Console.WriteLine("=== 1. No-DI (tight coupling) ===");
            var tight = new TightOrderProcessor();
            tight.Process(123);

            Console.WriteLine("\n=== 2. Manual DI ===");
            ManualDemo();

            Console.WriteLine("\n=== 3. Built-in Container DI ===");
            ContainerDemo();

            Console.WriteLine("\n=== 4. Lifetime Demonstration ===");
            LifetimeDemo();
        }

        static void ManualDemo()
        {
            // Manually create and inject ConsoleSender
            var svc1 = new NotificationService(new ConsoleSender());
            svc1.Notify("Alice", "Manual DI works!");

            // Manually swap to SmtpSender
            var svc2 = new NotificationService(new SmtpSender());
            svc2.Notify("Bob", "Swapped to SMTP sender.");
        }

        static void ContainerDemo()
        {
            // 1) Build the service collection
            var services = new ServiceCollection();

            // 2) Register IMessageSender → SmtpSender
            services.AddTransient<IMessageSender, SmtpSender>();
            // To switch behavior, change only the line above:
            // services.AddTransient<IMessageSender, ConsoleSender>();
            // services.AddTransient<IMessageSender, InMemorySender>();

            // 3) Register NotificationService itself
            services.AddTransient<NotificationService>();

            // 4) Build the container
            using var provider = services.BuildServiceProvider();

            // 5) Resolve and use
            var notif = provider.GetRequiredService<NotificationService>();
            notif.Notify("Carol", "Container-based DI!");
        }

        static void LifetimeDemo()
        {
            var services = new ServiceCollection();

            // Demonstrate three lifetimes for GuidService:
            services.AddTransient<GuidService>();   // new each call
            services.AddSingleton<GuidService>();   // single instance overall
            services.AddScoped<GuidService>();      // one per scope

            using var provider = services.BuildServiceProvider();

            Console.WriteLine("Transient:");
            Console.WriteLine(provider.GetService<GuidService>().Id);
            Console.WriteLine(provider.GetService<GuidService>().Id);

            Console.WriteLine("Singleton:");
            Console.WriteLine(provider.GetService<GuidService>().Id);
            Console.WriteLine(provider.GetService<GuidService>().Id);

            Console.WriteLine("Scoped (Scope 1):");
            using (var scope1 = provider.CreateScope())
            {
                Console.WriteLine(scope1.ServiceProvider.GetService<GuidService>().Id);
                Console.WriteLine(scope1.ServiceProvider.GetService<GuidService>().Id);
            }

            Console.WriteLine("Scoped (Scope 2):");
            using (var scope2 = provider.CreateScope())
            {
                Console.WriteLine(scope2.ServiceProvider.GetService<GuidService>().Id);
                Console.WriteLine(scope2.ServiceProvider.GetService<GuidService>().Id);
            }
        }
    }
}
