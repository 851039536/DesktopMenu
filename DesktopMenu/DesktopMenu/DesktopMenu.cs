using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MechTE_480.Files;
using MechTE_480.FormCategory;
using MechTE_480.Windows;
using MySql.Data.MySqlClient;
using FileInfo = System.IO.FileInfo;

namespace DesktopMenu.DesktopMenu
{
    public partial class DesktopMenuDll
    {
        //连接到MySQL数据库
        private const string ConnStr = "server=10.55.2.20;user=merryte;database=sw_db;port=3306;password=merry@TE;";
        private static readonly MySqlConnection Conn = new MySqlConnection(ConnStr);

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
            MWin.EnterHfp();
        }

        public static void EnterA2DP()
        {
            MWin.OpenA2Dp();
        }

        /// <summary>
        /// 新增数据
        /// </summary>
        /// <param name="path"></param>
        /// <returns></returns>
        private static bool AddMysql()
        {
            const string counts = "SELECT COUNT(*) FROM up_version WHERE up_version.`name` = 'exeStartTool';";
            const string sql = "insert into up_version(id,name,versions,count,idx,describes) values(@id,@name,@versions,@count,@idx,@describes);";
            var versions = ReadExeStartTime();
            //判断versions长度
            if (versions.Length != 10) return false;
            //更新之前查询是否有相同版本的记录总数
            int columnCount = 0;
            Conn.Open();
            using (var command = new MySqlCommand(counts, Conn))
            {
                columnCount = Convert.ToInt32(command.ExecuteScalar());
                if (columnCount <= 0) return false;
                columnCount++;
            }


            var describe = MFormUtil.ShowInputDialog("描述", "请输入程序更新内容!");

            if (MFormUtil.MesBox("是否是强制更新", "版本确认?"))
            {
                Console.WriteLine("强制更新");
                //执行更新操作
                using (var command = new MySqlCommand(sql, Conn))
                {
                    command.Parameters.AddWithValue("@id", 0);
                    command.Parameters.AddWithValue("@name", "exeStartTool");
                    command.Parameters.AddWithValue("@versions", versions);
                    command.Parameters.AddWithValue("@count", columnCount);
                    command.Parameters.AddWithValue("@idx", 1);
                    command.Parameters.AddWithValue("@describes", describe);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }

                Conn.Close();
                return false;
            }
            else
            {
                Console.WriteLine("手动更新");
                //执行更新操作
                using (var command = new MySqlCommand(sql, Conn))
                {
                    command.Parameters.AddWithValue("@id", 0);
                    command.Parameters.AddWithValue("@name", "exeStartTool");
                    command.Parameters.AddWithValue("@versions", versions);
                    command.Parameters.AddWithValue("@count", columnCount);
                    command.Parameters.AddWithValue("@idx", 0);
                    command.Parameters.AddWithValue("@describes", describe);
                    if (command.ExecuteNonQuery() == 1)
                    {
                        return true;
                    }
                }

                Conn.Close();
                return false;
            }
        }

        /// <summary>
        /// 获取选中exeStartTool.exe的生成时间
        /// </summary>
        /// <returns></returns>
        public static string ReadExeStartTime()
        {
            // 指定要获取生成时间的可执行文件路径
            string path = _selectedPath.Replace(".zip", "") + @"\exeStartTool.exe";

            Console.WriteLine("时间路径格式化" + path);
            // 创建FileInfo对象以获取文件信息
            FileInfo fileInfo = new FileInfo(path);
            // 获取文件的生成时间
            DateTime creationTime = fileInfo.LastWriteTime;
            // 打印生成时间
            Console.WriteLine($"可执行文件的生成时间为：{creationTime.ToString("yyMMddHHmm")}");
            return creationTime.ToString("yyMMddHHmm");
        }

        /// <summary>
        /// 执行工程模式程序上传操作
        /// </summary>
        public static void TeUploadingEng()
        {
            const string http = "http://10.55.2.25:20005/api/PostUploadloadFileEngineeringMode";

            var up = new Task(() =>
            {
                _selectedPath = GetWindowsSelectedPath();
                Console.WriteLine("1.选中的路径为：" + _selectedPath);

                if (_selectedPath == null)
                {
                    MWin.MesBoxs( "未选中值不存在!", "错误");
                    return;
                }
                // 判断是否是exeStartTool文件夹
                if (_selectedPath.Contains("exeStartTool"))
                {
                    //判断数据是否上传
                    if (!AddMysql())
                    {
                        MWin.MesBoxs( "更新数据库错误!", "错误");
                    }
                }
                var ret = MFileTransfer.UploadZip(http, _selectedPath);
                MWin.MesBoxs(ret ? "上传成功!" : "上传失败!", "Message");
            });
            up.Start();
            up.Wait();
        }

        /// <summary>
        /// 执行下载操作
        /// </summary>
        public static void DownloadEngFile()
        {
            const string downPath = @"D:\TE-Download";
            const string unPath = @"D:\TE-Download";
            const string http = "http://10.55.2.25:20005/api/PostDownloadZIP";
            var down = new Task(() =>
            {
                var title = MFormUtil.ShowInputDialog("文件下载", "请输入要下载的文件名称");
                if (title == "")
                {
                    MFormUtil.ShowErr("提示", "不能为空");
                    return;
                }
                Console.WriteLine("下载中,请稍等...");
                var ret = MFileTransfer.DownloadZip(http, "EngineeringMode", downPath,
                    unPath, title);
                if (ret)
                {
                    MFile.OpenFile(downPath);
                    MWin.MesBoxs("下载完成", "下载");
                }
                else
                {
                    MWin.MesBoxs("下载失败", "下载");
                }
            });
            down.Start();
            down.Wait();
        }

       
    }
}