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
    public class HomeController : BaseController
    {
        // GET: Front/Home
        public ActionResult Index()
        {
            ArticleMain_View artFilter = new ArticleMain_View();

            //置顶项
            var listIsTop = CMS_Article_BLL.FindIsTop();
            ViewBag.listIsTop = listIsTop;
            //网站公告
            artFilter.cid = 1;
            var listNotice = CMS_Article_BLL.Find(artFilter);
            ViewBag.NoticeList = listNotice;
            //产品定制
            artFilter.cid = 2;
            var listProduct = CMS_Article_BLL.Find(artFilter);
            ViewBag.ProductList = listProduct;
            //定制服务
            artFilter.cid = 3;
            var listService = CMS_Article_BLL.Find(artFilter);
            ViewBag.ServiceList = listService;
            //成功案例
            artFilter.cid = 4;
            var listCase = CMS_Article_BLL.Find(artFilter);
            ViewBag.CaseList = listCase;

            return View();
        }

        //文章内容
        public ActionResult LaceMian(int id = 0)
        {
            try
            {
                if (id == 0)
                {
                    Response.Redirect("/Front/Home/Index");
                }
                else
                {
                    //查找文章
                    ArticleMain_View artFilter = new ArticleMain_View();
                    artFilter.aid = id;
                    var listArticle = CMS_Article_BLL.Find(artFilter);
                    ViewBag.articleList = listArticle;
                    //查账该文章的评论数
                    CMS_Comment comFilter = new CMS_Comment();
                    comFilter.aid = id;
                    var countCommentSum = CMS_Comment_BLL.FindCommentSum(comFilter);
                    if (countCommentSum == 0)
                        ViewBag.commentSumCount = 0;
                    else
                        ViewBag.commentSumCount = countCommentSum;
                    //查找该文章的评论
                    CommentMain_View comView = new CommentMain_View();
                    comView.aid = id;
                    var listComment = CMS_Comment_BLL.Find(comView);
                    ViewBag.commentList = listComment;

                    if (Session["userID"] != null)
                    {
                        ViewBag.userID = Session["userID"].ToString();
                    }
                    else
                    {
                        ViewBag.userID = "0";
                    }
                }

            }
            catch (Exception error)
            {

                throw error;
            }

            return View();
        }

        //按栏目查找
        public ActionResult AritcleList(int id = 0, int limit = 10, int page = 1)
        {
            if (id == 0)
            {
                Response.Redirect("/Front/Home/Index");
            }
            ArticleMain_View artFilter = new ArticleMain_View();
            artFilter.cid = id;
            Pagination pagination = CMS_Article_BLL.Find(artFilter, limit, page);
            ViewBag.pageList = pagination.rows;
            ViewBag.pageSum = pagination.total;

            return View();
        }

        //按栏目查找并分页
        [HttpPost]
        public ActionResult FindPage(int id = 0, int page = 1)
        {
            if (id == 0)
            {
                Response.Redirect("/Front/Home/Index");
            }
            ArticleMain_View artFilter = new ArticleMain_View();
            artFilter.cid = id;
            Pagination pagination = CMS_Article_BLL.Find(artFilter, 10, page);
            ViewBag.pageList = pagination.rows;
            ViewBag.pageSum = pagination.total;

            return Json(pagination.rows);
        }

        //修改文章评论数
        //[HttpPost]
        //public ActionResult EditArticle(int aid)
        //{
        //    try
        //    {
        //        ArticleMain_View artFilter = new ArticleMain_View();
        //        artFilter.aid = aid;
        //        List<ArticleMain_View> list = CMS_Article_BLL.Find(artFilter); //查询该篇文章所有内容
        //        list[0].comments = list[0].comments + 1; //评论数+1
        //        var count = CMS_Article_BLL.Edit(list[0]); //修改
        //        return count;
        //    }
        //    catch (Exception error)
        //    {

        //        throw error;
        //    }
        //}

        //添加评论表

        [HttpPost]
        public ActionResult AddComment(string cmhtml, int uid, int aid)
        {
            try
            {
                if (string.IsNullOrEmpty(cmhtml) || aid == 0 || uid == 0)
                {
                    throw new System.Exception("评论内容没有等其他原因");
                }
                CMS_Comment com = new CMS_Comment();
                com.aid = aid;
                com.uid = uid;
                com.cmtime = DateTime.Now;
                com.cmhtml = cmhtml;
                var count = CMS_Comment_BLL.Add(com);
                return Json(count);
            }
            catch (Exception error)
            {

                throw error;
            }
        }
    }
}