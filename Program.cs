

namespace HaromszogTerKer
{
    /* HF.:
     * minden módosítást kommitolj!
     * írj másik terület túlterhelést
     * az alapot és a magasságot is ellenőrizd!
     * az ellenőrzést bontsd 2 részre, legyen eltérő a kivételek szövege!
     * 
     * EXTRA (AI segítséggel): 
     * try/catch szerepe / használata 
     * adatok bekérése
     * típus kényszerítések értelmezése:
       pl.: m(int, double) 
       miért hívható így is:m(3, 5) 
       és nem hívható:m(3.0, PI)
     */


    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 4;
            int c = 5;

            if(!haromOldalPozitiv(a, b, c) || !SzerkeszthetoHaromSzog(a,b,c))
            {
                throw new ArgumentException ($"Az oldal legyen pozitív és a hsz. szerkeszthető!");
                //ha ide jutunk, megakad a prg. futása
            }

            int kerulet = Kerulet(a, b, c);
            double terulet = Terulet(a, b, c);

            string adat = $"A {a},{b},{c} oldalú hsz.\n";
            adat += $"\tterülete: {terulet}\n\tkerülete: {kerulet}\n";
            Megjelenites(adat);

            int alap = 12;
            int mag = 13;
            Megjelenites($"alap: {alap}, mag.: {mag}, ter.: {Terulet(alap, mag)}\n");

            double oldal1 = 5.0;
            double oldal2 = 6.0;
            double szog = 30.0;
            Megjelenites($"a: {oldal1}, b: {oldal2}, gamma: {szog}°, ter.: {Terulet(oldal1, oldal2, szog):F2}\n");
        }

        static bool SzerkeszthetoHaromSzog(int a, int b, int c)
        {
            return a + b > c && a + c > b && b + c > a;
        }

        private static bool haromOldalPozitiv(int a, int b, int c)
        {
            bool pozitivA = PozitivSzam(a);
            bool pozitivB = PozitivSzam(b);
            bool pozitivC = PozitivSzam(c);

            return pozitivA && pozitivB && pozitivC;
        }

        private static bool PozitivSzam(int szam)
        {
            return (szam >= 0);
        }

        private static void Megjelenites(string adat)
        {
            Console.Write(adat);
        }

        /* Terulet függvény túlterhelések:
         * Terulet(int, int, int)
         * Terulet(int, int)
         * Terulet(double, double, double)
         */
        private static double Terulet(int a, int b, int c)
        {
            int s = Kerulet(a, b, c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        private static double Terulet(int alap, int magassag)
        {
            return alap * magassag / 2;
        }

        private static double Terulet(double a, double b, double gammaSzog)
        {
            if (gammaSzog <= 0 || gammaSzog >= 180)
            {
                throw new ArgumentOutOfRangeException(nameof(gammaSzog), "A háromszög belső szöge 0 és 180 fok közé kell essen!");
            }
            double gammaRadian = gammaSzog * Math.PI / 180.0;
            return (a * b * Math.Sin(gammaRadian)) / 2.0;
        }

        private static int Kerulet(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
