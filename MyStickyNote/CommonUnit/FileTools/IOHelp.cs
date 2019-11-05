using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyStickyNote.Models.Models;

namespace MyStickyNote.CommonUnit.FileTools
{
    public class IOHelp: DataHandleI
    {
        public static IOHelp Instance;

        static IOHelp()
        {
            Instance = new IOHelp();
        }

        private IOHelp()
        {
           
        }



        public string GetContent(string filePath)
        {
            return File.ReadAllText(filePath);
        }

        public Dictionary<string,string> GetContents(string folderPath)
        {
            CheckNeedCreateDirectory(folderPath);
            Dictionary<string, string> res = new Dictionary<string, string>();
            foreach (var item in new DirectoryInfo(folderPath).GetFiles())
            {
                if (!item.FullName.EndsWith("_Note.json"))
                {
                    res.Add(item.FullName, GetContent(item.FullName));
                }
            }
            return res;
        }

        private void CheckNeedCreateDirectory(string folder)
        {
            if (!Directory.Exists(folder))
            {
                Directory.CreateDirectory(folder);
            }
        }

        public void SaveAllDatas(List<StickNoteBase> needSave)
        {
            foreach (var item in needSave)
            {
                SaveData(item);
            }
        }

        public void SaveData(StickNoteBase needSave)
        {
            CheckNeedCreateDirectory(Path.GetDirectoryName(needSave.FilePath));
            File.WriteAllText(needSave.FilePath, needSave.ToString());
        }
        public void DeleteData(StickNoteBase needDel)
        {
            File.Delete(needDel.FilePath);
        }

        public void DeleteDatas(List<StickNoteBase> needDels)
        {
            foreach (var del in needDels)
            {
                DeleteData(del);
            }
        }

    }
}
