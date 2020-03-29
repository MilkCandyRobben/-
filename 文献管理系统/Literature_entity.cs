using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace 文献管理系统
{
    #region//文章article的xml示例
    //<article mdate = "2018-01-07" key="tr/meltdown/s18" publtype="informal">
    //<author>Paul Kocher</author>
    //<author>Daniel Genkin</author>
    //<author>Daniel Gruss</author>
    //<author>Werner Haas</author>
    //<author>Mike Hamburg</author>
    //<author>Moritz Lipp</author>
    //<author>Stefan Mangard</author>
    //<author>Thomas Prescher 0002</author>
    //<author>Michael Schwarz 0001</author>
    //<author>Yuval Yarom</author>
    //<title>Spectre Attacks: Exploiting Speculative Execution.</title>
    //<journal>meltdownattack.com</journal>
    //<year>2018</year>
    //<ee>https://spectreattack.com/spectre.pdf</ee>
    //</article>
    #endregion

    /// <summary>
    /// Created by lb 2020.3.29
    /// 文章实体类(目前重要)
    /// </summary>
    /// 
    class Literature_entity
    {
        public enum LITERATURE_TYPE//文献类型
        {
            ARTICLE,
            INPROCEEDINGS, 
            INCOLLECTION,
            PHDTHESIS,
            BOOK,
        }

        public string title { set; get; }//文献名称(重要)
        public List<string> authors { set; get; }//作者姓名列表(重要)
        public LITERATURE_TYPE type { set; get; }//文献类型

        public List<string> year { set; get; }//发表年份
        public List<string> month { set; get; }//发表月份
        public List<string> journal { set; get; }//期刊
        public List<string> ee { set; get; }//文章网页
        public List<string> url { set; get; }//文章路径
        public List<string> series { set; get; }//系列
        public List<string> volume { set; get; }//卷数
        public List<string> publisher { set; get; }//出版商
        public List<string> isbn { set; get; }//国际规范图书编号
        public List<string> note { set; get; }//备注
        public List<string> pages { set; get; }//页码
        public List<string> number { set; get; }//编号
        public List<string> booktitle { set; get; }//所在书籍名称
        public List<string> cdrom { set; get; }//存储位置
        public List<string> crossref { set; get; }//交叉引用
        public List<string> school { set; get; }//作者学校或者发表学校

        /// <summary>
        /// 文献的构造函数
        /// </summary>
        /// <param name="title">文献名称</param>
        /// <param name="authors">作者姓名列表</param>
        /// <param name="type">文献类型</param>
        public Literature_entity(string title, List<string> authors, LITERATURE_TYPE type)
        {
            this.title = title;
            this.authors = authors;
            this.type = type;
        }        

        /// <summary>
        /// 为文章添加作者,添加1个/多个
        /// </summary>
        public void addAuthor(string author)
        {
            if (authors == null)
            {
                authors = new List<string>();
            }
            this.authors.Add(author);
            this.authors = this.authors.Distinct().ToList();//Distinct去重
        }
        public void addAuthors(List<string> authors)
        {
            this.authors.Union(authors);//Union取并集,去重
        }
        public void addAuthors(string[] authors)
        {
            this.authors.Union(new List<string>(authors));//Union取并集,去重
        }

        /// <summary>
        /// 获取此文章的作者数
        /// </summary>
        /// <returns></returns>
        int getAuthorsCount()
        {
            return this.authors.Count();
        }

        /// <summary>
        /// 判断作者是否在该文章的作者列表里
        /// </summary>
        /// <param name="author">作者名</param>
        /// <returns></returns>
        bool isAuthorExist(string author)
        {
            foreach(var i in this.authors)
            {
                if (i.ToString().Equals(author))
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 简易封装模块
        /// </summary>
        /// <param name="title">文献名称</param>
        /// <param name="authors">作者姓名列表</param>
        /// <param name="type">文献类型</param>
        public void simple_PkgModule(out string title, out List<string> authors, out LITERATURE_TYPE type)
        {
            title = this.title;
            authors = this.authors;
            type = this.type;
        }

        /// <summary>
        /// 完整封装模块
        /// </summary>
        /// <param name="title"></param>
        /// <param name="authors"></param>
        /// <param name="type"></param>
        /// <param name="year"></param>
        /// <param name="month"></param>
        /// <param name="journal"></param>
        /// <param name="ee"></param>
        /// <param name="url"></param>
        /// <param name="series"></param>
        /// <param name="volume"></param>
        /// <param name="publisher"></param>
        /// <param name="isbn"></param>
        /// <param name="note"></param>
        /// <param name="pages"></param>
        /// <param name="number"></param>
        /// <param name="booktitle"></param>
        /// <param name="cdrom"></param>
        /// <param name="crossref"></param>
        /// <param name="school"></param>
        public void PkgModule(out string title, out List<string> authors, out LITERATURE_TYPE type,
            out List<string> year, out List<string> month, out List<string> journal, out List<string> ee, out List<string> url,
            out List<string> series, out List<string> volume, out List<string>publisher, out List<string> isbn, out List<string> note,
            out List<string>pages, out List<string>number, out List<string> booktitle, out List<string> cdrom, out List<string>crossref,
            out List<string> school)
        {
            title = this.title;
            authors = this.authors;
            type = this.type;
            year = this.year;
            month = this.month;
            journal = this.journal;
            ee = this.ee;
            url = this.url;
            series = this.series;
            volume = this.volume;
            publisher = this.publisher;
            isbn = this.isbn;
            note = this.note;
            pages = this.pages;
            number = this.number;
            booktitle = this.booktitle;
            cdrom = this.cdrom;
            crossref = this.crossref;
            school = this.school;
        }
    }
}
