using MyStickyNote.CommonUnit.FileTools;
using MyStickyNote.Models.Models;
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
        public TextStickyNote_UC()
        {
            InitializeComponent();
            this.Loaded += TextStickyNote_UC_Loaded;
        }

        private void TextStickyNote_UC_Loaded(object sender, RoutedEventArgs e)
        {
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
            //IOHelp.Instance.SaveData(textNote);
        }
    }
}
