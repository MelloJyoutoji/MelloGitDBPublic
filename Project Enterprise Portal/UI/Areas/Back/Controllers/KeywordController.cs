using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace UI.Areas.Back.Controllers
{
    public class KeywordController : Controller
    {
        // GET: Back/Keyword
        public ActionResult KeywordHome()
        {
            return View();
        }

        //查询
        public ActionResult Find(int rows, int page)
        {
            try
            {
                CMS_Keyword keyFilter = new CMS_Keyword();
                Pagination pagination = CMS_Keyword_BLL.Find(keyFilter, rows, page);
                return Json(pagination, JsonRequestBehavior.AllowGet);
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        //修改
        [HttpPost]
        public ActionResult Edit(int kid)
        {
            try
            {
                CMS_Keyword keyFilter = new CMS_Keyword();
                keyFilter.kid = kid;
                Pagination pagination = CMS_Keyword_BLL.Find(keyFilter, 10, 1);
                List<CMS_Keyword> list = pagination.rows as List<CMS_Keyword>;
                list[0].show = 0;
                var count = CMS_Keyword_BLL.Edit(list[0]);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}