using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfSample.DataModels
{
    public class TextDispModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        string textData = "初期化されました";
        public string TextData {
            get 
            {
                return textData;
            } 
            set
            {
                textData = value;
                OnPropertyChanged("TextData");
            }
        }

        private void OnPropertyChanged(string propertyName)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        

    }
}
