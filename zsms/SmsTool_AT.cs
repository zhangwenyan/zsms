using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Threading;

namespace zsms
{
    public class SmsTool_AT : BaseSmsTool
    {
        private SerialPort sp;
        public AutoResetEvent are_sendAt = new AutoResetEvent(false);
        private String tmpMsg = "";

        private String portName;
        private int bandRate;
        private bool smsRecover;

        public override event DGRSms onSmsRecover;

        public SmsTool_AT(String portName,int bandRate)
        {
            this.portName = portName;
            this.bandRate = bandRate;
        }

        public SmsTool_AT(String portName,int bandRate,bool smsRecover):this(portName,bandRate)
        {
            this.smsRecover = smsRecover;
        }


        public override void Dispose()
        {
            this.isDispose = true;
            are_sendAt.Set();
            sp.Dispose();
        }

        public override string getMsg()
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("短信猫 ");
            String r = sendAt("AT+COPS?").ToLower();

            if(r.Contains("china mobile"))
            {
                sb.Append("中国移动 ");
            }
            else if(r.Contains("china unicom"))
            {
                sb.Append("中国联通 ");
            }

            return sb.ToString();

        }

        public override void init()
        {
            Console.WriteLine("开始初始化连接");
            if (sp != null)
            {
                if (sp.IsOpen)
                {
                    sp.DiscardInBuffer();
                    sp.DiscardOutBuffer();
                    sp.Close();
                }
                sp.Dispose();
                sp = null;
            }
            sp = new SerialPort();
            sp.PortName = this.portName;
            if (this.bandRate != 0)
            {
                sp.BaudRate = this.bandRate;
            }
            sp.Open();
            sp.RtsEnable = true;//必须开启,让短信猫能够接收数据
            sp.DataReceived += sp_DataReceived;
            if (smsRecover)
            {

                checkInBoxSms();
                try
                {
                    var r = sendAt("AT+CMGD=1,1");//清除已读短息
                    if (!r.Contains("OK"))
                    {
                        throw new Exception(r);
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("清除已读短信失败:" + ex.Message);
                }
            }


        }

        /// <summary>
        /// 检查是否有未读短信
        /// </summary>
        private void checkInBoxSms()
        {
            new Thread(delegate ()
            {
                try
                {
                    PDUEncoding pe = new PDUEncoding();
                    string result = sendAt("AT+CMGL=0",60000);//获取未读信息列表,自动标记为已读信息
                    if (result.Length > 20)
                    {
                        string[] lines = result.Split('\n');
                        for (int i = 0; i < lines.Length; i++)
                        {
                            string line = lines[i];

                            if (line.StartsWith("+CMGL"))
                            {

                                int StartIndex = line.IndexOf(":") + 1;
                                int EndIndex = line.IndexOf(",");
                                string indexStr = line.Substring(StartIndex, EndIndex - StartIndex).Trim();
                                int index = int.Parse(indexStr);

                                sendAt("AT+CMGD=" + index);//清除该短信


                                line = lines[++i];
                                var content = pe.PDUDecoder(line);
                                string mbno = content.PhoneNumber;
                                string msg = content.SmsContent;
                                DateTime dt = content.SendTime;
                                int total = content.Total;


                                if (onSmsRecover != null)
                                {
                                    onSmsRecover(new RSms()
                                    {
                                        Mbno = mbno,
                                        Msg = msg,
                                        DT = dt
                                    });
                                }

                                Console.WriteLine("读到短信:" + mbno + "," + msg + ",时间:" + dt);

                            }
                        }

                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("检查接收短信出错:" + ex.Message);
                }

            }).Start();
        }

        private void sp_DataReceived(object sender, EventArgs e)
        {
            var tmp = sp.ReadExisting();
            Console.Write(tmp);
            tmpMsg += tmp;
            if (tmpMsg.Contains("OK") || tmpMsg.Contains("ERROR") || tmpMsg.Contains(">"))
            {
                are_sendAt.Set();
            }
            else if (tmpMsg.Contains("+CMTI:"))
            {
                Console.WriteLine("有短信");
                Console.WriteLine("---------");
                Console.WriteLine(tmpMsg);
                Console.WriteLine("-----------------------");

                tmpMsg = "";
                if (smsRecover)
                {
                    checkInBoxSms();
                }
            }

        }


        public String sendAt(String str)
        {
            return sendAt(str, 30000);
        }
        public String sendAt(String str,int timeout)
        {
            Console.WriteLine("准备命令:" + str);

            lock (this)
            {
                if (isDispose)
                {
                    throw new Exception("tool is Dispose");
                }


              
                try
                {
                    Console.WriteLine("开始发送命令:" + str);
                    if (sp == null || !sp.IsOpen)
                    {
                        init();
                    }
                    sp.DiscardOutBuffer();
                    sp.Write(str + "\n");
                    var b = are_sendAt.WaitOne(timeout);

                    if (b)
                    {
                        var tmp = tmpMsg;
                        tmpMsg = "";
                        return tmp;
                    }
                    else
                    {
                        throw new Exception("发送at命令超时");
                    }
                }catch(Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    throw ex;
                }
                finally
                {
                    Console.WriteLine("发送命令完成:" + str);
                }
            }
        }


        public override void sendSms(ESms esms)
        {

            PDUEncoding pe = new PDUEncoding();
            foreach (CodedMessage cm in pe.PDUEncoder(esms.Mbno, esms.Msg))
            {
                String r0 = sendAt("AT+CMGS=" + cm.Length);
                if (r0.Contains("ERROR"))
                {
                    throw new Exception("发送短信失败");
                }
                String r1 = sendAt(cm.PduCode + (char)26);
                if (!r1.Contains("OK"))
                {
                    throw new Exception("发送短信失败:"+r1);
                }
            }

        }
    }
}
