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
        public List<string> getInfomation(string []index) {
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
            

            return Infomation;

        }
        private static void ValidationCallBack(object sender, ValidationEventArgs e)
        {
            //Console.WriteLine("Validation Error: {0}", e.Message);
        }
    }
}
