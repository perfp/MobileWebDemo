using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml.Linq;
using MobileWebDemo.Infrastructure;
using MobileWebDemo.Models;

namespace MWTest.UnitTests
{
   
    [TestClass]
    [DeploymentItem("Content\\search.xml", "Content")]
    public class MessageRepositoryTests{
        
        [TestMethod]       
        public void CanFilterXmlBasedOnCounty()
        {
            var messages = CreateRepository();

            var messagePrototype = new Message();
            messagePrototype.County = "Akershus";

            var filteredList = messages.GetFilteredList(messagePrototype);
            Assert.AreEqual(26, filteredList.Count());
        }

   

        [TestMethod]
        public void CanFilterXmlBasedOnMessageType()
        {
            var messages = CreateRepository();

            var messagePrototype = new Message();
            messagePrototype.MessageType = Message.MessageTypes.MidlertidigStengt;

            var filteredList = messages.GetFilteredList(messagePrototype);
            Assert.AreEqual(9, filteredList.Count());
        }

        [TestMethod]
        public void CanFilterAllUnnecessaryElements(){
            var messages = CreateRepository();

            var filteredList = messages.GetFilteredList(new Message());

            Assert.IsNull(filteredList.First().Element("version"));
        }

        private static MessageRepository CreateRepository()
        {
            var xdoc = XDocument.Load("Content\\search.xml");
            var messages = new MessageRepository(xdoc);
            return messages;
        }
    }
}
