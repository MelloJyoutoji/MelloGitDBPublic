using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace UI.Areas.Back.Controllers
{
    public class HomeController : Controller
    {
        // GET: Back/Home
        public ActionResult Index()
        {
            return View();
        }

        //Home page
        public ActionResult HomePage()
        {
            return View();
        }

        //json查找前五条评论
        [HttpPost]
        public ActionResult FindComment()
        {
            try
            {
                var list = CMS_Comment_BLL.Find();
                return Json(list);
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        //json查找前五条用户
        [HttpPost]
        public ActionResult FindUser()
        {
            try
            {
                var list = CMS_User_BLL.Find();
                return Json(list);
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        //json查找前五篇文章
        [HttpPost]
        public ActionResult FindArticle()
        {
            try
            {
                var list = CMS_Article_BLL.Find();
                return Json(list);
            }
            catch (Exception error)
            {

                throw error;
            }
        }
    }
}