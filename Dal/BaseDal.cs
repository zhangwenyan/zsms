using System;
using System.Collections.Generic;
using easysql;
using config;
using eweb;

namespace Dal
{
    /// <summary>
    /// 数据操作层基类，对于没有实现的方法，一定要抛出异常。
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class BaseDal<T> where T : new()
    {
        protected BaseDBHelper dh = DBHelperFactory.Create(Config.dbType, Config.connstr);
        protected log4net.ILog Log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        protected string tbName;

        protected BaseDal()
        {
            var t = typeof(T);
            var atts = t.GetCustomAttributes(typeof(Table), true);
            if (atts.Length > 0)
            {
                Table table = (Table)atts[0];
                this.tbName = table.tbName;
            } 

        }

        public virtual  List<T> queryPage(T bean,int page, int rows, out int total,params Restrain[] restrains)
        {
            return dh.QueryByPage<T>(tbName, bean, page, rows, out total, restrains);
        }

        public virtual PageResultInfo queryPage(PageInfo<T> pi,params Restrain[] restrains)
        {
            int total = 0;
            var list = queryPage(pi.query, pi.page, pi.rows, out total, restrains);
            return new PageResultInfo()
            {
                total = total,
                rows = list
            };
        }
      


        public virtual void add(T model)
        {
            dh.Add(tbName, model);
        }

        public virtual void modify(T model)
        {
            dh.Modify(tbName, model);
        }

        public virtual void del(string ids)
        {
            using(BaseDatabase db = dh.CreateDatabaseAndOpen())
            {
                var idArr = ids.Split(',');
                foreach(var id in idArr)
                {
                    db.DelById(tbName, int.Parse(id));
                }
            }
        }


        /// <summary>
        ///  添加唯一字段的数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="msg">当添加后数量大约1时的提示信息</param>
        /// <param name="restrains"></param>
        public void addOnly(T model, String msg, params Restrain[] restrains)
        {
            BaseDatabase db = dh.CreateDatabaseAndOpen();
            try
            {
                db.BeginTransaction();
                db.Add(tbName, model);
                var count = db.Total<object>(tbName, null, restrains);
                if (count > 1)
                {
                    throw new MsgException(msg);
                }
                db.CommitTranscation();
            }
            catch (Exception ex)
            {
                db.RollbackTranscation();
                throw ex;
            }
            finally
            {
                db.Dispose();
            }
        }



        /// <summary>
        ///  修改唯一字段的数据
        /// </summary>
        /// <param name="model"></param>
        /// <param name="msg">当修改后数量大约1时的提示信息</param>
        /// <param name="restrains"></param>
        public void modifyOnly(T model, String msg, params Restrain[] restrains)
        {
            BaseDatabase db = dh.CreateDatabaseAndOpen();
            try
            {
                db.BeginTransaction();
                db.Modify(tbName, model);
                var count = db.Total<object>(tbName, null, restrains);
                if (count > 1)
                {
                    throw new MsgException(msg);
                }
                db.CommitTranscation();
            }
            catch (Exception ex)
            {
                db.RollbackTranscation();
                throw ex;
            }
            finally
            {
                db.Dispose();
            }
        }
    }
}
