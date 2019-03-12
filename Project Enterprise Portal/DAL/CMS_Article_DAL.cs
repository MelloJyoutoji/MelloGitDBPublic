using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class CMS_Article_DAL
    {
        /// <summary>
        /// 查找文章前六条数据
        /// </summary>
        /// <param name="artFilter">条件</param>
        /// <returns>list</returns>
        public static dynamic Find(ArticleMain_View artFilter)
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                try
                {
                    var list = from data in cms.ArticleMain_View
                               select data;
                    if (artFilter.cid > 0)
                        list = list.Where(data => data.cid == artFilter.cid).Select(data => data);
                    if (artFilter.aid > 0)
                        list = list.Where(data => data.aid == artFilter.aid).Select(data => data);
                    list = list.OrderByDescending(data => data.ptime);
                    list = list.Take(6);
                    return list.ToList();
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
        }

        /// <summary>
        /// 查找文章
        /// </summary>
        /// <param name="artFilter">条件</param>
        /// <returns>list</returns>
        public static dynamic Find(CMS_Article artFilter)
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                try
                {
                    var list = from data in cms.CMS_Article
                               select data;
                    if (artFilter.cid > 0)
                        list = list.Where(data => data.cid == artFilter.cid).Select(data => data);
                    if (artFilter.aid > 0)
                        list = list.Where(data => data.aid == artFilter.aid).Select(data => data);
                    return list.ToList();
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
        }

        /// <summary>
        /// 查找全部文章并分页
        /// </summary>
        /// <param name="artFilter">Model对象</param>
        /// <param name="limit">一页显示的内容数量</param>
        /// <param name="page">当前是多少页</param>
        /// <returns>pagination</returns>
        public static dynamic Find(ArticleMain_View artFilter, int limit, int page)
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                try
                {
                    Pagination pagination = new Pagination();
                    var list = from data in cms.ArticleMain_View
                               select data;
                    if (artFilter.cid > 0)
                        list = list.Where(data => data.cid == artFilter.cid).Select(data => data);
                    if (!string.IsNullOrEmpty(artFilter.title))
                        list = list.Where(data => data.title.Contains(artFilter.title)).Select(data => data);
                    if (!string.IsNullOrEmpty(artFilter.author))
                        list = list.Where(data => data.author.Contains(artFilter.author)).Select(data => data);
                    pagination.total = list.Count();
                    list = list.OrderByDescending(data => data.aid);
                    list = list.Skip(limit * (page - 1)).Take(limit);
                    pagination.rows = list.ToList();
                    return pagination;
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
        }

        /// <summary>
        /// 修改
        /// </summary>
        /// <param name="artFilter">条件对象</param>
        /// <returns>int</returns>
        public static dynamic Edit(CMS_Article artFilter)
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    cms.Entry(artFilter).State = System.Data.Entity.EntityState.Modified;
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
        /// 获取前五条数据
        /// </summary>
        /// <returns>list</returns>
        public static dynamic Find()
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    var list = from data in cms.CMS_Article
                               select data;
                    list = list.OrderByDescending(data => data.aid);
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
        /// 添加
        /// </summary>
        /// <param name="art">对象</param>
        /// <returns>int</returns>
        public static dynamic Add(CMS_Article art)
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    cms.CMS_Article.Add(art);
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
        /// 删除
        /// </summary>
        /// <param name="aid">编号</param>
        /// <returns>int</returns>
        public static dynamic Del(int aid)
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    cms.CMS_Article.Remove(cms.CMS_Article.Find(aid));
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
        /// 查询最近被置顶的一篇文章
        /// </summary>
        /// <returns>list</returns>
        public static dynamic FindIsTop()
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                try
                {
                    var list = from data in cms.ArticleMain_View
                               select data;
                    list = list.Where(data => data.istop == true).Select(data => data);
                    list = list.OrderByDescending(data => data.ptime);
                    list = list.Take(1);
                    return list.ToList();
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
        }
    }
}
