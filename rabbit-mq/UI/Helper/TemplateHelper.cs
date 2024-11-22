namespace UI
{
    public static class TemplateHelper
    {
        private static readonly string _root = Environment.GetFolderPath(Environment.SpecialFolder.CommonApplicationData);

        public static bool Exists(string templateName)
        {
            string fileName = $"template-{templateName}.txt";
            string path = Path.Combine(_root, fileName);
            return File.Exists(path);
        }

        public static List<string> Get()
        {
            List<string> options = [];

            foreach (string filePath in Directory.GetFiles(_root, "template-*.txt"))
            {
                string fileName = Path.GetFileNameWithoutExtension(filePath);
                string templateName = fileName["template-".Length..];
                options.Add(templateName);
            }

            options.Sort();

            return options;
        }

        public static string Get(string templateName)
        {
            string fileName = $"template-{templateName}.txt";
            string path = Path.Combine(_root, fileName);

            if (!File.Exists(path))
            {
                return string.Empty;
            }

            return File.ReadAllText(path);
        }

        public static void Update(string templateName, string content)
        {
            string fileName = $"template-{templateName}.txt";
            string path = Path.Combine(_root, fileName);
            File.WriteAllText(path, content);
        }

        public static void Delete(string templateName)
        {
            string fileName = $"template-{templateName}.txt";
            string path = Path.Combine(_root, fileName);
            if (File.Exists(path))
            {
                File.Delete(path);
            }
        }
    }
}
