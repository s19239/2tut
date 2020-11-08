using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using tut2.Models;

namespace tut2
{
    [Serializable]
    public class Uni
    {
        [XmlAttribute(AttributeName = "createdAt")]
        public DateTime Created { get; set; }

        [XmlAttribute(AttributeName = "Author_Name")]
        public string Author { get; set; }

        [XmlElement(ElementName = "Students")]
        public HashSet<Student> Students { get; set; }

        [XmlElement(ElementName = "Studies")]
        public HashSet<Studies> Studies { get; set; }
    }
}
