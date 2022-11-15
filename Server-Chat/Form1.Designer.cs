namespace Server_Chat
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnIntroClients = new System.Windows.Forms.Button();
            this.btnStopIntro = new System.Windows.Forms.Button();
            this.btnDistribute = new System.Windows.Forms.Button();
            this.btnSendMssgC1 = new System.Windows.Forms.Button();
            this.btnSendMssgC2 = new System.Windows.Forms.Button();
            this.btnSendMssgAll = new System.Windows.Forms.Button();
            this.tbServerMessage = new System.Windows.Forms.TextBox();
            this.labPromptServer = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnIntroClients
            // 
            this.btnIntroClients.Location = new System.Drawing.Point(60, 43);
            this.btnIntroClients.Name = "btnIntroClients";
            this.btnIntroClients.Size = new System.Drawing.Size(113, 23);
            this.btnIntroClients.TabIndex = 0;
            this.btnIntroClients.Text = "Introduce Clients";
            this.btnIntroClients.UseVisualStyleBackColor = true;
            this.btnIntroClients.Click += new System.EventHandler(this.btnIntroClients_Click);
            // 
            // btnStopIntro
            // 
            this.btnStopIntro.Location = new System.Drawing.Point(60, 85);
            this.btnStopIntro.Name = "btnStopIntro";
            this.btnStopIntro.Size = new System.Drawing.Size(113, 23);
            this.btnStopIntro.TabIndex = 1;
            this.btnStopIntro.Text = "Stop Introduction";
            this.btnStopIntro.UseVisualStyleBackColor = true;
            this.btnStopIntro.Click += new System.EventHandler(this.btnStopIntro_Click);
            // 
            // btnDistribute
            // 
            this.btnDistribute.Location = new System.Drawing.Point(325, 85);
            this.btnDistribute.Name = "btnDistribute";
            this.btnDistribute.Size = new System.Drawing.Size(113, 23);
            this.btnDistribute.TabIndex = 2;
            this.btnDistribute.Text = "Distribute Message";
            this.btnDistribute.UseVisualStyleBackColor = true;
            this.btnDistribute.Click += new System.EventHandler(this.btnDistribute_Click);
            // 
            // btnSendMssgC1
            // 
            this.btnSendMssgC1.Enabled = false;
            this.btnSendMssgC1.Location = new System.Drawing.Point(452, 215);
            this.btnSendMssgC1.Name = "btnSendMssgC1";
            this.btnSendMssgC1.Size = new System.Drawing.Size(113, 23);
            this.btnSendMssgC1.TabIndex = 3;
            this.btnSendMssgC1.Text = "Send Client 1";
            this.btnSendMssgC1.UseVisualStyleBackColor = true;
            this.btnSendMssgC1.Click += new System.EventHandler(this.btnSendMssgC1_Click);
            // 
            // btnSendMssgC2
            // 
            this.btnSendMssgC2.Enabled = false;
            this.btnSendMssgC2.Location = new System.Drawing.Point(452, 244);
            this.btnSendMssgC2.Name = "btnSendMssgC2";
            this.btnSendMssgC2.Size = new System.Drawing.Size(113, 23);
            this.btnSendMssgC2.TabIndex = 4;
            this.btnSendMssgC2.Text = "Send Client 2";
            this.btnSendMssgC2.UseVisualStyleBackColor = true;
            this.btnSendMssgC2.Click += new System.EventHandler(this.btnSendMssgC2_Click);
            // 
            // btnSendMssgAll
            // 
            this.btnSendMssgAll.Enabled = false;
            this.btnSendMssgAll.Location = new System.Drawing.Point(325, 275);
            this.btnSendMssgAll.Name = "btnSendMssgAll";
            this.btnSendMssgAll.Size = new System.Drawing.Size(113, 23);
            this.btnSendMssgAll.TabIndex = 5;
            this.btnSendMssgAll.Text = "Send Message";
            this.btnSendMssgAll.UseVisualStyleBackColor = true;
            this.btnSendMssgAll.Click += new System.EventHandler(this.btnSendMssgAll_Click);
            // 
            // tbServerMessage
            // 
            this.tbServerMessage.Location = new System.Drawing.Point(309, 244);
            this.tbServerMessage.Name = "tbServerMessage";
            this.tbServerMessage.Size = new System.Drawing.Size(137, 20);
            this.tbServerMessage.TabIndex = 6;
            this.tbServerMessage.TextChanged += new System.EventHandler(this.tbServerMessage_TextChanged);
            // 
            // labPromptServer
            // 
            this.labPromptServer.AutoSize = true;
            this.labPromptServer.Location = new System.Drawing.Point(306, 225);
            this.labPromptServer.Name = "labPromptServer";
            this.labPromptServer.Size = new System.Drawing.Size(115, 13);
            this.labPromptServer.TabIndex = 7;
            this.labPromptServer.Text = "Server Send Message:";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.labPromptServer);
            this.Controls.Add(this.tbServerMessage);
            this.Controls.Add(this.btnSendMssgAll);
            this.Controls.Add(this.btnSendMssgC2);
            this.Controls.Add(this.btnSendMssgC1);
            this.Controls.Add(this.btnDistribute);
            this.Controls.Add(this.btnStopIntro);
            this.Controls.Add(this.btnIntroClients);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnIntroClients;
        private System.Windows.Forms.Button btnStopIntro;
        private System.Windows.Forms.Button btnDistribute;
        private System.Windows.Forms.Button btnSendMssgC1;
        private System.Windows.Forms.Button btnSendMssgC2;
        private System.Windows.Forms.Button btnSendMssgAll;
        private System.Windows.Forms.TextBox tbServerMessage;
        private System.Windows.Forms.Label labPromptServer;
    }
}

