using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml;
using System.Xml.Linq;
using MobileWebDemo.Infrastructure;
using MobileWebDemo.Models;
using MobileWebDemo.Tools;


namespace MobileWebDemo.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
          

            return View();
        }

        [HttpGet]
        public ActionResult GetData(string filter, string value)
        {
            var path = ".\\Content\\search.xml";
            if (Url != null) path = Server.MapPath("~/Content/search.xml"); 

            var doc = XDocument.Load(path);
            var messageRepository = new MessageRepository(doc);

            var message = new Message();            
            if (filter == "type") message.MessageType = value;
            if (filter == "county") message.County = value;

            var filteredList = messageRepository.GetFilteredList(message);
            
            doc.Element("searchresult").Element("result-array").Element("result").Element("messages").ReplaceAll(filteredList);           
            return new XmlResult(doc);
        }
    }
}
