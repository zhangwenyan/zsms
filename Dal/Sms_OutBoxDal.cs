﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model;
using easysql;

namespace Dal
{
    public class Sms_OutBoxDal:BaseDal<Sms_OutBoxModel>
    {
        /// <summary>
        /// 查询待发送短信,立即发送
        /// </summary>
        /// <returns></returns>
        public Sms_OutBoxModel queryTask(out int total)
        {
            dh.Execute("update " + tbName + " set sendTime={0} where sendTime is null", DateTime.Now);
            return dh.QueryByPage<Sms_OutBoxModel>(this.tbName, null, 1, 1, out total, Restrain.Lt("SendTime", DateTime.Now), Restrain.Order("sendTime")).FirstOrDefault();
        }


        /// <summary>
        /// 通过id将短信转换为已发送
        /// </summary>
        /// <param name="id"></param>
        public void changeToSendedById(int id)
        {
            using(BaseDatabase db = dh.CreateDatabaseAndOpen())
            {
                Sms_OutBoxModel model = db.QueryById<Sms_OutBoxModel>(tbName, id);
                if (model == null)
                {
                    Log.Info("将短信转换为已发送错误:找不到该短信");
                    return;
                }
                var sendedModel = new Sms_SendedOutBoxModel();
                sendedModel.username = model.username;
                sendedModel.mbno = model.mbno;
                sendedModel.msg = model.msg;
                sendedModel.sendTime = DateTime.Now;
                sendedModel.v2 = model.v2;
                sendedModel.v3 = model.id.ToString();

                db.BeginTransaction();
                db.Add("SendedOutBox", sendedModel);
                db.DelById(tbName, model.id);
                db.CommitTranscation();
            }
        }


        public void changeToBad(int id,String badWhy)
        {
            using(BaseDatabase db = dh.CreateDatabaseAndOpen())
            {
                var model = db.QueryById<Sms_OutBoxModel>(tbName, id);
                if (model == null)
                {
                    Log.Info("将短信转换为发送失败错误:找不到该短信");
                    return;
                }

                var badModel = new Sms_BadOutBoxModel();
                badModel.username = model.username;
                badModel.mbno = model.mbno;
                badModel.msg = model.msg;
                badModel.sendTime = DateTime.Now;//真实发送时间????
                badModel.v2 = model.v2;//编号
                badModel.v3 = model.id.ToString();
                badModel.bad_why = badWhy;
                badModel.comport = model.comport;

                db.BeginTransaction();//开启事务
                db.Add("badoutbox", badModel);
                db.DelById(tbName, (int)model.id);
                db.CommitTranscation();//提交事务
            }
        }

    }
}
