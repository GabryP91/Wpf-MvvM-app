using System.Windows.Input;

namespace Wpf_MvvM_app.MVVM
{
    //Implementazione Interfaccia Icommand, che richiede i metodi CanExecute, Execute e l'evento CanExecuteChanged.
    class RelayCommand : ICommand
    {
        // delegato (riferimento a un metodo,"variabile" che può contenere un metodo) che accetta un oggetto e non restituisce nulla
        private Action<object> execute;

        // delegato (riferimento a un metodo,"variabile" che può contenere un metodo) che accetta un oggetto e restituisce un valore di tipo bool
        //serve per indicare se un comando è abilitato (es. se un bottone deve essere attivo o disabilitato)
        private Func<object, bool> canExecute;

        //evento che segnala alla UI (ad esempio, un bottone in XAML) che la possibilità di eseguire un comando è cambiata.
        public event EventHandler? CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        //Costruttore
        //Action<object> execute → rappresenta il metodo che sarà chiamato quando il comando viene eseguito.
        //Func<object, bool> canExecute → funzione che dice se il comando può essere eseguito (se false, per esempio un bottone sarà disabilitato).
        public RelayCommand(Action<object> execute, Func<object, bool> canExecute = null)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        //metodo che dice alla UI se il comando può essere eseguito in questo momento.
        public bool CanExecute(object? parameter)
        {
            return canExecute == null || canExecute(parameter);
        }

        //è il metodo che viene chiamato quando il comando viene eseguito (es. quando premi un bottone collegato al comando).
        public void Execute(object? parameter)
        {
            execute(parameter);
        }
    }
}
