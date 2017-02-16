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

        public virtual  List<T> queryPage(T bean,int page, int rows, out int total,params Restrain[] restrains)
        {
            return dh.QueryByPage<T>(tbname, bean, page, rows, out total, restrains);
        }

        public virtual void add(T model)
        {
            dh.Add(tbname, model);
        }

        public virtual void modify(T model)
        {
            dh.Modify(tbname, model);
        }

        public virtual void del(string ids)
        {
            using(BaseDatabase db = dh.CreateDatabaseAndOpen())
            {
                var idArr = ids.Split(',');
                foreach(var id in idArr)
                {
                    db.DelById(tbname, int.Parse(id));
                }
            }
        }
    }
}
