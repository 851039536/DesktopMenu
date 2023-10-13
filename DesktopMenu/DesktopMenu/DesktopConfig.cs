using System;
using System.IO;
using MechTE_480.MECH;

namespace DesktopMenu.DesktopMenu
{
    /// <summary>
    /// 配置
    /// </summary>
    public static partial class DesktopMenuDll
    {
        /// <summary>
        /// 当前程序根目录路径
        /// </summary>
        private static readonly string CurrentPath = MechUtils.GetTheCurrentProgramAndDirectory();
        
        
        /// <summary>
        /// 获取Windows当前选文件定路径
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
    }
}