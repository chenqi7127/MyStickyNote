using MyStickyNote.CommonUnit;
using MyStickyNote.Models.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStickyNote.ViewModels
{
    class TextNoteViewModel: StickNoteBase
    {
        public string NoteContentPath { get; set; }

        public TextNoteViewModel():base()
        {
            NoteContentPath = $@"{CommonString.SavePath}\{UUID}_Note.json";
        }
        public override void DeleteNote()
        {
            if (File.Exists(NoteContentPath))
            {
                File.Delete(NoteContentPath);
            }
            base.DeleteNote();
        }
    }
}
