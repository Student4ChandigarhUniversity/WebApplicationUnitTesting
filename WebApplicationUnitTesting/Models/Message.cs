using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplicationUnitTesting.Models
{
    public interface IMessage
    {
        string sender { get; set; }
        string reciever { get; set; }
        string message { get; set; }

        bool SendMessage();
        bool SendMessage(string sender,string reciever, string message);
    }


    public class MessageingService
    {
        public IMessage message;

        public MessageingService(IMessage message)
        {

            this.message = message;
        }

        public bool SendMessage()
        {
            return message.SendMessage();
        }

        public bool SendMessage(string s, string r,string m)
        {
            return message.SendMessage(s, r, m);
        }
    }


    //public class SMS: IMessage
    //{
    //}

    //public class Email :IMessage
    //{

    //}
}
