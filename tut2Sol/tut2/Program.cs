using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using tut2.Models;

namespace tut2
{
    class Program
    {
        static void Main(string[] args)
        {
            var path = @"data\dane.csv";



            var mylist = new HashSet<Student>(new Comparator());

            var university = new Uni
            {
                Created = DateTime.Now,
                Author = "Aliia Baimuratova s19239",
                Students = mylist,

            };
         

            try
            {
               
                using (StreamReader reader = new StreamReader(path))
                {
                    reader.ReadToEnd();
                }
            }
            catch (FileNotFoundException ex)
            {
               
                using (StreamWriter sr = new StreamWriter(@"log.txt"))
                {
                    sr.WriteLine(String.Concat("File is not found("));
                }
            }
            var fi = new FileInfo(path);

            using (var stream = new StreamReader(fi.OpenRead()))
            {
                string line = null;
                while ((line = stream.ReadLine()) != null)
                {
                    string[] columns = line.Split(',');
                    if (columns.Length != 9)
                    {
                        using (StreamWriter wr = new StreamWriter(@"log.txt"))
                        {
                            wr.WriteLine(String.Concat(line, " incorrect data"));
                        }
                    }

                    foreach (string str in columns)
                    {
                        if (string.IsNullOrEmpty(str))
                        {
                            using (StreamWriter wr = new StreamWriter(@"log.txt"))
                            {
                                wr.WriteLine(String.Concat(line, " data is null"));
                            }
                        }
                        var stud = getStudents(columns);
                        mylist.Add(stud);

                        if (mylist.Contains(stud))
                        {
                            using (StreamWriter wr = new StreamWriter(@"log.txt"))
                            {
                                wr.WriteLine(String.Concat(line, " this data already recorded"));
                            }
                        }




                        if (!mylist.Add(stud))
                        {
                            using (StreamWriter wr = new StreamWriter(@"log.txt"))
                            {
                                wr.WriteLine(String.Concat(line, "    object is a duplicate"));
                            }


                        }

                    }
                }
                Student getStudents(string[] columns)
                {
                    var student = new Student

                    {


                        FirstName = columns[0],
                        LastName = columns[1],
                        IndexNumber = columns[4],
                        Birthdate = DateTime.Parse(columns[5]),
                        Email = columns[6],
                        DadsName = columns[7],
                        MomName = columns[8],
                        Studies = new Studies
                        {
                            Name = columns[2],
                            StudyMode = columns[3],

                        }

                    };


                    return student;
                }
                var writer = new FileStream(@"result.xml", FileMode.Create);
                var serializer = new XmlSerializer(typeof(HashSet<Student>),
                                                    new XmlRootAttribute("University"));
                serializer.Serialize(writer, university);


            }

        }
    }
}
