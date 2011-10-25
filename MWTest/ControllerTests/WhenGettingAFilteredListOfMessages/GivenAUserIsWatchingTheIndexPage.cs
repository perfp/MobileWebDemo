using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MobileWebDemo.Controllers;
using MobileWebDemo.Tools;
using System.Xml.Linq;
using System.Linq;

namespace MWTest.WhenGettingAFilteredListOfMessages
{
  
    [TestClass]
    [DeploymentItem("Content\\search.xml", "Content")]
    public class GivenAUserIsWatchingTheIndexPage
    {
        XmlResult result;

        [TestInitialize]
        public void Arrange()
        {
            var controller = new HomeController();
            result = (XmlResult)controller.GetData("type", "Midlertidig stengt");
        }

        [TestMethod]       
        public void ThenWeShouldReturnAnXmlDocument()
        {
            Assert.IsInstanceOfType(result.ObjectToSerialize, typeof(XDocument));
        }

        [TestMethod]
        public void AndTheOutputShouldContainMessages()
        {
            var doc = (XDocument)result.ObjectToSerialize;
            var messages = doc
               .Element("searchresult")
               .Element("result-array")
               .Element("result")
               .Element("messages")
               .Elements("message");

            Assert.AreEqual(9, messages.Count());

        }
    }
}
