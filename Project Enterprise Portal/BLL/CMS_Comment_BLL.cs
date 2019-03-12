using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class CMS_Comment_BLL
    {
        /// <summary>
        /// 查找评论数
        /// </summary>
        /// <param name="comFilter">对象</param>
        /// <returns>int</returns>
        public static dynamic FindCommentSum(CMS_Comment comFilter)
        {
            try
            {
                var count = CMS_Comment_DAL.FindCommentSum(comFilter);
                return count;
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        /// <summary>
        /// 查询文章评论(分页)
        /// </summary>
        /// <param name="comFilter">对象</param>
        /// <returns>pagination</returns>
        public static dynamic Find(CommentMain_View comFilter)
        {
            try
            {
                var list = CMS_Comment_DAL.Find(comFilter);
                return list;
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        /// <summary>
        /// 添加评论
        /// </summary>
        /// <param name="com">对象</param>
        /// <returns>int</returns>
        public static dynamic Add(CMS_Comment com)
        {
            try
            {
                return CMS_Comment_DAL.Add(com);
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        /// <summary>
        /// 查找前五条数据
        /// </summary>
        /// <returns>list</returns>
        public static dynamic Find()
        {
            try
            {
                return CMS_Comment_DAL.Find();
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        /// <summary>
        /// 分页查询评论表
        /// </summary>
        /// <param name="comFilter">对象</param>
        /// <param name="limit">一页的数量</param>
        /// <param name="page">当前第几页</param>
        /// <returns>Pagination</returns>
        public static dynamic Find(CommentMain_View comFilter, int limit, int page)
        {
            try
            {
                Pagination pagination = CMS_Comment_DAL.Find(comFilter, limit, page);
                return pagination;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
