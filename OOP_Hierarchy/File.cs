namespace OOP
{
    enum FileFormat
    {
        jpg,
        png,
        gif,
        docx,
        xls
    }
    internal class File : Shortcut
    {
        private FileFormat format;
        private Shortcut shortcut;
        private string content;
        protected string Author;
        public FileFormat GetFormat() => this.format;
        public Shortcut GetShortcut() => this.shortcut;
        public string GetContent() => this.content;
        public string GetAuthor() => this.Author;
        public void SetFormat(FileFormat format) { }
        public void SetShortcut(Shortcut shortcut) { }
        public void SetContent(string content) { }
        public void SetAuthor(string author) { }

    }
}
