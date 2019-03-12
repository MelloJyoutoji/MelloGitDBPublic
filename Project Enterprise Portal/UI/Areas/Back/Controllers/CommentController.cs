using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace UI.Areas.Back.Controllers
{
    public class CommentController : Controller
    {
        // GET: Back/Comment
        public ActionResult CommentHome()
        {
            return View();
        }

        public ActionResult Find(int rows, int page, int uid = 0, int aid = 0)
        {
            try
            {
                CommentMain_View comFilter = new CommentMain_View();
                if (uid > 0)
                    comFilter.uid = uid;
                if (aid > 0)
                    comFilter.aid = aid;
                Pagination pagination = CMS_Comment_BLL.Find(comFilter, rows, page);
                return Json(pagination, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}