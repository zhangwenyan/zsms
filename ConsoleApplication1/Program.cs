using Aliyun.Acs.Core;
using Aliyun.Acs.Core.Exceptions;
using Aliyun.Acs.Core.Profile;
using Aliyun.Acs.Sms.Model.V20160927;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ZUtil;
namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            IClientProfile profile = DefaultProfile.GetProfile("cn-hangzhou", "fUp8ugoXHBUx8rCQ", "Zamp8jopaIOzVLPnX8r804vb3SrXPY");
            IAcsClient client = new DefaultAcsClient(profile);
            SingleSendSmsRequest request = new SingleSendSmsRequest();
            try
            {
                request.SignName = "燎火";
                request.TemplateCode = "SMS_45790033";
                request.RecNum = "17681109309";
                request.ParamString = "{\"name\":\"aas\",\"date\":\"dddd\"}";
                SingleSendSmsResponse httpResponse = client.GetAcsResponse(request);
            }
            catch (ServerException e)
            {
                
            }
            catch (ClientException e)
            {
            }
        }
    }
}
