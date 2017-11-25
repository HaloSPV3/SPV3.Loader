﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace Halo_CE_Mouse_Tool
{
    public partial class Mainform : Form
    {
        public static Donateform donateform;

        public Mainform()
        {
            InitializeComponent();
            this.Icon = Halo_CE_Mouse_Tool.Properties.Resources.HMFIcon;
        }
        
        private void EnableBtnTimer_Tick(object sender, EventArgs e)
        {
            if (Process.GetProcessesByName("haloce").Length > 0)
            {
                ActivateBtn.Enabled = true;
                StatusLabel.Text = "Halo CE Process Detected.";
                StatusLabel.ForeColor = Color.Green;
            }
            else
            {
                ActivateBtn.Enabled = false;
                StatusLabel.Text = "Waiting for Halo CE Process...";
                StatusLabel.ForeColor = Color.Red;
            }
        }


        private void ActivateBtn_Click(object sender, EventArgs e)
        {
            float mousesensX;
            float mousesensY;
            bool validX = float.TryParse(SensX.Text, out mousesensX);
            bool validY = float.TryParse(SensY.Text, out mousesensY);
            if (!validX || !validY)
            {
                MessageBox.Show("Only numbers allowed in this field.");
            }
            else
            {
                MessageBox.Show(HaloMemWriter.WriteHaloMemory(mousesensX * 0.25f, mousesensY * 0.25F).ToString());
            }
        }

        private void GithubLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool");
        }

        private void DonateLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            if (donateform == null || donateform.IsDisposed)
            {
                donateform = new Donateform();
                donateform.Show();
            }

        }

        private void RedditLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Process.Start("https://www.reddit.com/r/halospv3/comments/6aoxu0/halo_ce_mouse_tool_released_fine_tune_your_mouse/");
        }

        private void Mainform_Load(object sender, EventArgs e)
        {
            if (CheckForUpdates.UpdateAvailable() == "yes")
            {
                DialogResult d = MessageBox.Show("An Update is Available. Would you like to visit the downloads page?", "Update Found", MessageBoxButtons.YesNo);
                if (d == DialogResult.Yes)
                {
                    Process.Start("https://github.com/AWilliams17/Halo-CE-Mouse-Tool/releases");
                }
            }
            else if (CheckForUpdates.UpdateAvailable() == "error")
            {
                MessageBox.Show("Failed to check for available updates.");
            }
        }
    }
}
