using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyStickyNote.CommonUnit
{
    public class CommonString
    {
        /// <summary>
        /// 文件的保存路径
        /// </summary>
        public static string SavePath = $@"{System.Environment.GetFolderPath(System.Environment.SpecialFolder.ApplicationData)}\MyStickyNote";

    }
}
