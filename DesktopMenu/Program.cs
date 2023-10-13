using System;
using System.Threading;
using DesktopMenu.DesktopMenu;

namespace DesktopMenu
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("值0:" + args[0]);
            Console.WriteLine("值1:" + args[1]);
            switch (args[1])
            {
                case "uploadingEng":
                    DesktopMenuDll.UpEngFile();
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
                    DesktopMenuDll.OpenSwWebsite();
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
                case "Config":
                    DesktopMenuDll.OpenConfig();
                    break;
            }

            Thread.Sleep(4000);
        }
    }
}