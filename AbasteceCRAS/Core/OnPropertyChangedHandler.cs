using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace AbasteceCRAS.Core
{
    public class OnPropertyChangedHandler : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;


        protected void OnPropertyChanged([CallerMemberName] string nome = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nome));
        }
    }
}
