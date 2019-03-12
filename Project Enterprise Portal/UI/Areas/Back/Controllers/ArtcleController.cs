using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace UI.Areas.Back.Controllers
{
    public class ArtcleController : Controller
    {
        // GET: Back/Artcle
        public ActionResult ArtcleHome()
        {
            return View();
        }

        //查找全部文章
        [HttpPost]
        public ActionResult FindArticle(int rows, int page, string title, string author, int cid = 0)
        {
            try
            {
                ArticleMain_View artFilter = new ArticleMain_View();
                artFilter.title = title;
                artFilter.author = author;
                artFilter.cid = cid;
                Pagination pagination = new Pagination();
                pagination = CMS_Article_BLL.Find(artFilter, rows, page);
                return Json(pagination, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        //添加页面创建
        public ActionResult AddPage()
        {
            var list = CMS_Category_BLL.Find();
            ViewBag.ddList = list;
            return View();
        }

        //添加
        [HttpPost]
        public ActionResult Add(CMS_Article art)
        {
            try
            {
                art.ptime = DateTime.Now;
                art.ctime = DateTime.Now;
                art.uid = 1;
                art.istop = false;
                art.state = 2;
                art.hits = 0;
                art.comments = 0;
                var count = CMS_Article_BLL.Add(art);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            catch (Exception er)
            {

                throw er;
            }
        }

        //修改页面创建
        public ActionResult EditPage()
        {
            var list = CMS_Category_BLL.Find();
            ViewBag.ddList = list;
            return View();
        }

        //查询文章
        [HttpPost]
        public ActionResult Find(int aid)
        {
            try
            {
                ArticleMain_View artFilter = new ArticleMain_View();
                artFilter.aid = aid;
                var list = CMS_Article_BLL.Find(artFilter);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //修改
        [HttpPost]
        public ActionResult Edit(CMS_Article art)
        {
            try
            {
                var count = CMS_Article_BLL.Edit(art);
                return Json(count);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //删除
        public ActionResult Del(int aid)
        {
            try
            {
                var count = CMS_Article_BLL.Del(aid);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //移动栏目
        [HttpPost]
        public ActionResult EditCid(int aid, int cid)
        {
            try
            {
                ArticleMain_View artFilter = new ArticleMain_View();
                artFilter.aid = aid;
                var list = CMS_Article_BLL.Find(artFilter);
                list[0].cid = cid;
                var count = CMS_Article_BLL.Edit(list[0]);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //是否置顶
        [HttpPost]
        public ActionResult EditIsTop(int aid)
        {
            try
            {
                CMS_Article artFilter = new CMS_Article();
                artFilter.aid = aid;
                var list = CMS_Article_BLL.Find(artFilter);
                if (list[0].istop == false)
                    list[0].istop = true;
                else if (list[0].istop == true)
                    list[0].istop = false;
                var count = CMS_Article_BLL.Edit(list[0]);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //查找菜单树
        [HttpPost]
        public ActionResult FindCate()
        {
            var list = CMS_Category_BLL.Find();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
    }
}