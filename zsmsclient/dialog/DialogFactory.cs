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

        private static Frame_SendedOutBoxList _Frame_SendedOutBoxList;
        public static Frame_SendedOutBoxList showFrame_SendedOutBoxList()
        {
            if(_Frame_SendedOutBoxList==null || _Frame_SendedOutBoxList.IsDisposed)
            {
                _Frame_SendedOutBoxList = new Frame_SendedOutBoxList();
            }
            _Frame_SendedOutBoxList.Show();
            _Frame_SendedOutBoxList.Focus();
            return _Frame_SendedOutBoxList;
        }


        private static Frame_BadOutBoxList _Frame_BadOutBoxList;
        public static Frame_BadOutBoxList showFrame_BadOutBoxList()
        {
            if (_Frame_BadOutBoxList == null || _Frame_BadOutBoxList.IsDisposed)
            {
                _Frame_BadOutBoxList = new Frame_BadOutBoxList();
            }
            _Frame_BadOutBoxList.Show();
            _Frame_BadOutBoxList.Focus();
            return _Frame_BadOutBoxList;
        }

        private static Frame_InBoxList _Frame_InBoxList;
        public static Frame_InBoxList showFrame_InBoxList()
        {
            if (_Frame_InBoxList == null || _Frame_InBoxList.IsDisposed)
            {
                _Frame_InBoxList = new Frame_InBoxList();
            }
            _Frame_InBoxList.Show();
            _Frame_InBoxList.Focus();
            return _Frame_InBoxList;
        }

        private static Frame_OtherSetting _Frame_OtherSetting;
        public static Frame_OtherSetting showFrame_OtherSetting()
        {
            if (_Frame_OtherSetting == null || _Frame_OtherSetting.IsDisposed)
            {
                _Frame_OtherSetting = new Frame_OtherSetting();
            }
            _Frame_OtherSetting.Show();
            _Frame_OtherSetting.Focus();
            return _Frame_OtherSetting;
        }

        private static Frame_StartSetting _Frame_StartSetting;
        public static Frame_StartSetting showFrame_StartSetting()
        {
            if (_Frame_StartSetting == null || _Frame_StartSetting.IsDisposed)
            {
                _Frame_StartSetting = new Frame_StartSetting();
            }
            _Frame_StartSetting.Show();
            _Frame_StartSetting.Focus();
            return _Frame_StartSetting;
        }
    }
}
