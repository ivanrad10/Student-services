using CLI.DAO;
using CLI.Model;
using CLI.Observer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CLI.Controller
{
    public class KatedraController
    {
        private readonly KatedraDAO katedraDAO;

        public KatedraController()
        {
            katedraDAO = new KatedraDAO();
        }

        public List<Katedra> GetAllKatedras()
        {
            return katedraDAO.GetAllKatedra();
        }
        public void Subscribe(IObserver observer)
        {
            katedraDAO.katedraSubject.Subsciribe(observer);
        }
    }
}
