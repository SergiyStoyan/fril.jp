//********************************************************************************************
//Author: Sergey Stoyan, CliverSoft.com
//        http://cliversoft.com
//        stoyan@cliversoft.com
//        sergey.stoyan@gmail.com
//        27 February 2007
//Copyright: (C) 2007, Sergey Stoyan
//********************************************************************************************

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Cliver.fril.jp
{
    public partial class SysTray : Form //BaseForm//
    {
        SysTray()
        {
            InitializeComponent();

            RightClickMenu.Opening += RightClickMenu_Opening;
        }

        private void RightClickMenu_Opening(object sender, CancelEventArgs e)
        {
            StartStop.Checked = Service.Running;
        }

        public static readonly SysTray This = new SysTray();

        private void notifyIcon1_DoubleClick(object sender, EventArgs e)
        {
            scheduleToolStripMenuItem_Click(null, null);
        }

        private void scheduleToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowserForm.Open();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AboutForm.Open();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Program.Exit();
            Environment.Exit(0);
        }

        private void SysTray_VisibleChanged(object sender, EventArgs e)
        {
            this.Visible = false;
        }

        private void notifyIcon1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void StartStop_CheckedChanged(object sender, EventArgs e)
        {
            Service.Running = StartStop.Checked;
        }

        private void workDirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Process.Start(Log.WorkDir);
        }

        private void notifyIcon_MouseClick(object sender, MouseEventArgs e)
        {
        }

        private void SettingsStripMenuItem_Click(object sender, EventArgs e)
        {
            SettingsForm.Open();
        }
    }
}
