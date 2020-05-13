using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using System.Runtime.InteropServices;
using System.IO;

namespace Timer
{
    

    public partial class frmMain : Form
    {
        public class HotKeys
        {
            Dictionary<int, HotKeyCallBackHanlder> keymap = new Dictionary<int, HotKeyCallBackHanlder>();
            public delegate void HotKeyCallBackHanlder();
            public enum HotkeyModifiers
            {
                Alt = 1,
                Control = 2,
                Shift = 4,
                Win = 8
            }

            public void ProcessHotKey(Message m)
            {
                if (m.Msg == 0x312)
                {
                    int id = m.WParam.ToInt32();
                    HotKeyCallBackHanlder callback;
                    if (keymap.TryGetValue(id, out callback))
                        callback();
                }
            }
        }

        //全局快捷键类

        public class IniFile
        {
            private string FFileName;
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileInt(string lpAppName, string lpKeyName, int nDefault, string lpFileName);
            [DllImport("kernel32")]
            private static extern int GetPrivateProfileString(string lpAppName, string lpKeyName, string lpDefault,
            StringBuilder lpReturnedString, int nSize, string lpFileName);
            [DllImport("kernel32")]
            private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
            public IniFile(string filename)
            {
                FFileName = filename;
            }
            public int ReadInt(string section, string key, int def)
            {
                return GetPrivateProfileInt(section, key, def, FFileName);
            }
            public string ReadString(string section, string key, string def)
            {
                StringBuilder temp = new StringBuilder(1024);

                GetPrivateProfileString(section, key, def, temp, 1024, FFileName); return temp.ToString();
            }
            public void WriteInt(string section, string key, int iVal)
            {
                WritePrivateProfileString(section, key, iVal.ToString(), FFileName);
            }
            public void WriteString(string section, string key, string strVal)
            {
                WritePrivateProfileString(section, key, strVal, FFileName);
            }
            public void DelKey(string section, string key)
            {
                WritePrivateProfileString(section, key, null, FFileName);
            }
            public void DelSection(string section)
            {
                WritePrivateProfileString(section, null, null, FFileName);
            }
        }
        //ini文件类

        HotKeys h = new HotKeys();
        const int WM_KEYDOWN = 0x0100;
        const int WM_KEYUP = 0x0101;
        const int WM_CHAR = 0x0102;
        [DllImport("user32.dll", EntryPoint = "FindWindow")]
        private static extern IntPtr FindWindow(string lpClassName, string lpWindowName);
        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        private static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);
        [DllImport("user32.dll", EntryPoint = "PostMessage")]
        private static extern int PostMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "SendMessage")]
        private static extern int SendMessage(IntPtr hwnd, uint wMsg, int wParam, int lParam);
        [DllImport("user32.dll", EntryPoint = "WindowFromPoint")]
        private static extern IntPtr WindowFromPoint(int px, int py);
        [DllImport("kernel32")]
        private static extern bool WritePrivateProfileString(string lpAppName, string lpKeyName, string lpString, string lpFileName);
        [DllImport("user32.dll")]
        static extern bool RegisterHotKey(IntPtr hWnd, int id, int modifiers, Keys vk);
        [DllImport("user32.dll")]
        static extern bool UnregisterHotKey(IntPtr hWnd, int id);
        //winAPI声明

        delegate void SetTextCallback(string text);

        IntPtr hwndkp;
        private Point offset;
        Thread tNowTime;
        Thread tKeyPress1, tKeyPress2, tKeyPress3, tKeyPress4;
        static Boolean bShowBtn=true;
        static int KeyPressSleep1 = 100, KeyPressSleep2 = 100, KeyPressSleep3 = 100, KeyPressSleep4 = 100;
        public int KeyNum1 = 49, KeyNum2 = 50, KeyNum3 = 51, KeyNum4 = 52;
        IniFile finiset = new IniFile(".\\Timer.ini");
        KeyEventArgs e1, e2, e3, e4;
        public DateTime startTime;
        static int keyid = 202;
        //变量声明

        public delegate void Refreshfrm();
        Refreshfrm RefreshfrmNowTime;

        public frmMain()
        {
            InitializeComponent();
            
        }
        private void RefreshlabNowTime() 
        {
            labNowTime.Text = DateTime.Now.ToString("hh:mm:ss");
            labTimer.Text= (DateTime.Now - startTime).ToString();
            KeyNum1 = Convert.ToInt16(txtKeypress1.Text);
            KeyNum2 = Convert.ToInt16(txtKeypress2.Text);
            KeyNum3 = Convert.ToInt16(txtKeypress3.Text);
            KeyNum4 = Convert.ToInt16(txtKeypress4.Text);
            KeyPressSleep1 = Convert.ToInt16(txtKPTime1.Text);
            KeyPressSleep2 = Convert.ToInt16(txtKPTime2.Text);
            KeyPressSleep3 = Convert.ToInt16(txtKPTime3.Text);
            KeyPressSleep4 = Convert.ToInt16(txtKPTime4.Text);
        }
        public void RefreshNowTime()
        {
            while (1 == 1)
            {
                this.Invoke(RefreshfrmNowTime);
                Application.DoEvents();
                Thread.Sleep(100);
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            iniread();
            System.Windows.Forms.Keys key = (System.Windows.Forms.Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), txtHotKey.Text);
            fSaveNowTime();
            RefreshfrmNowTime = new Refreshfrm(RefreshlabNowTime);
            tNowTime = new Thread(RefreshNowTime);
            tNowTime.Start();
            fhotkeyChange();
            tKeyPress1 = new Thread(skp1);
            tKeyPress2 = new Thread(skp2);
            tKeyPress3 = new Thread(skp3);
            tKeyPress4 = new Thread(skp4);
        }

        private void iniread()
        {
            
            try
            {
                this.Left = finiset.ReadInt("Main", "X", 1);
                this.Top = finiset.ReadInt("Main", "Y", 1);
                txtKeypress1.Text = finiset.ReadString("KeyPress", "kp1", null);
                txtKeypress2.Text = finiset.ReadString("KeyPress", "kp2", null);
                txtKeypress3.Text = finiset.ReadString("KeyPress", "kp3", null);
                txtKeypress4.Text = finiset.ReadString("KeyPress", "kp4", null);
                txtKPTime1.Text = finiset.ReadString("KeyPress", "kpt1", null);
                txtKPTime2.Text = finiset.ReadString("KeyPress", "kpt2", null);
                txtKPTime3.Text = finiset.ReadString("KeyPress", "kpt3", null);
                txtKPTime4.Text = finiset.ReadString("KeyPress", "kpt4", null);
                txtHotKey.Text = finiset.ReadString("KeyPress", "HotKey", null);
                if (txtHotKey.Text == "") { txtHotKey.Text = "F10"; }
            }
            catch
            {

            }
        }
        //读取ini文件

        private void iniwrite()
        {
            try
            {
                finiset.WriteString("KeyPress", "HotKey", txtHotKey.Text);
                finiset.WriteString("KeyPress", "kp1", txtKeypress1.Text);
                finiset.WriteString("KeyPress", "kp2", txtKeypress2.Text);
                finiset.WriteString("KeyPress", "kp3", txtKeypress3.Text);
                finiset.WriteString("KeyPress", "kp4", txtKeypress4.Text);
                finiset.WriteString("KeyPress", "kpt1", txtKPTime1.Text);
                finiset.WriteString("KeyPress", "kpt2", txtKPTime2.Text);
                finiset.WriteString("KeyPress", "kpt3", txtKPTime3.Text);
                finiset.WriteString("KeyPress", "kpt4", txtKPTime4.Text);
                finiset.WriteInt("Main", "X", this.Left);
                finiset.WriteInt("Main", "Y", this.Top);
            }
            catch
            {

            }
        }
        //保存ini文件

        public void OnHotkey()
        {
            BTNKeyPressStart_Click(null,null);
        }
        //全局快捷键触发事件

        protected override void WndProc(ref Message m)//监视Windows消息
        {
            const int WM_HOTKEY = 0x0312;//按快捷键
            switch (m.Msg)
            {
                case WM_HOTKEY:
                    BTNKeyPressStart_Click(null,null);//调用主处理程序
                    break;
            }
            base.WndProc(ref m);
        }


        private void ffrmmousedown(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = this.PointToScreen(e.Location);
            offset = new Point(cur.X - this.Left, cur.Y - this.Top);
        }
        private void ffrmmousemove(object sender, MouseEventArgs e)
        {
            if (MouseButtons.Left != e.Button) return;
            Point cur = MousePosition;
            this.Location = new Point(cur.X - offset.X, cur.Y - offset.Y);
        }
        //点击任意位置移动窗体


        private void fSaveNowTime()
        {
            startTime = DateTime.Now;
        }
        //保存开始计时时间

        private void btnReset_Click(object sender, EventArgs e)
        {
            fSaveNowTime();
        }
        //重置按钮

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
                Application.Exit();
                Environment.Exit(0);
        }
        //下拉菜单-Exit

        private void sFormClose()
        {
            try
            {
                UnregisterHotKey(Handle, keyid);
            }
            catch
            {

            }
            try
            {
                tKeyPress1.Abort();
            }
            catch
            {

            }

            try
            {
                tKeyPress2.Abort();
            }
            catch
            {

            }
            try
            {
                tKeyPress3.Abort();
            }
            catch
            {

            }
            try
            {
                tKeyPress4.Abort();
            }
            catch
            {

            }
            try
            {
                tNowTime.Abort();
            }
            catch
            {

            }
            //防止退出线程未关闭
        }

        private void topToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (topToolStripMenuItem.Checked == true) { 
                this.TopMost = true; 
                this.Opacity = 0.6;
                transparentToolStripMenuItem.Visible = true;
                transparentToolStripMenuItem.Checked = true;
            }
            else { 
                this.TopMost = false; 
                this.Opacity = 1;
                transparentToolStripMenuItem.Visible = false;
                transparentToolStripMenuItem.Checked = false;
            }
        }
        //置顶并改变透明度

        private void labTime_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (bShowBtn == true) { bShowBtn = false; this.Height = 90; labNowTime.Visible = false; }
            else { bShowBtn = true; this.Height = 220; labNowTime.Visible = true; }
        }

        private void transparentToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (transparentToolStripMenuItem.Checked == true){
                transparentToolStripMenuItem.Checked = false;
            }
            else
            {
                transparentToolStripMenuItem.Checked = true;
            }
            if (transparentToolStripMenuItem.Checked==true){
                this.Opacity = 0.6;
            }
            else{
                this.Opacity=1;
            }
        }

        private void txtKeypress1_KeyDown(object sender, KeyEventArgs e)
        {
            e1 = e;
            TextBox sendertxtBox = (TextBox)sender;
            txtKeypress_KeyDown(sender, e, sendertxtBox);
            
        }

        private void txtKeypress2_KeyDown(object sender, KeyEventArgs e)
        {
            e2 = e;
            TextBox sendertxtBox = (TextBox)sender;
            txtKeypress_KeyDown(sender, e, sendertxtBox);
            
        }

        private void txtKeypress3_KeyDown(object sender, KeyEventArgs e)
        {
            e3 = e;
            TextBox sendertxtBox = (TextBox)sender;
            txtKeypress_KeyDown(sender, e, sendertxtBox);
            
        }

        private void txtKeypress4_KeyDown(object sender, KeyEventArgs e)
        {
            e4 = e;
            TextBox sendertxtBox = (TextBox)sender;
            txtKeypress_KeyDown(sender, e, sendertxtBox);
            
        }

        private void txtKeypress_KeyDown(object sender, KeyEventArgs e, TextBox sendertxtBox)
        {
            sendertxtBox.Text = e.KeyValue.ToString();
            switch (sendertxtBox.Name)
            {
                case "txtKeypress1":
                    {
                        break;
                    }
                case "txtKeypress2":
                    {
                        break;
                    }
                case "txtKeypress3":
                    {
                        break;
                    }
                case "txtKeypress4":
                    {
                        break;
                    }
            }
        }

        private void labNowTime_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            if (bShowBtn == true) { bShowBtn = false; this.Height = 50; }
            else { bShowBtn = true; this.Height = 220;  }
        }

        private void TXTKPTime1_TextChanged(object sender, EventArgs e)
        {
            TextBox sendertxtBox = (TextBox)sender;
            TXT_TextChanged(sender, e, sendertxtBox);
        }

        private void TXTKPTime1_KeyPress(object sender, KeyPressEventArgs e)
        {
            TextBox sendertxtBox = (TextBox)sender;
            TXTKPTime_Keypress(sender, e, sendertxtBox);
        }

        private void TXTKPTime_Keypress(object sender, KeyPressEventArgs e, TextBox sendertxtBox)
        {
            if (((int)e.KeyChar < 48 || (int)e.KeyChar > 57) && (int)e.KeyChar != 8)
                e.Handled = true;
        }

        private void TXT_TextChanged(object sender, EventArgs e, TextBox sendertxtBox)
        {
            try
            {
                if (sendertxtBox.Text == "")
                {
                    sendertxtBox.Text = "0";
                }
                if (Convert.ToInt64(sendertxtBox.Text)>30000){
                    sendertxtBox.Text = "";
                    sendertxtBox.Text = "30000";
                }
            }
            catch { }
        }

        private void BTNKeyPressStart_Click(object sender, EventArgs e)
        {
            //iniwrite();
            if (btnKeyPressStart.Text == "Start" && txtHotKey.Focused == false)
            {
                btnKeyPressStart.Text = "Stop";
                btnKeyPressStart.Enabled = true;
                labTimer.ForeColor = System.Drawing.Color.Red;
                hwndkp = WindowFromPoint(Cursor.Position.X, Cursor.Position.Y);
                if (KeyNum1 >=32 && KeyNum1<=225)
                {
                    tKeyPress1.Start();
                }
                if (KeyNum2 > 32 && KeyNum2 < 225)
                {
                    tKeyPress2.Start();
                }
                if (KeyNum3 > 32 && KeyNum3 < 225)
                {
                    tKeyPress3.Start();
                }
                if (KeyNum4 > 32 && KeyNum4 < 225)
                {
                    tKeyPress4.Start();
                }
            }
            else
            {
                btnKeyPressStart.Text = "Start";
                btnKeyPressStart.Enabled = false;
                labTimer.ForeColor = System.Drawing.Color.Black;
                try 
                {
                    tKeyPress1.Abort();
                }
                catch 
                {

                }
                
                try
                {
                    tKeyPress2.Abort();
                }
                catch
                {

                }
                try
                {
                    tKeyPress3.Abort();
                }
                catch
                {

                }
                try
                {
                    tKeyPress4.Abort();
                }
                catch
                {

                }
            }
        }

        void skp1()
        {
            while (hwndkp != IntPtr.Zero)
            {
                PostMessage(hwndkp, WM_KEYDOWN, KeyNum1, 0);
                Thread.Sleep(5);
                PostMessage(hwndkp, WM_KEYUP, KeyNum1, 0);
                Thread.Sleep(KeyPressSleep1);
            }
        }
        void skp2()
        {
            while (hwndkp != IntPtr.Zero)
            {
                PostMessage(hwndkp, WM_KEYDOWN, KeyNum2, 0);
                Thread.Sleep(5);
                PostMessage(hwndkp, WM_KEYUP, KeyNum2, 0);
                Thread.Sleep(KeyPressSleep2);
            }
        }
        void skp3()
        {
            while (hwndkp != IntPtr.Zero)
            {
                PostMessage(hwndkp, WM_KEYDOWN, KeyNum3, 0);
                Thread.Sleep(5);
                PostMessage(hwndkp, WM_KEYUP, KeyNum3, 0);
                Thread.Sleep(KeyPressSleep3);
            }
        }
        void skp4()
        {
            while (hwndkp != IntPtr.Zero)
            {
                PostMessage(hwndkp, WM_KEYDOWN, KeyNum4, 0);
                Thread.Sleep(5);
                PostMessage(hwndkp, WM_KEYUP, KeyNum4, 0);
                Thread.Sleep(KeyPressSleep4);
            }
        }

        private void txtHotKey_KeyDown(object sender, KeyEventArgs e)
        {
            txtHotKey.Text = e.KeyData.ToString();
            fhotkeyChange();
        }

        private void fhotkeyChange()
        {
            System.Windows.Forms.Keys key = (System.Windows.Forms.Keys)Enum.Parse(typeof(System.Windows.Forms.Keys), txtHotKey.Text);
            try
            {
                UnregisterHotKey(Handle, keyid);
            }
            catch
            {

            }
            for (int i = 202; i < 213; i++)
            {
                try
                {
                    if (txtHotKey.Text != "Escape")
                    {
                        RegisterHotKey(Handle, i, 0, key);
                    }
                    else
                    {
                    }
                }
                catch
                {

                }
                finally
                {
                    keyid=i;
                    i = 221;
                }
            }
        }

        private void btnSaveSetting_Click(object sender, EventArgs e)
        {
            iniwrite();
        }
    }
}
