using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace test
{
    public class CandidateXML
    {
        [XmlElement("name")]
        public string Name { get; set; }
        [XmlElement("party")]
        public string Party { get; set; }
    }
}
