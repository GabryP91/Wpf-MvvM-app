using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Wpf_MvvM_app.MVVM
{
    // classe base che implementa l'interfaccia INotifyPropertyChanged, che espone un evento PropertyChanged (per supporto al databinding)
    internal class ViewModelBase : INotifyPropertyChanged
    {
        //Evento che WPF ascolta per sapere quando una proprietà è cambiata
        public event PropertyChangedEventHandler? PropertyChanged;

        //Metodo che attiva l'evento PropertyChanged, passando il nome della proprietà che è cambiata.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

    }
}
