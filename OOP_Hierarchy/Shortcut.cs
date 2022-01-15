using System;

namespace OOP
{
    struct Image { }
    internal class Shortcut
    {
        protected string name;
        protected long weight;
        protected DateTime creatingDate;
        private Image image;

        public string GetName() => this.name;
        public long GetWeight() => this.weight;
        public Image GetImage() => this.image;
        public DateTime GetDate() => this.creatingDate;
        public void SetName(string name) { }
        public void SetWeight(long weight) { }
        public void SetImage(Image image) { }
        public void SetDate(DateTime date) { }

    }
}
