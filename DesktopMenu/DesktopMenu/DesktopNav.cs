using MechTE_480.Order;

namespace DesktopMenu.DesktopMenu
{
    /// <summary>
    /// 导航
    /// </summary>
    public static partial class DesktopMenuDll
    {
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
        
        /// <summary>
        /// //hid验证工具
        /// </summary>
        public static void OpenSimpleHidWrite()
        {
            MechCmd.StartShell(CurrentPath + @"\SimpleHIDWrite\SimpleHIDWrite.exe");
        }   
        public static void Airoha_ANC_Debug_Tool()
        {
            MechCmd.StartShell(CurrentPath + @"\Airoha_ANC_Debug_Tool\Airoha_ANC_Debug_Tool.exe");
        }
    }
}