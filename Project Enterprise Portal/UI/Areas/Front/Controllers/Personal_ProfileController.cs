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
    public class Personal_ProfileController : BaseController
    {
        // GET: Personal_Profile
        public ActionResult Personal_Profile(int uid = 0)
        {
            try
            {
                if (uid == 0)
                {
                    Response.Redirect("/Login/Login");
                }
                CMS_User userFilter = new CMS_User();
                userFilter.uid = uid;
                List<CMS_User> list = CMS_User_BLL.Login(userFilter); //查询用户
                ViewBag.userList = list;
                var countInCommentSum = CMS_User_BLL.FindComSum(userFilter); //查询用户评论数
                ViewBag.countInCommentSum = countInCommentSum;

                return View();
            }
            catch (Exception error)
            {
                throw error;
            }
        }

        //查找用户
        public ActionResult Find(int uid)
        {
            try
            {
                CMS_User userFilter = new CMS_User();
                userFilter.uid = uid;
                var list = CMS_User_BLL.Login(userFilter);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //查找用户
        [HttpPost]
        public ActionResult FindinPwd(string oldpwd, int uid)
        {
            try
            {
                CMS_User userFilter = new CMS_User();
                userFilter.upwd = oldpwd;
                userFilter.uid = uid;
                var list = CMS_User_BLL.Find(userFilter);
                return Json(list, JsonRequestBehavior.AllowGet);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        //上传头像
        public ActionResult Upload()
        {
            try
            {
                HttpFileCollectionBase files = Request.Files;
                HttpPostedFileBase file = files[0];
                //获取文件名后缀
                string extName = VirtualPathUtility.GetExtension(file.FileName).ToLower();
                //获取保存目录的物理路径
                if (System.IO.Directory.Exists(Server.MapPath("/images/face/")) == false)//如果不存在就创建images文件夹
                {
                    System.IO.Directory.CreateDirectory(Server.MapPath("/images/face/"));
                }
                string path = Server.MapPath("/images/face/"); //path为某个文件夹的绝对路径，不要直接保存到数据库
                //    string path = "F:\\TgeoSmart\\Image\\";
                //生成新文件的名称，guid保证某一时刻内图片名唯一（文件不会被覆盖）
                string fileNewName = Guid.NewGuid().ToString();
                string ImageUrl = path + fileNewName + extName;
                //SaveAs将文件保存到指定文件夹中
                file.SaveAs(ImageUrl);
                //此路径为相对路径，只有把相对路径保存到数据库中图片才能正确显示（不加~为相对路径）
                string url = "\\/images/face/\\" + fileNewName + extName;
                if (!string.IsNullOrEmpty(url)) //修改数据库
                {
                    CMS_User userFilter = new CMS_User();
                    userFilter.uid = Convert.ToInt32(Session["userID"]);
                    var list = CMS_User_BLL.Find(userFilter);
                    list[0].face = fileNewName + extName;
                    CMS_User_BLL.Edit(list[0]);
                }
                return Json(new
                {
                    Result = true,
                    Data = url
                });
            }
            catch (Exception exception)
            {
                return Json(new
                {
                    Result = false,
                    exception.Message
                });
            }
        }
    }
}