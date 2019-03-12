using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class CMS_Comment_DAL
    {
        /// <summary>
        /// 查找评论数
        /// </summary>
        /// <param name="comFilter">对象</param>
        /// <returns>int</returns>
        public static dynamic FindCommentSum(CMS_Comment comFilter)
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                try
                {
                    var list = from data in cms.CMS_Comment
                               select data;
                    if (comFilter.aid == 0)
                        throw new System.Exception("需要知道是哪一篇文章的评论");
                    else
                        list = list.Where(data => data.aid == comFilter.aid).Select(data => data);
                    var count = list.Count();
                    return count;
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
        }

        /// <summary>
        /// 查询文章评论
        /// </summary>
        /// <param name="comFilter">对象</param>
        /// <returns>pagination</returns>
        public static dynamic Find(CommentMain_View comFilter)
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                try
                {
                    var list = from data in cms.CommentMain_View
                               select data;
                    if (comFilter.aid == 0)
                        throw new System.Exception("需要知道是哪一篇文章的评论");
                    else
                        list = list.Where(data => data.aid == comFilter.aid).Select(data => data);
                    return list.ToList();
                }
                catch (Exception error)
                {

                    throw error;
                }
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
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    cms.CMS_Comment.Add(com);
                    var count = cms.SaveChanges();
                    return count;
                }
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
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    var list = from data in cms.CMS_Comment
                               select data;
                    list = list.OrderByDescending(data => data.cmtime);
                    list = list.Take(5);
                    return list.ToList();
                }
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
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    Pagination pagination = new Pagination();
                    var list = from data in cms.CommentMain_View
                               select data;
                    if (comFilter.aid > 0)
                        list = list.Where(data => data.aid == comFilter.aid).Select(data => data);
                    if (comFilter.uid > 0)
                        list = list.Where(data => data.uid == comFilter.uid).Select(data => data);
                    pagination.total = list.Count();
                    list = list.OrderByDescending(data => data.cmid);
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
    }
}
