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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace Cliver.fril.jp
{
    public partial class SysTray : BaseForm//Form //
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
            settingsToolStripMenuItem_Click(null, null);
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            BrowserForm bf = new BrowserForm();
            bf.ShowDialog();
    //        if(bf !=null)
    //        {
    //            bf.Activate();
    //            return;
    //        }
    //bf = new BrowserForm();
    //bf.ShowDialog();
    //        bf = null;
        }
//BrowserForm bf = null;

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
    }
}
