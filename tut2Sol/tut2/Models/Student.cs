using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace tut2.Models
{
  public  class Student
    {
        public string FirstName { get; set; }

        private string _lastName;
        public string LastName
        {
            get { return _lastName; }
            set
            {
                _lastName = value ?? throw new ArgumentException();
            }
        }

        [XmlAttribute(attributeName: "indexNumber")]
        public string IndexNumber { get; set; }
        public DateTime Birthdate { get; set; }
        [XmlElement(elementName: "email")]
        public string Email { get; set; }

        [XmlElement(elementName: "Studies")]
        public Studies Studies { get; set; }

        public string MomName { get; set; }
        public string DadsName { get; set; }
    }
}
