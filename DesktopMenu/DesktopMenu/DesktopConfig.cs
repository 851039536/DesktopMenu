using System;
using System.IO;
using System.Threading;
using MechTE_480.Files;
using MechTE_480.ProcessCategory;
using MechTE_480.util;

namespace DesktopMenu.DesktopMenu
{
    /// <summary>
    /// 配置
    /// </summary>
    public partial class DesktopMenuDll
    {
        /// <summary>
        /// 当前程序根目录路径
        /// </summary>
        private static readonly string CurrentPath = MUtil.GetCurrentProgramDirectory();

        /// <summary>
        /// 当前选定文件路径
        /// </summary>
        private static string _selectedPath;

        /// <summary>
        /// 获取Windows当前选定文件路径
        /// </summary>
        /// <returns>完整路径</returns>
        public static string GetWindowsSelectedPath()
        {
            string[] commandLineArgs = Environment.GetCommandLineArgs();
            if (commandLineArgs.Length > 1)
            {
                string path = commandLineArgs[1];
                if (File.Exists(path) || Directory.Exists(path))
                {
                    return path;
                }
            }
            return null;
        }

        /// <summary>
        /// 卸载 > 删除注册表
        /// </summary>
        public static void Unload()
        {
            MProcessUtil.StartApps(@"\Unload.bat");
            Thread.Sleep(5000);
            MFile.OpenFile(CurrentPath);
        }
    }
}