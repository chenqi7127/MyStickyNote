using MyStickyNote.CommonUnit.FileTools;
using MyStickyNote.Models.Models;
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
        StickNoteBase textNote;
        public Action OnAddNote;
        public Action<TextStickyNote_UC> OnRemoveNote;
        private RichTextBox NoteRichBox;
        public TextStickyNote_UC()
        {
            InitializeComponent();
            this.Loaded += TextStickyNote_UC_Loaded;
            this.LostMouseCapture += TextStickyNote_UC_LostMouseCapture;
        }

        private void TextStickyNote_UC_LostMouseCapture(object sender, MouseEventArgs e)
        {
            IOHelp.Instance.SaveData(textNote);
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
            NoteTopPart.OnRemoveNote = () => { textNote.DeleteNote(); OnRemoveNote?.Invoke(this); };
        }

        private void InitDataContext()
        {
            textNote = new StickNoteBase();
            LoadNoteRichBox();
        }

        private void FinishTask_Click(object sender, RoutedEventArgs e)
        {
            NoteRichBox.Selection.ApplyPropertyValue(TextBlock.TextDecorationsProperty, TextDecorations.Strikethrough);
        }

        private void SaveNoteRichBox()
        {
            var textRange = new TextRange(NoteRichBox.Document.ContentStart, NoteRichBox.Document.ContentEnd);
            using (FileStream fs = new FileStream(@"D:\text.rtf",FileMode.Create))
            {
                textRange.Save(fs, DataFormats.Rtf);
            }
        }

        private void LoadNoteRichBox()
        {
            var textRange = new TextRange(NoteRichBox.Document.ContentStart, NoteRichBox.Document.ContentEnd);
            using (FileStream fs = new FileStream(@"D:\text.rtf", FileMode.Open,FileAccess.Read))
            {
                textRange.Load(fs, DataFormats.Rtf);
            }
        }
    }
}
