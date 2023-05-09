using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace calc
{
    public class CloseButton : Button
    {
        public CloseButton()
        {
            Click += (s, e) => Application.Current.Shutdown();
        }
    }
}
