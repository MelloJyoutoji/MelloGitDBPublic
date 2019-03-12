using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class CMS_Keyword_DAL
    {
        /// <summary>
        /// 得到关键字
        /// </summary>
        /// <returns>list</returns>
        public static dynamic Find()
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                try
                {
                    var list = from data in cms.CMS_Keyword
                               select data;
                    list = list.OrderByDescending(data => data.stimes);//.OrderByDescending(data => data.ltimes);
                    list = list.Where(data => data.show == 1).Select(data => data);
                    list = list.Take(5);

                    return list.ToList();
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
        }

        /// <summary>
        /// 分页查询热搜
        /// </summary>
        /// <param name="keyFilter">对象</param>
        /// <param name="limit">一页N条数据</param>
        /// <param name="page">当前第N页</param>
        /// <returns></returns>
        public static dynamic Find(CMS_Keyword keyFilter, int limit, int page)
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    Pagination pagination = new Pagination();
                    var list = from data in cms.CMS_Keyword
                               select data;
                    if (keyFilter.kid > 0)
                        list = list.Where(data => data.kid == keyFilter.kid).Select(data => data);
                    pagination.total = list.Count();
                    list = list.OrderByDescending(data => data.kid);
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
        /// <param name="key">对象</param>
        /// <returns>int</returns>
        public static dynamic Edit(CMS_Keyword keyFilter)
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    cms.Entry(keyFilter).State = System.Data.Entity.EntityState.Modified;
                    var count = cms.SaveChanges();
                    return count;
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 查找关键字,有条件
        /// </summary>
        /// <param name="keyFilter">对象</param>
        /// <returns>list</returns>
        public static dynamic Find(CMS_Keyword keyFilter)
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    var list = from data in cms.CMS_Keyword
                               select data;
                    if (!string.IsNullOrEmpty(keyFilter.keyword))
                        list = list.Where(data => data.keyword.Contains(keyFilter.keyword)).Select(data => data);
                    return list.ToList();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        /// <summary>
        /// 添加
        /// </summary>
        /// <param name="key">对象</param>
        /// <returns>int</returns>
        public static dynamic Add(CMS_Keyword key)
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    cms.CMS_Keyword.Add(key);
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
