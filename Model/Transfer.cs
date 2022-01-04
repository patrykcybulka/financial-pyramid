using System.Xml.Serialization;

namespace financial_pyramid.Model
{
    [XmlRoot(ElementName = "przelew")]
    public class Transfer
    {
        [XmlAttribute(AttributeName = "od")]
        public int From { get; set; }

        [XmlAttribute(AttributeName = "kwota")]
        public int Amount { get; set; }
    }
}
