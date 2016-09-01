using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace test
{

    public class PersonXML
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        [XmlElement("pesel")]
        public string Pesel { get; set; }
    }
}
