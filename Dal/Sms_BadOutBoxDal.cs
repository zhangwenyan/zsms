using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;
using eweb;
using Model.info;

namespace Dal
{
    public class Sms_BadOutBoxDal:BaseDal<Sms_BadOutBoxModel>
    {
        public PageResultInfo queryPage(PageInfo<Sms_BadOutBoxModel> pi, String mbnoName)
        {
            int total = 0;
            String sql = @"
                select badOutBox.*,mbno.name as mbnoName from badOutBox
                left join mbno on mbno.mbno=badOutBox.mbno
                where 1=1
            ";
            List<Object> paramValues = new List<object>();
            if (!String.IsNullOrEmpty(mbnoName))
            {
                sql += " and mbno.name like {" + paramValues.Count + "}";
                paramValues.Add("%" + mbnoName + "%");
            }
            sql += " order by SendTime desc";
            var list = dh.QueryPageBySql<Sms_BadOutBoxInfo>(sql, pi.page, pi.rows, out total, paramValues.ToArray());
            return new PageResultInfo()
            {
                total = total,
                rows = list
            };
        }
    }
}
