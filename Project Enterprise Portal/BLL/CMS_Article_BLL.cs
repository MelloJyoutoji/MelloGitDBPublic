using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class CMS_Article_BLL
    {
        /// <summary>
        /// 查找文章前六条数据
        /// </summary>
        /// <param name="artFilter">条件</param>
        /// <returns>list</returns>
        public static dynamic Find(ArticleMain_View artFilter)
        {
            var list = CMS_Article_DAL.Find(artFilter);
            return list;
        }

        /// <summary>
        /// 查找文章
        /// </summary>
        /// <param name="artFilter">条件</param>
        /// <returns>list</returns>
        public static dynamic Find(CMS_Article artFilter)
        {
            try
            {
                var list = CMS_Article_DAL.Find(artFilter);
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
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
            try
            {
                Pagination pagination = CMS_Article_DAL.Find(artFilter, limit, page);
                return pagination;
            }
            catch (Exception error)
            {

                throw error;
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
                return CMS_Article_DAL.Edit(artFilter);
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
                return CMS_Article_DAL.Find();
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
                return CMS_Article_DAL.Add(art);
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
                var count = CMS_Article_DAL.Del(aid);
                return count;
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
            try
            {
                var list = CMS_Article_DAL.FindIsTop();
                return list;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
