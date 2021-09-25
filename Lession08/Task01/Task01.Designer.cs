
namespace Lession08
{
    partial class Task01
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
            this.button_ShowResult = new System.Windows.Forms.Button();
            this.textBox_ResultData = new System.Windows.Forms.TextBox();
            this.label_Title = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.button_ShowResult, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.textBox_ResultData, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.label_Title, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 50F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 450);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // button_ShowResult
            // 
            this.button_ShowResult.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_ShowResult.Location = new System.Drawing.Point(3, 403);
            this.button_ShowResult.Name = "button_ShowResult";
            this.button_ShowResult.Size = new System.Drawing.Size(794, 44);
            this.button_ShowResult.TabIndex = 0;
            this.button_ShowResult.Text = "Вывести данные";
            this.button_ShowResult.UseVisualStyleBackColor = true;
            this.button_ShowResult.Click += new System.EventHandler(this.button_ShowResult_Click);
            // 
            // textBox_ResultData
            // 
            this.textBox_ResultData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_ResultData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_ResultData.Location = new System.Drawing.Point(3, 53);
            this.textBox_ResultData.Multiline = true;
            this.textBox_ResultData.Name = "textBox_ResultData";
            this.textBox_ResultData.ReadOnly = true;
            this.textBox_ResultData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBox_ResultData.Size = new System.Drawing.Size(794, 344);
            this.textBox_ResultData.TabIndex = 1;
            // 
            // label_Title
            // 
            this.label_Title.AutoSize = true;
            this.label_Title.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_Title.Location = new System.Drawing.Point(3, 0);
            this.label_Title.Name = "label_Title";
            this.label_Title.Size = new System.Drawing.Size(775, 50);
            this.label_Title.TabIndex = 2;
            this.label_Title.Text = "Задание 1. С помощью рефлексии выведите все свойства структуры DateTime.";
            this.label_Title.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // Task01
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "Task01";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Задание 1. Рефлексия класса DateTime";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button button_ShowResult;
        private System.Windows.Forms.TextBox textBox_ResultData;
        private System.Windows.Forms.Label label_Title;
    }
}