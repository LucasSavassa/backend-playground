namespace UI
{
    partial class Main
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            tab = new TabControl();
            tabPageMain = new TabPage();
            buttonAdd = new Button();
            tabPageSettings = new TabPage();
            tab.SuspendLayout();
            tabPageMain.SuspendLayout();
            SuspendLayout();
            // 
            // tab
            // 
            tab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tab.Controls.Add(tabPageMain);
            tab.Controls.Add(tabPageSettings);
            tab.Location = new Point(12, 12);
            tab.Name = "tab";
            tab.SelectedIndex = 0;
            tab.Size = new Size(958, 529);
            tab.TabIndex = 0;
            // 
            // tabPageMain
            // 
            tabPageMain.AutoScroll = true;
            tabPageMain.Controls.Add(buttonAdd);
            tabPageMain.Location = new Point(4, 29);
            tabPageMain.Name = "tabPageMain";
            tabPageMain.Padding = new Padding(3);
            tabPageMain.Size = new Size(950, 496);
            tabPageMain.TabIndex = 0;
            tabPageMain.Text = "Main";
            tabPageMain.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAdd.Location = new Point(850, 461);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(94, 29);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // tabPageSettings
            // 
            tabPageSettings.Location = new Point(4, 29);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new Padding(3);
            tabPageSettings.Size = new Size(768, 393);
            tabPageSettings.TabIndex = 1;
            tabPageSettings.Text = "Settings";
            tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // Form
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 553);
            Controls.Add(tab);
            MinimumSize = new Size(1000, 600);
            Name = "Form";
            ShowIcon = false;
            Text = "Simulator";
            tab.ResumeLayout(false);
            tabPageMain.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private TabControl tab;
        private TabPage tabPageMain;
        private TabPage tabPageSettings;
        private Button buttonAdd;
    }
}
