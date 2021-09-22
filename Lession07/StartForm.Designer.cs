
namespace Lession07
{
    partial class StartForm
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.Label_Title = new System.Windows.Forms.Label();
            this.button_Task01 = new System.Windows.Forms.Button();
            this.button_Task02 = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.Label_Title, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.button_Task01, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_Task02, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 18.69919F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.6504F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 40.65041F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(384, 211);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // Label_Title
            // 
            this.Label_Title.AutoSize = true;
            this.Label_Title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.Label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.Label_Title.Location = new System.Drawing.Point(3, 0);
            this.Label_Title.Name = "Label_Title";
            this.Label_Title.Size = new System.Drawing.Size(378, 39);
            this.Label_Title.TabIndex = 0;
            this.Label_Title.Text = "Домашнее задание №7";
            this.Label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Task01
            // 
            this.button_Task01.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Task01.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Task01.Location = new System.Drawing.Point(5, 44);
            this.button_Task01.Margin = new System.Windows.Forms.Padding(5);
            this.button_Task01.Name = "button_Task01";
            this.button_Task01.Size = new System.Drawing.Size(374, 75);
            this.button_Task01.TabIndex = 1;
            this.button_Task01.Text = "Задание 1. Удвоитель";
            this.button_Task01.UseVisualStyleBackColor = true;
            this.button_Task01.Click += new System.EventHandler(this.button_Task01_Click);
            // 
            // button_Task02
            // 
            this.button_Task02.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_Task02.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_Task02.Location = new System.Drawing.Point(5, 129);
            this.button_Task02.Margin = new System.Windows.Forms.Padding(5);
            this.button_Task02.Name = "button_Task02";
            this.button_Task02.Size = new System.Drawing.Size(374, 77);
            this.button_Task02.TabIndex = 2;
            this.button_Task02.Text = "Задание 2. Угадай число";
            this.button_Task02.UseVisualStyleBackColor = true;
            this.button_Task02.Click += new System.EventHandler(this.button_Task02_Click);
            // 
            // StartForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(384, 211);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(400, 250);
            this.MinimumSize = new System.Drawing.Size(400, 250);
            this.Name = "StartForm";
            this.Text = "Главное меню";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label Label_Title;
        private System.Windows.Forms.Button button_Task01;
        private System.Windows.Forms.Button button_Task02;
    }
}

