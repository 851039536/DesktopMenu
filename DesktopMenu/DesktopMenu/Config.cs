using System;
using System.Diagnostics;
using System.IO;
using System.Threading;
using MechTE_480.Files;
using MechTE_480.MECH;
using MechTE_480.Order;

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
        private static readonly string CurrentPath = MechUtils.GetTheCurrentProgramAndDirectory();

        /// <summary>
        /// 当前选定文件路径
        /// </summary>
        private static string _selectedPath;

        /// <summary>
        /// 获取Windows当前选定文件路径
        /// </summary>
        /// <returns>完整路径</returns>
        private static string GetWindowsSelectedPath()
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
            MechProcess.StartApps(@"\Unload.bat");
            Thread.Sleep(2000);
            MechFile.OpenFile(CurrentPath);
        }
    }
}