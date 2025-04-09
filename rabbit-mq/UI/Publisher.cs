using Domain;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace UI
{
    public partial class Publisher : UserControl
    {
        private int _frequency = 1;
        private IPublisher _publisher;
        private int _messageCount;

        public event EventHandler? Deleted;

        public Publisher(IPublisher publisher)
        {
            _publisher = publisher;
            InitializeComponent();
        }

        private void Publisher_Load(object sender, EventArgs e)
        {
            SetOptions();
        }

        private void SetOptions()
        {
            List<string> options = TemplateHelper.Get();
            comboBox.Items.AddRange([.. options]);
            comboBox.SelectedIndex = 0;
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
            {
                return;
            }

            string message = GetMessage();
            if (string.IsNullOrWhiteSpace(message))
            {
                richTextBox.AppendText($"[{DateTime.Now.ToLocalTime()}] No template message found\n");
                return;
            }

            richTextBox.AppendText($"[{DateTime.Now.ToLocalTime()}] Starting...\n");
            timer.Start();
            backgroundWorker.RunWorkerAsync(message);
        }

        private void backgroundWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string message = (string)e.Argument!;

            while (!backgroundWorker.CancellationPending)
            {
                message = UpdateCollectTime(message);
                int interval = 1000 / _frequency;
                Thread.Sleep(interval);
                _publisher.Publish(message).Wait();
                backgroundWorker.ReportProgress(0);
            }

            e.Cancel = true;
        }

        private string UpdateCollectTime(string message)
        {
            string updatedMessage = message;

            JsonNode? node = JsonNode.Parse(message);

            if (node == null)
            {
                return updatedMessage;
            }

            if (node is JsonObject jsonObject)
            {
                if (jsonObject.ContainsKey("collect_time"))
                {
                    jsonObject["collect_time"] = DateTimeOffset.Now.ToUnixTimeMilliseconds();
                    updatedMessage = jsonObject.ToJsonString();
                }
            }

            return updatedMessage;
        }

        private string GetMessage()
        {
            string template = (string)comboBox.SelectedItem!;
            return TemplateHelper.Get(template);
        }

        private void backgroundWorker_ProgressChanged(object sender, System.ComponentModel.ProgressChangedEventArgs e)
        {
            _messageCount++;
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            richTextBox.AppendText($"[{DateTime.Now.ToLocalTime()}] Messages sent: {_messageCount}\n");
            _messageCount = 0;
        }

        private void buttonEnd_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.WorkerSupportsCancellation)
            {
                backgroundWorker.CancelAsync();
            }

            timer.Stop();
            richTextBox.ResetText();
        }

        private void buttonErase_Click(object sender, EventArgs e)
        {
            if (Deleted != null)
            {
                Deleted(this, EventArgs.Empty);
            }
        }

        private void trackBar_ValueChanged(object sender, EventArgs e)
        {
            _frequency = trackBar.Value;
        }

        private void richTextBox_TextChanged(object sender, EventArgs e)
        {
            string[] lines = richTextBox.Text.Split('\n');

            if (lines.Length > 6)
            {
                richTextBox.Text = string.Join("\n", lines.Skip(lines.Length - 6));
            }
        }
    }
}
