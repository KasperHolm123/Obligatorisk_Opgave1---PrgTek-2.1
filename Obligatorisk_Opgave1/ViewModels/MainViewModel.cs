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
    public delegate void WarningMessage(Exception ex);

    public class MainViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public event WarningMessage CallFailed;


        public PriorityQueue<Vampire> VipVampires { get; set; } 
        public PriorityQueue<Vampire> StartVampires { get; set; }
        public PriorityQueue<Vampire> EndVampires { get; set; }
        public RelayCommand StartCall { get; set; }
        public RelayCommand StopCall { get; set; }
        public RelayCommand MakeVip { get; set; }

        private string callerName = "";
        

        public MainViewModel()
        {
            VipVampires = new PriorityQueue<Vampire>();
            StartVampires = new PriorityQueue<Vampire>();
            EndVampires = new PriorityQueue<Vampire>();
            FillLists();
            StartCall = new RelayCommand(p => TakeCall());
            StopCall = new RelayCommand(p => EndCall());
            MakeVip = new RelayCommand(p => MakeVampireVip());
        }

        private void FillLists()
        {
            Vampire vamp1 = new Vampire(1, "Kasper");
            Vampire vamp2 = new Vampire(2, "Emil");
            Vampire vamp3 = new Vampire(3, "Martin");
            Vampire vamp4 = new Vampire(4, "Jonas");
            Vampire vamp5 = new Vampire(0, "Hans");
            Vampire vamp6Vip = new Vampire(5, "Jesper");
            StartVampires.Enqueue(vamp1, vamp1.Priority);
            StartVampires.Enqueue(vamp4, vamp4.Priority);
            StartVampires.Enqueue(vamp5);
            StartVampires.Enqueue(vamp2, vamp2.Priority);
            StartVampires.Enqueue(vamp3, vamp3.Priority);
            StartVampires.Enqueue(vamp6Vip, vamp6Vip.Priority);
        }

        private Vampire currVamp;
        private void TakeCall()
        {
            try
            {
                if (currVamp != null)
                    throw new Exception("Et opkald er allerede i gang");

                if (VipVampires.Count > 0)
                {
                    currVamp = VipVampires.Dequeue();
                    CallerName = currVamp.Name;
                }
                else
                {
                    if (currVamp == null)
                    {
                        currVamp = StartVampires.Dequeue();
                        CallerName = currVamp.Name;
                    }
                }
            }
            catch (Exception ex)
            {
                if(CallFailed != null)
                    CallFailed(ex);
            }
        }

        private void EndCall()
        {
            try
            {
                if (currVamp == null)
                    throw new Exception("Der er ikke noget opkald i gang");

                if (currVamp != null)
                {
                    EndVampires.Enqueue(currVamp);
                    currVamp.CallEndedTime = DateTime.Now.ToString("HH:mm:ss");
                    CallerName = "";
                    currVamp = null;
                }
            }
            catch (Exception ex)
            {
                if (CallFailed != null)
                    CallFailed(ex);
            }
        }
        
        public Vampire selectedVamp { get; set; }
        private void MakeVampireVip()
        {
            try
            {
                if (selectedVamp == null)
                    throw new Exception("Der er ikke valgt nogen vampyr");
                selectedVamp.IsVip = true;
                VipVampires.Enqueue(selectedVamp);
                StartVampires.Remove(selectedVamp);
                selectedVamp = null;
            }
            catch (Exception ex)
            {
                if (CallFailed != null)
                    CallFailed(ex);
            }
        }

        public string CallerName
        {
            get { return callerName; }
            set
            {
                callerName = value;
                OnPropertyChanged();
            }
        }
        
        private void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
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

        public void Execute(object parameter) //Invoke delegate
        {
            execute(parameter);
        }
    }
}
