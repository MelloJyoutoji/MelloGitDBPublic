using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class CMS_Keyword_BLL
    {
        /// <summary>
        /// 得到关键字
        /// </summary>
        /// <returns>list</returns>
        public static dynamic Find()
        {
            try
            {
                var list = CMS_Keyword_DAL.Find();
                return list;
            }
            catch (Exception error)
            {

                throw error;
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
                Pagination pagination = CMS_Keyword_DAL.Find(keyFilter, limit, page);
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
        /// <param name="key">对象</param>
        /// <returns>int</returns>
        public static dynamic Edit(CMS_Keyword key)
        {
            try
            {
                return CMS_Keyword_DAL.Edit(key);
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
                return CMS_Keyword_DAL.Find(keyFilter);
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
                return CMS_Keyword_DAL.Add(key);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
