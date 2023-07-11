using System;
using System.Threading;

namespace EngineeringMode
{
    internal class Program
    {
        
        public static void Main(string[] args)
        {
            Console.WriteLine("值0:"+args[0]);
            Console.WriteLine("值1:"+args[1]);
            switch (args[1])
            {
                case "uploadingEng":// 上传
                    EngineeringFile.UpEngFile();
                    break;   
                case "downloadEng":// 下载
                    EngineeringFile.DownloadEngFile();
                    break;   
                case "SimpleHIDWrite"://hid验证工具.
                    EngineeringFile.OpenSimpleHidWrite();
                    break;    
                case "SwWebsite":
                    EngineeringFile.OpenSwWebsite();
                    break;   
                case "TestTheData":
                    EngineeringFile.OpenTestTheData();
                    break; 
                case "VersionSystem":
                    EngineeringFile.OpenVersionSystem();
                    break;  
                case "BackgroundSystem":
                    EngineeringFile.OpenBackgroundSystem();
                    break;
            }
            
            Thread.Sleep(4000);
        }
    }
}