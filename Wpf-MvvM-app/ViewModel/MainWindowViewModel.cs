using System.Collections.ObjectModel;
using Wpf_MvvM_app.Model;
using Wpf_MvvM_app.MVVM;

namespace Wpf_MvvM_app.ViewModel
{
    internal class MainWindowViewModel : ViewModelBase
    {
        //Rappresenta l’elemento selezionato dalla lista nella UI.
        private Item selectedItem;

        //Collezione dinamica oggetti
        public ObservableCollection<Item> Items { get; set; }

        //Creazione tre comandi che vengono chiamati al click dei rispettivi bottoni e che a loro volta chiamano rispettive funzioni
        public RelayCommand AddCommand => new RelayCommand(execute => AddItem());

        //Chiama DelItem() ma solo se c'è un elemento selezionato, in caso contrario Il bottone sarà disattivato.
        public RelayCommand DeleteCommand => new RelayCommand(execute => DelItem(), canExecute => SelectedItem != null);
        public RelayCommand SaveCommand => new RelayCommand(execute => Save(), canExecute => CanSave());

        public MainWindowViewModel()
        {

            Items = new ObservableCollection<Item>();

        }


        public Item SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                OnPropertyChanged();
            }
        }

        private void AddItem()
        {
            Items.Add(new Item
            {
                Name = "Product 1",
                SerialNumber = "0001",
                Quantity = 1,
            });
          
        }

        private void DelItem()
        {
            Items.Remove(SelectedItem);

        }

        private void Save()
        {

        }

        private bool CanSave() 
        {
            return true;
        }
    }
}