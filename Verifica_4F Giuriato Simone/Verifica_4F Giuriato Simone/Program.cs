using System;

namespace Verifica_4F_Giuriato_Simone
{
    class Program
    {
        class Treno         //classe padre Treno
        {
            //attributi
            public string codTreno;
            public string tipo;
            public string nome;
            public double valore;
            public Treno(string codTreno, string tipo, string nome, double valore)  //costruttore
            {
                this.codTreno = codTreno;
                this.tipo = tipo;
                this.nome = nome;
                this.valore = 0;

            }
            public virtual double Costo()   //metodo per calcolare costo base
            {
                valore = 100000;
                return valore;

            }
            public virtual double CostoU(double km)     //metodo per calcolare costo in base ai kilometri effettuati
            {
                return km;
            }
        }
        class Passeggeri : Treno        //classe figlia Passeggeri
        {
            //attributi
            int numVagoni;
            string alimentazione;
            public Passeggeri(string codTreno, string tipo, string nome, double valore, int numVagoni, string alimentazione)  : base (codTreno, tipo,nome, valore) //costruttore
            {
                this.numVagoni = 0;
                this.alimentazione = alimentazione;

            }
            public override double Costo()  //metodo per calcolare costo base
            {
                return base.Costo() * 1.25;     //riprendo il valore dal metodo della classe padre e lo moltiplico per la percentuale
            }
            public override double CostoU(double km)        //metodo per calcolare costo in base ai kilometri effettuati
            {
                return base.CostoU(km) * 150;       //riprendo il valore del metodo della classe padre e lo moltiplico per i soldi al kilometro
            }
        }
        class Merci: Treno          //classe figlia Merci
        {
            //attributi
            int numVagoni;
            string alimentazione;
            public Merci(string codTreno, string tipo, string nome, double valore, int numVagoni, string alimentazione) :base(codTreno, tipo, nome, valore) //costruttore
            {
                this.numVagoni = 0;
                this.alimentazione = alimentazione;
            }
            public override double Costo()      //metodo per calcolare costo base
            {
                return base.Costo() * 1.35;
            }
            public override double CostoU(double km)        //metodo per calcolare costo in base ai kilometri effettuati
            {
                return base.CostoU(km) * 100;
            }
        }
        static void Main(string[] args)
        {
            bool controllo1, controllo2;        //inizializzo variabili per controllo
            Passeggeri p = new Passeggeri("AAA", "regionale","Pippo", 100000, 3, "Carbone");
            Merci m = new Merci("BBB", "nazionale", "Pluto", 100000, 5, "Elettrico");
            double km1, km2;
            do
            {
                Console.WriteLine("Quanti kilometri effettua il treno Passeggeri?");
                string a = Convert.ToString(Console.ReadLine());
                controllo1 = double.TryParse(a, out km1);
            } while (!controllo1);      //controllo che l'utente inserisca un numero corretto e non stringhe
           
            double costoUtilizzoP=p.CostoU(km1);
            double valorePasseggeri = p.Costo();
            double sommaCostiP = valorePasseggeri + costoUtilizzoP;
            Console.WriteLine("Il codice del treno è: " + p.codTreno + " //  Il tipo è: " + p.tipo + " //  Il suo nome è: "+ p.nome + "\n-Costo base per farlo partire: "+ valorePasseggeri+ "euro"+ " "+ "-Costo totale in base ai km: "+ costoUtilizzoP+"euro" );
            Console.WriteLine("La somma totale dei costi per il treno Passeggeri è: " + sommaCostiP +"euro.");
            Console.WriteLine(" ");

            do
            {
                Console.WriteLine("\nQuanti kilometri effettua il treno Merci?");
                string b = Convert.ToString(Console.ReadLine());
                controllo2 = double.TryParse(b, out km2);
            } while (!controllo2);   //controllo che l'utente inserisca un numero corretto e non stringhe

            double costoUtilizzoM = m.CostoU(km2);
            double valoreMerci = m.Costo();
            double sommaCostiM = valoreMerci + costoUtilizzoM;
            Console.WriteLine("Il codice del treno è: " + m.codTreno + " // Il tipo:" + m.tipo + " // Il treno si chiama: " + m.nome + "\n-Costo base per farlo partire:" + valoreMerci + "euro  -Costo totale in base ai km effettuati: " + costoUtilizzoM +"euro");
            Console.WriteLine("La somma totale dei costi per il treno Merci è: " + sommaCostiM+"euro.");


            Console.ReadKey();
        }
    }
}
