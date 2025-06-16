using System;
namespace DependencyInjection
{
	public class SmtpSender:IMessageSender
	{
        /// <summary>
        /// A “real” sender that would email messages via SMTP.
        /// Here we just simulate by writing to console, but imagine
        /// this class contains your SMTP client logic.
        /// </summary>
        public void Send(string message)
        {
            // In production, you’d connect to SMTP server here.
            Console.WriteLine($"[SmtpSender] Email sent :{message}");
        }
		
	}
}

