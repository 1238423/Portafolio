using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto
{
    public class Diputado
    {
        public Guid Id { get; set; }
        public string Nombre { get; set; }
        public string Partido { get; set; }
        public string Departamento { get; set; }
    }

    public class _CandidatosLocalD
    {
        private List<Diputado> diputados;

        public _CandidatosLocalD()
        {
            diputados = new List<Diputado>();
        }

        public void AgregarDiputado(Diputado diputado)
        {
            diputados.Add(diputado);
        }
        public List<Diputado> ObtenerDiputados()
        {
            return diputados;
        }
    }
}
