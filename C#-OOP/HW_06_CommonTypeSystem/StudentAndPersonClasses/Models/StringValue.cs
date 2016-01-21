namespace StudentAndPersonClasses.Models
{
    using System;
    public class StringValue : System.Attribute
    {

        private string newValue;

        public StringValue(string value)
        {
            newValue = value;
        }

        public string Value
        {
            get { return newValue; }
        }

    }
}
