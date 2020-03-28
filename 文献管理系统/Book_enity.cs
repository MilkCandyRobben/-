using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文献管理系统
{
    #region//书籍book的xml示例
    //<book mdate = "2004-01-13" key="books/bi/WedekindH1974">
    //<author>Hartmut Wedekind</author>
    //<author>Theo H&auml; rder</author>
    //<title>Datenbanksysteme I</title>
    //<series>Reihe Informatik</series>
    //<volume>16</volume>
    //<publisher>Bibliographisches Institut</publisher>
    //<year>1974</year>
    //</book>

    //<book mdate = "2004-01-13" key= "books/bi/Fellner1992" >
    //<author> Dieter W.Fellner</author>
    //<title>Computer-Grafik, 2. Auflage</title>
    //<series>Reihe Informatik</series>
    //<volume>58</volume>
    //<publisher>Bibliographisches Institut</publisher>
    //<year>1992</year>
    //<isbn>3-411-15122-6</isbn>
    //</book>

    //<book mdate = "2019-05-27" key= "books/huber/ReyWender2008" >
    //<author> G & uuml; nter Daniel Rey</author>
    //<author>Karl Friedrich Wender</author>
    //<title>Neuronale Netze - Eine Einf&uuml;hrung in die Grundlagen, Anwendungen und Datenauswertung</title>
    //<publisher>Hans Huber Verlag</publisher>
    //<year>2008</year>
    //<isbn>978-3-456-84513-5</isbn>
    //<ee>http://d-nb.info/987165437</ee>
    //</book>
    #endregion

    /// <summary>
    /// Created by lb 2020.3.29
    /// 书籍实体类(目前不重要)
    /// </summary>
    /// 
    class Book_enity
    {
        public string name { set; get; }//书籍名称(重要)
        public List<string> authors { set; get; }//作者姓名列表(重要)
        public string year { set; get; }//发表年份
        public string series { set; get; }//书籍系列
        public string volume { set; get; }//书籍卷数
        public string publisher { set; get; }//出版商
        public string isbn { set; get; }//国际规范图书编号
        public string ee { set; get; }//书籍网页

        /// <summary>
        /// 书籍的构造函数
        /// </summary>
        /// <param name="name">书籍名称</param>
        /// <param name="authors">作者姓名列表</param>
        /// <param name="year">发表年份</param>
        /// <param name="series">书籍系列</param>
        /// <param name="volume">书籍卷数</param>
        /// <param name="publisher">出版商</param>
        /// <param name="isbn">国际规范图书编号</param>
        /// <param name="ee">书籍网页</param>
        public Book_enity(string name, List<string> authors, string year = null, string series = null, string volume = null, string publisher = null,string isbn=null, string ee=null)
        {
            this.name = name;
            this.authors = authors;
            this.year = year;
            this.series = series;
            this.volume = volume;
            this.publisher = publisher;
            this.isbn = isbn;
            this.ee = ee;
        }

        /// <summary>
        /// 获取此书籍的作者数
        /// </summary>
        /// <returns></returns>
        int getAuthorsCount()
        {
            return this.authors.Count();
        }

        /// <summary>
        /// 判断作者是否在该书籍的作者列表里
        /// </summary>
        /// <param name="author">作者名</param>
        /// <returns></returns>
        bool isAuthorExist(string author)
        {
            foreach (var i in this.authors)
            {
                if (i.ToString().Equals(author))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 封装模块
        /// </summary>
        /// <param name="name"></param>
        /// <param name="authors"></param>
        /// <param name="year"></param>
        /// <param name="volume"></param>
        /// <param name="publisher"></param>
        /// <param name="isbn"></param>
        /// <param name="ee"></param>
        public void pkgModule(out string name, out List<string> authors, out string year, out string series, out string volume, out string publisher, out string isbn , out string ee)
        {
            name = this.name;
            authors = this.authors;
            year = this.year;
            series = this.series;
            volume = this.volume;
            publisher = this.publisher;
            isbn = this.isbn;
            ee = this.ee;
        }
    }
}
