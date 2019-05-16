using GalaSoft.MvvmLight;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStickyNote.Models.Models
{
    public class StickyNote: ViewModelBase
    {
        private double locationX;

        public double LocationX
        {
            get { return locationX; }
            set { locationX = value; RaisePropertyChanged("LocationX"); }
        }

        private double locationY;

        public double LocationY
        {
            get { return locationY; }
            set { locationY = value; RaisePropertyChanged("LocationY"); }
        }

        private List<String> imageList;

        public List<String> ImageList
        {
            get { return imageList; }
            set { imageList = value; RaisePropertyChanged("ImageList"); }
        }

        private Notetype type;

        public Notetype Type
        {
            get { return type; }
            set { type = value; RaisePropertyChanged("Type"); }
        }

        private string title;

        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged("Title"); }
        }

        private String noteContent;

        public String NoteContent
        {
            get { return noteContent; }
            set { noteContent = value; RaisePropertyChanged("NoteContent"); }
        }

        private NoteTheme noteTheme;

        public NoteTheme NoteTheme
        {
            get { return noteTheme; }
            set { noteTheme = value; RaisePropertyChanged("NoteTheme"); }
        }

        private NoteState noteState;

        public NoteState NoteState
        {
            get { return noteState; }
            set { noteState = value; RaisePropertyChanged("NoteState"); }
        }
    }

    public enum Notetype
    {
        NormalNote,
        ImageNote
    }

    public enum NoteTheme
    {
        NormalTheme,
        DarkTheme,
        LightTheme
    }

    public enum NoteState
    {
        Expended,
        Retract
    }
}
