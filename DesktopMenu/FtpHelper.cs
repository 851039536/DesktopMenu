using System.Collections.Generic;
using System.IO;
using FluentFTP;

namespace DesktopMenu
{
    public class FtpHelper
    {
        #region 属性与构造函数

        /// <summary>
        /// IP地址
        /// </summary>
        public string IpAddr { get; set; }

        /// <summary>
        /// 相对路径
        /// </summary>
        public string RelatePath { get; set; }

        /// <summary>
        /// 端口号
        /// </summary>
        public int Port { get; set; }

        /// <summary>
        /// 用户名
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// 密码
        /// </summary>
        public string Password { get; set; }

        public FtpHelper()
        {
        }

        /// <summary>
        /// 对象
        /// </summary>
        /// <param name="ipAddr">xx.xx.x.x</param>
        /// <param name="port">串口</param>
        /// <param name="userName">用户</param>
        /// <param name="password">密码</param>
        /// <param name="relatePath">路径如 /xxxx</param>
        public FtpHelper(string ipAddr, int port, string userName, string password, string relatePath)
        {
            IpAddr = ipAddr;
            Port = port;
            UserName = userName;
            Password = password;
            RelatePath = relatePath;
        }

        #endregion

        #region 方法

        /// <summary>
        /// 获取指定文件内容
        /// </summary>
        /// <returns></returns>
        public IEnumerable<FtpListItem> ListDir()
        {
            FtpListItem[] lists;
            using (var ftpClient = new FtpClient(this.IpAddr, this.UserName, this.Password, this.Port))
            {
                // 设置匿名登录，无需密码  
                // if (UserName == "anonymous")
                // {
                //     ftpClient.Credentials = new NetworkCredential("anonymous", string.Empty);
                // }
                ftpClient.Connect();
                ftpClient.SetWorkingDirectory(this.RelatePath);
                lists = ftpClient.GetListing();
            }

            return lists;
        }

        /// <summary>
        /// 上传文件到FTP服务器
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="file"></param>
        /// <param name="isOk"></param>
        public void UpLoad(string dir, string file, out bool isOk)
        {
            isOk = false;
            FileInfo fi = new FileInfo(file);
            using (FileStream fs = fi.OpenRead())
            {
                //long length = fs.Length;
                using (var ftpClient = new FtpClient(this.IpAddr, this.UserName, this.Password, this.Port))
                {
                    ftpClient.Connect();
                    ftpClient.SetWorkingDirectory(this.RelatePath);
                    string remotePath = dir + "/" + Path.GetFileName(file);
                    FtpRemoteExists ftpRemodeExistsMode;

                    // if (file.EndsWith(".txt"))
                    // {
                    ftpRemodeExistsMode = FtpRemoteExists.Overwrite;
                    // }
                    // else
                    // {
                    //     ftpRemodeExistsMode = FtpRemoteExists.Skip;
                    // }
                    FtpStatus status = ftpClient.UploadStream(fs, remotePath, ftpRemodeExistsMode, true);

                    isOk = status == FtpStatus.Success;
                }
            }
        }

        /// <summary>
        /// 上传多个文件
        /// </summary>
        /// <param name="dir"></param>
        /// <param name="files"></param>
        /// <param name="isOk"></param>
        public void UpLoad(string dir, string[] files, out bool isOk)
        {
            isOk = false;
            if (CheckDirIsExists(dir))
            {
                foreach (var file in files)
                {
                    UpLoad(dir, file, out isOk);
                }
            }
        }

        /// <summary>
        /// 上传指定文件夹到服务器
        /// </summary>
        /// <param name="localFolderPath"></param>
        /// <param name="remoteFolderPath"></param>
        public void UpLoadDirectory(string localFolderPath, string remoteFolderPath)
        {
            using (var ftpClient = new FtpClient(this.IpAddr, this.UserName, this.Password, this.Port))
            {
                ftpClient.Connect();
                ftpClient.SetWorkingDirectory(this.RelatePath);
                var ret = ftpClient.UploadDirectory(localFolderPath, remoteFolderPath);
            }
        }

        /// <summary>
        /// 删除ftp文件夹
        /// </summary>
        /// <param name="localFolderPath"></param>
        public void DeleteDirectory(string localFolderPath)
        {
            using (var ftpClient = new FtpClient(this.IpAddr, this.UserName, this.Password, this.Port))
            {
                ftpClient.Connect();
                ftpClient.SetWorkingDirectory(this.RelatePath);
                ftpClient.DeleteDirectory(localFolderPath);
            }
        }

        /// <summary>
        /// 删除ftp文件
        /// </summary>
        /// <param name="file"></param>
        public void Delete(string file)
        {
            using (var ftpClient = new FtpClient(this.IpAddr, this.UserName, this.Password, this.Port))
            {
                ftpClient.Connect();
                ftpClient.SetWorkingDirectory(this.RelatePath);
                ftpClient.DeleteFile(file);
            }
        }


        /// <summary>
        /// 检查FTP服务器上指定目录是否存在。如果目录不存在，则创建该目录
        /// </summary>
        /// <param name="dir"></param>
        /// <returns></returns>
        private bool CheckDirIsExists(string dir)
        {
            bool flag = false;
            using (var ftpClient = new FtpClient(this.IpAddr, this.UserName, this.Password, this.Port))
            {
                ftpClient.Connect();
                // 设置FTP工作目录
                ftpClient.SetWorkingDirectory(RelatePath);
                flag = ftpClient.DirectoryExists(dir);
                if (!flag)
                {
                    // 如果目录不存在，则创建目录
                    flag = ftpClient.CreateDirectory(dir);
                }
            }

            return flag;
        }

        /// <summary>
        /// 下载指定文件信息(txt,exe等)
        /// </summary>
        /// <param name="localAddress">本地地址</param>
        /// <param name="remoteAddress">远程地址</param>
        /// <returns></returns>
        public bool DownloadFile(string localAddress, string remoteAddress)
        {
            using (var ftpClient = new FtpClient(this.IpAddr, this.UserName, this.Password, this.Port))
            {
                ftpClient.SetWorkingDirectory("/");
                ftpClient.Connect();
                if (ftpClient.DownloadFile(localAddress, remoteAddress) == FtpStatus.Success)
                {
                    return true;
                }

                return false;
            }
        }

        /// <summary>
        /// 下载指定文件夹内的信息
        /// </summary>
        /// <param name="localAddress"></param>
        /// <param name="remoteAddress"></param>
        /// <returns></returns>
        public bool DownloadDirectory(string localAddress, string remoteAddress)
        {
            using (var ftpClient = new FtpClient(this.IpAddr, this.UserName, this.Password, this.Port))
            {
                ftpClient.SetWorkingDirectory("/");
                ftpClient.Connect();
                var ret = ftpClient.DownloadDirectory(localAddress, remoteAddress);
                if (ret.Count > 0)
                {
                    return true;
                }

                return false;
            }
        }

        #endregion
    }
}