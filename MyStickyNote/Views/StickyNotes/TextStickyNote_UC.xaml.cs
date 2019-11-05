using MyStickyNote.CommonUnit.FileTools;
using MyStickyNote.Models.Models;
using MyStickyNote.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
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

namespace MyStickyNote.StickyNotes
{
    /// <summary>
    /// StickyNote_UC.xaml 的交互逻辑
    /// </summary>
    public partial class TextStickyNote_UC : UserControl
    {
        TextNoteViewModel vm;
        public Action OnAddNote;
        public Action<TextStickyNote_UC> OnRemoveNote;
        private RichTextBox NoteRichBox;
        public TextStickyNote_UC()
        {
            InitializeComponent();
            this.Loaded += TextStickyNote_UC_Loaded;
            this.LostFocus += TextStickyNote_UC_LostFocus;
        }

        private void TextStickyNote_UC_LostFocus(object sender, RoutedEventArgs e)
        {
            SaveNoteRichBox();
            vm.SaveNote();
        }

        public TextStickyNote_UC(TextNoteViewModel tmvn) : this()
        {
            if (tmvn != null)
                vm = tmvn;
            else
                vm = new TextNoteViewModel();
            this.DataContext = vm;
        }

        private void SaveNoteRichBox()
        {
            if (vm.IsModifyed)
            {
                var textRange = new TextRange(NoteRichBox.Document.ContentStart, NoteRichBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(vm.NoteContentPath, FileMode.Create))
                {
                    textRange.Save(fs, DataFormats.Rtf);
                }
            }

        }

        private void TextStickyNote_UC_Loaded(object sender, RoutedEventArgs e)
        {
            NoteRichBox = NoteTopPart.TextContent as RichTextBox;
            InitDataContext();
            InitEvent();
        }

        private void InitEvent()
        {
            NoteTopPart.OnAddNote = OnAddNote;
            NoteTopPart.OnRemoveNote = () => { vm.DeleteNote(); OnRemoveNote?.Invoke(this); };
        }

        private void InitDataContext()
        {
            LoadNoteRichBox();
        }

        private void LoadNoteRichBox()
        {
            if (File.Exists(vm.NoteContentPath))
            {
                var textRange = new TextRange(NoteRichBox.Document.ContentStart, NoteRichBox.Document.ContentEnd);
                using (FileStream fs = new FileStream(vm.NoteContentPath, FileMode.Open, FileAccess.Read))
                {
                    textRange.Load(fs, DataFormats.Rtf);
                }
            }
        }

        private void FinishTask_Click(object sender, RoutedEventArgs e)
        {
            NoteRichBox.Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty, TextDecorations.Strikethrough);
        }

        private void RichTextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            vm.IsModifyed = true;
        }
    }
}
