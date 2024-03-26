using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Observer
{
    public class SubjectObs
    {
        private List<IObserver> observers;
        public SubjectObs()
        {
            observers = new List<IObserver>();
        }

        public void Subsciribe(IObserver observer)
        {
            observers.Add(observer);
        }

        public void Unsubscribe(IObserver observer)
        {
            observers.Remove(observer);
        }

        public void NotifyObserver()
        {
            foreach (var observer in observers)
            { 
                observer.Update();
            }
        }
    }
}
