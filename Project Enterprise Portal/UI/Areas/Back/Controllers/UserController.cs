using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace UI.Areas.Back.Controllers
{
    public class UserController : Controller
    {
        // GET: Back/User
        public ActionResult UserHome()
        {
            return View();
        }

        //查询用户对象
        [HttpPost]
        public ActionResult Find(int rows, int page, string Uname)
        {
            try
            {
                CMS_User userFilter = new CMS_User();
                if (!string.IsNullOrEmpty(Uname))
                    userFilter.uname = Uname;
                Pagination pagination = CMS_User_BLL.Find(userFilter, rows, page);
                return Json(pagination, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //修改
        [HttpPost]
        public ActionResult Edit(int uid)
        {
            try
            {
                CMS_User userFilter = new CMS_User();
                userFilter.uid = uid;
                Pagination pagination = CMS_User_BLL.Find(userFilter, 10, 1);
                List<CMS_User> list = pagination.rows as List<CMS_User>;
                if (list[0].admin == 0)
                    list[0].admin = 1;
                else if (list[0].admin == 1)
                    list[0].admin = 0;
                var count = CMS_User_BLL.Edit(list[0]);
                return Json(count, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}