using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calc
{
    public class Model 
    {
        private float _rezult;
        public float Rezult 
        { get { return _rezult; }
            set 
            { 
                _rezult = value;
              
            } 
        }
        private string _operation;
        public string Operation 
        { get { return _operation; } 
            set 
            {
                _operation = value;
               
            } 
        }

        private float _operator1;
        public float Operator1 
        { get {return _operator1; } 
            set 
            {
                _operator1 = value;
               
            }
        }

        private float _operator2;
        public float Operator2 
        { get { return _operator2; }
            set 
            {
                _operator2 = value;
               
            }
        }

        public void Summ() 
        {
           _rezult = _operator1 + _operator2;
        }

        public void Subtraction()
        {
            _rezult = _operator1 - _operator2;
        }

        public void Multiply()
        {
            _rezult = _operator1 * _operator2;
        }

        public void Division()
        {
            _rezult = _operator1 / _operator2;
        }

        public float ExecutOperation() 
        {
            if (_operation == "+")  Summ();
            if (_operation == "-") Subtraction();
            if (_operation == "*") Multiply();
            if (_operation == "/") Division();
            return Rezult;
            
        }
    }
}
