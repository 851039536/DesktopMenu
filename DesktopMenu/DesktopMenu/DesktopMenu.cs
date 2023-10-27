using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using MechTE_480.Files;
using MechTE_480.Form;
using MechTE_480.Windows;

namespace DesktopMenu.DesktopMenu
{
    public partial class DesktopMenuDll
    {

        public static void SystemFunctionList()
        {
            var psi = new ProcessStartInfo
            {
                FileName = CurrentPath + @"\PluginApp\HotPluginApp.exe",
                UseShellExecute = false,
                WorkingDirectory = CurrentPath + @"\PluginApp",
                CreateNoWindow = true
            };
            Process.Start(psi);
        }
        
        public static void EnterHfp()
        {
            MechWin.EnterHfp();
        }    
        public static void EnterA2DP()
        {
            MechWin.OpenA2DP();
        }

        /// <summary>
        /// 执行上传操作
        /// </summary>
        public static void UpEngFile()
        {
            var up = new Task(() =>
            {
                const string http = "http://10.55.2.25:20005/api/PostUploadloadFileEngineeringMode";

                _selectedPath = GetWindowsSelectedPath();

                Console.WriteLine("1.选中的路径为：" + _selectedPath);

                if (_selectedPath == null)
                {
                    Console.WriteLine("值不存在,上传失败");
                    return;
                }

                if (MechForm.MesBox(_selectedPath, "上传"))
                {
                    // CompressFile(_selectedPath, _selectedPath);
                    Console.WriteLine("2.执行上传");
                    var ret = MFileTransfer.UploadZip(http, _selectedPath);
                    MechWin.MesBoxs(ret ? "上传成功!" : "上传失败!", "Message");
                }
            });
            up.Start();
            up.Wait();
            Console.WriteLine(up.IsCompleted);
        }

        /// <summary>
        /// 执行下载操作
        /// </summary>
        public static void DownloadEngFile()
        {
            var down = new Task(() =>
            {
                const string downPath = @"D:\TE-Download";
                const string unPath = @"D:\TE-Download";
                const string http = "http://10.55.2.25:20005/api/PostDownloadZIP";

                var title = MechForm.ShowInputDialog("文件下载", "请输入要下载的文件名称");
                if (title == "")
                {
                    MechForm.ShowErr("提示", "不能为空");
                    return;
                }

                Console.WriteLine("下载中,请稍等...");
                var ret = MFileTransfer.DownloadZip(http,"EngineeringMode" ,downPath,
                    unPath, title);
                if (ret)
                {
                    MechFile.OpenFile(downPath);
                    MechWin.MesBoxs("下载完成", "下载");
                }
                else
                {
                    MechWin.MesBoxs("下载失败", "下载");
                }
            });
            down.Start();
            down.Wait();
        }
        
       
    }
}