
namespace Lession07
{
    partial class Task02_EnterNumber
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
            this.label_entertext = new System.Windows.Forms.Label();
            this.textBox_number = new System.Windows.Forms.TextBox();
            this.button_continue = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.label_entertext, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.textBox_number, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.button_continue, 0, 2);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 3;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(367, 110);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // label_entertext
            // 
            this.label_entertext.AutoSize = true;
            this.label_entertext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_entertext.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label_entertext.Location = new System.Drawing.Point(3, 0);
            this.label_entertext.Name = "label_entertext";
            this.label_entertext.Size = new System.Drawing.Size(361, 36);
            this.label_entertext.TabIndex = 0;
            this.label_entertext.Text = "Введите число:";
            this.label_entertext.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // textBox_number
            // 
            this.textBox_number.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBox_number.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBox_number.Location = new System.Drawing.Point(3, 39);
            this.textBox_number.Name = "textBox_number";
            this.textBox_number.Size = new System.Drawing.Size(361, 31);
            this.textBox_number.TabIndex = 1;
            this.textBox_number.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.textBox_number.TextChanged += new System.EventHandler(this.textBox_number_TextChanged);
            this.textBox_number.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_number_KeyPress);
            // 
            // button_continue
            // 
            this.button_continue.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_continue.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_continue.Location = new System.Drawing.Point(3, 75);
            this.button_continue.Name = "button_continue";
            this.button_continue.Size = new System.Drawing.Size(361, 32);
            this.button_continue.TabIndex = 2;
            this.button_continue.Text = "Продолжить";
            this.button_continue.UseVisualStyleBackColor = true;
            this.button_continue.Click += new System.EventHandler(this.button_continue_Click);
            // 
            // Task02_EnterNumber
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(367, 110);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximumSize = new System.Drawing.Size(383, 149);
            this.MinimumSize = new System.Drawing.Size(383, 149);
            this.Name = "Task02_EnterNumber";
            this.Text = "Введите число";
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label label_entertext;
        private System.Windows.Forms.TextBox textBox_number;
        private System.Windows.Forms.Button button_continue;
    }
}