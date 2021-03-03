using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wpf3DPlayer.Common
{
    public class ObservableBase
    {
        private PropertyChangedEventHandler propertyChanged;
        public event PropertyChangedEventHandler PropertyChanged
        {
            add { propertyChanged += value; }
            remove { propertyChanged -= value; }
        }

        protected void SetProperty<TProperty>(ref TProperty property, TProperty value, [CallerMemberName] string propertyName = "")
        {
            var equalityComparer = EqualityComparer<TProperty>.Default;
            if (!equalityComparer.Equals(property, value))
            {
                property = value;
                NotifyPropertyChanged(propertyName);
            }
        }

        protected void NotifyPropertyChanged(string propertyName)
        {
            propertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}