using System.Xml.Serialization;

namespace financial_pyramid.Model
{
    [XmlRoot(ElementName = "przelewy")]
    public class Transfers
    {
        [XmlElement(ElementName = "przelew")]
        public List<Transfer> ListOfTransfers { get; set; }
    }
}
