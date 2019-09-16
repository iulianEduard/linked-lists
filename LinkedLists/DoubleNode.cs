using System;
using System.Collections.Generic;
using System.Text;

namespace LinkedLists
{
    public class DoubleNode
    {
        private int _value;

        public int Value
        {
            get
            {
                return _value;
            }
            set
            {
                _value = value;
            }
        }

        public DoubleNode Previous { get; set; }

        public DoubleNode Next { get; set; }

        public DoubleNode(int value)
        {
            _value = value;
        }
    }
}
