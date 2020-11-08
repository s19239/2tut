using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace tut2.Models
{
    [Serializable]
    public class Studies
    {
        [XmlElement(ElementName = "NameOfStudies")]
        public string Name { get; set; }

        [XmlElement(ElementName = "ModeOfStidies")]
        public string StudyMode { get; set; }
    }
}
