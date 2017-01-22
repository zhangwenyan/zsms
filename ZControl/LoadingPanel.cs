using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace CustomizedLoading
{
    public partial class LoadingPanel : UserControl
    {
        #region Private fields

        private AutoCircle m_autoCircle;
        private Label m_lblText;
        private string m_strLoadingText;

        #endregion

        #region Public properties

        [Category("LoadingPanelProperties"),DefaultValue("Loading..."), Description("提示信息"), Bindable(true)]
        public string LoadingText
        {
            get
            {
                return m_strLoadingText;
            }
            set
            {
                this.m_strLoadingText = value;
                if (this.m_lblText != null)
                    this.m_lblText.Text = value;
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        [Category("LoadingPanelProperties"), DefaultValue(70), Description("旋转速率（毫秒），值越大，旋转越快"), Bindable(true)]
        public int Interval
        {
            get
            {
                if (this.m_autoCircle != null)
                    return this.m_autoCircle.Interval;
                else
                    return 100;
            }
            set
            {
                if (this.m_autoCircle != null)
                    this.m_autoCircle.Interval = value;
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 渐变扇片数量
        /// </summary>        
        [Category("LoadingPanelProperties"), Description("设置渐变扇片数量"), DefaultValue(5), Bindable(true)]
        public int TailNumber
        {
            get
            {
                if (this.m_autoCircle != null)
                    return this.m_autoCircle.TailNumber;
                else
                    return 5;
            }
            set
            {
                if (this.m_autoCircle != null)
                    this.m_autoCircle.TailNumber = value;

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 扇片数量
        /// </summary>
        [Category("LoadingPanelProperties"), Description("设置扇片数量"), DefaultValue(9), Bindable(true)]
        public int SectorNumber
        {
            get
            {
                if (this.m_autoCircle != null)
                    return this.m_autoCircle.SectorNumber;
                else
                    return 5;
            }
            set
            {
                if (this.m_autoCircle != null)
                    this.m_autoCircle.SectorNumber = value;
                //重绘UI
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 扇片厚度
        /// </summary>
        [Category("LoadingPanelProperties"), Description("设置扇片厚度"), DefaultValue(9), Bindable(true)]
        public int RingThickness
        {
            get
            {
                if (this.m_autoCircle != null)
                    return this.m_autoCircle.RingThickness;
                else
                    return 9;
            }
            set
            {
                if (this.m_autoCircle != null)
                    this.m_autoCircle.RingThickness = value;
                //重绘UI
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 设置扇片颜色
        /// </summary>
        [Category("LoadingPanelProperties"), Description("设置扇片颜色"), Bindable(true)]
        public Color RingColor
        {
            get 
            {
                if (this.m_autoCircle != null)
                    return this.m_autoCircle.ForeColor;
                else
                    return Color.Black;
            }
            set
            {
                if (this.m_autoCircle != null)
                    this.m_autoCircle.ForeColor = value;
                //重绘UI
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 设置渐变扇片颜色
        /// </summary>
        [Category("LoadingPanelProperties"), Description("设置渐变扇片颜色"), Bindable(true)]
        public Color RingTailColor
        {
            get
            {
                if (this.m_autoCircle != null)
                    return this.m_autoCircle.RingColor;
                else
                    return Color.White;
            }
            set
            {
                if (this.m_autoCircle != null)
                    this.m_autoCircle.RingColor = value;
                //重绘UI
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 设置信息字体颜色
        /// </summary>
        [Category("LoadingPanelProperties"), Description("设置信息字体颜色"), Bindable(true)]
        public Color LoadingTextColor
        {
            get
            {
                if (this.m_lblText != null)
                    return this.m_lblText.ForeColor;
                else
                    return Color.Black;
            }
            set
            {
                if (this.m_autoCircle != null)
                    this.m_lblText.ForeColor = value;
                //重绘UI
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        #endregion

        #region Delegate & Event

        public delegate void RotateStateChangedHandler();
        /// <summary>
        /// 当LoadingPanel运行状态改变时
        /// </summary>
        public event RotateStateChangedHandler OnRotateStateChanged;

        #endregion

        /// <summary>
        /// Default constructor
        /// </summary>
        public LoadingPanel()
        {
            InitializeComponent();
            this.m_autoCircle = new AutoCircle();
            this.m_lblText = new Label();
            this.m_strLoadingText = "Loading...";
            this.m_lblText.Text = this.m_strLoadingText;
            this.Visible = false;
        }        

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            m_autoCircle.Size = new Size(26, 26);
            m_autoCircle.Location = new Point(0, 0);

            m_lblText.Size = new Size(this.Width - this.m_autoCircle.Size.Width - 5, 20);
            m_lblText.Font = new Font("宋体", 11F, FontStyle.Regular);
            m_lblText.Location = new Point(this.m_autoCircle.Size.Width + 5, 7);

            this.Controls.Add(m_autoCircle);
            this.Controls.Add(m_lblText);
            this.MinimumSize = new Size(100, 30);
        }

        /// <summary>
        /// 开始
        /// </summary>
        public void Start()
        {
            if (this.m_autoCircle != null)
            {
                this.m_autoCircle.Start();
                this.Invoke(new Action(delegate()
                    {
                        this.Visible = true;
                    }));
                
                if (this.OnRotateStateChanged != null)
                    this.OnRotateStateChanged();
            }
        }

        /// <summary>
        /// 关闭
        /// </summary>
        public void Stop()
        {
            if (this.m_autoCircle != null)
            {
                this.m_autoCircle.Stop();
                this.m_autoCircle.Clear();
                this.Invoke(new Action(delegate()
                {
                    this.Visible = false;
                }));
                if (this.OnRotateStateChanged != null)
                    this.OnRotateStateChanged();
            }
        }
    }
}
