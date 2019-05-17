using GalaSoft.MvvmLight;
using MyStickyNote.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace MyStickyNote.Models.Models
{
    public class StickNoteBase: ViewModelBase
    {
        public StickNoteBase()
        {
            UUID = System.Guid.NewGuid().ToString("N");
            //FilePath = @"D:\zhegeksd.txt";
            FilePath = $@"{System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)}\MyStickyNote\{UUID}.json";
            //TODO set note's theme state location title
        }
        #region 属性
        public string UUID { get; set; }
        public string FilePath { get; set; }

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
        #endregion

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }
    }

    public class NotifyList<T>: List<T>
    {
        public event Action CollectionChanged;
        private void Refresh()
        {
            if (CollectionChanged != null)
                CollectionChanged.Invoke();
        }
        public void Add(T item)
        {
            base.Add(item);
            Refresh();
        }
        public void Insert(int index, T item)
        {
            base.Insert(index, item);
            Refresh();
        }
        public void Clear()
        {
            base.Clear();
            Refresh();
        }
        public void RemoveAt(int index)
        {
            base.RemoveAt(index);
            Refresh();
        }
        public bool Remove(T item)
        {
            var res = base.Remove(item);
            if (res)
                Refresh();
            return res;
        }
    }
}
