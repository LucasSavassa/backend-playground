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
            buttonAddPerformance = new Button();
            buttonAddGeneric = new Button();
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
            tab.Location = new Point(11, 12);
            tab.Name = "tab";
            tab.SelectedIndex = 0;
            tab.Size = new Size(958, 961);
            tab.TabIndex = 0;
            // 
            // tabPageMain
            // 
            tabPageMain.AutoScroll = true;
            tabPageMain.Controls.Add(buttonAddPerformance);
            tabPageMain.Controls.Add(buttonAddGeneric);
            tabPageMain.Location = new Point(4, 29);
            tabPageMain.Name = "tabPageMain";
            tabPageMain.Padding = new Padding(3);
            tabPageMain.Size = new Size(950, 928);
            tabPageMain.TabIndex = 0;
            tabPageMain.Text = "Main";
            tabPageMain.UseVisualStyleBackColor = true;
            // 
            // buttonAddPerformance
            // 
            buttonAddPerformance.Dock = DockStyle.Bottom;
            buttonAddPerformance.Location = new Point(3, 867);
            buttonAddPerformance.Name = "buttonAddPerformance";
            buttonAddPerformance.Size = new Size(944, 29);
            buttonAddPerformance.TabIndex = 1;
            buttonAddPerformance.Text = "Add performance publisher";
            buttonAddPerformance.UseVisualStyleBackColor = true;
            buttonAddPerformance.Click += buttonAddPerformance_Click;
            // 
            // buttonAddGeneric
            // 
            buttonAddGeneric.Dock = DockStyle.Bottom;
            buttonAddGeneric.Location = new Point(3, 896);
            buttonAddGeneric.Name = "buttonAddGeneric";
            buttonAddGeneric.Size = new Size(944, 29);
            buttonAddGeneric.TabIndex = 0;
            buttonAddGeneric.Text = "Add generic publisher";
            buttonAddGeneric.UseVisualStyleBackColor = true;
            buttonAddGeneric.Click += buttonAddGeneric_Click;
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
            tabPageTemplate.Location = new Point(4, 29);
            tabPageTemplate.Name = "tabPageTemplate";
            tabPageTemplate.Padding = new Padding(3);
            tabPageTemplate.Size = new Size(950, 928);
            tabPageTemplate.TabIndex = 1;
            tabPageTemplate.Text = "Template";
            tabPageTemplate.UseVisualStyleBackColor = true;
            // 
            // buttonTemplateSave
            // 
            buttonTemplateSave.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonTemplateSave.Location = new Point(797, 403);
            buttonTemplateSave.Margin = new Padding(3, 4, 3, 4);
            buttonTemplateSave.Name = "buttonTemplateSave";
            buttonTemplateSave.Size = new Size(139, 31);
            buttonTemplateSave.TabIndex = 7;
            buttonTemplateSave.Text = "Save";
            buttonTemplateSave.UseVisualStyleBackColor = true;
            buttonTemplateSave.Click += buttonTemplateSave_Click;
            // 
            // buttonTemplateDelete
            // 
            buttonTemplateDelete.Anchor = AnchorStyles.Bottom | AnchorStyles.Right;
            buttonTemplateDelete.Location = new Point(797, 441);
            buttonTemplateDelete.Margin = new Padding(3, 4, 3, 4);
            buttonTemplateDelete.Name = "buttonTemplateDelete";
            buttonTemplateDelete.Size = new Size(139, 31);
            buttonTemplateDelete.TabIndex = 6;
            buttonTemplateDelete.Text = "Delete";
            buttonTemplateDelete.UseVisualStyleBackColor = true;
            buttonTemplateDelete.Click += buttonTemplateDelete_Click;
            // 
            // richTextBoxTemplateContent
            // 
            richTextBoxTemplateContent.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBoxTemplateContent.BackColor = SystemColors.ControlLight;
            richTextBoxTemplateContent.Location = new Point(160, 92);
            richTextBoxTemplateContent.Margin = new Padding(3, 4, 3, 4);
            richTextBoxTemplateContent.Name = "richTextBoxTemplateContent";
            richTextBoxTemplateContent.Size = new Size(629, 379);
            richTextBoxTemplateContent.TabIndex = 5;
            richTextBoxTemplateContent.Text = "";
            // 
            // labelTemplateContent
            // 
            labelTemplateContent.AutoSize = true;
            labelTemplateContent.Location = new Point(160, 68);
            labelTemplateContent.Name = "labelTemplateContent";
            labelTemplateContent.Size = new Size(125, 20);
            labelTemplateContent.TabIndex = 4;
            labelTemplateContent.Text = "Template content";
            // 
            // textBoxTemplateName
            // 
            textBoxTemplateName.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            textBoxTemplateName.BackColor = SystemColors.ControlLight;
            textBoxTemplateName.Location = new Point(160, 33);
            textBoxTemplateName.Margin = new Padding(3, 4, 3, 4);
            textBoxTemplateName.Name = "textBoxTemplateName";
            textBoxTemplateName.Size = new Size(629, 27);
            textBoxTemplateName.TabIndex = 3;
            // 
            // labelTemplateName
            // 
            labelTemplateName.AutoSize = true;
            labelTemplateName.Location = new Point(160, 9);
            labelTemplateName.Name = "labelTemplateName";
            labelTemplateName.Size = new Size(112, 20);
            labelTemplateName.TabIndex = 2;
            labelTemplateName.Text = "Template name";
            // 
            // labelTemplateType
            // 
            labelTemplateType.AutoSize = true;
            labelTemplateType.Location = new Point(11, 9);
            labelTemplateType.Name = "labelTemplateType";
            labelTemplateType.Size = new Size(104, 20);
            labelTemplateType.TabIndex = 1;
            labelTemplateType.Text = "Template type";
            // 
            // comboBoxTemplateType
            // 
            comboBoxTemplateType.FormattingEnabled = true;
            comboBoxTemplateType.Items.AddRange(new object[] { "none" });
            comboBoxTemplateType.Location = new Point(8, 33);
            comboBoxTemplateType.Margin = new Padding(3, 4, 3, 4);
            comboBoxTemplateType.Name = "comboBoxTemplateType";
            comboBoxTemplateType.Size = new Size(138, 28);
            comboBoxTemplateType.TabIndex = 0;
            comboBoxTemplateType.SelectedIndexChanged += comboBoxTemplateType_SelectedIndexChanged;
            // 
            // tabPageSettings
            // 
            tabPageSettings.Location = new Point(4, 29);
            tabPageSettings.Margin = new Padding(3, 4, 3, 4);
            tabPageSettings.Name = "tabPageSettings";
            tabPageSettings.Padding = new Padding(3, 4, 3, 4);
            tabPageSettings.Size = new Size(950, 928);
            tabPageSettings.TabIndex = 2;
            tabPageSettings.Text = "Settings";
            tabPageSettings.UseVisualStyleBackColor = true;
            // 
            // Main
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(984, 993);
            Controls.Add(tab);
            MinimumSize = new Size(1000, 598);
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
        private Button buttonAddGeneric;
        private TabPage tabPageSettings;
        private Label labelTemplateType;
        private ComboBox comboBoxTemplateType;
        private RichTextBox richTextBoxTemplateContent;
        private Label labelTemplateContent;
        private TextBox textBoxTemplateName;
        private Label labelTemplateName;
        private Button buttonTemplateSave;
        private Button buttonTemplateDelete;
        private Button buttonAddPerformance;
    }
}
