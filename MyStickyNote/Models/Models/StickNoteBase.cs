using GalaSoft.MvvmLight;
using MyStickyNote.Models.Enums;
using System;

namespace MyStickyNote.Models.Models
{
    public class StickNoteBase: ViewModelBase
    {
        public string UUID { get; set; }
        public string FilePath { get; set; }

        private String noteContent;
        /// <summary>
        /// 便签的内容
        /// </summary>
        public String NoteContent
        {
            get { return noteContent; }
            set { noteContent = value; RaisePropertyChanged("NoteContent"); }
        }

        private NoteTheme noteTheme;
        /// <summary>
        /// 便签的主题
        /// </summary>
        public NoteTheme NoteTheme
        {
            get { return noteTheme; }
            set { noteTheme = value; RaisePropertyChanged("NoteTheme"); }
        }

        private NoteState noteState;
        /// <summary>
        /// 便签的状态
        /// </summary>
        public NoteState NoteState
        {
            get { return noteState; }
            set { noteState = value; RaisePropertyChanged("NoteState"); }
        }

        private double locationX;
        /// <summary>
        /// 便签的X轴坐标
        /// </summary>
        public double LocationX
        {
            get { return locationX; }
            set { locationX = value; RaisePropertyChanged("LocationX"); }
        }

        private double locationY;
        /// <summary>
        /// 便签的Y轴坐标
        /// </summary>
        public double LocationY
        {
            get { return locationY; }
            set { locationY = value; RaisePropertyChanged("LocationY"); }
        }

        private Notetype type;
        /// <summary>
        /// 便签类型
        /// </summary>
        public Notetype Type
        {
            get { return type; }
            set { type = value; RaisePropertyChanged("Type"); }
        }

        private string title;
        /// <summary>
        /// 便签的标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged("Title"); }
        }
    }
}
