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
                if (Operation == "%") _rezult += "%";
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
            get 
            {
                var a = model.Operator1.ToString();
                if (_operator1 != null && _operator1[_operator1.Length - 1] == ',')
                    return _operator1;                
                else if (a == "0")
                    return "";
                else return a;
            }
            set
            {
                _operator1 = value;
                if (_operator1[_operator1.Length - 1] != ',')
                    model.Operator1 = float.Parse(_operator1);
                OnProrertyChanged(nameof(Operator1));
            }
        }

        private string _operator2;
        public string Operator2
        {
            get 
            {
                var b = model.Operator2.ToString();
                if (_operator2 != null && _operator2[_operator2.Length - 1] == ',')
                    return _operator2;
                else if (b == "0")
                    return "";
                else return b;
            }
            set
            {
                _operator2 = value;
                if (_operator2[_operator2.Length - 1] != ',')
                    model.Operator2 = float.Parse(_operator2);
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

            else Operator2 +=parameter;

            UpdateRezult();
        }

        public void OperationMethod(string parameter)
        {
            if (parameter == "+" || parameter == "-" ||
                parameter == "*" || parameter == "/"||
                parameter == "%")
            {
                Operation = parameter;
            }
            else if (parameter == ",")
            {
                if (Operation == null) 
                {
                    Operator1 +=",";
                }
                else Operator2 += ","; 
            }

            UpdateRezult();
        }
        public void Clear()
        {
            if (Operator2 != "")
            {                
                if (Operator2.Length > 1)
                {
                    Operator2 = Operator2.Substring(0, Operator2.Length - 1);
                    if (Operator2[Operator2.Length - 1] == ',')
                        Operator2 = Operator2.Substring(0, Operator2.Length - 1);
                   
                }
                else
                {
                    Operator2 = "0";
                    Operation = null;
                }
            }
            else if (Operator1 != "")
            {
                if (Operator1.Length > 1)
                {
                    Operator1 = Operator1.Substring(0, Operator1.Length - 1);
                    if(Operator1[Operator1.Length-1] == ',')
                        Operator1 = Operator1.Substring(0, Operator1.Length - 1);
                    
                }
                else
                {
                    Operator1 = "0";
                }
                UpdateRezult();
            }
        }
        private void UpdateRezult()
        {
             if (Operator1 != "")
                Rezult = model.ExecutOperation().ToString();
            
        }


    }

} 

