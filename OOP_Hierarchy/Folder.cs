using System.Collections.Generic;

namespace OOP
{
    internal class Folder : File
    {
        private List<File> files;

        public List<File> GetFiles() => this.files;
        public void SetFiles(List<File> files) { }
    }
}
