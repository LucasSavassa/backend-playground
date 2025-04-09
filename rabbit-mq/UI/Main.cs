using Domain;

namespace UI
{
    public partial class Main : Form
    {
        private readonly List<Publisher> publishers = [];

        public Main()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            List<string> options = TemplateHelper.Get();
            comboBoxTemplateType.Items.AddRange([.. options]);
            comboBoxTemplateType.SelectedIndex = 0;
        }

        private void buttonAddPerformance_Click(object sender, EventArgs e)
        {
            Publisher publisher = CreatePerformancePublisher();
            publishers.Add(publisher);
            tabPageMain.Controls.Add(publisher);
        }

        private Publisher CreatePerformancePublisher()
        {
            IPublisher publisher = new Domain.Publisher.Publisher("Generic publisher", "performance");
            return CreatePublisher(publisher);
        }

        private void buttonAddGeneric_Click(object sender, EventArgs e)
        {
            Publisher publisher = CreateGenericPublisher();
            publishers.Add(publisher);
            tabPageMain.Controls.Add(publisher);
        }

        private Publisher CreateGenericPublisher()
        {
            IPublisher publisher = new Domain.Publisher.Publisher("Generic publisher", "generic");
            return CreatePublisher(publisher);
        }

        private Publisher CreatePublisher(IPublisher publisher)
        {
            Publisher component = new Publisher(publisher);
            component.Deleted += Publisher_Deleted;
            int x = this.tabPageMain.Padding.Horizontal;
            int y = this.tabPageMain.Padding.Vertical + ((component.Height + this.tabPageMain.Padding.Vertical) * publishers.Count);
            int width = this.tabPageMain.Width - (this.tabPageMain.Padding.Horizontal * 2);
            component.Location = new Point(x, y);
            component.Width = width;
            component.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            return component;

        }

        private void Publisher_Deleted(object? sender, EventArgs e)
        {
            if (sender is null)
            {
                return;
            }

            Publisher publisher = (Publisher)sender;
            tabPageMain.Controls.Remove(publisher);
            publishers.Remove(publisher);
            publisher.Dispose();

            RepositionRemaining();
        }

        private void RepositionRemaining()
        {
            for (int i = 0; i < publishers.Count; i++)
            {
                Publisher publisher = publishers[i];
                int x = this.tabPageMain.Padding.Horizontal;
                int y = this.tabPageMain.Padding.Vertical + ((publisher.Height + this.tabPageMain.Padding.Vertical) * i);
                publisher.Location = new Point(x, y);
            }
        }

        private void comboBoxTemplateType_SelectedIndexChanged(object sender, EventArgs e)
        {
            int index = comboBoxTemplateType.SelectedIndex;
            string template = comboBoxTemplateType.Text;
            ToggleTemplateState(index, template);
        }

        private void ToggleTemplateState(int index, string templateName)
        {
            if (string.IsNullOrWhiteSpace(templateName) || templateName == "none")
            {
                comboBoxTemplateType.SelectedIndex = 0;
                textBoxTemplateName.Text = string.Empty;
                richTextBoxTemplateContent.Text = string.Empty;
            }
            else
            {
                comboBoxTemplateType.SelectedIndex = index;
                textBoxTemplateName.Text = templateName;
                richTextBoxTemplateContent.Text = TemplateHelper.Get(templateName);
            }
        }

        private void buttonTemplateSave_Click(object sender, EventArgs e)
        {
            string templateName = textBoxTemplateName.Text;
            string content = richTextBoxTemplateContent.Text;

            TemplateHelper.Update(templateName, content);
            if (!comboBoxTemplateType.Items.Contains(templateName))
            {
                comboBoxTemplateType.Items.Add(templateName);
            }

            int index = comboBoxTemplateType.Items.IndexOf(templateName);
            ToggleTemplateState(index, templateName);
        }

        private void buttonTemplateDelete_Click(object sender, EventArgs e)
        {
            string templateName = textBoxTemplateName.Text;

            TemplateHelper.Delete(templateName);
            ToggleTemplateState(0, string.Empty);
        }
    }
}
