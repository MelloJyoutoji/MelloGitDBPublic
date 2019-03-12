using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class CMS_User_DAL
    {
        /// <summary>
        /// 查询是否存在该用户名
        /// </summary>
        /// <param name="userFilter">实体类对象</param>
        /// <returns>int;0为不存在,1为存在</returns>
        public static int FindUname(CMS_User userFilter)
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                var list = from data in cms.CMS_User
                           select data;
                foreach (var item in list.ToList())
                {
                    if (item.uname == userFilter.uname)
                        return 1;
                }
                return 0;
            }
        }

        /// <summary>
        /// 登录方法+根据用户ID查询用户信息
        /// </summary>
        /// <param name="userFilter">账号密码</param>
        /// <returns>list</returns>
        public static dynamic Login(CMS_User userFilter)
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                try
                {
                    var list = from data in cms.CMS_User
                               select data;
                    if (!String.IsNullOrEmpty(userFilter.uname))
                        list = list.Where(data => data.uname.Contains(userFilter.uname)).Select(data => data);
                    if (!String.IsNullOrEmpty(userFilter.upwd))
                        list = list.Where(data => data.upwd == (userFilter.upwd)).Select(data => data);
                    if (userFilter.uid > 0)
                        list = list.Where(data => data.uid == userFilter.uid).Select(data => data);

                    return list.ToList();
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
        }

        /// <summary>
        /// 注册方法
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>int</returns>
        public static dynamic Register(CMS_User user)
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                try
                {
                    cms.CMS_User.Add(user);
                    var count = cms.SaveChanges();
                    return count;
                }
                catch (Exception error)
                {

                    throw error;
                }
            }
        }

        /// <summary>
        /// 查找最新五条数据
        /// </summary>
        /// <returns>list</returns>
        public static dynamic Find()
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    var list = from data in cms.CMS_User
                               select data;
                    list = list.OrderByDescending(data => data.uid);
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
        /// 用户对象分页条件查询
        /// </summary>
        /// <param name="userFilter">用户对象</param>
        /// <param name="limit">一页显示的数量</param>
        /// <param name="page">当前第几页</param>
        /// <returns>Pagination</returns>
        public static dynamic Find(CMS_User userFilter, int limit, int page)
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    Pagination pagination = new Pagination();
                    var list = from data in cms.CMS_User
                               select data;
                    if (!string.IsNullOrEmpty(userFilter.uname))
                        list = list.Where(data => data.uname.Contains(userFilter.uname)).Select(data => data);
                    if (userFilter.uid > 0)
                        list = list.Where(data => data.uid == userFilter.uid).Select(data => data);
                    pagination.total = list.Count();
                    list = list.OrderByDescending(data => data.uid);
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
        /// 修改用户资料
        /// </summary>
        /// <param name="user">对象</param>
        /// <returns>int</returns>
        public static dynamic Edit(CMS_User userFilter)
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    cms.Entry(userFilter).State = System.Data.Entity.EntityState.Modified;
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
        /// 查找用户
        /// </summary>
        /// <param name="userFilter">用户对象</param>
        /// <returns>list</returns>
        public static dynamic Find(CMS_User userFilter)
        {
            using (CMSDatabase_Model cms = new CMSDatabase_Model())
            {
                try
                {
                    var list = from data in cms.CMS_User
                               select data;
                    if (userFilter.uid > 0)
                        list = list.Where(data => data.uid == userFilter.uid).Select(data => data);
                    if (!string.IsNullOrEmpty(userFilter.upwd))
                        list = list.Where(data => data.upwd == (userFilter.upwd)).Select(data => data);
                    return list.ToList();
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }
        }

        /// <summary>
        /// 查询一个用户的回复次数
        /// </summary>
        /// <param name="userFilter">对象</param>
        /// <returns>int</returns>
        public static dynamic FindComSum(CMS_User userFilter)
        {
            try
            {
                using (CMSDatabase_Model cms = new CMSDatabase_Model())
                {
                    var list = from data in cms.CMS_Comment
                               select data;
                    if (userFilter.uid > 0)
                        list = list.Where(data => data.uid == userFilter.uid).Select(data => data);
                    var count = list.Count();
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
