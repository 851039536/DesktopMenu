namespace UcWindSystem
{
    partial class WindSystem
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            closeEthernet = new System.Windows.Forms.Button();
            devmgmt = new System.Windows.Forms.Button();
            PnlClose = new System.Windows.Forms.Panel();
            panel1 = new System.Windows.Forms.Panel();
            btnOsk = new System.Windows.Forms.Button();
            btnSysdm = new System.Windows.Forms.Button();
            btnControl = new System.Windows.Forms.Button();
            btnNcpa = new System.Windows.Forms.Button();
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            panel2 = new System.Windows.Forms.Panel();
            btnDisk = new System.Windows.Forms.Button();
            PnlClose.SuspendLayout();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // closeEthernet
            // 
            closeEthernet.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            closeEthernet.BackColor = System.Drawing.Color.LightCyan;
            closeEthernet.FlatAppearance.BorderSize = 0;
            closeEthernet.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            closeEthernet.Font = new System.Drawing.Font("微软雅黑",15F);
            closeEthernet.ForeColor = System.Drawing.Color.FromArgb(64,64,64);
            closeEthernet.Location = new System.Drawing.Point(7,6);
            closeEthernet.Margin = new System.Windows.Forms.Padding(7,6,7,6);
            closeEthernet.Name = "closeEthernet";
            closeEthernet.Size = new System.Drawing.Size(221,60);
            closeEthernet.TabIndex = 0;
            closeEthernet.Text = "清除以太网连接";
            closeEthernet.UseVisualStyleBackColor = false;
            closeEthernet.Click += closeEthernet_Click;
            // 
            // devmgmt
            // 
            devmgmt.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            devmgmt.BackColor = System.Drawing.Color.LightCyan;
            devmgmt.FlatAppearance.BorderSize = 0;
            devmgmt.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            devmgmt.Font = new System.Drawing.Font("微软雅黑",15F);
            devmgmt.ForeColor = System.Drawing.Color.FromArgb(64,64,64);
            devmgmt.Location = new System.Drawing.Point(20,6);
            devmgmt.Margin = new System.Windows.Forms.Padding(7,6,7,6);
            devmgmt.Name = "devmgmt";
            devmgmt.Size = new System.Drawing.Size(158,60);
            devmgmt.TabIndex = 1;
            devmgmt.Text = "装置管理";
            devmgmt.UseVisualStyleBackColor = false;
            devmgmt.Click += devmgmt_Click;
            // 
            // PnlClose
            // 
            PnlClose.BackColor = System.Drawing.Color.Silver;
            PnlClose.Controls.Add(closeEthernet);
            PnlClose.Location = new System.Drawing.Point(9,50);
            PnlClose.Margin = new System.Windows.Forms.Padding(2,4,2,4);
            PnlClose.Name = "PnlClose";
            PnlClose.Size = new System.Drawing.Size(417,235);
            PnlClose.TabIndex = 2;
            // 
            // panel1
            // 
            panel1.BackColor = System.Drawing.Color.Silver;
            panel1.Controls.Add(btnOsk);
            panel1.Controls.Add(btnSysdm);
            panel1.Controls.Add(btnControl);
            panel1.Controls.Add(btnNcpa);
            panel1.Controls.Add(devmgmt);
            panel1.Location = new System.Drawing.Point(459,50);
            panel1.Margin = new System.Windows.Forms.Padding(2,4,2,4);
            panel1.Name = "panel1";
            panel1.Size = new System.Drawing.Size(372,235);
            panel1.TabIndex = 3;
            // 
            // btnOsk
            // 
            btnOsk.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            btnOsk.BackColor = System.Drawing.Color.LightCyan;
            btnOsk.FlatAppearance.BorderSize = 0;
            btnOsk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnOsk.Font = new System.Drawing.Font("微软雅黑",15F);
            btnOsk.ForeColor = System.Drawing.Color.FromArgb(64,64,64);
            btnOsk.Location = new System.Drawing.Point(192,80);
            btnOsk.Margin = new System.Windows.Forms.Padding(7,6,7,6);
            btnOsk.Name = "btnOsk";
            btnOsk.Size = new System.Drawing.Size(158,60);
            btnOsk.TabIndex = 5;
            btnOsk.Text = "屏幕键盘";
            btnOsk.UseVisualStyleBackColor = false;
            btnOsk.Click += btnOsk_Click;
            // 
            // btnSysdm
            // 
            btnSysdm.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            btnSysdm.BackColor = System.Drawing.Color.LightCyan;
            btnSysdm.FlatAppearance.BorderSize = 0;
            btnSysdm.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnSysdm.Font = new System.Drawing.Font("微软雅黑",15F);
            btnSysdm.ForeColor = System.Drawing.Color.FromArgb(64,64,64);
            btnSysdm.Location = new System.Drawing.Point(20,80);
            btnSysdm.Margin = new System.Windows.Forms.Padding(7,6,7,6);
            btnSysdm.Name = "btnSysdm";
            btnSysdm.Size = new System.Drawing.Size(158,60);
            btnSysdm.TabIndex = 4;
            btnSysdm.Text = "系统属性";
            btnSysdm.UseVisualStyleBackColor = false;
            btnSysdm.Click += btnSysdm_Click;
            // 
            // btnControl
            // 
            btnControl.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            btnControl.BackColor = System.Drawing.Color.LightCyan;
            btnControl.FlatAppearance.BorderSize = 0;
            btnControl.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnControl.Font = new System.Drawing.Font("微软雅黑",15F);
            btnControl.ForeColor = System.Drawing.Color.FromArgb(64,64,64);
            btnControl.Location = new System.Drawing.Point(20,153);
            btnControl.Margin = new System.Windows.Forms.Padding(7,6,7,6);
            btnControl.Name = "btnControl";
            btnControl.Size = new System.Drawing.Size(158,60);
            btnControl.TabIndex = 3;
            btnControl.Text = "控制面板";
            btnControl.UseVisualStyleBackColor = false;
            btnControl.Click += btnControl_Click;
            // 
            // btnNcpa
            // 
            btnNcpa.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            btnNcpa.BackColor = System.Drawing.Color.LightCyan;
            btnNcpa.FlatAppearance.BorderSize = 0;
            btnNcpa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnNcpa.Font = new System.Drawing.Font("微软雅黑",15F);
            btnNcpa.ForeColor = System.Drawing.Color.FromArgb(64,64,64);
            btnNcpa.Location = new System.Drawing.Point(192,6);
            btnNcpa.Margin = new System.Windows.Forms.Padding(7,6,7,6);
            btnNcpa.Name = "btnNcpa";
            btnNcpa.Size = new System.Drawing.Size(158,60);
            btnNcpa.TabIndex = 2;
            btnNcpa.Text = "网络连接";
            btnNcpa.UseVisualStyleBackColor = false;
            btnNcpa.Click += btnNcpa_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(9,14);
            label1.Margin = new System.Windows.Forms.Padding(2,0,2,0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(92,27);
            label1.TabIndex = 4;
            label1.Text = "清理操作";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(459,14);
            label2.Margin = new System.Windows.Forms.Padding(2,0,2,0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(92,27);
            label2.TabIndex = 5;
            label2.Text = "系统操作";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new System.Drawing.Point(9,302);
            label3.Margin = new System.Windows.Forms.Padding(2,0,2,0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(92,27);
            label3.TabIndex = 6;
            label3.Text = "文件操作";
            // 
            // panel2
            // 
            panel2.BackColor = System.Drawing.Color.Silver;
            panel2.Controls.Add(btnDisk);
            panel2.Location = new System.Drawing.Point(9,337);
            panel2.Margin = new System.Windows.Forms.Padding(2,4,2,4);
            panel2.Name = "panel2";
            panel2.Size = new System.Drawing.Size(417,178);
            panel2.TabIndex = 7;
            // 
            // btnDisk
            // 
            btnDisk.AccessibleRole = System.Windows.Forms.AccessibleRole.TitleBar;
            btnDisk.BackColor = System.Drawing.Color.LightCyan;
            btnDisk.FlatAppearance.BorderSize = 0;
            btnDisk.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            btnDisk.Font = new System.Drawing.Font("微软雅黑",15F);
            btnDisk.ForeColor = System.Drawing.Color.FromArgb(64,64,64);
            btnDisk.Location = new System.Drawing.Point(7,6);
            btnDisk.Margin = new System.Windows.Forms.Padding(7,6,7,6);
            btnDisk.Name = "btnDisk";
            btnDisk.Size = new System.Drawing.Size(158,60);
            btnDisk.TabIndex = 0;
            btnDisk.Text = "公共网盘";
            btnDisk.UseVisualStyleBackColor = false;
            btnDisk.Click += btnDisk_Click;
            // 
            // WindSystem
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(12F,27F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            Controls.Add(panel2);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            Controls.Add(PnlClose);
            Font = new System.Drawing.Font("微软雅黑",15F,System.Drawing.FontStyle.Regular,System.Drawing.GraphicsUnit.Point,134);
            Margin = new System.Windows.Forms.Padding(7,6,7,6);
            Name = "WindSystem";
            Size = new System.Drawing.Size(1277,748);
            Load += WindSystem_Load_1;
            Resize += WindSystem_Resize;
            PnlClose.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button closeEthernet;
        private System.Windows.Forms.Button devmgmt;
        private System.Windows.Forms.Panel PnlClose;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btnNcpa;
        private System.Windows.Forms.Button btnControl;
        private System.Windows.Forms.Button btnSysdm;
        private System.Windows.Forms.Button btnOsk;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnDisk;
    }
}
