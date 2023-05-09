using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public class ViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
       
        private Model model { get; set; }
        public NamberCommand NamberCommand { get; set; }
        public OperationCommand OperationCommand { get; set; }
        public ClearCommand ClearCommand { get; set; }

        public ViewModel() 
        {
            this.model = new Model();
            this.NamberCommand = new NamberCommand(this);
            this.OperationCommand = new OperationCommand(this);
            this.ClearCommand = new ClearCommand(this);
        }

        private string _rezult;
        public string Rezult
        {
            get 
            {
                return _rezult;                 
            }
            set
            {
                _rezult = value;
                OnProrertyChanged(nameof(Rezult));
            }
           
        }
        public string Operation
        {
            get { return model.Operation; }
            set
            {
                model.Operation = value;
                OnProrertyChanged(nameof(Operation));
            }
        }

        private string _operator1;
        public string Operator1
        {
            get { return model.Operator1.ToString(); }
            set
            {
                _operator1 = value;
                model.Operator1 = Convert.ToInt64(_operator1);
                OnProrertyChanged(nameof(Operator1));
            }
        }

        private string _operator2;
        public string Operator2
        {
            get { return model.Operator2.ToString(); }
            set
            {
                _operator2 = value;
                model.Operator2 = Convert.ToInt64(_operator2);
                OnProrertyChanged(nameof(Operator2));
            }
        }

        private void OnProrertyChanged(string prop)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        public void NamberMethod(string parameter)
        {
           
            if (Operation == null) Operator1 += parameter;
            
            else Operator2 += parameter;

            UpdateRezult();
        }

        public void OperationMethod(string parameter) 
        {
            if (parameter == "+" || parameter == "-" ||
                parameter == "*" || parameter == "/") 
            {
                Operation = parameter; 
            }

            UpdateRezult();
        }
        public void Clear()
        {
            if (Operator2 != "0")
            {
                if (Operator2.Length > 1)
                {
                    Operator2 = Operator2.Substring(0, Operator2.Length - 1);
                }
                else
                {
                    Operator2 = null;
                    Operation = null;
                }
            }
            else if (Operator1 != "0")
            {
                if (Operator1.Length > 1)
                {
                    Operator1 = Operator1.Substring(0, Operator1.Length - 1);
                }
                else Operator1 = null;
            }
            UpdateRezult();
        }
        private void UpdateRezult() 
        {
            if (Operator1 != "0" && Operator2 != "0")
                Rezult = model.ExecutOperation().ToString();
        }

        
    }
}
