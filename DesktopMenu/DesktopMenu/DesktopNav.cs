using MechTE_480.Files;
using MechTE_480.Order;

namespace DesktopMenu.DesktopMenu
{
    /// <summary>
    /// 导航
    /// </summary>
    public partial class DesktopMenuDll
    {
        public static void OpenTestTheData()
        {
            MechProcess.StartApp("http://10.55.2.25:8089/");
        }

        public static void OpenVersionSystem()
        {
            MechProcess.StartApp("http://10.55.2.25:9999/");
        }

        public static void OpenBackgroundSystem()
        {
            MechProcess.StartApp("http://10.55.2.25:9000/");
        }

        /// <summary>
        /// //hid验证工具
        /// </summary>
        public static void OpenSimpleHidWrite()
        {
            MechProcess.StartShell(CurrentPath + @"\SimpleHIDWrite\SimpleHIDWrite.exe");
        }

        public static void Airoha_ANC_Debug_Tool()
        {
            MechProcess.StartShell(CurrentPath + @"\Airoha_ANC_Debug_Tool\Airoha_ANC_Debug_Tool.exe");
        }

        public static void OpenConfig()
        {
            MechProcess.StartShell(CurrentPath + @"\config\Config.txt");
        }

   
    }
}