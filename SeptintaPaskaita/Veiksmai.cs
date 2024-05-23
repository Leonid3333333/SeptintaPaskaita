using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeptintaPaskaita
{
    public class Veiksmai
    {
        private StreamWriter _streamWriter;
        private StreamReader _streamReader;
        private readonly string _manoFailas;

        public Veiksmai(string manoFailas)
        {
            _manoFailas = manoFailas;
        }
        private void AtidarytiSrautaIFaila()
        {
            _streamWriter = new StreamWriter(_manoFailas);
        }
        public void IrasykKlientaIFaila(Klientas klientas)
        {
            AtidarytiSrautaIFaila();
            _streamWriter.WriteLine($"{klientas.AsmensKodas},{klientas.Vardas},{klientas.Pavarde}");
            _streamWriter.Close();
        }
        public void IrasykKlientusIFaila(List<Klientas> klientai)
        {
            AtidarytiSrautaIFaila();
            foreach (Klientas klientas in klientai)
            {
                _streamWriter.WriteLine($"{klientas.AsmensKodas},{klientas.Vardas},{klientas.Pavarde}");
            }
            _streamWriter.Close();
        }
        public List<Klientas> SkaitytiKlientuSarasa()
        {
            List<Klientas> klientai = new List<Klientas>();

            _streamReader = new StreamReader(_manoFailas);
            string eilute;
            while ((eilute = _streamReader.ReadLine()) != null)
            {
                string[] reiksmes = eilute.Split(',');
                klientai.Add(new Klientas(long.Parse(reiksmes[0]), reiksmes[1], reiksmes[2]));
            }
            _streamReader.Close();
            return klientai;
        }
    }
}
