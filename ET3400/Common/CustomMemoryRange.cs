using System;
using System.Windows.Forms;

namespace ET3400.Common
{
    public class CustomMemoryRange : MemoryRange
    {
        private TextBox _source;
        private int _lastValue;

        public CustomMemoryRange(TextBox source)
        {
            _source = source;
        }

        public override string Description { get { return "Custom"; } }
        public override int Start
        {
            get
            {
                //int value;
                if (_source.Text == "") _source.Text = "0000";
                try
                {
                    _lastValue = Convert.ToInt32(_source.Text, 16);
                }
                catch (FormatException)
                {
                }
                return _lastValue;
            }
        }
        public override int End { get; set; }

    }
}