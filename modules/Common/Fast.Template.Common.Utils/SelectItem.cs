using System;

namespace Fast.Template.Common.Utils
{
    /// <summary>
    /// 列表项
    /// </summary>
    public class SelectItem
    {
        public SelectItem(string key, string value)
        {
            Key = key;
            Value = value;
        }

        public string Key { get; set; }
        public string Value { get; set; }
    }

    //public class SelectItem : SelectItem<string>
    //{
    //    public SelectItem(string text, string value) : base(text, value)
    //    {
    //    }
    //}

    //public class SelectItem<T>
    //{
    //    public SelectItem(string text, T value)
    //    {
    //        Text = text;
    //        Value = value;
    //    }

    //    public string Text { get; set; }
    //    public T Value { get; set; }
    //}
}
