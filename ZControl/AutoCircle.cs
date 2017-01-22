using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
//Add new namespace
using System.Drawing.Drawing2D;
using System.Collections;

namespace CustomizedLoading
{
	public partial class AutoCircle : UserControl
    {
        #region Private fields

        private Timer m_tListener;
        private Color m_clrRingColor;
        private int m_nSeperatorAngle = 5;
        private int m_nIndex;
        private int m_nNumberOfSector;
        private int m_nRingThickness;
        private int m_nNumberOfTail;
        /// <summary>
        /// 是否继承父控件背景色
        /// </summary>
        private bool IsTransparent
        {
            get
            {
                return (this.BackColor == Color.Transparent);
            }
        }

        /// <summary>
        /// 扇片角度
        /// </summary>
        private int PieAngle
        {
            get
            {
                //包含边界的扇片角度
                int angleOfPie = 360 / this.SectorNumber;
                //除去边界的扇片角度
                int pieAngle = angleOfPie - this.m_nSeperatorAngle;
                return pieAngle;
            }
        }	

        #endregion

        #region Public properties

        /// <summary>
        /// 渐变扇片数量
        /// </summary>        
        [Category("AutoCircleRing"), Description("设置渐变扇片数量"), DefaultValue(5), Bindable(true)]
        public int TailNumber
        {
            get
            {
                return this.m_nNumberOfTail;
            }
            set
            {
                if (value < 0)
                    throw new ArgumentOutOfRangeException("渐变扇片数量应大于0");

                this.m_nNumberOfTail = value;

                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 背景颜色
        /// <para>默认白色</para>
        /// </summary>
        [Category("AutoCircleRing"), Description("设置背景颜色"), Bindable(true)]
        public Color RingColor
        {
            get
            {
                if (this.m_clrRingColor == Color.Empty)
                    return Color.White;

                return this.m_clrRingColor;
            }
            set
            {
                this.m_clrRingColor = value;
                //重绘UI
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 前景色
        /// </summary>
        [Category("AutoCircleRing"), Description("设置前景色"), Bindable(true)]
        public override Color ForeColor
        {
            get
            {
                return base.ForeColor;
            }
            set
            {
                base.ForeColor = value;
                //重绘UI
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        /// <summary>
        /// 扇片数量
        /// </summary>
        [Category("AutoCircleRing"), Description("设置扇片数量"), DefaultValue(9), Bindable(true)]
        public int SectorNumber
        {
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("扇片数量不能为0");
                if ((360 % value) != 0)
                    throw new ArgumentException("扇片数量应该为能够整除360的数. 360不能被值" + value.ToString() + "整除！");

                this.m_nNumberOfSector = value;
                //重绘UI
                this.UpdateStyles();
                this.Invalidate();
            }
            get
            {
                return this.m_nNumberOfSector;
            }
        }

        /// <summary>
        /// 扇片厚度
        /// </summary>
        [Category("AutoCircleRing"), Description("设置扇片厚度"), DefaultValue(9), Bindable(true)]
        public int RingThickness
        {
            get
            {
                return this.m_nRingThickness;
            }
            set
            {
                if (value <= 0)
                    throw new ArgumentOutOfRangeException("厚度不能为0");

                int m_limit = Math.Min(this.Width, this.Height) / 2;
                if (value >= m_limit)
                    throw new ArgumentOutOfRangeException("扇片厚度必须小于控件的长或宽");

                this.m_nRingThickness = value;
                //重绘UI
                this.UpdateStyles();
                this.Invalidate();
            }
        }

        #endregion

		/// <summary>
		/// 是否开始旋转动画
        /// <para>不在属性列表中显示，由上级用户控件适用</para>
		/// </summary>
        [System.ComponentModel.Browsable(false), DefaultValue(true), DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool IsRotate
        {
            get
            {
                return this.m_tListener.Enabled;
            }
            set
            {
                this.m_tListener.Enabled = value;
            }
        }

		/// <summary>
		/// 旋转频率（毫秒）
        /// <para>值越大，旋转越慢</para>
		/// </summary>
        [Category("AutoCircleRing"), Description("旋转频率（毫秒），值越大，旋转越慢"), DefaultValue(70), Bindable(true)]
        public int Interval
        {
            get
            {
                return this.m_tListener.Interval;
            }
            set
            {
                this.m_tListener.Interval = value;
            }
        }

        #region Default constructor.

        public AutoCircle()
        {
            //将ControlStyles.DoubleBuffer置为true，着色工作将在缓存中进行
            //完成后绘制在UI中，防止界面闪烁
            this.SetStyle(ControlStyles.DoubleBuffer, true);

            //允许继承父控件背景色
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);

            //控件尺寸变化后进行重绘
            this.ResizeRedraw = true;

            //初始标记
            this.m_nIndex = 1;
            this.m_nNumberOfSector = 9;
            this.m_nRingThickness = 9;
            this.m_clrRingColor = Color.Empty;
            this.m_nNumberOfTail = 6;
            this.m_tListener = new Timer();
            this.m_tListener.Interval = 100;
            this.m_tListener.Tick += new EventHandler(timer_Tick);
            this.m_tListener.Enabled = false;
        }

        #endregion
        

        public void Start()
        {
            this.m_tListener.Enabled = true;
            this.m_tListener.Start();
        }

        public void Stop()
        {
            this.m_tListener.Stop();
            this.m_tListener.Enabled = false;
        }

        public void Clear()
        {
            using (Graphics grp = this.CreateGraphics())
                this.FillEmptySectors(grp);
        }

		protected override void OnPaintBackground(PaintEventArgs pevent)
		{
			if (!this.IsTransparent)
				base.OnPaintBackground (pevent);
		}

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            if (this.DesignMode)
            {
                this.m_tListener.Enabled = false;
            }
        }

        protected override CreateParams CreateParams
        {
            get
            {
                CreateParams cp = base.CreateParams;
                if (IsTransparent)
                    cp.ExStyle |= 0x20;
                return cp;
            }
        }

        protected override void OnMove(EventArgs e)
        {
            if (!IsTransparent)
                base.OnMove(e);
            else
                this.RecreateHandle();
        }

        protected override void OnBackColorChanged(EventArgs e)
        {
            this.UpdateStyles();
            base.OnBackColorChanged(e);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            //填充静止环颜色
            this.FillEmptySectors(e.Graphics);
            //填充旋转扇片颜色
            this.FillPieAndTail();
        }

        private void FillEmptySectors(Graphics grp)
        {
            int startAngle = 0;

            for (int i = 0; i < this.SectorNumber; i++)
            {
                this.DrawFilledSector(grp, this.RingColor, startAngle);

                startAngle += this.PieAngle + this.m_nSeperatorAngle;
            }
        }

        private void DrawFilledSector(Graphics grp, Color color, int startAngle)
        {
            grp.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;

            Rectangle main = this.ClientRectangle;

            if (main.Width - (2 * this.m_nRingThickness) < 1 || main.Height - (2 * this.m_nRingThickness) <= 1)
                return;

            GraphicsPath outerPath = new GraphicsPath();
            outerPath.AddPie(main, startAngle, this.PieAngle);

            Rectangle sub = new Rectangle(main.X + this.m_nRingThickness, main.Y + this.m_nRingThickness, main.Width - (2 * this.m_nRingThickness), main.Height - (2 * this.m_nRingThickness));
            GraphicsPath innerPath = new GraphicsPath();
            innerPath.AddPie(sub, startAngle - 1, this.PieAngle + 2);

            System.Drawing.Region mainRegion = new Region(outerPath);
            System.Drawing.Region subRegion = new Region(innerPath);
            mainRegion.Exclude(subRegion);

            grp.FillRegion(new SolidBrush(color), mainRegion);
        }

        private void ChangeIndex()
        {
            this.FillPieAndTail();
            this.m_nIndex = (this.m_nIndex + 1) % this.SectorNumber;
        }

        private void FillPieAndTail()
        {
            Color color = this.ForeColor;

            for (int i = 0; i <= this.TailNumber; i++)
            {
                this.FillPieAccordingToTheIndex(this.m_nIndex - i, color);
                color = ControlPaint.Light(color);
            }

            this.FillPieAccordingToTheIndex(this.m_nIndex - (this.TailNumber + 1), this.RingColor);
        }

        private void FillPieAccordingToTheIndex(int index, Color color)
        {
            int count = index % this.SectorNumber;
            int angle = count * (this.PieAngle + this.m_nSeperatorAngle);

            using (Graphics grp = this.CreateGraphics())
            {
                grp.SmoothingMode = SmoothingMode.HighQuality;
                this.DrawFilledSector(grp, color, angle);
            }
        }

		private void timer_Tick(object sender, EventArgs e)
		{
			this.ChangeIndex ();
		}
	}
}
