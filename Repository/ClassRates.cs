using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassRates : ClassNotify
    {
        private string _key;
        private double _value;

        public ClassRates()
        {
            key = "";
            value = 0D;
        }

        public double value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                }
                Notify("value");
            }
        }

        public string key
        {
            get { return _key; }
            set
            {
                if (_key != value)
                {
                    _key = value;
                }
                Notify("key");
            }
        }

    }
}
