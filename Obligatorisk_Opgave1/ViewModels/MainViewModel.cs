using Obligatorisk_Opgave1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Obligatorisk_Opgave1.ViewModels
{
    public class MainViewModel
    {
        public PriorityQueue<Vampire> Vampires { get; set; }

        public RelayCommand StartCall { get; set; }
        public RelayCommand EndCall { get; set; }

        public MainViewModel()
        {
            FillLists();
            Vampires = new PriorityQueue<Vampire>();
            StartCall = new RelayCommand(p => );
            EndCall = new RelayCommand(p => );
        }

        private void FillLists()
        {
            Vampire vamp1 = new Vampire(0, "Kasper");
            Vampire vamp2 = new Vampire(50, "bruh");
            Vampire vamp3 = new Vampire(200, "br");
            Vampire vamp4 = new Vampire(100, "Jonas");
            Vampires.Enqueue(vamp1);
            Vampires.Enqueue(vamp4);
            Vampires.Enqueue(vamp2);
            Vampires.Enqueue(vamp3);
        }

        private void TakeCall()
        {

        }

    }
    public class RelayCommand : ICommand
    {
        readonly Action<object> execute;
        readonly Predicate<object> canExecute;

        public RelayCommand(Action<object> execute)
          : this(execute, null)
        {
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter) //Return true hvis delegate unassigned, ellers håndtere event handler 
        {
            return canExecute == null ? true : canExecute(parameter);
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void Execute(object parameter)//Invoke delegate
        {
            execute(parameter);
        }
    }
}
