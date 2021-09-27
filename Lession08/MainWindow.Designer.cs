
namespace Lession08
{
    partial class MainWindow
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.ToolStripMenuItem_Tasks = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Task01 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Task02 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItemTrueFalseEditor = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Task04 = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Converter = new System.Windows.Forms.ToolStripMenuItem();
            this.windowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolBoxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_Help = new System.Windows.Forms.ToolStripMenuItem();
            this.ToolStripMenuItem_About = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.panel_toolbox = new System.Windows.Forms.Panel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.button_tool_close = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.label_tool_title = new System.Windows.Forms.Label();
            this.richTextBox_tooltext = new System.Windows.Forms.RichTextBox();
            this.splitter_toolbox = new System.Windows.Forms.Splitter();
            this.ToolStripMenuItem_TrueFalseGame = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.panel_toolbox.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Tasks,
            this.windowToolStripMenuItem,
            this.ToolStripMenuItem_Help});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // ToolStripMenuItem_Tasks
            // 
            this.ToolStripMenuItem_Tasks.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_Task01,
            this.ToolStripMenuItem_Task02,
            this.ToolStripMenuItemTrueFalseEditor,
            this.ToolStripMenuItem_Task04,
            this.ToolStripMenuItem_Converter,
            this.ToolStripMenuItem_TrueFalseGame});
            this.ToolStripMenuItem_Tasks.Name = "ToolStripMenuItem_Tasks";
            this.ToolStripMenuItem_Tasks.Size = new System.Drawing.Size(64, 20);
            this.ToolStripMenuItem_Tasks.Text = "Задания";
            // 
            // ToolStripMenuItem_Task01
            // 
            this.ToolStripMenuItem_Task01.Name = "ToolStripMenuItem_Task01";
            this.ToolStripMenuItem_Task01.Size = new System.Drawing.Size(425, 22);
            this.ToolStripMenuItem_Task01.Text = "Задание 1. Рефлексия класса DateTime";
            this.ToolStripMenuItem_Task01.Click += new System.EventHandler(this.ToolStripMenuItem_Task01_Click);
            // 
            // ToolStripMenuItem_Task02
            // 
            this.ToolStripMenuItem_Task02.Name = "ToolStripMenuItem_Task02";
            this.ToolStripMenuItem_Task02.Size = new System.Drawing.Size(425, 22);
            this.ToolStripMenuItem_Task02.Text = "Задание 2. TextBox и NumericUpDown";
            this.ToolStripMenuItem_Task02.Click += new System.EventHandler(this.ToolStripMenuItem_Task02_Click);
            // 
            // ToolStripMenuItemTrueFalseEditor
            // 
            this.ToolStripMenuItemTrueFalseEditor.Name = "ToolStripMenuItemTrueFalseEditor";
            this.ToolStripMenuItemTrueFalseEditor.Size = new System.Drawing.Size(425, 22);
            this.ToolStripMenuItemTrueFalseEditor.Text = "Задание 3. Редактор \"Верю  - не верю\". Обработка исключений";
            this.ToolStripMenuItemTrueFalseEditor.Click += new System.EventHandler(this.ToolStripMenuItemTrueFalseEditor_Click);
            // 
            // ToolStripMenuItem_Task04
            // 
            this.ToolStripMenuItem_Task04.Name = "ToolStripMenuItem_Task04";
            this.ToolStripMenuItem_Task04.Size = new System.Drawing.Size(425, 22);
            this.ToolStripMenuItem_Task04.Text = "Задание 4. Собственная утилита хранения данных";
            this.ToolStripMenuItem_Task04.Click += new System.EventHandler(this.ToolStripMenuItem_Task04_Click);
            // 
            // ToolStripMenuItem_Converter
            // 
            this.ToolStripMenuItem_Converter.Name = "ToolStripMenuItem_Converter";
            this.ToolStripMenuItem_Converter.Size = new System.Drawing.Size(425, 22);
            this.ToolStripMenuItem_Converter.Text = "Задание 5. Конвертер из CSV в XML";
            this.ToolStripMenuItem_Converter.Click += new System.EventHandler(this.ToolStripMenuItem_Converter_Click);
            // 
            // windowToolStripMenuItem
            // 
            this.windowToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBoxToolStripMenuItem});
            this.windowToolStripMenuItem.Name = "windowToolStripMenuItem";
            this.windowToolStripMenuItem.Size = new System.Drawing.Size(47, 20);
            this.windowToolStripMenuItem.Text = "Окна";
            // 
            // toolBoxToolStripMenuItem
            // 
            this.toolBoxToolStripMenuItem.Name = "toolBoxToolStripMenuItem";
            this.toolBoxToolStripMenuItem.Size = new System.Drawing.Size(206, 22);
            this.toolBoxToolStripMenuItem.Text = "Служебные сообщения";
            this.toolBoxToolStripMenuItem.Click += new System.EventHandler(this.toolBoxToolStripMenuItem_Click);
            // 
            // ToolStripMenuItem_Help
            // 
            this.ToolStripMenuItem_Help.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ToolStripMenuItem_About});
            this.ToolStripMenuItem_Help.Name = "ToolStripMenuItem_Help";
            this.ToolStripMenuItem_Help.Size = new System.Drawing.Size(65, 20);
            this.ToolStripMenuItem_Help.Text = "Справка";
            // 
            // ToolStripMenuItem_About
            // 
            this.ToolStripMenuItem_About.Name = "ToolStripMenuItem_About";
            this.ToolStripMenuItem_About.Size = new System.Drawing.Size(149, 22);
            this.ToolStripMenuItem_About.Text = "О программе";
            this.ToolStripMenuItem_About.Click += new System.EventHandler(this.ToolStripMenuItem_About_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Location = new System.Drawing.Point(0, 428);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(800, 22);
            this.statusStrip1.TabIndex = 4;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // panel_toolbox
            // 
            this.panel_toolbox.Controls.Add(this.tableLayoutPanel1);
            this.panel_toolbox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel_toolbox.Location = new System.Drawing.Point(0, 258);
            this.panel_toolbox.Name = "panel_toolbox";
            this.panel_toolbox.Size = new System.Drawing.Size(800, 170);
            this.panel_toolbox.TabIndex = 5;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 1;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Controls.Add(this.tableLayoutPanel2, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.richTextBox_tooltext, 0, 1);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(800, 170);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.BackColor = System.Drawing.SystemColors.GradientInactiveCaption;
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 60F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel2.Controls.Add(this.button_tool_close, 2, 0);
            this.tableLayoutPanel2.Controls.Add(this.button1, 1, 0);
            this.tableLayoutPanel2.Controls.Add(this.label_tool_title, 0, 0);
            this.tableLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel2.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(800, 20);
            this.tableLayoutPanel2.TabIndex = 0;
            // 
            // button_tool_close
            // 
            this.button_tool_close.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button_tool_close.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button_tool_close.Location = new System.Drawing.Point(781, 1);
            this.button_tool_close.Margin = new System.Windows.Forms.Padding(1);
            this.button_tool_close.Name = "button_tool_close";
            this.button_tool_close.Size = new System.Drawing.Size(18, 18);
            this.button_tool_close.TabIndex = 0;
            this.button_tool_close.Text = "X";
            this.button_tool_close.UseVisualStyleBackColor = true;
            this.button_tool_close.Click += new System.EventHandler(this.button_tool_close_Click);
            // 
            // button1
            // 
            this.button1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.button1.Location = new System.Drawing.Point(721, 1);
            this.button1.Margin = new System.Windows.Forms.Padding(1);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(58, 18);
            this.button1.TabIndex = 1;
            this.button1.Text = "Clear";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label_tool_title
            // 
            this.label_tool_title.AutoSize = true;
            this.label_tool_title.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label_tool_title.Location = new System.Drawing.Point(3, 0);
            this.label_tool_title.Name = "label_tool_title";
            this.label_tool_title.Size = new System.Drawing.Size(714, 20);
            this.label_tool_title.TabIndex = 2;
            this.label_tool_title.Text = "Служебные сообщения";
            this.label_tool_title.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // richTextBox_tooltext
            // 
            this.richTextBox_tooltext.Dock = System.Windows.Forms.DockStyle.Fill;
            this.richTextBox_tooltext.Location = new System.Drawing.Point(0, 20);
            this.richTextBox_tooltext.Margin = new System.Windows.Forms.Padding(0);
            this.richTextBox_tooltext.Name = "richTextBox_tooltext";
            this.richTextBox_tooltext.ReadOnly = true;
            this.richTextBox_tooltext.Size = new System.Drawing.Size(800, 150);
            this.richTextBox_tooltext.TabIndex = 1;
            this.richTextBox_tooltext.Text = "";
            // 
            // splitter_toolbox
            // 
            this.splitter_toolbox.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.splitter_toolbox.Location = new System.Drawing.Point(0, 255);
            this.splitter_toolbox.Name = "splitter_toolbox";
            this.splitter_toolbox.Size = new System.Drawing.Size(800, 3);
            this.splitter_toolbox.TabIndex = 6;
            this.splitter_toolbox.TabStop = false;
            // 
            // ToolStripMenuItem_TrueFalseGame
            // 
            this.ToolStripMenuItem_TrueFalseGame.Name = "ToolStripMenuItem_TrueFalseGame";
            this.ToolStripMenuItem_TrueFalseGame.Size = new System.Drawing.Size(425, 22);
            this.ToolStripMenuItem_TrueFalseGame.Text = "Дополнительно. Игра \"Верю не верю\"";
            this.ToolStripMenuItem_TrueFalseGame.Click += new System.EventHandler(this.ToolStripMenuItem_TrueFalseGame_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.splitter_toolbox);
            this.Controls.Add(this.panel_toolbox);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainWindow";
            this.Text = "MainWindow";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.panel_toolbox.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Panel panel_toolbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Button button_tool_close;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label_tool_title;
        private System.Windows.Forms.Splitter splitter_toolbox;
        private System.Windows.Forms.ToolStripMenuItem windowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolBoxToolStripMenuItem;
        private System.Windows.Forms.RichTextBox richTextBox_tooltext;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Tasks;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItemTrueFalseEditor;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Task01;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Task02;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Help;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_About;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Task04;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_Converter;
        private System.Windows.Forms.ToolStripMenuItem ToolStripMenuItem_TrueFalseGame;
    }
}

