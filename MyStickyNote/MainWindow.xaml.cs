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
using MyStickyNote.CommonUnit;
using Newtonsoft.Json;
using MyStickyNote.Models.Models;

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
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO load all notes if there is no note create a new textNote
            var allNotes = IOHelp.Instance.GetContents(CommonString.SavePath);
            if (allNotes.Count == 0)
            {
                AddNote();
            }
            foreach (var noteStr in allNotes)
            {
                var note = JsonConvert.DeserializeObject<StickNoteBase>(noteStr);
                AddNote();
            }
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
            TextStickyNote_UC sn = new TextStickyNote_UC();
            sn.OnAddNote = AddNote;
            sn.OnRemoveNote = RemoveNote;
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
