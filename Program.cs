

namespace HaromszogTerKer
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int a = 3;
            int b = 4;
            int c = 20;

            if(!haromOldalEllenorzese(a, b, c))
            {
                throw new ArgumentException ("Az oldal csak pozitív lehet");
                //ha ide jutunk, megakad a prg. futása
            }

            int kerulet = Kerulet(a, b, c);
            double terulet = Terulet(a, b, c);

            string adat = $"A {a},{b},{c} oldalú hsz.\n";
            adat += $"\tterülete: {terulet}\n\tkerülete: {kerulet}";
            Megjelenites(adat);
        }

        private static bool haromOldalEllenorzese(int a, int b, int c)
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

        private static double Terulet(int a, int b, int c)
        {
            int s = Kerulet(a, b, c) / 2;
            return Math.Sqrt(s * (s - a) * (s - b) * (s - c));
        }

        private static int Kerulet(int a, int b, int c)
        {
            return a + b + c;
        }
    }
}
