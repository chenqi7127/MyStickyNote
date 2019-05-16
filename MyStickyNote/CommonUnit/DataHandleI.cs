using MyStickyNote.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStickyNote.CommonUnit
{
    interface DataHandleI
    {
        string GetContent(string filePath);

        List<string> GetContents(string folderPath);

        void SaveData<T>(T needSave)where T: StickNoteBase;

        void SaveAllDatas<T>(List<T> needSave) where T : StickNoteBase;
    }
}
