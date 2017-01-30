using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;

namespace Dal
{
    public class Sms_OutBoxDal:BaseDal<Sms_OutBoxModel>
    {
        public Sms_OutBoxDal() : base("OutBox")
        {

        }


        /// <summary>
        /// 查询待发送短信,立即发送
        /// </summary>
        /// <returns></returns>
        public Sms_OutBoxModel queryTask(out int total)
        {
            return dh.QueryByPage<Sms_OutBoxModel>(this.tbname, null, 1, 1, out total, Restrain.Lt("SendTime", DateTime.Now), Restrain.Order("sendTime")).FirstOrDefault();
        }


        /// <summary>
        /// 通过id将短信转换为已发送
        /// </summary>
        /// <param name="id"></param>
        public void changeToSendedById(int id)
        {
            using(BaseDatabase db = dh.CreateDatabaseAndOpen())
            {
                Sms_OutBoxModel model = db.QueryById<Sms_OutBoxModel>(tbname, id);
                if (model == null)
                {
                    Log.Info("将短信转换为已发送错误:找不到该短信");
                    return;
                }
                var sendedModel = new Sms_SendedOutBoxModel();
                sendedModel.Username = model.Username;
                sendedModel.Mbno = model.Mbno;
                sendedModel.Msg = model.Msg;
                sendedModel.SendTime = DateTime.Now;
                sendedModel.V2 = model.V2;
                sendedModel.V3 = model.Id.ToString();

                db.BeginTransaction();
                db.Add("SendedOutBox", sendedModel);
                db.DelById(tbname, model.Id);
                db.CommitTranscation();
            }
        }

        public List<Sms_OutBoxModel> queryByPage(int page, int rows, out int total)
        {
           return dh.QueryByPage<Sms_OutBoxModel>(tbname, null, page, rows, out total,Restrain.Order("sendTime"));
        }

        public void changeToBad(int id,String badWhy)
        {
            using(BaseDatabase db = dh.CreateDatabaseAndOpen())
            {
                var model = db.QueryById<Sms_OutBoxModel>(tbname, id);
                if (model == null)
                {
                    Log.Info("将短信转换为发送失败错误:找不到该短信");
                    return;
                }

                var badModel = new Sms_BadOutBoxModel();
                badModel.Username = model.Username;
                badModel.Mbno = model.Mbno;
                badModel.Msg = model.Msg;
                badModel.SendTime = DateTime.Now;//真实发送时间????
                badModel.V2 = model.V2;//编号
                badModel.V3 = model.Id.ToString();
                badModel.Bad_why = badWhy;
                badModel.Comport = model.Comport;

                db.BeginTransaction();//开启事务
                db.Add("badoutbox", badModel);
                db.DelById(tbname, (int)model.Id);
                db.CommitTranscation();//提交事务
            }
        }


        public void add(Sms_OutBoxModel model)
        {
            dh.Add<Sms_OutBoxModel>(tbname, model);
        }
    }
}
