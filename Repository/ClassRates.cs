using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class ClassRates : ClassNotify
    {
        private string _disclaimer;
        private string _license;
        private long _timestamp;
        private string _Base;
        private string _key;
        private double _value;
        private string _strDateTime;
        private double _rateDK;

        private double _DKK;

        public ClassRates()
        {
            strDateTime = "";
            _DKK = 0D;
            rateDK = 0D;
            disclaimer = "";
            license = "";
            timestamp = 0;
            Base = "";
            key = "";
            value = 0D;
        }

        public ClassRates(ClassExchangeRates inRates, string inKey, double inValue)
        {
            strDateTime = "";
            _DKK = inRates.rates["DKK"];
            rateDK = 0D;
            disclaimer = inRates.disclaimer;
            license = inRates.license;
            timestamp = inRates.timestamp;
            Base = inRates.Base;
            key = inKey;
            value = inValue;
        }

        public double rateDK
        {
            get { return _rateDK; }
            set
            {
                if (_rateDK != value)
                {
                    _rateDK = value;
                }
                Notify("rateDK");
            }
        }

        public string strDateTime
        {
            get { return _strDateTime; }
            set
            {
                if (_strDateTime != value)
                {
                    _strDateTime = value;
                }
                Notify("strDateTime");
            }
        }

        public double value
        {
            get { return _value; }
            set
            {
                if (_value != value)
                {
                    _value = value;
                    CalculateRateInDKK();
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
        public string disclaimer
        {
            get { return _disclaimer; }
            set
            {
                if (_disclaimer != value)
                {
                    _disclaimer = value;
                }
                Notify("disclaimer");
            }
        }

        public string license
        {
            get { return _license; }
            set
            {
                if (_license != value)
                {
                    _license = value;
                }
                Notify("license");
            }
        }

        public long timestamp
        {
            get { return _timestamp; }
            set
            {
                if (_timestamp != value)
                {
                    _timestamp = value;
                    MakeTimeString();
                }
                Notify("timestamp");
            }
        }

        public string Base
        {
            get { return _Base; }
            set
            {
                if (_Base != value)
                {
                    _Base = value;
                }
                Notify("Base");
            }
        }
        private void MakeTimeString()
        {
            strDateTime = DateTimeOffset.FromUnixTimeSeconds(timestamp).ToString("dd-MM-yyyy HH:mm:ss");
        }
        private void CalculateRateInDKK()
        {
            rateDK = (1 / value) * _DKK;
        }
    }
}
