using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;
using eweb.info;
using Model.info;

namespace Dal
{
    public class Sms_SendedOutBoxDal:BaseDal<Sms_SendedOutBoxModel>
    {
        public PageResultInfo queryPage(PageInfo<Sms_SendedOutBoxModel> pi, String mbnoName)
        {
            int total = 0;
            String sql = @"
                select sendedOutBox.*,mbno.name as mbnoName from sendedOutBox
                left join mbno on mbno.mbno=sendedOutbox.mbno
                where 1=1
            ";
            List<Object> paramValues = new List<object>();
            if (!String.IsNullOrEmpty(mbnoName))
            {
                sql += " and mbno.name like {" + paramValues.Count + "}";
                paramValues.Add("%"+mbnoName + "%");
            }
            sql += " order by SendTime desc";
            var list = dh.QueryPageBySql<Sms_SendedOutBoxInfo>(sql, pi.page, pi.rows, out total,paramValues.ToArray());
            return new PageResultInfo()
            {
                total = total,
                rows = list
            };
        }

    }
}
