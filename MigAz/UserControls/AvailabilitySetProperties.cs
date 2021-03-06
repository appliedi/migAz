﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MigAz.Azure.Asm;
using MigAz.Azure.Arm;

namespace MigAz.UserControls
{
    public partial class AvailabilitySetProperties : UserControl
    {
        TreeNode _armAvailabilitySetNode;

        public delegate Task AfterPropertyChanged();
        public event AfterPropertyChanged PropertyChanged;

        public AvailabilitySetProperties()
        {
            InitializeComponent();
        }

        internal void Bind(TreeNode availabilitySetNode)
        {
            _armAvailabilitySetNode = availabilitySetNode;

            AvailabilitySet armAvailabilitySet = (AvailabilitySet)_armAvailabilitySetNode.Tag;

            //lblAccountType.Text = asmCloudService.AccountType;
            txtTargetName.Text = armAvailabilitySet.TargetName;
        }

        private void txtTargetName_TextChanged(object sender, EventArgs e)
        {
            TextBox txtSender = (TextBox)sender;

            AvailabilitySet armAvailabilitySet = (AvailabilitySet)_armAvailabilitySetNode.Tag;

            armAvailabilitySet.TargetName = txtSender.Text;
            _armAvailabilitySetNode.Text = armAvailabilitySet.GetFinalTargetName();

            PropertyChanged();
        }
    }
}
