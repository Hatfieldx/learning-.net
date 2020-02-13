using CarsPro;
using System;
using System.Collections.Generic;
using System.Xml;
using System.Xml.Linq;
using System.Linq;

namespace XML_EDU
{
    class Phone
    {
        public string Model { get; set; }
        public string Company { get; set; }
        public int Price { get; set; }

        public Phone()
        {

        }

        public Phone(string model, string company, int price)
        {
            Model = model;
            Company = company;
            Price = price;
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
                        
            LadaSedan lada = new LadaSedan("Lada", "Red", 5, "Rols");

            string dirPath = @"D:\test dir\users.xml";
            string dirPath1 = @"D:\test dir\users1.xml";

            XmlDocument xmlDoc = new XmlDocument();

            xmlDoc.Load(dirPath);

            XmlElement xRoot = xmlDoc.DocumentElement;

            foreach (XmlNode xnode in xRoot)
            {
                if (xnode.Attributes.Count > 0)
                {
                    XmlNode attr = xnode.Attributes.GetNamedItem("name");

                    if (attr != null)
                    {
                        Console.WriteLine(attr.InnerText);
                    }
                }

                foreach (XmlNode childnode in xnode)
                {
                    Console.WriteLine(childnode.InnerText);
                }
            }

            XmlNode newuser = xmlDoc.CreateElement("user");
            XmlNode userPropAge = xmlDoc.CreateElement("age");
            XmlNode userPropName = xmlDoc.CreateElement("name");
            //userPropAge.InnerText = "34";


            XmlText textAge = xmlDoc.CreateTextNode("34");
            XmlText textName = xmlDoc.CreateTextNode("Vasian");
            //userPropName.InnerText = "Vasian";

            xRoot.AppendChild(newuser);

            newuser.AppendChild(userPropName);
            userPropName.AppendChild(textName);

            newuser.AppendChild(userPropAge);
            userPropAge.AppendChild(textAge);

            xmlDoc.Save(dirPath);

            //xRoot.RemoveChild(xRoot.LastChild);

            XmlNodeList selection = xRoot.SelectNodes("user[name = 'Vasian']");

            foreach (XmlNode item in selection)
            {
                Console.WriteLine(item.OuterXml);

                xRoot.RemoveChild(item);
            }

            xmlDoc.Save(dirPath);

            var g = new { model = "galaxy", age = 43, company = "samsung", exp = true };
            string dirPathLINQ = @"D:\test dir\usersLINQ.xml";

            List<Phone> phones = new List<Phone>()
            {
                new Phone() {Model = "galaxy", Company =  "samsung", Price = 700},
                new Phone() {Model = "iphone", Company =  "apple", Price = 800},
                new Phone() {Model = "Lumia", Company =  "MS", Price = 100},
                new Phone() {Model = "Nokia", Company =  "nokia", Price = 400}
            };

            XDocument xdoc = new XDocument();

            XElement xroot = new XElement("phones");



            foreach (Phone phone in phones)
            {
                xroot.Add(
                    new XElement("phone"
                                    , new XAttribute("model", phone.Model)
                                    , new XElement("company", phone.Company)
                                    , new XElement("price", phone.Price)));
            }

            //XElement xroot = new XElement("phones",
            //    new XElement("iphone6", 
            //        new XElement("company", "Apple"))
            //    );

            //XElement samsung = new XElement(
            //    "Galaxy", new XAttribute("age", "2000"),
            //    new XElement("company", "samsung"),
            //    new XElement("price", "5000"),
            //    new XElement("explous", "true")
            //    );

            //xroot.Add(samsung);
            xdoc.Add(xroot);
            xdoc.Save(dirPathLINQ);

            XDocument xReadDoc = XDocument.Load(dirPathLINQ);

            var root = xReadDoc.Element("phones");

            var res = (from xe in root.Elements("phone")
                      where xe.Attribute("model").Value == "Lumia"
                      select new
                      {
                          model = xe.Attribute("model").Value,
                          company = xe.Element("company").Value,
                          price = xe.Element("price").Value
                      }).FirstOrDefault();

            Console.WriteLine($"{res.model} - {res.company} - {res.price}");



            Console.ReadKey();
        }
    }
}
