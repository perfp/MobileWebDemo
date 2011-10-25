﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using MobileWebDemo.Models;

namespace MobileWebDemo.Infrastructure
{
    public class MessageRepository
    {
        private System.Xml.Linq.XDocument xdoc;
        private IEnumerable<XElement> filteredList;

        public MessageRepository(System.Xml.Linq.XDocument xdoc)
        {         
            this.xdoc = xdoc;
        }

        public IEnumerable<XElement> GetFilteredList(Models.Message messagePrototype)
        {
            var messages = xdoc
                .Element("searchresult")
                .Element("result-array")
                .Element("result")
                .Element("messages")
                .Elements("message");

            this.filteredList = messages;

            var county = messagePrototype.County;
            FilterByCounty(county);
            FilterByType( messagePrototype.MessageType);

            return filteredList;
        }

        private void FilterByType(string messageType)
        {
            if (!string.IsNullOrEmpty(messageType))
            {
               filteredList =  filteredList.Where(x => x.Element("messageType").Value == messageType);
            }          
        }

        private void FilterByCounty(string county)
        {
            if (!string.IsNullOrEmpty(county))
            {
                filteredList = filteredList.Where(x => x.Element("actualCounties").Elements("string").Count(s => s.Value == county) > 0);
            }            
        }
    }
}