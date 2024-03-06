using System;
using System.Diagnostics;
using System.Threading.Tasks;
using MechTE_480.Files;
using MechTE_480.Form;
using MechTE_480.Windows;
using MySql.Data.MySqlClient;
using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;
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


            var describe = MForm.ShowInputDialog("描述", "请输入程序更新内容!");

            if (MForm.MesBox("是否是强制更新", "版本确认?"))
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
                //弹窗确认是否上传
                // if (!MForm.MesBox(_selectedPath, "确认上传?")) return;
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
                var title = MForm.ShowInputDialog("文件下载", "请输入要下载的文件名称");
                if (title == "")
                {
                    MForm.ShowErr("提示", "不能为空");
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


        private const string AccessKey = "rKyHGPMv87TXon7_IIBlUdAgORhH_EdTb7OhPWjI";
        private const string SecretKey = "0N2b3nywVEznTNhxNBWqD9eEueAi8965FifWIkwm";
        private const string Bucket = "ksoftware"; // //空间名，可以是公开或者私有的

        /// <summary>
        /// 上传本地文件到七牛云
        /// </summary>
        /// <param name="upLoadFile">本地路径</param>
        /// <returns></returns>
        public static bool QiNiuUpLoading(string upLoadFile)
        {
            string fileName = System.IO.Path.GetFileNameWithoutExtension(upLoadFile);

            DeleteFile(fileName); //上传之前删除文件
            // 上传策略
            PutPolicy putPolicy = new PutPolicy();
            // 上传策略的过期时间(单位:秒)
            putPolicy.SetExpires(3600);
            // 文件上传完毕后，在多少天后自动被删除
            // putPolicy.DeleteAfterDays = 1;
            // 设置要上传的目标空间
            putPolicy.Scope = Bucket;

            Mac mac = new Mac(AccessKey, SecretKey);
            // 上传文件名
            string filePath = upLoadFile; //上传路径
            // 生成上传token
            string token = Auth.CreateUploadToken(mac, putPolicy.ToJsonString());
            Config config = new Config
            {
                // 设置 http 或者 https 上传
                UseHttps = false,
                // 上传是否使用cdn加速
                UseCdnDomains = false,
                // 设置上传区域
                // config.Zone = Zone.ZONE_CN_North;
                ChunkSize = ChunkUnit.U512K
            };
            // 表单上传
            FormUploader target = new FormUploader(config);
            HttpResult result = target.UploadFile(filePath, fileName, token, null);
            if (result.Code != 200)
            {
                MWin.MesBoxs("上传失败!", "Message");
                return false;
            }

            MWin.MesBoxs("上传成功!", "Message");
            return true;
        }

        /// <summary>
        /// 云文件路径
        /// </summary>
        /// <param name="url">云文件路径</param>
        /// <param name="localFileFullName">名称 , 自定义</param>
        /// <returns></returns>
        public static bool DownloadFile(string url, string localFileFullName)
        {
            //文件链接地址:http://oio2cxdal.bkt.clouddn.com/1/20170213231810.jpg
            var ret = DownloadManager.Download(url, localFileFullName);
            if (ret.Code == 200)
            {
                Console.WriteLine("下载完成");
                return true;
            }

            return false;
        }

        /// <summary>
        /// 根据文件名删除文件
        /// </summary>
        /// <param name="saveKey"></param>
        private static bool DeleteFile(string saveKey)
        {
            Mac mac = new Mac(AccessKey, SecretKey);
            BucketManager bm = new BucketManager(mac, new Config());

            var ret = bm.Delete(Bucket, saveKey);
            if (ret.Code == 200)
            {
                Console.WriteLine("文件已删除");
                return true;
            }
            return false;
        }
    }
}