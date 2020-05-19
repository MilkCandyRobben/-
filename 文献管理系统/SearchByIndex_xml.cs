using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;
using System.Data;
using System.Drawing;
using System.IO;
using System.Security.Cryptography.X509Certificates;

namespace 文献管理系统
{
    class SearchByIndex_xml
    {
        

        //public List<string> Infomation { set; get; }//author Tom+":"
        //public void clearInfo()
        //{
        //    this.Infomation.Clear();
        //}

        public FileStream fs_out;
        public StreamWriter sw;
        public List<string> author_set { set; get; }
        
        public bool getInfomation(string[] indexGroup,string filePath,string outputPath)
        {
            fs_out = new FileStream(outputPath, FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs_out);
            //XmlReaderSettings解决dtd约束权限问题 加入这三句就能够解决
            //ValidationCallBack记得要Override
            //XmlReaderSettings settings = new XmlReaderSettings();
            //settings.ProhibitDtd = false;
            //settings.ValidationType = ValidationType.DTD;
            //settings.ValidationEventHandler += new ValidationEventHandler(ValidationCallBack);


            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(filePath, settings);

            //XmlReader reader = XmlReader.Create(filepath, settings);

            //reader的create函数也需要加入settings设置 

            //if (Infomation == null)
            //{
            //    Infomation = new List<string>();
            //}

            foreach (string index in indexGroup) {
                while (reader.Read())
                {
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.GetAttribute("index") == index)
                        {
                            //通过index定位当前的标签的name是什么并且选择
                            //由于XmlReader是按行读取的 所以需要按行判断标签的名字是否符合要求
                            //此处属于投机取巧 因为author journal标签是字标签 
                            //当遍历到最后一位时 遇到article或者inproceedings等大标签即停止
                            //搜索花的时间最长为1分钟
                            switch (reader.Name)//article inproceeding incollection
                            {
                                case "article":
                                    reader.MoveToElement();//跳过空白节点 免得影响条件判断
                                    while (reader.Read())
                                    {

                                        reader.MoveToContent();
                                        if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "author" || reader.Name == "volume" || reader.Name == "ee" || reader.Name == "isbn" || reader.Name == "url" || reader.Name == "journal" || reader.Name == "month" || reader.Name == "year" || reader.Name == "title" || reader.Name == "publisher"))
                                        {

                                            sw.Write(reader.Name + ":" + reader.ReadInnerXml() + '\n');
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
                                            sw.Write(reader.Name + ":" + reader.ReadInnerXml() + '\n');

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

                                            sw.Write(reader.Name + ":" + reader.ReadInnerXml() + '\n');

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

                                            sw.Write(reader.Name + ":" + reader.ReadInnerXml() + '\n');

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

                                            sw.Write(reader.Name + ":" + reader.ReadInnerXml() + '\n');

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
                                            sw.Write(reader.Name + ":" + reader.ReadInnerXml() + '\n');

                                        }
                                        else
                                            break;
                                    }
                                    break;
                            }
                            sw.Write('\n');
                            break;
                            //这个break是为了避免reader停不下来知道最后一行
                        }
                    }
                }
            }
            reader.Close();
            sw.Close();
            fs_out.Close();
            
            // return Infomation;
            return true;
        }

        public bool Author_Partnership(string[] indexGroup, string filepath, string outputPath) 
        {
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.DtdProcessing = DtdProcessing.Parse;
            XmlReader reader = XmlReader.Create(filepath, settings);

            fs_out = new FileStream(outputPath, FileMode.Append, FileAccess.Write);
            sw = new StreamWriter(fs_out);

            reader.MoveToContent();
            foreach (string index in indexGroup) 
            {
                while (reader.Read())
                {
                    
                    if (reader.NodeType == XmlNodeType.Element)
                    {
                        if (reader.GetAttribute("index") == index) 
                        {
                            reader.MoveToContent();
                            while (reader.Read())
                            {
                                reader.MoveToContent();
                                if ((reader.NodeType == XmlNodeType.Element) && (reader.Name == "author" || reader.Name == "editor"))
                                {
                                    author_set.Add(reader.ReadInnerXml());
                                }
                                else
                                    break;
                            }
                            
                            break;
                        }
                    }
                        
                }
            }
            HashSet<string> hs = new HashSet<string>(author_set);
            string[] author_combine = hs.ToArray<string>();
            sw.WriteLine("Partnership:");
            for (int i = 0; i < author_combine.Length; i++)
            {
                sw.WriteLine(author_combine[i]);
            }
            reader.Close();
            sw.Close();
            fs_out.Close();

            return true;
        }
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            //Console.WriteLine("Validation Error: {0}", e.Message);
        }
    }
}
