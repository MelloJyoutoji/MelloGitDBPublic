using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class CMS_Category_BLL
    {
        /// <summary>
        /// 查找栏目
        /// </summary>
        /// <returns>list</returns>
        public static dynamic Find()
        {
            var list = CMS_Category_DAL.Find();
            return list;
        }

        /// <summary>
        /// 分页查询栏目
        /// </summary>
        /// <param name="cateFilter">对象</param>
        /// <param name="limit">一页共几条</param>
        /// <param name="page">目前第几页</param>
        /// <returns>pagination</returns>
        public static dynamic Find(CMS_Category cateFilter, int limit, int page)
        {
            try
            {
                Pagination pagination = CMS_Category_DAL.Find(cateFilter, limit, page);
                return pagination;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="cateFilter">对象</param>
        /// <returns>int</returns>
        public static dynamic Edit(CMS_Category cateFilter)
        {
            try
            {
                return CMS_Category_DAL.Edit(cateFilter);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
