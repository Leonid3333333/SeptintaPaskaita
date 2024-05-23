using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptintaPaskaita
{
    public class Klientas
    {
            public long AsmensKodas { get; set; }
            public string Vardas { get; set; }
            public string Pavarde { get; set; }

            public Klientas(long asmensKodas, string vardas, string pavarde)
            {
                AsmensKodas = asmensKodas;
                Vardas = vardas;
                Pavarde = pavarde;
            }
    }
}
