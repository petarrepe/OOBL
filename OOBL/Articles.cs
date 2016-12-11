using System;
using System.Xml.Serialization;

namespace OOBL
{
    [Serializable]
    [XmlRoot("Article")]
    public class Article
    {
        internal string Name;
        internal double Price;
        internal double VatRate;
        internal Util.UnitOfSelling unitOfSelling;

        public Article()
        {

        }
    }
}
