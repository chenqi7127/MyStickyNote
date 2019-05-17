﻿using System;
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

        public List<string> GetContents(string folderPath)
        {
            List<string> res = new List<string>();
            foreach (var item in new DirectoryInfo(folderPath).GetFiles())
            {
                res.Add(GetContent(item.FullName));
            }
            return res;
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
            if(!Directory.Exists(Path.GetDirectoryName(needSave.FilePath)))
            {
                Directory.CreateDirectory(Path.GetDirectoryName(needSave.FilePath));
            }
            File.WriteAllText(needSave.FilePath, needSave.ToString());
        }
    }
}
