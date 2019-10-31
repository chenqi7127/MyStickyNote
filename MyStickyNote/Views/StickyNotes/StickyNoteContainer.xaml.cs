using MyStickyNote.NoteThemes;
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

namespace MyStickyNote.Views.StickyNotes
{
    /// <summary>
    /// StickyNoteContainer.xaml 的交互逻辑
    /// </summary>
    public partial class StickyNoteContainer : UserControl
    {
        public Action OnAddNote;
        public Action OnRemoveNote;

        #region dp


        public UIElement TextContent
        {
            get { return (UIElement)GetValue(TextContentProperty); }
            set { SetValue(TextContentProperty, value); }
        }

        // Using a DependencyProperty as the backing store for TextContent.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty TextContentProperty =
            DependencyProperty.Register("TextContent", typeof(UIElement), typeof(StickyNoteContainer), new PropertyMetadata(null));


        #endregion

        public StickyNoteContainer()
        {
            InitializeComponent();
            this.GotKeyboardFocus += NoteContent_GotFocus;
            this.LostKeyboardFocus += NoteContent_LostFocus;
        }
        private void NoteContent_LostFocus(object sender, RoutedEventArgs e)
        {
            //todo hide all titleButton add some animation maybe we can change title's background <-
        }

        private void NoteContent_GotFocus(object sender, RoutedEventArgs e)
        {
            //todo show all button add some animation  ->
        }

        #region 拖拽部分
        private void Left(double horizontalChange)
        {
            var width = this.ActualWidth - horizontalChange;
            if (width >= 200)
            {
                this.Width = width;
                this.Margin = new Thickness(this.Margin.Left + horizontalChange, this.Margin.Top, 0, 0);
            }
        }
        private void Right(double horizontalChange)
        {
            var width = this.ActualWidth + horizontalChange;
            if (width >= 200)
            {
                this.Width = width;
            }
        }
        private void Top(double horizontalChange)
        {
            var height = this.ActualHeight - horizontalChange;
            if (height >= 100)
            {
                this.Height = height;
                this.Margin = new Thickness(this.Margin.Left, this.Margin.Top + horizontalChange, 0, 0);
            }
        }

        private void Bottom(double horizontalChange)
        {
            var height = this.ActualHeight + horizontalChange;
            if (height >= 100)
            {
                this.Height = height;
            }
        }

        private void Move_DragDelta(object sender, System.Windows.Controls.Primitives.DragDeltaEventArgs e)
        {
            var thickness = new Thickness();
            thickness.Left = this.Margin.Left + e.HorizontalChange;
            thickness.Top = this.Margin.Top + e.VerticalChange;
            this.Margin = thickness;
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

        /// <summary>
        /// 删除便签按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void RemoveNote_Click(object sender, RoutedEventArgs e)
        {
            OnRemoveNote?.Invoke();
        }

        /// <summary>
        /// 新增标签按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AddNote_Click(object sender, RoutedEventArgs e)
        {
            OnAddNote?.Invoke();
        }

        private void Title_DoubleClick(object sender, MouseButtonEventArgs e)
        {
            if (e.ClickCount == 2)
            {
                AboveTitle.Visibility = Visibility.Collapsed;
                Title.Focus();
            }
        }

        #region Title part
        private void QuitTitleEdit(object sender, KeyboardFocusChangedEventArgs e)
        {
            AboveTitle.Visibility = Visibility.Visible;
        }

        private void ChangeNoteStyle_Click(object sender, RoutedEventArgs e)
        {
            //todo change Color or type like image or link to file or web
            ThemeManager.Instance.SetThemeResource(ThemeType.Black);
        }

        private void FinishedInput(object sender, KeyEventArgs e)
        {
            //todo save title and show AboveTitle then focus on NoteContent
        }
        #endregion

    }
}
