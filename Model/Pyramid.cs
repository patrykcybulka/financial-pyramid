using System.Xml.Serialization;

namespace financial_pyramid.Model
{
    [XmlRoot(ElementName = "piramida")]
    public class Pyramid
    {
        [XmlElement(ElementName = "uczestnik")]
        public Participant Participant { get; set; }
    }
}
