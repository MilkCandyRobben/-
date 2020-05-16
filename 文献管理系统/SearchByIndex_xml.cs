using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Data;
using System.Drawing;
namespace 文献管理系统
{
    class SearchByIndex_xml
    {
        public string filePath = "E:\\dblp_index.xml";
        public List<string> Infomation { set; get; }
        public List<string> getInfomation(string[] indexGroup)
        {
            //XmlReaderSettings解决dtd约束权限问题 加入这三句就能够解决
            //ValidationCallBack记得要Override
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ProhibitDtd = false;
            settings.ValidationType = ValidationType.DTD;
            settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);
            //reader的create函数也需要加入settings设置 
            XmlReader reader = XmlReader.Create(filePath, settings);
            if (Infomation == null)
            {
                Infomation = new List<string>();
            }

            foreach (string index in indexGroup) {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.GetAttribute("index") == index)
                        {
                            switch (reader.Name)
                            {
                                case "article":
                                    reader.MoveToElement();//跳过空白节点 免得影响条件判断
                                    while (reader.Read())
                                    {
                                        reader.MoveToContent();
                                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "author" || reader.Name == "volume" || reader.Name == "ee" || reader.Name == "isbn" || reader.Name == "url" || reader.Name == "journal" || reader.Name == "month" || reader.Name == "year" || reader.Name == "title" || reader.Name == "publisher"))
                                        {
                                            this.Infomation.Add(reader.Name);
                                            this.Infomation.Add(reader.ReadInnerXml());

                                        }
                                        else
                                            break;
                                    }
                                    break;
                                case "book":
                                    reader.MoveToElement();
                                    while (reader.Read())
                                    {
                                        reader.MoveToContent();
                                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "author" || reader.Name == "title" || reader.Name == "year" || reader.Name == "series" || reader.Name == "publisher" || reader.Name == "isbn" || reader.Name == "ee"))
                                        {
                                            this.Infomation.Add(reader.Name);
                                            this.Infomation.Add(reader.ReadInnerXml());

                                        }
                                        else
                                            break;
                                    }
                                    break;
                                case "incollection":
                                    reader.MoveToElement();
                                    while (reader.Read())
                                    {
                                        reader.MoveToContent();
                                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "author" || reader.Name == "title" || reader.Name == "pages" || reader.Name == "year" || reader.Name == "booktitle" || reader.Name == "url" || reader.Name == "crossref" || reader.Name == "ee" || reader.Name == "cdrom" || reader.Name == "note" || reader.Name == "month"))
                                        {

                                            this.Infomation.Add(reader.Name);
                                            this.Infomation.Add(reader.ReadInnerXml());

                                        }
                                        else
                                            break;
                                    }
                                    break;
                                case "inproceedings":
                                    reader.MoveToElement();
                                    while (reader.Read())
                                    {
                                        reader.MoveToContent();
                                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "author" || reader.Name == "title" || reader.Name == "pages" || reader.Name == "year" || reader.Name == "booktitle" || reader.Name == "url" || reader.Name == "crossref" || reader.Name == "ee" || reader.Name == "cdrom" || reader.Name == "note" || reader.Name == "month"))
                                        {

                                            this.Infomation.Add(reader.Name);
                                            this.Infomation.Add(reader.ReadInnerXml());

                                        }
                                        else
                                            break;
                                    }
                                    break;
                                case "www":
                                    reader.MoveToElement();
                                    while (reader.Read())
                                    {
                                        reader.MoveToContent();
                                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "volume" || reader.Name == "editor" || reader.Name == "author" || reader.Name == "title" || reader.Name == "pages" || reader.Name == "year" || reader.Name == "booktitle" || reader.Name == "url" || reader.Name == "crossref" || reader.Name == "ee" || reader.Name == "cdrom" || reader.Name == "note" || reader.Name == "month"))
                                        {

                                            this.Infomation.Add(reader.Name);
                                            this.Infomation.Add(reader.ReadInnerXml());

                                        }
                                        else
                                            break;
                                    }
                                    break;

                                case "phdthesis":
                                    reader.MoveToElement();
                                    while (reader.Read())
                                    {
                                        reader.MoveToContent();
                                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "author" || reader.Name == "title" || reader.Name == "year" || reader.Name == "school" || reader.Name == "pages" || reader.Name == "publisher" || reader.Name == "series" || reader.Name == "volume" || reader.Name == "isbn" || reader.Name == "ee"))
                                        {
                                            this.Infomation.Add(reader.Name);
                                            this.Infomation.Add(reader.ReadInnerXml());

                                        }
                                        else
                                            break;
                                    }
                                    break;
                            }
                            break;
                        }
                    }
                }
            }
            reader.Close();
            return Infomation;

        }
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            //Console.WriteLine("Validation Error: {0}", e.Message);
        }
    }
}
