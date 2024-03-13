using System;
using MechTE_480.Files;
using MechTE_480.FormCategory;
using MechTE_480.Windows;
using Qiniu.Http;
using Qiniu.Storage;
using Qiniu.Util;

namespace DesktopMenu.QiNiu
{
    public static class QiNiuHelper
    {
        private const string AccessKey = "rKyHGPMv87TXon7_IIBlUdAgORhH_EdTb7OhPWjI";
        private const string SecretKey = "0N2b3nywVEznTNhxNBWqD9eEueAi8965FifWIkwm";
        //// 设置空间名,可以是公开或者私有的
        private const string Bucket = "haiwaikai";

        /// <summary>
        /// 上传本地文件到七牛云
        /// </summary>
        /// <param name="specified">指定云空间文件夹: 如sw/</param>
        /// <param name="upLoadFile">本地路径</param>
        /// <returns></returns>
        public static bool QiNiuUpLoading(string  specified, string upLoadFile)
        {
            string saveKey = MFile.GetFileName(upLoadFile);

            DeleteFile(specified+saveKey); //上传之前删除文件
            // 上传策略
            var putPolicy = new PutPolicy();
            // 上传策略的过期时间(单位:秒)
            putPolicy.SetExpires(3600);
            // 文件上传完毕后，在多少天后自动被删除
            // putPolicy.DeleteAfterDays = 1;
            // 设置要上传的目标空间
            putPolicy.Scope = Bucket;

            //自定义这个返回的JSON格式的内容
            putPolicy.ReturnBody = "{\"key\":\"$(key)\",\"hash\":\"$(etag)\",\"fsiz\":$(fsize),\"bucket\":\"$(bucket)\",\"name\":\"$(x:name)\"}";

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
                // 空间对应的机房
                Zone = Zone.ZONE_AS_Singapore,
                ChunkSize = ChunkUnit.U512K
            };
            // 表单上传
            FormUploader target = new FormUploader(config);

            //设置上传的文件名
            string key = specified + saveKey;
            
            HttpResult result = target.UploadFile(filePath, key, token, null);
            if (result.Code != 200)
            {
                MWin.MesBoxs("上传失败!", "Message");
                return false;
            }

            MWin.MesBoxs("上传成功!", "Message");
            return true;
        }

        /// <summary>
        /// 下载文件,公开空间使用
        /// </summary>
        /// <param name="url">云文件路径: 如http://kai.xxx.cn/blog/article/1.jpg</param>
        /// <param name="localFileFullName">下载到本地 : @"C:\Users\ch190006\Desktop\test\123.exe"</param>
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


        /// <summary>
        /// 获取空间文件列表  
        /// </summary>
        /// <param name="fileName">如果为空则查询所有文件</param>
        public static void ListFiles(string fileName)
        {
            Mac mac = new Mac(AccessKey, SecretKey);

            string marker = ""; // 首次请求时marker必须为空
            string prefix = fileName; // 按文件名前缀保留搜索结果
            string delimiter =null; // 目录分割字符(比如"/")
            int limit = 100;

            BucketManager bm = new BucketManager(mac,new Config());
            //List<FileDesc> items = new List<FileDesc>();
            //List<string> commonPrefixes = new List<string>();

            do
            {
                ListResult result = bm.ListFiles(Bucket, prefix, marker, limit, delimiter);

                Console.WriteLine(result);
                marker = result.Result.Marker;

                foreach (var resultItem in result.Result.Items)
                {
                    MFormUtil.MesBox(resultItem.Key, "Message");
                }

                //if (result.Result.Items != null)
                //{
                //    items.AddRange(result.Result.Items);
                //}

                //if (result.Result.CommonPrefixes != null)
                //{
                //    commonPrefixes.AddRange(result.Result.CommonPrefixes);
                //}

            } while (!string.IsNullOrEmpty(marker));

            //foreach (string cp in commonPrefixes)
            //{
            //    Console.WriteLine(cp);
            //}

            //foreach(var item in items)
            //{
            //    Console.WriteLine(item.Key);
            //}
        }
        
    }
}