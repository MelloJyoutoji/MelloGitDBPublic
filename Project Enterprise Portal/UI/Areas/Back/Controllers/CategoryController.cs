using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace UI.Areas.Back.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Back/Category
        public ActionResult CategoryHome()
        {
            return View();
        }

        //查询
        public ActionResult Find(int rows, int page)
        {
            try
            {
                CMS_Category cateFilter = new CMS_Category();
                Pagination pagination = CMS_Category_BLL.Find(cateFilter, rows, page);
                return Json(pagination, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //查询
        [HttpPost]
        public ActionResult FindByID(int cid)
        {
            try
            {
                CMS_Category cateFilter = new CMS_Category();
                cateFilter.cid = cid;
                Pagination pagination = CMS_Category_BLL.Find(cateFilter, 10, 1);
                List<CMS_Category> list = pagination.rows as List<CMS_Category>;
                return Json(list[0], JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //修改页面
        public ActionResult EditPage()
        {
            return View();
        }

        //修改
        [HttpPost]
        public ActionResult Edit(CMS_Category cate)
        {
            try
            {
                var count = CMS_Category_BLL.Edit(cate);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}