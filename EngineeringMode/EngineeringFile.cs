using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using GeneralUpDownload_FrameworkV452;
using MechTE_480.MECH;

namespace EngineeringMode
{
    public static class EngineeringFile
    {
        private static string _selectedPath;

        /// <summary>
        /// 获取Windows当前选文件定路径
        /// </summary>
        /// <returns>完整路径</returns>
        private static string GetSelectedPath()
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
        /// Windows操作系统提供的一个函数，用于在应用程序中显示消息框。消息框可以用于显示警告、错误、提示等信息，并与用户进行交互。
        /// </summary>
        /// <param name="hWnd">窗口句柄设为0，表示使用默认窗口</param>
        /// <param name="text">提示描述</param>
        /// <param name="caption">标题</param>
        /// <param name="options">消息框的选项，例如按钮类型和图标类型</param>
        /// <returns></returns>
        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        private static extern int MessageBox(IntPtr hWnd, string text, string caption, int options);


        
        /// <summary>
        /// 执行上传操作
        /// </summary>
        public static void UpEngFile()
        {
            var up = new Task(() =>
            {
                const string http = "http://10.55.2.25:20005/api/PostUploadloadFileEngineeringMode";
                _selectedPath = GetSelectedPath();
                Console.WriteLine("1.选中的路径为：" + _selectedPath);
                if (_selectedPath == null)
                {
                    Console.WriteLine("值不存在,下载失败");
                    return;
                }

                Console.WriteLine("2.执行上传");
                
                var ret = ZipFiles.UploadZip(http, _selectedPath);
                Console.WriteLine(ret ? "3.上传成功" : "3.上传失败");
                if (ret)
                {
                    MessageBox(IntPtr.Zero, "上传成功!", "Message", 0);
                }
                else
                {
                    MessageBox(IntPtr.Zero, "上传失败!", "Message", 0);
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

        private static readonly string CurrentPath = MechUtils.GetTheCurrentProgramAndDirectory();


        public static void OpenSimpleHidWrite()
        {
            MechCmd.StartShell(CurrentPath + @"\SimpleHIDWrite\SimpleHIDWrite.exe");
        }

        public static void OpenSwWebsite()
        {
            MechCmd.StartApp("http://10.55.2.25:8099/");
        }

        public static void OpenTestTheData()
        {
            MechCmd.StartApp("http://10.55.2.25:8089/");
        }

        public static void OpenVersionSystem()
        {
            MechCmd.StartApp("http://10.55.2.25:9999/");
        }

        public static void OpenBackgroundSystem()
        {
            MechCmd.StartApp("http://10.55.2.25:9000/");
        }
    }
}