using System;
namespace DependencyInjection
{
	//Abstraction for sending message
	public interface IMessageSender
	{
		void Send(string message);
	}
}

