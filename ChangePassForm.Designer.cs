
namespace bd
{
    partial class ChangePassForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.changePassButton = new System.Windows.Forms.Button();
            this.passTextBox = new System.Windows.Forms.TextBox();
            this.loginTextBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.confirmPassTextBox = new System.Windows.Forms.TextBox();
            this.newPassTextBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(28, 112);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(117, 17);
            this.label3.TabIndex = 11;
            this.label3.Text = "Текущий пароль";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(28, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 17);
            this.label2.TabIndex = 10;
            this.label2.Text = "Логин";
            // 
            // changePassButton
            // 
            this.changePassButton.Cursor = System.Windows.Forms.Cursors.Hand;
            this.changePassButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.changePassButton.Location = new System.Drawing.Point(31, 304);
            this.changePassButton.Name = "changePassButton";
            this.changePassButton.Size = new System.Drawing.Size(269, 46);
            this.changePassButton.TabIndex = 11;
            this.changePassButton.Text = "Сменить пароль";
            this.changePassButton.UseVisualStyleBackColor = true;
            this.changePassButton.Click += new System.EventHandler(this.changePassButton_Click);
            // 
            // passTextBox
            // 
            this.passTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.passTextBox.Location = new System.Drawing.Point(181, 109);
            this.passTextBox.Name = "passTextBox";
            this.passTextBox.Size = new System.Drawing.Size(195, 24);
            this.passTextBox.TabIndex = 8;
            this.passTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.passTextBox_KeyPress);
            // 
            // loginTextBox
            // 
            this.loginTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.loginTextBox.Location = new System.Drawing.Point(181, 46);
            this.loginTextBox.Name = "loginTextBox";
            this.loginTextBox.Size = new System.Drawing.Size(195, 24);
            this.loginTextBox.TabIndex = 7;
            this.loginTextBox.TextChanged += new System.EventHandler(this.loginTextBox_TextChanged);
            this.loginTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.loginTextBox_KeyPress);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(28, 242);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(145, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Подтвердить пароль";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(28, 180);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(102, 17);
            this.label5.TabIndex = 14;
            this.label5.Text = "Новый пароль";
            // 
            // confirmPassTextBox
            // 
            this.confirmPassTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.confirmPassTextBox.Location = new System.Drawing.Point(181, 238);
            this.confirmPassTextBox.Name = "confirmPassTextBox";
            this.confirmPassTextBox.Size = new System.Drawing.Size(195, 24);
            this.confirmPassTextBox.TabIndex = 10;
            this.confirmPassTextBox.TextChanged += new System.EventHandler(this.confirmPassTextBox_TextChanged);
            this.confirmPassTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.confirmPassTextBox_KeyPress);
            // 
            // newPassTextBox
            // 
            this.newPassTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.18868F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.newPassTextBox.Location = new System.Drawing.Point(181, 175);
            this.newPassTextBox.Name = "newPassTextBox";
            this.newPassTextBox.Size = new System.Drawing.Size(195, 24);
            this.newPassTextBox.TabIndex = 9;
            this.newPassTextBox.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            this.newPassTextBox.Enter += new System.EventHandler(this.userNameTextBox_Enter);
            this.newPassTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.newPassTextBox_KeyPress);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.button1);
            this.groupBox1.Controls.Add(this.loginTextBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.passTextBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.changePassButton);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.confirmPassTextBox);
            this.groupBox1.Controls.Add(this.newPassTextBox);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.830189F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(548, 378);
            this.groupBox1.TabIndex = 16;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Изменение пароля";
            this.groupBox1.Enter += new System.EventHandler(this.groupBox1_Enter);
            // 
            // button1
            // 
            this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.ForeColor = System.Drawing.SystemColors.ControlText;
            this.button1.Location = new System.Drawing.Point(402, 304);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(121, 46);
            this.button1.TabIndex = 16;
            this.button1.Text = "Отменить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ChangePassForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(573, 401);
            this.Controls.Add(this.groupBox1);
            this.Name = "ChangePassForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "RegForm";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ChangePassForm_FormClosing);
            this.Load += new System.EventHandler(this.RegForm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button changePassButton;
        private System.Windows.Forms.TextBox passTextBox;
        private System.Windows.Forms.TextBox loginTextBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox confirmPassTextBox;
        private System.Windows.Forms.TextBox newPassTextBox;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button button1;
    }
}