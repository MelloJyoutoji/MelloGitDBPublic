using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class CMS_Category_DAL
    {
        /// <summary>
        /// 查找栏目
        /// </summary>
        /// <returns>list</returns>
        public static dynamic Find()
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                try
                {
                    var list = from data in cms.CMS_Category
                               //where data.nav == true
                               select data;
                    return list.ToList();
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
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
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    Pagination pagination = new Pagination();
                    var list = from data in cms.CMS_Category
                               select data;
                    if (cateFilter.cid > 0)
                        list = list.Where(data => data.cid == cateFilter.cid).Select(data => data);
                    pagination.total = list.Count();
                    list = list.OrderByDescending(data => data.cid);
                    list = list.Skip(limit * (page - 1)).Take(limit);
                    pagination.rows = list.ToList();
                    return pagination;
                }
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
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    cms.Entry(cateFilter).State = System.Data.Entity.EntityState.Modified;
                    var count = cms.SaveChanges();
                    return count;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
