using GalaSoft.MvvmLight;
using MyStickyNote.CommonUnit;
using MyStickyNote.CommonUnit.FileTools;
using MyStickyNote.Models.Enums;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Runtime.CompilerServices;

namespace MyStickyNote.Models.Models
{
    public class StickNoteBase: ViewModelBase
    {
        //todo 在这里切换保存的方式
        private DataHandleI dataHandle = IOHelp.Instance;
        public StickNoteBase()
        {
            UUID = System.Guid.NewGuid().ToString("N");
            FilePath = $@"{CommonString.SavePath}\{Type.ToString()}_{UUID}.json";
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

        private double nodeWidth;
        /// <summary>
        /// 便签的X轴坐标
        /// </summary>
        public double NodeWidth
        {
            get { return nodeWidth; }
            set { nodeWidth = value; RaisePropertyChanged("NodeWidth"); }
        }

        private double nodeHeight;
        /// <summary>
        /// 便签的Y轴坐标
        /// </summary>
        public double NodeHeight
        {
            get { return nodeHeight; }
            set { nodeHeight = value; RaisePropertyChanged("NodeHeight"); }
        }
        #region NoteMargin
        private Thickness noteMargin = new Thickness(0);
        public Thickness NoteMargin
        {
            get { return noteMargin; }
            set
            {
                if (noteMargin != value)
                {
                    noteMargin = value; RaisePropertyChanged(nameof(NoteMargin));
                }
            }

        }

        #endregion

        private string title;
        /// <summary>
        /// 便签的标题
        /// </summary>
        public string Title
        {
            get { return title; }
            set { title = value; RaisePropertyChanged("Title"); }
        }

        public Notetype Type { get; set; }

        /// <summary>
        /// 是否修改过
        /// </summary>
        public bool IsModifyed { get; set; }
        #endregion

        public override string ToString()
        {
            return JsonConvert.SerializeObject(this);
        }

        public virtual void DeleteNote()
        {
            dataHandle.DeleteData(this);
        }

        public virtual void SaveNote()
        {
            if (IsModifyed)
            {
                IsModifyed = false;
                dataHandle.SaveData(this);
            }
        }

        public override void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.IsModifyed = true;
            base.RaisePropertyChanged(propertyName);
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
