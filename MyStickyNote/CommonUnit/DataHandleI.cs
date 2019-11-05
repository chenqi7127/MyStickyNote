using MyStickyNote.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStickyNote.CommonUnit
{
    public interface DataHandleI
    {
        string GetContent(string filePath);

        Dictionary<string,string> GetContents(string folderPath);

        void SaveData(StickNoteBase needSave);

        void SaveAllDatas(List<StickNoteBase> needSave);

        void DeleteData(StickNoteBase needSave);

        void DeleteDatas(List<StickNoteBase> needSave);
    }
}
