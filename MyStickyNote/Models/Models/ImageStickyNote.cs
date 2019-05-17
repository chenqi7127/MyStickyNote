using System;
using System.Collections.Generic;

namespace MyStickyNote.Models.Models
{
    public class ImageStickyNote: StickNoteBase
    {
        private NotifyList<String> imageList;

        public NotifyList<String> ImageList
        {
            get { return imageList; }
            set { imageList = value; RaisePropertyChanged("ImageList"); }
        }

        public ImageStickyNote():base()
        {
            this.Type = Enums.Notetype.ImageNote;
            ImageList.CollectionChanged += () => { RaisePropertyChanged("ImageList"); };
        }
    }


}
