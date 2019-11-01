using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyStickyNote.CommonUnit.FileTools;
using MyStickyNote.CommonUnit;
using Newtonsoft.Json;
using MyStickyNote.Models.Models;
using MyStickyNote.StickyNotes;
using MyStickyNote.Views.StickyNotes;

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
            //todo 这里最好加上失去焦点的时候的操作 不用遍历全部便签
            //sn.LostMouseCapture+=
            NotesGrid.Children.Add(sn);
            #region Add DateStickyNote
            //DateStickyNote sn = new DateStickyNote();
            ////sn.OnAddNote = AddNote;
            ////sn.OnRemoveNote = RemoveNote;
            //sn.GotMouseCapture += StickyNote_UC_GotMouseCapture;
            //NotesGrid.Children.Add(sn);
            #endregion
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
