using System.Xml.Serialization;

namespace financial_pyramid.Model
{
    [XmlRoot(ElementName = "uczestnik")]
    public class Participant
    {
        [XmlAttribute(AttributeName = "id")]
        public int Id { get; set; }

        [XmlElement(ElementName = "uczestnik")]
        public List<Participant> Subordinates { get; set; }
    }
}
