using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using MyStickyNote.CommonUnit.FileTools;
using MyStickyNote.CommonUnit;
using Newtonsoft.Json;
using MyStickyNote.Models.Models;
using MyStickyNote.StickyNotes;
using MyStickyNote.Views.StickyNotes;
using MyStickyNote.Models.Enums;
using System;
using MyStickyNote.ViewModels;
using System.IO;

namespace MyStickyNote
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public static DataHandleI DataHandle = IOHelp.Instance;
        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            //TODO load all notes if there is no note create a new textNote
            var allNotes = DataHandle.GetContents(CommonString.SavePath);
            //todo 这里最好改一下 用工厂来做 这里不管其他东西 只判断是否传入东西 不传入就是默认
            if (allNotes.Count == 0)
            {
                AddNormalNote();
            }
            foreach (var note in allNotes)
            {
                if (Path.GetFileName(note.Key).StartsWith(Notetype.NormalNote.ToString()))
                {
                    var noteBase = JsonConvert.DeserializeObject<TextNoteViewModel>(note.Value);
                    AddNormalNote(noteBase);
                }
            }
        }

        private void AddNormalNote(TextNoteViewModel noteBase = null)
        {
            TextStickyNote_UC sn = new TextStickyNote_UC(noteBase);
            sn.OnAddNote = AddNote;
            sn.OnRemoveNote = RemoveNote;
            sn.GotMouseCapture += StickyNote_UC_GotMouseCapture;
            //sn.LostMouseCapture+=
            NotesGrid.Children.Add(sn);
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
            AddNormalNote(null);
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
