using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace UI.Controllers
{
    public class LoginController : BaseController
    {
        // GET: Login
        public ActionResult Login()
        {
            return View();
        }

        // GET: Register
        public ActionResult Register()
        {
            return View();
        }

        //验证输入的用户名是否存在
        [HttpPost]
        public ActionResult FindUname(string uname)
        {
            CMS_User userFilter = new CMS_User();
            userFilter.uname = uname;
            int count = CMS_User_BLL.FindUname(userFilter);
            return Json(count);
        }

        //响应登录
        [HttpPost]
        public ActionResult ResponseLogin(string uname, string pwd)
        {
            try
            {
                CMS_User userFilter = new CMS_User();
                userFilter.uname = uname;
                userFilter.upwd = pwd;
                var list = CMS_User_BLL.Login(userFilter);
                if (list.Count > 0)
                {
                    CMS_User user = list[0] as Model.CMS_User;
                    Session["userID"] = user.uid;
                }
                return Json(list);
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        //取得用户
        public string GetSession()
        {
            if (Session["userID"] != null)
            {
                return Session["userID"].ToString();
            }
            else
            {
                return "0";
            }
        }

        //注册响应
        [HttpPost]
        public ActionResult ResponseRegister(string uname, string pwd, string mobile)
        {
            try
            {
                CMS_User user = new CMS_User();
                user.uname = uname;
                user.upwd = pwd;
                user.mobile = mobile;
                user.admin = 0;
                var count = CMS_User_BLL.Register(user);
                return Json(count);
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        //查找用户
        [HttpPost]
        public ActionResult FindUser(int id)
        {
            try
            {
                CMS_User userFilter = new CMS_User();
                userFilter.uid = id;
                var list = CMS_User_BLL.Login(userFilter);
                return Json(list);
            }
            catch (Exception error)
            {

                throw error;
            }
        }
    }
}