using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using BLL;

namespace UI.Controllers
{
    public class BaseController : Controller
    {
        public BaseController()
        {
            List<CMS_Keyword> list = new List<CMS_Keyword>();
            list = CMS_Keyword_BLL.Find();
            ViewBag.keyList = list;
        }
    }
}