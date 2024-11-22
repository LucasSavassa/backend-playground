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
            tabPageTemplate = new TabPage();
            buttonTemplateSave = new Button();
            buttonTemplateDelete = new Button();
            richTextBoxTemplateContent = new RichTextBox();
            labelTemplateContent = new Label();
            textBoxTemplateName = new TextBox();
            labelTemplateName = new Label();
            labelTemplateType = new Label();
            comboBoxTemplateType = new ComboBox();
            tabPageSettings = new TabPage();
            tab.SuspendLayout();
            tabPageMain.SuspendLayout();
            tabPageTemplate.SuspendLayout();
            SuspendLayout();
            // 
            // tab
            // 
            tab.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            tab.Controls.Add(tabPageMain);
            tab.Controls.Add(tabPageTemplate);
            tab.Controls.Add(tabPageSettings);
            tab.Location = new Point(10, 9);
            tab.Margin = new Padding(3, 2, 3, 2);
            tab.Name = "tab";
            tab.SelectedIndex = 0;
            tab.Size = new Size(838, 397);
            tab.TabIndex = 0;
            // 
            // tabPageMain
            // 
            tabPageMain.AutoScroll = true;
            tabPageMain.Controls.Add(buttonAdd);
            tabPageMain.Location = new Point(4, 24);
            tabPageMain.Margin = new Padding(3, 2, 3, 2);
            tabPageMain.Name = "tabPageMain";
            tabPageMain.Padding = new Padding(3, 2, 3, 2);
            tabPageMain.Size = new Size(830, 369);
            tabPageMain.TabIndex = 0;
            tabPageMain.Text = "Main";
            tabPageMain.UseVisualStyleBackColor = true;
            // 
            // buttonAdd
            // 
            buttonAdd.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonAdd.Location = new Point(744, 346);
            buttonAdd.Margin = new Padding(3, 2, 3, 2);
            buttonAdd.Name = "buttonAdd";
            buttonAdd.Size = new Size(82, 22);
            buttonAdd.TabIndex = 0;
            buttonAdd.Text = "Add";
            buttonAdd.UseVisualStyleBackColor = true;
            buttonAdd.Click += buttonAdd_Click;
            // 
            // tabPageTemplate
            // 
            tabPageTemplate.Controls.Add(buttonTemplateSave);
            tabPageTemplate.Controls.Add(buttonTemplateDelete);
            tabPageTemplate.Controls.Add(richTextBoxTemplateContent);
            tabPageTemplate.Controls.Add(labelTemplateContent);
            tabPageTemplate.Controls.Add(textBoxTemplateName);
            tabPageTemplate.Controls.Add(labelTemplateName);
            tabPageTemplate.Controls.Add(labelTemplateType);
            tabPageTemplate.Controls.Add(comboBoxTemplateType);
            tabPageTemplate.Location = new Point(4, 24);
            tabPageTemplate.Margin = new Padding(3, 2, 3, 2);
            tabPageTemplate.Name = "tabPageTemplate";
            tabPageTemplate.Padding = new Padding(3, 2, 3, 2);
            tabPageTemplate.Size = new Size(830, 369);
            tabPageTemplate.TabIndex = 1;
            tabPageTemplate.Text = "Template";
            tabPageTemplate.UseVisualStyleBackColor = true;
            // 
            // buttonTemplateSave
            // 
            buttonTemplateSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonTemplateSave.Location = new Point(697, 302);
            buttonTemplateSave.Name = "buttonTemplateSave";
            buttonTemplateSave.Size = new Size(122, 23);
            buttonTemplateSave.TabIndex = 7;
            buttonTemplateSave.Text = "Save";
            buttonTemplateSave.UseVisualStyleBackColor = true;
            buttonTemplateSave.Click += buttonTemplateSave_Click;
            // 
            // buttonTemplateDelete
            // 
            buttonTemplateDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonTemplateDelete.Location = new Point(697, 331);
            buttonTemplateDelete.Name = "buttonTemplateDelete";
            buttonTemplateDelete.Size = new Size(122, 23);
            buttonTemplateDelete.TabIndex = 6;
            buttonTemplateDelete.Text = "Delete";
            buttonTemplateDelete.UseVisualStyleBackColor = true;
            buttonTemplateDelete.Click += buttonTemplateDelete_Click;
            // 
            // richTextBoxTemplateContent
            // 
            richTextBoxTemplateContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxTemplateContent.BackColor = SystemColors.ControlLight;
            richTextBoxTemplateContent.Location = new Point(140, 69);
            richTextBoxTemplateContent.Name = "richTextBoxTemplateContent";
            richTextBoxTemplateContent.Size = new Size(551, 285);
            richTextBoxTemplateContent.TabIndex = 5;
            richTextBoxTemplateContent.Text = "";
            // 
            // labelTemplateContent
            // 
            labelTemplateContent.AutoSize = true;
            labelTemplateContent.Location = new Point(140, 51);
            labelTemplateContent.Name = "labelTemplateContent";
            labelTemplateContent.Size = new Size(100, 15);
            labelTemplateContent.TabIndex = 4;
            labelTemplateContent.Text = "Template content";
            // 
            // textBoxTemplateName
            // 
            textBoxTemplateName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTemplateName.BackColor = SystemColors.ControlLight;
            textBoxTemplateName.Location = new Point(140, 25);
            textBoxTemplateName.Name = "textBoxTemplateName";
            textBoxTemplateName.Size = new Size(551, 23);
            textBoxTemplateName.TabIndex = 3;
            // 
            // labelTemplateName
            // 
            labelTemplateName.AutoSize = true;
            labelTemplateName.Location = new Point(140, 7);
            labelTemplateName.Name = "labelTemplateName";
            labelTemplateName.Size = new Size(89, 15);
            labelTemplateName.TabIndex = 2;
            labelTemplateName.Text = "Template name";
            // 
            // labelTemplateType
            // 
            labelTemplateType.AutoSize = true;
            labelTemplateType.Location = new Point(10, 7);
            labelTemplateType.Name = "labelTemplateType";
            labelTemplateType.Size = new Size(82, 15);
            labelTemplateType.TabIndex = 1;
            labelTemplateType.Text = "Template type";
            // 
            // comboBoxTemplateType
            // 
            comboBoxTemplateType.FormattingEnabled = true;
            comboBoxTemplateType.Items.AddRange(new object[] { "none" });
            comboBoxTemplateType.Location = new Point(7, 25);
            comboBoxTemplateType.Name = "comboBoxTemplateType";
            comboBoxTemplateType.Size = new Size(121, 23);
            comboBoxTemplateType.TabIndex = 0;
            comboBoxTemplateType.SelectedIndexChanged += comboBoxTemplateType_SelectedIndexChanged;
            // 
            // tabPageSettings
            // 
            tabPageSettings.Location = new Point(4, 24);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new Padding(3);
            tabPageSettings.Size = new Size(830, 369);
            tabPageSettings.TabIndex = 2;
            tabPageSettings.Text = "Settings";
            tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(861, 421);
            Controls.Add(tab);
            Margin = new Padding(3, 2, 3, 2);
            MinimumSize = new Size(877, 460);
            Name = "Main";
            ShowIcon = false;
            Text = "Simulator";
            Load += Main_Load;
            tab.ResumeLayout(false);
            tabPageMain.ResumeLayout(false);
            tabPageTemplate.ResumeLayout(false);
            tabPageTemplate.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tab;
        private TabPage tabPageMain;
        private TabPage tabPageTemplate;
        private Button buttonAdd;
        private TabPage tabPageSettings;
        private Label labelTemplateType;
        private ComboBox comboBoxTemplateType;
        private RichTextBox richTextBoxTemplateContent;
        private Label labelTemplateContent;
        private TextBox textBoxTemplateName;
        private Label labelTemplateName;
        private Button buttonTemplateSave;
        private Button buttonTemplateDelete;
    }
}
