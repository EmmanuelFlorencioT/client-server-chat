using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Server_Chat
{
    public partial class Form1 : Form
    {
        Listener l = null;
        
        public Form1()
        {
            InitializeComponent();
            l = new Listener();
        }

        private void btnIntroClients_Click(object sender, EventArgs e)
        {
            l.StartListening();
        }

        private void btnStopIntro_Click(object sender, EventArgs e)
        {
            l.CheckClients();
        }

        private void btnDistribute_Click(object sender, EventArgs e)
        {
            l.continueDistribution = true;
            l.StartDistribution();
        }

        private void tbServerMessage_TextChanged(object sender, EventArgs e)
        {
            btnSendMssgC1.Enabled = btnSendMssgC2.Enabled
                = btnSendMssgAll.Enabled = tbServerMessage.Text.Length > 0;
        }

        private void btnSendMssgC1_Click(object sender, EventArgs e)
        {
            DoSendMessage(1);
        }

        private void btnSendMssgC2_Click(object sender, EventArgs e)
        {
            DoSendMessage(2);
        }

        private void btnSendMssgAll_Click(object sender, EventArgs e)
        {
            DoSendMessage(3);
        }

        private void DoSendMessage(int client)
        {
            l.continueDistribution = false;
            l.SendMessage(tbServerMessage.Text, client);
            tbServerMessage.Text = "";
        }
    }
}
