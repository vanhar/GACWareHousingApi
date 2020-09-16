using GACWareHousingApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace GACWareHousingApi.Helpers
{
    public static class XmlParserHandler
    {
        public static IEnumerable<SalesOrder> ParseSalesOrder(string xml)
        {
            XDocument doc = XDocument.Parse(xml);

            return from c in doc.Descendants("SalesOrder")
                   select new SalesOrder()
                   {
                       OrderCode = (string)c.Attribute("OrderCode"),
                       CustomerCode = (string)c.Attribute("CustomerCode"),
                       OrderDate = (DateTime)c.Attribute("OrderDate"),
                       CreatedBy = "System",
                       ModifiedBy = "System",
                       CreatedOn =DateTime.Now,
                       ModifiedOn =DateTime.Now,
                       SalesOrderDetails = from f in c.Descendants("SalesOrderDetail")
                                           select new SalesOrderDetail()
                                           {
                                               OrderCode = (string)f.Attribute("OrderCode"),
                                               ProductCode = (string)f.Attribute("ProductCode"),
                                               Quantity = (int)f.Attribute("Quantity"),
                                               CreatedBy = "System",
                                               ModifiedBy = "System",
                                               CreatedOn = DateTime.Now,
                                               ModifiedOn = DateTime.Now,
                                           }
                   };

        }
    }
}
