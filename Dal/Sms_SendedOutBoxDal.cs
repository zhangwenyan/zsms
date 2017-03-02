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
        public override PageResultInfo queryPage(PageInfo<Sms_SendedOutBoxModel> pi, params Restrain[] restrains)
        {
            int total = 0;
            String sql = @"
                select sendedOutBox.*,mbno.name as mbnoName from sendedOutBox
                left join mbno on mbno.mbno=sendedOutbox.mbno
            ";
            var list = dh.QueryPageBySql<Sms_SendedOutBoxInfo>(sql, pi.page, pi.rows, out total,restrains);
            return new PageResultInfo()
            {
                total = total,
                rows = list
            };
        }

    }
}
