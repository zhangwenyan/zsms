using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using easysql;
using System.Configuration;
using config;
namespace Dal
{
        /// <summary>
        /// 数据操作层基类，对于没有实现的方法，一定要抛出异常。
        /// </summary>
        /// <typeparam name="T"></typeparam>
        public abstract class BaseDal<T> where T : new()
        {
            protected BaseDBHelper dh = DBHelperFactory.Create(Config.databaseType, Config.connstr);
            protected log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
            protected string tbname;
          

            protected BaseDal(string tbname)
            {
                this.tbname = tbname;
            }

            protected List<T> PriQuery(T bean, params Restrain[] restrains)
            {
                return dh.Query<T>(tbname, bean, restrains);
            }
            protected List<T> PriQueryByPage(T bean, int page, int rows, out int total, params Restrain[] restrains)
            {
                return dh.QueryByPage<T>(tbname, bean, page, rows, out total, restrains);
            }

            protected void PriAdd(T model)
            {
                dh.Add(tbname, model);
            }
            /// <summary>
            /// 删除多条记录,如果只提供了id将只删除一条记录
            /// </summary>
            /// <param name="bean"></param>
            /// <returns></returns>
            protected int PriDel(T bean, params Restrain[] restrains)
            {
                return dh.Del(tbname, bean, restrains);
            }

            protected void PriModify(T model)
            {
                dh.Modify(tbname, model);
            }

            protected bool PriDelById(int id)
            {
                return dh.DelById(tbname, id);
            }

            protected T QueryById(int id)
            {
                return dh.QueryById<T>(tbname, id);
            }



           
            public List<T> IQuery(T bean, params Restrain[] restrains)
            {

                return dh.Query(tbname, bean, restrains);
            }
            public void IAdd(T model)
            {
                dh.Add(tbname, model);
            }
            public void IModify(T model)
            {
                dh.Modify(tbname, model);
            }
            public void IDelById(int id)
            {
                dh.DelById(tbname, id);
            }

            /// <summary>
            /// 批量删除多条记录,如果bean为null,则会删除全部数据
            /// </summary>
            /// <param name="bean"></param>
            public void Del(T bean)
            {
                dh.Del(tbname, bean);
            }


            public T QueryOne(T bean, params Restrain[] restrains)
            {
                var list = dh.Query(tbname, bean, restrains);
                if (list.Count > 0)
                {
                    return list[0];
                }
                return default(T);
            }

        }
    }
