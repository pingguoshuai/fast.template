namespace Fast.Template.IdsAdmin.Common
{
    public class SelectItem<T>
    {
        public SelectItem(string text, T value)
        {
            Text = text;
            Value = value;
        }

        public string Text { get; set; }
        public T Value { get; set; }
    }
}
