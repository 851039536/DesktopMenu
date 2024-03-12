using System;
using System.Threading;
using DesktopMenu.DesktopMenu;
using MechTE_480.ProcessCategory;

namespace DesktopMenu
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            FtpHelper ftp = new FtpHelper(@"10.55.2.25", 21, "anonymous", "", @"/190006");
            ftp.Delete(@"/190006/test/123.exe");
            ftp.DeleteDirectory(@"/190006/test2");

            Console.WriteLine("值0:" + args[0]);
            Console.WriteLine("值1:" + args[1]);
            switch (args[1])
            {
                case "QiNiuUpLoading":
                    DesktopMenuDll.QiNiuUpLoading(DesktopMenuDll.GetWindowsSelectedPath());
                    break;
                case "TeUploadingEng":
                    DesktopMenuDll.TeUploadingEng();
                    break;
                case "SystemFunctionList":
                    DesktopMenuDll.SystemFunctionList();
                    break;
                case "EnterHfp":
                    DesktopMenuDll.EnterHfp();
                    break;
                case "EnterA2DP":
                    DesktopMenuDll.EnterA2DP();
                    break;
                case "downloadEng":
                    DesktopMenuDll.DownloadEngFile();
                    break;
                case "SimpleHIDWrite":
                    DesktopMenuDll.OpenSimpleHidWrite();
                    break;
                case "Airoha_ANC_Debug_Tool":
                    DesktopMenuDll.Airoha_ANC_Debug_Tool();
                    break;
                case "SwWebsite":
                    MProcessUtil.StartApp("http://10.55.2.25:8099/");
                    break;
                case "TestTheData":
                    DesktopMenuDll.OpenTestTheData();
                    break;
                case "VersionSystem":
                    DesktopMenuDll.OpenVersionSystem();
                    break;
                case "BackgroundSystem":
                    DesktopMenuDll.OpenBackgroundSystem();
                    break;
                case "unload":
                    DesktopMenuDll.Unload();
                    break;
                case "ToolConfig":
                    DesktopMenuDll.ToolConfig();
                    break;
                case "SystemConfig":
                    DesktopMenuDll.SystemConfig();
                    break;
            }

            Thread.Sleep(2000);
        }
    }
}