using System;
using System.Xml.Serialization;

namespace OOBL
{
    [Serializable]
    //[XmlRoot("Article")]
    public class Article
    {
        [XmlElement("Name")]
        public string Name;
        [XmlElement("Price")]
        public double Price;
        [XmlElement("VatRate")]
        public double VatRate;
        [XmlElement("unitOfSelling")]
        public Util.UnitOfSelling unitOfSelling;

        public Article()
        {

        }
    }
}
