using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfSample.DataModels;

namespace WpfSample
{
    class TextDispViewModel
    {
        
        TextDispModel model = new TextDispModel();
        
        public ICommand SetTextDataCommand
        {
            get
            {
                return new BaseCommand((text) =>
                {
                    Model.TextData = (string)text;
                });
            }
        }

        public TextDispModel Model
        {
            get { return model; }
            set
            {
                model = value;
            }
        }
    }
}
