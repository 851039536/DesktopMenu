using PlugInProgram;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace UcWindSystem
{
    public partial class WindSystem : UserControlBase
    {


        /// <summary>
        /// 定义当前窗体的宽度
        /// </summary>
        public static float X;
        /// <summary>
        /// 定义当前窗体的高度
        /// </summary>
        public static float Y;
        /// <summary>
        /// 控件大小随窗体大小等比例缩放,
        /// 在窗体重载中使用
        /// </summary>
        /// <param name="cons"></param>
        public static void SetTag(Control cons)
        {
            foreach (Control con in cons.Controls)
            {
                con.Tag = con.Width + ";" + con.Height + ";" + con.Left + ";" + con.Top + ";" + con.Font.Size;
                if (con.Controls.Count > 0)
                {
                    SetTag(con);
                }
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="newx"></param>
        /// <param name="newy"></param>
        /// <param name="cons"></param>
        public static void SetControls(float newx,float newy,Control cons)
        {
            //遍历窗体中的控件，重新设置控件的值
            foreach (Control con in cons.Controls)
            {
                //获取控件的Tag属性值，并分割后存储字符串数组
                if (con.Tag != null)
                {
                    string[] mytag = con.Tag.ToString().Split(new char[]
                    {
                ';'
                    });
                    //根据窗体缩放的比例确定控件的值
                    con.Width = Convert.ToInt32(System.Convert.ToSingle(mytag[0]) * newx); //宽度
                    con.Height = Convert.ToInt32(System.Convert.ToSingle(mytag[1]) * newy); //高度
                    con.Left = Convert.ToInt32(System.Convert.ToSingle(mytag[2]) * newx); //左边距
                    con.Top = Convert.ToInt32(System.Convert.ToSingle(mytag[3]) * newy); //顶边距
                    Single currentSize = System.Convert.ToSingle(mytag[4]) * newy; //字体大小
                    con.Font = new Font(con.Font.Name,currentSize,con.Font.Style,con.Font.Unit);
                    if (con.Controls.Count > 0)
                    {
                        SetControls(newx,newy,con);
                    }
                }
            }
        }
        public WindSystem()
        {
            InitializeComponent();
            ucName = "wind常用"; // 插件名称
        }

        private void closeEthernet_Click(object sender,EventArgs e)
        {
            OpenProcess(@"\bat\CloseEthernet.bat",true);
        }

        private static void OpenProcess(string name,bool idx)
        {
            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.UseShellExecute = true;
            startInfo.WorkingDirectory = Environment.CurrentDirectory;
            startInfo.FileName = Environment.CurrentDirectory + name;
            if (idx)
            {
                startInfo.Verb = "runas";
            }
            try
            {
                Process.Start(startInfo);
            } catch (Exception ex)
            {
                Console.WriteLine("无法以管理员权限重新启动应用程序：" + ex.Message);
            }
        }

        private void devmgmt_Click(object sender,EventArgs e)
        {
            devmgmt.Enabled = false;
            Thread.Sleep(2000);
            StartShell("devmgmt.msc");
            devmgmt.Enabled = true;
        }


        public static void StartShell(string cmd)
        {
            ExeCommand(new string[1] { cmd });
        }
        private static void ExeCommand(IEnumerable<string> commandTexts)
        {
            Process process = new Process();
            process.StartInfo.FileName = "cmd.exe";
            process.StartInfo.UseShellExecute = false;
            process.StartInfo.RedirectStandardInput = true;
            process.StartInfo.RedirectStandardOutput = true;
            process.StartInfo.RedirectStandardError = true;
            process.StartInfo.CreateNoWindow = true;
            try
            {
                process.Start();
                foreach (string commandText in commandTexts)
                {
                    process.StandardInput.WriteLine(commandText);
                }

                process.StandardInput.WriteLine("exit");
                process.StandardOutput.ReadToEnd();
                process.WaitForExit();
                process.Close();
            } catch (Exception)
            {
            }
        }

        private void btnNcpa_Click(object sender,EventArgs e)
        {
            btnNcpa.Enabled = false;
            Thread.Sleep(2000);
            StartShell("ncpa.cpl");
            btnNcpa.Enabled = true;
        }

        private void btnControl_Click(object sender,EventArgs e)
        {
            btnControl.Enabled = false;
            Thread.Sleep(2000);
            StartShell("control");
            btnControl.Enabled = true;
        }

        private void btnSysdm_Click(object sender,EventArgs e)
        {

            btnSysdm.Enabled = false;
            Thread.Sleep(2000);
            StartShell("sysdm.cpl");
            btnSysdm.Enabled = true;
        }

        private void btnOsk_Click(object sender,EventArgs e)
        {
            btnOsk.Enabled = false;
            Thread.Sleep(2000);
            StartShell("osk");
            btnOsk.Enabled = true;
        }
        [DllImport("shell32.dll")]
        private static extern int ShellExecute(IntPtr hwnd,StringBuilder lpszOp,StringBuilder lpszFile,StringBuilder lpszParams,StringBuilder lpszDir,int fsShowCmd);


        public static void OpenFile(string path,int fsShow = 1)
        {
            ShellExecute(IntPtr.Zero,new StringBuilder("Open"),new StringBuilder(path),new StringBuilder(""),new StringBuilder(""),fsShow);
        }
        private void btnDisk_Click(object sender,EventArgs e)
        {
            btnDisk.Enabled = false;
            Thread.Sleep(2000);
            OpenFile(@"\\10.55.2.3\mech_production_line_sharing\03_use_by_te_all");
            btnDisk.Enabled = true;

        }

        private void WindSystem_Load_1(object sender,EventArgs e)
        {
            RichTextBox rtb = new RichTextBox();
            this.Controls.Add(rtb);
            rtb.Dock = DockStyle.Fill;

            X = this.Width;
            Y = this.Height;
            SetTag(this);
        }

        private void WindSystem_Resize(object sender,EventArgs e)
        {
            float newX = this.Width / X; //获取当前宽度与初始宽度的比例
            float newY = this.Height / Y; //获取当前高度与初始高度的比例
            SetControls(newX,newY,this);
        }
    }
}
