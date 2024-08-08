using CalypsoToT24API.Infrastructure.Models;
using System.Xml;

namespace CalypsoToT24API.Helper
{
    public static class XmlParser
    {
        public static CalypsoEventsFTWS ParseXml(string xmlContent)
        {
            CalypsoEventsFTWS calypsoEvent = null;
            using (XmlReader reader = XmlReader.Create(new StringReader(xmlContent)))
            {
                while (reader.Read())
                {
                    if (reader.IsStartElement())
                    {
                        switch (reader.Name)
                        {
                            case "CalypsoEventsFTWS":
                                calypsoEvent = new CalypsoEventsFTWS();
                                break;
                            case "CompanyCode":
                                if (calypsoEvent != null)
                                    calypsoEvent.CompanyCode = reader.ReadString();
                                break;
                            case "CalypsoEventId":
                                if (calypsoEvent != null)
                                    calypsoEvent.CalypsoEventId = reader.ReadString();
                                break;
                            case "CalypsoData":
                                if (calypsoEvent != null)
                                    calypsoEvent.CalypsoData = reader.ReadString();
                                break;
                        }
                    }
                }
            }
            return calypsoEvent;
        }
    }
}
