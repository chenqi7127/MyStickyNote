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
using MyStickyNote.MyControls;
using MyStickyNote.CommonUnit.FileTools;

namespace MyStickyNote
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            //FirstNote.AddNoteAction = AddNote;
            //FirstNote.RemoveNoteAction = RemoveNote;
        }

        private void RemoveNote(TextStickyNote_UC obj)
        {
            if (NotesGrid.Children.Count > 1)
            {
                NotesGrid.Children.Remove(obj);
                obj = null;
            }
        }

        private void AddNote()
        {
            //todo maybe we need to add this to database ,think about the databse
            TextStickyNote_UC sn = new TextStickyNote_UC();
            //sn.AddNoteAction = AddNote;
            //sn.RemoveNoteAction = RemoveNote;
            sn.GotMouseCapture += StickyNote_UC_GotMouseCapture;
            NotesGrid.Children.Add(sn);
        }

        private void StickyNote_UC_GotMouseCapture(object sender, MouseEventArgs e)
        {
            foreach (UIElement item in NotesGrid.Children)
            {
                Grid.SetZIndex(item, 0);
            } 
            Grid.SetZIndex(sender as UIElement, 1);
        }
    }
}
