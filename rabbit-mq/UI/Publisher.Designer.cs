namespace UI
{
    partial class Publisher
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pictureBox = new PictureBox();
            comboBox = new ComboBox();
            richTextBox = new RichTextBox();
            buttonStart = new Button();
            buttonEnd = new Button();
            trackBar = new TrackBar();
            backgroundWorker = new System.ComponentModel.BackgroundWorker();
            buttonErase = new Button();
            timer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).BeginInit();
            SuspendLayout();
            // 
            // pictureBox
            // 
            pictureBox.Image = Properties.Resources.worker;
            pictureBox.InitialImage = null;
            pictureBox.Location = new Point(10, 11);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new Size(112, 131);
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.TabIndex = 0;
            pictureBox.TabStop = false;
            // 
            // comboBox
            // 
            comboBox.FormattingEnabled = true;
            comboBox.Items.AddRange(new object[] { "none" });
            comboBox.Location = new Point(155, 11);
            comboBox.Name = "comboBox";
            comboBox.Size = new Size(191, 28);
            comboBox.TabIndex = 1;
            // 
            // richTextBox
            // 
            richTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox.BackColor = SystemColors.InfoText;
            richTextBox.ForeColor = SystemColors.ControlLightLight;
            richTextBox.Location = new Point(362, 11);
            richTextBox.Name = "richTextBox";
            richTextBox.Size = new Size(348, 129);
            richTextBox.TabIndex = 2;
            richTextBox.Text = "";
            richTextBox.TextChanged += richTextBox_TextChanged;
            // 
            // buttonStart
            // 
            buttonStart.Font = new Font("Segoe UI", 8F);
            buttonStart.Location = new Point(155, 44);
            buttonStart.Name = "buttonStart";
            buttonStart.Size = new Size(59, 29);
            buttonStart.TabIndex = 3;
            buttonStart.Text = "Start";
            buttonStart.UseVisualStyleBackColor = true;
            buttonStart.Click += buttonStart_Click;
            // 
            // buttonEnd
            // 
            buttonEnd.Font = new Font("Segoe UI", 8F);
            buttonEnd.Location = new Point(221, 44);
            buttonEnd.Name = "buttonEnd";
            buttonEnd.Size = new Size(59, 29);
            buttonEnd.TabIndex = 4;
            buttonEnd.Text = "End";
            buttonEnd.UseVisualStyleBackColor = true;
            buttonEnd.Click += buttonEnd_Click;
            // 
            // trackBar
            // 
            trackBar.Location = new Point(155, 84);
            trackBar.Maximum = 20;
            trackBar.Minimum = 1;
            trackBar.Name = "trackBar";
            trackBar.Size = new Size(192, 56);
            trackBar.SmallChange = 2;
            trackBar.TabIndex = 5;
            trackBar.TickFrequency = 2;
            trackBar.Value = 1;
            trackBar.ValueChanged += trackBar_ValueChanged;
            // 
            // backgroundWorker
            // 
            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;
            backgroundWorker.DoWork += backgroundWorker_DoWork;
            backgroundWorker.ProgressChanged += backgroundWorker_ProgressChanged;
            // 
            // buttonErase
            // 
            buttonErase.Font = new Font("Segoe UI", 8F);
            buttonErase.Location = new Point(287, 44);
            buttonErase.Name = "buttonErase";
            buttonErase.Size = new Size(59, 29);
            buttonErase.TabIndex = 6;
            buttonErase.Text = "Delete";
            buttonErase.UseVisualStyleBackColor = true;
            buttonErase.Click += buttonErase_Click;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // Publisher
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(buttonErase);
            Controls.Add(trackBar);
            Controls.Add(buttonEnd);
            Controls.Add(buttonStart);
            Controls.Add(richTextBox);
            Controls.Add(comboBox);
            Controls.Add(pictureBox);
            Name = "Publisher";
            Size = new Size(722, 149);
            Load += Publisher_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            ((System.ComponentModel.ISupportInitialize)trackBar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pictureBox;
        private ComboBox comboBox;
        private RichTextBox richTextBox;
        private Button buttonStart;
        private Button buttonEnd;
        private TrackBar trackBar;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
        private Button buttonErase;
        private System.Windows.Forms.Timer timer;
    }
}
