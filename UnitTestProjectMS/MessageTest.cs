using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using WebApplicationUnitTesting.Models;

namespace UnitTestProjectMS
{
    [TestClass]
    public class MessageTest
    {
        static Mock<IMessage> mockemailclass;
        static IMessage obj;
        static MessageingService service;
        [ClassInitialize]
        public static void ClassInit(TestContext context)
        {
            mockemailclass = new Mock<IMessage>();
            obj = mockemailclass.Object;
            service= new MessageingService(obj);

        }


        [TestMethod]
        public void MessageTest1()
        {
            mockemailclass.SetupProperty(c => c.sender, "abc@gmail.com");
            mockemailclass.SetupProperty(c => c.reciever, "xyz@gmail.com");
            mockemailclass.SetupProperty(c => c.message, "Message");

            mockemailclass.Setup(c => c.SendMessage()).Returns(true);
            mockemailclass.Setup(c => c.SendMessage(It.IsAny<string>(), It.IsAny<string>(), It.IsAny<string>()));


            bool result = service.SendMessage();
            Assert.IsTrue(result);
            result = service.SendMessage("a","b","Hello");
            Assert.IsFalse(result);


            Assert.AreEqual(service.message.message, "Message");
            Assert.AreEqual(service.message.sender, "abc@gmail.com");

            mockemailclass.Verify(c => c.SendMessage());
        }
    }
}
