using Domain;

namespace UI
{
    public partial class Main : System.Windows.Forms.Form
    {
        private readonly List<Publisher> publishers = [];

        public Main()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            Publisher publisher = CreatePublisher();
            publishers.Add(publisher);
            tabPageMain.Controls.Add(publisher);
        }

        private Publisher CreatePublisher()
        {
            IPublisher publisher = new Domain.Publisher.Publisher("Worker", "simulation");
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
    }
}
