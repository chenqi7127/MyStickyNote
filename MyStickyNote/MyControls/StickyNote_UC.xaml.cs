using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MyStickyNote.MyControls
{
    /// <summary>
    /// StickyNote_UC.xaml 的交互逻辑
    /// </summary>
    public partial class StickyNote_UC : UserControl
    {
        private double _ScreenWidth = 0;
        private double _ScreenHeigh = 0;

        public StickyNote_UC()
        {
            InitializeComponent();
            _ScreenHeigh = SystemParameters.PrimaryScreenHeight;
            _ScreenWidth = SystemParameters.PrimaryScreenWidth;
            BackCanvas.Width = _ScreenWidth;
            BackCanvas.Height = _ScreenHeigh;
        }

        #region 拖拽部分
        private void Left(double horizontalChange)
        {
            double left = Canvas.GetLeft(StickyNote);
            StickyNote.Width -= horizontalChange;
            Canvas.SetLeft(StickyNote, left + horizontalChange);
        }
        private void Right(double horizontalChange)
        {
            StickyNote.Width += horizontalChange;
        }
        private void Top(double horizontalChange)
        {
            double top = Canvas.GetTop(StickyNote);
            StickyNote.Height -= horizontalChange;
            Canvas.SetTop(StickyNote, top + horizontalChange);
        }

        private void Bottom(double horizontalChange)
        {
            StickyNote.Height += horizontalChange;
        }

        private void Move_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            double left = Canvas.GetLeft(StickyNote);
            Canvas.SetLeft(StickyNote, left + e.HorizontalChange);
            double top = Canvas.GetTop(StickyNote);
            Canvas.SetTop(StickyNote, top + e.VerticalChange);
        }

        private void Left_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Left(e.HorizontalChange);
        }

        private void LeftTop_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Left(e.HorizontalChange);
            Top(e.VerticalChange);
        }

        private void RightTop_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Right(e.HorizontalChange);
            Top(e.VerticalChange);
        }

        private void Top_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Top(e.VerticalChange);
        }

        private void Right_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Right(e.HorizontalChange);
        }

        private void RightBottom_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Right(e.HorizontalChange);
            Bottom(e.VerticalChange);
        }

        private void LeftBottom_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Left(e.HorizontalChange);
            Bottom(e.VerticalChange);
        }

        private void Bottom_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            Bottom(e.VerticalChange);
        }
        #endregion
    }
}
