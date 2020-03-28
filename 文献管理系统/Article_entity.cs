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
    class Article_entity
    {
        public string title { set; get; }//文章名称(重要)
        public List<string> authors { set; get; }//作者姓名列表(重要)
        public string year { set; get; }//发表年份
        public string journal { set; get; }//期刊网站
        public string ee { set; get; }//文章网页

        /// <summary>
        /// 文章的构造函数
        /// </summary>
        /// <param name="title">文章名称</param>
        /// <param name="authors">作者姓名列表</param>
        /// <param name="year">发表年份</param>
        /// <param name="journal">期刊网站</param>
        /// <param name="ee">文章网页</param>
        public Article_entity(string title, List<string> authors, string year = null, string journal = null, string ee = null)
        {
            this.title = title;
            this.authors = authors;
            this.year = year;
            this.journal = journal;
            this.ee = ee;
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
        /// 封装模块
        /// </summary>
        /// <param name="title">文章名称</param>
        /// <param name="authors">作者姓名列表</param>
        /// <param name="year">发表年份</param>
        /// <param name="journal">期刊网站</param>
        /// <param name="ee">文章网页</param>
        public void pkgModule(out string title, out List<string> authors, out string year, out string journal, out string ee)
        {
            title = this.title;
            authors = this.authors;
            year = this.year;
            journal = this.journal;
            ee = this.ee;
        }
    }
}
