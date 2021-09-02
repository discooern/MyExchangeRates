using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IO;
using Repository;

namespace BIZ
{
    public class ClassBIZ : ClassNotify
    {
        ClassCurrencyApiCall CCAC = new ClassCurrencyApiCall();
        private ClassExchangeRates _exRates;
        private ClassRates _rate;
        private List<ClassRates> _listRates;

        public ClassBIZ()
        {
            exRates = new ClassExchangeRates();
            rate = new ClassRates();
            GetData();
        }


        public List<ClassRates> listRates
        {
            get { return _listRates; }
            set
            {
                if (_listRates != value)
                {
                    _listRates = value;
                }
                Notify("listRates");
            }
        }

        public ClassRates rate
        {
            get { return _rate; }
            set
            {
                if (_rate != value)
                {
                    _rate = value;
                }
                Notify("rate");
            }
        }

        public ClassExchangeRates exRates
        {
            get { return _exRates; }
            set
            {
                if (_exRates != value)
                {
                    _exRates = value;
                }
                Notify("exRates");
            }
        }

        private void GetData()
        {
            var task = Task.Run(async () => await CCAC.GetApiData());
            exRates = (ClassExchangeRates)task.Result;
            SetUpRatesList();
        }

        private void SetUpRatesList()
        {
            List<ClassRates> temp = new List<ClassRates>();
            foreach (var item in exRates.rates)
            {
                ClassRates cr = new ClassRates(exRates, item.Key, item.Value);
                temp.Add(cr);
            }
            listRates = temp;
        }
    }
}
