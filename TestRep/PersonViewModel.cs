using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace TestRep
{
    class PersonViewModel :INotifyPropertyChanged
    {
        public PersonViewModel()
        {
            myCommand = new ButtonCommand(this);
        }

        private Person p = new Person();
        public bool IsOld 
        {
            get { return p.Age > 25; }
        }

        public int txtAge
        {
            set { p.Age = value; }
            get { return p.Age; }
        }

        public string txtName
        {
            get { return p.Name; }
            set { p.Name = value; }
        }

        public string txtFirstName
        {
            get { return p.FirstName; }
            set { p.FirstName = value; }
        }

        public string txtTax
        {
            get { return p.Tax.ToString(); }
        }

        public void CalcTax()
        {
            p.CalcTax();
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs("txtTax"));
            }
        }

        private ButtonCommand myCommand;
        public ICommand btnClick
        {
            get { return myCommand; }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
