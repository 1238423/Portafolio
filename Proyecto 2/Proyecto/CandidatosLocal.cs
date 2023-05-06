using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Presidente
    {
       
            public Guid Id { get; set; }
            public string Name { get; set; }
            public string Partido { get; set; }
            public string VicePresident { get; set; }
        
    }
    public class CandidatosLocal
    {

        private List<Presidente> presidentes;

        public CandidatosLocal()
        {
            presidentes = new List<Presidente>();
        }

        public void AgregarPresidente(Presidente presidente)
        {
            presidentes.Add(presidente);
        }

        public List<Presidente> ObtenerPresidentes()
        {
            return presidentes;
        }
    }
}
