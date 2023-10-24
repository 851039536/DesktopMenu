using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Threading.Tasks;
using MechTE_480.Files;
using MechTE_480.Form;
using MechTE_480.Windows;
using UpDownloadFramework;

namespace DesktopMenu.DesktopMenu
{
    public partial class DesktopMenuDll
    {
        // 实现一个压缩文件的方法
        public static void CompressFile(string sourceFilePath, string zipFilePath)
        {
            // 如果文件没有找到，则报错
            if (!File.Exists(sourceFilePath))
            {
                throw new FileNotFoundException(sourceFilePath + "文件不存在！");
            }

            // 如果压缩文件没有找到，则进行创建
            if (!Directory.Exists(zipFilePath))
            {
                Directory.CreateDirectory(zipFilePath);
            }

            // 压缩文件的名称
            string zipFileName = zipFilePath + "\\" + Path.GetFileNameWithoutExtension(sourceFilePath) + ".zip";
            // 如果压缩文件存在，则进行删除
            if (File.Exists(zipFileName))
            {
                File.Delete(zipFileName);
            }
            // 开始压缩文件
            ZipFile.CreateFromDirectory(sourceFilePath, zipFileName);
        }


        public static void FunctionList()
        {
            var psi = new ProcessStartInfo
            {
                FileName = CurrentPath + @"\PluginApp\HotPluginApp.exe",
                UseShellExecute = false,
                WorkingDirectory = CurrentPath+@"\PluginApp",
                CreateNoWindow = true
            };
            Process.Start(psi);
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
                    var ret = ZipFiles.UploadZip(http, _selectedPath);
                    Console.WriteLine(ret ? "3.上传成功" : "3.上传失败");
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
                var ret = ZipFiles.DownloadEngineeringModeZip(http, downPath,
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