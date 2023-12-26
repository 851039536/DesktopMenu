using MechTE_480.process;

namespace DesktopMenu.DesktopMenu
{
    /// <summary>
    /// 导航
    /// </summary>
    public partial class DesktopMenuDll
    {
        private static void StartApp(string name)
        {
            MProcess.StartApp(name);
        }

        public static void OpenTestTheData()
        {
            StartApp("http://10.55.2.25:8089/");
        }

        public static void OpenVersionSystem()
        {
            StartApp("http://10.55.2.25:9999/");
        }

        public static void OpenBackgroundSystem()
        {
            StartApp("http://10.55.2.25:9000/");
        }

        /// <summary>
        /// //hid验证工具
        /// </summary>
        public static void OpenSimpleHidWrite()
        {
            MProcess.Shell(CurrentPath + @"\SimpleHIDWrite\SimpleHIDWrite.exe");
        }

        public static void Airoha_ANC_Debug_Tool()
        {
            MProcess.Shell(CurrentPath + @"\Airoha_ANC_Debug_Tool\Airoha_ANC_Debug_Tool.exe");
        }

        public static void ToolConfig()
        {
            MProcess.Shell(CurrentPath + @"\config\ToolConfig.txt");
        }
        public static void SystemConfig()
        {
            MProcess.Shell(CurrentPath + @"\config\SystemConfig.txt");
        }


    }
}