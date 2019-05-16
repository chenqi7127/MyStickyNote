using System;
using System.Collections.Generic;

namespace MyStickyNote.Models.Models
{
    public class ImageStickyNote: StickNoteBase
    {
        private List<String> imageList;

        public List<String> ImageList
        {
            get { return imageList; }
            set { imageList = value; RaisePropertyChanged("ImageList"); }
        }
    }


}
