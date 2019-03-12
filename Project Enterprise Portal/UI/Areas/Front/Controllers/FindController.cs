using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;
using UI.Controllers;

namespace UI.Areas.Front.Controllers
{
    public class FindController : BaseController
    {
        // GET: Front/Find
        public ActionResult Search(string tlti, int limit = 10, int page = 1)
        {
            ArticleMain_View artFilter = new ArticleMain_View();
            artFilter.title = tlti; //取出到搜索内容

            //查询热词
            CMS_Keyword keyFilter = new CMS_Keyword();
            keyFilter.keyword = tlti;
            var list = CMS_Keyword_BLL.Find(keyFilter);
            if (list.Count > 0) //查到了便修改次数
            {
                list[0].stimes = Convert.ToInt32(list[0].stimes) + 1;
                list[0].ltimes = DateTime.Now;
                CMS_Keyword_BLL.Edit(list[0]);
            }
            else
            { //没查到便添加
                CMS_Keyword key = new CMS_Keyword();
                key.keyword = tlti;
                key.stimes = 1;
                key.ltimes = DateTime.Now;
                key.show = 1;
                CMS_Keyword_BLL.Add(key);
            }

            //赋值到页面
            Pagination pagination = CMS_Article_BLL.Find(artFilter, limit, page);
            ViewBag.pageList = pagination.rows;
            ViewBag.pageSum = pagination.total;

            return View();
        }
    }
}