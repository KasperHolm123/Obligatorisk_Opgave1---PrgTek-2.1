using Obligatorisk_Opgave1.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.ComponentModel;
using System.Diagnostics;

namespace Obligatorisk_Opgave1.ViewModels
{
    public class MainViewModel
    {
        public PriorityQueue<Vampire> StartVampires { get; set; }
        public PriorityQueue<Vampire> EndVampires { get; set; }

        public RelayCommand StartCall { get; set; }
        public RelayCommand StopCall { get; set; }

        public MainViewModel()
        {
            StartVampires = new PriorityQueue<Vampire>();
            EndVampires = new PriorityQueue<Vampire>();
            FillLists();
            StartCall = new RelayCommand(p => TakeCall());
            StopCall = new RelayCommand(p => EndCall());
        }

        private void FillLists()
        {
            Vampire vamp1 = new Vampire(1, 0, "Kasper");
            Vampire vamp2 = new Vampire(2, 50, "bruh");
            Vampire vamp3 = new Vampire(3, 200, "br");
            Vampire vamp4 = new Vampire(4, 100, "Jonas");
            StartVampires.Enqueue(vamp1, vamp1.Priority);
            StartVampires.Enqueue(vamp4, vamp4.Priority);
            StartVampires.Enqueue(vamp2, vamp2.Priority);
            StartVampires.Enqueue(vamp3, vamp3.Priority);
        }

        private Vampire currVamp;
        bool CallStarted;
        private void TakeCall()
        {
            currVamp = StartVampires.Dequeue();
            CallStarted = true;
        }

        private void EndCall()
        {
            if (CallStarted)
                EndVampires.Enqueue(currVamp);
            CallStarted = false;
            
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
