using System.Xml.Serialization;

namespace CalypsoToT24API.Infrastructure.Models
{
    [XmlRoot(ElementName = "Envelope", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
    public class Envelope
    {
        [XmlElement(ElementName = "Body", Namespace = "http://schemas.xmlsoap.org/soap/envelope/")]
        public Body Body { get; set; }
    }

    public class Body
    {
        [XmlElement(ElementName = "CalypsoEventsFTWS", Namespace = "http://tempuri.org/")]
        public CalypsoEventsFTWS CalypsoEventsFTWS { get; set; }
    }

    public class CalypsoEventsFTWS
    {
        public string CompanyCode { get; set; }
        public string CalypsoEventId { get; set; }  
        public string CalypsoData { get; set; }     
    }
}
