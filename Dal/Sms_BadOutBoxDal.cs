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
    public class Sms_BadOutBoxDal:BaseDal<Sms_BadOutBoxModel>
    {
        public override PageResultInfo queryPage(PageInfo<Sms_BadOutBoxModel> pi, params Restrain[] restrains)
        {
            int total = 0;
            String sql = @"
                select badOutBox.*,mbno.name as mbnoName from badOutBox
                left join mbno on mbno.mbno=badOutBox.mbno
            ";
            var list = dh.QueryPageBySql<Sms_BadOutBoxInfo>(sql, pi.page, pi.rows, out total, restrains);
            return new PageResultInfo()
            {
                total = total,
                rows = list
            };
        }
    }
}
