using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace zsmsclient.dialog
{
    public class DialogFactory
    {
        private static Frame_SendSms _Frame_SendSms;
        public static Frame_SendSms showFrame_SendSms()
        {
            if(_Frame_SendSms==null || _Frame_SendSms.IsDisposed)
            {
                _Frame_SendSms = new Frame_SendSms();
            }
            _Frame_SendSms.Show();
            _Frame_SendSms.Focus();
            return _Frame_SendSms;
        }

        private static Frame_OutBoxList _Frame_OutBoxList;
        public static Frame_OutBoxList showFrame_OutBoxList()
        {
            if (_Frame_OutBoxList == null || _Frame_OutBoxList.IsDisposed)
            {
                _Frame_OutBoxList = new Frame_OutBoxList();
            }
            _Frame_OutBoxList.Show();
            _Frame_OutBoxList.Focus();
            return _Frame_OutBoxList;
        }

        private static Frame_SmsToolSetting _Frame_SmsToolSetting;
        public static Frame_SmsToolSetting showFrame_SmsToolSetting()
        {
            if (_Frame_SmsToolSetting == null || _Frame_SmsToolSetting.IsDisposed)
            {
                _Frame_SmsToolSetting = new Frame_SmsToolSetting();
            }
            _Frame_SmsToolSetting.Show();
            _Frame_SmsToolSetting.Focus();
            return _Frame_SmsToolSetting;
        }
        private static Frame_DatabaseSetting _Frame_DatabaseSetting;
        public static Frame_DatabaseSetting showFrame_DatabaseSetting()
        {
            if (_Frame_DatabaseSetting == null || _Frame_DatabaseSetting.IsDisposed)
            {
                _Frame_DatabaseSetting = new Frame_DatabaseSetting();
            }
            _Frame_DatabaseSetting.Show();
            _Frame_DatabaseSetting.Focus();
            return _Frame_DatabaseSetting;
        }

    }
}
