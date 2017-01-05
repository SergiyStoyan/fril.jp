using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Cliver;

namespace Cliver.fril.jp
{
    public partial class ScheduleForm : BaseForm//Form//
    {
        public ScheduleForm()
        {
            InitializeComponent();

            schedules.ValueMember = "Time";
            schedules.DisplayMember = "Text";

            Text = "Schedules";

            foreach (string n in Settings.Schedules.Names2Schedule.Keys)
                schedules.Items.Add(n);
        }

        private void bRemove_Click(object sender, EventArgs e)
        {
            if (schedules.SelectedIndex < 0)
                return;
            schedules.Items.RemoveAt(schedules.SelectedIndex);
            Settings.Schedules.Names2Schedule.Remove((string)schedules.SelectedItem);
            Settings.Schedules.Save();
        }

        public string SelectedScheduleName = null;

        private void bOK_Click(object sender, EventArgs e)
        {
            SelectedScheduleName = (string)schedules.SelectedItem;
            Close();
        }

        private void bCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void schedules_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            bOK_Click(null, null);
        }
    }
}