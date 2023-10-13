using System;
using System.Diagnostics;
using System.IO;
using System.IO.Compression;
using System.Runtime.InteropServices;
using System.Threading;
using System.Threading.Tasks;
using GeneralUpDownload_FrameworkV452;
using MechTE_480.Files;
using MechTE_480.Form;

namespace DesktopMenu.DesktopMenu
{
     public static partial class DesktopMenuDll
    {
        private static string _selectedPath;
       

        /// <summary>
        /// Windows操作系统提供的一个函数，用于在应用程序中显示消息框。消息框可以用于显示警告、错误、提示等信息，并与用户进行交互。
        /// </summary>
        /// <param name="hWnd">窗口句柄设为0，表示使用默认窗口</param>
        /// <param name="text">提示描述</param>
        /// <param name="caption">标题</param>
        /// <param name="options">消息框的选项，例如按钮类型和图标类型</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int MessageBox(IntPtr hWnd, string text, string caption, int options);
        
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
                    MessageBox(IntPtr.Zero, ret ? "上传成功!" : "上传失败!", "Message", 0);
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
                    Console.WriteLine("下载完成...");
                    MechFile.OpenFile(downPath);
                    MessageBox(IntPtr.Zero,"下载完成", "下载",0);  
                }
                else
                {
                    MessageBox(IntPtr.Zero,"下载失败", "下载",0);  
                }
            });
            down.Start();
            down.Wait();
        }
   
        /// <summary>
        /// 卸载 > 删除注册表
        /// </summary>
        public static void Unload()
        {
            // 管理员启动并传值
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = CurrentPath + @"\Unload.bat";
            startInfo.Verb = "runas"; // 请求管理员权限
            try
            {
                Process.Start(startInfo);
                
                Thread.Sleep(2000);
                MechFile.OpenFile(CurrentPath);
            } catch (Exception ex)
            {
                Console.WriteLine(@"无法以管理员权限重新启动应用程序：" + ex.Message);
            }
            
        }
    }
}