using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DAL;

namespace BLL
{
    public class CMS_User_BLL
    {
        /// <summary>
        /// 查询是否存在该用户名
        /// </summary>
        /// <param name="userFilter">实体类对象</param>
        /// <returns>int;0为不存在,1为存在</returns>
        public static int FindUname(CMS_User userFilter)
        {
            return CMS_User_DAL.FindUname(userFilter);
        }

        /// <summary>
        /// 登录方法+根据用户ID查询用户信息
        /// </summary>
        /// <param name="userFilter">账号密码</param>
        /// <returns>list</returns>
        public static dynamic Login(CMS_User userFilter)
        {
            try
            {
                var list = CMS_User_DAL.Login(userFilter);
                return list;
            }
            catch (Exception error)
            {

                throw error;
            }
        }

        /// <summary>
        /// 注册方法
        /// </summary>
        /// <param name="user">用户</param>
        /// <returns>int</returns>
        public static dynamic Register(CMS_User user)
        {
            try
            {
                var count = CMS_User_DAL.Register(user);
                return count;
            }
            catch (Exception error)
            {

                throw error;
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
                return CMS_User_DAL.Find();
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
                Pagination pagination = CMS_User_DAL.Find(userFilter, limit, page);
                return pagination;
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
        public static dynamic Edit(CMS_User user)
        {
            try
            {
                var count = CMS_User_DAL.Edit(user);
                return count;
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
                    return CMS_User_DAL.Find(userFilter);
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
                return CMS_User_DAL.FindComSum(userFilter);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
