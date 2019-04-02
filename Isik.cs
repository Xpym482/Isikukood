using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Isikukood
{
    class Isik
    {
        private int paev_isik;
        private int kuu_isik;
        private int aasta_isik;
        protected string sugu;
        protected int[] kordajad1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 1 };
        protected int[] kordajad2 = { 3, 4, 5, 6, 7, 8, 9, 1, 2, 3 };
        protected int[] kood;

        public Isik(string newIsikukood)
        {
            kood = Array.ConvertAll(newIsikukood.ToCharArray(), element => (int)Char.GetNumericValue(element));

            if(isValid(kood))
            {
                sunniPaev();
            }
            else
            {
                Console.WriteLine("Proovige uuesti.");
            }
        }


        public void sunniPaev()
        {
            aasta_isik = int.Parse(kood[1].ToString() + kood[2].ToString());
            paev_isik = int.Parse(kood[5].ToString() + kood[6].ToString());
            kuu_isik = int.Parse(kood[3].ToString() + kood[4].ToString());

            int day = DateTime.Today.Day;
            int month = DateTime.Today.Month;
            int year = DateTime.Today.Year;

            switch (kood[0])
            {
                case 3:
                    aasta_isik = aasta_isik + 1900;
                    sugu = "mees";
                    break;
                case 4:
                    aasta_isik = aasta_isik + 1900;
                    sugu = "naine";
                    break;
                case 5:
                    aasta_isik = aasta_isik + 2000;
                    sugu = "mees";
                    break;
                case 6:
                    aasta_isik = aasta_isik + 2000;
                    sugu = "naine";
                    break;
            }

            year = year - aasta_isik;
            if (month < kuu_isik)
            {
                    year--;
                Console.WriteLine("Te olete {0} {1} aastad vana.", sugu, year);
            }
            else if(month == kuu_isik && day < paev_isik)
            {
                year--;
                Console.WriteLine("Te olete {0} {1} aastad vana.", sugu, year);
            }
            else
            {
                Console.WriteLine("Te olete {0} {1} aastad vana.", sugu, year);
            }
        }

        public bool isValid(int[] arr)
        {
            int summa = 0;
            double jaak = 0;

            for (int i = 0; i < 10; i++)
            {
                summa += arr[i] * kordajad1[i];
            }

            if (jaak == 10)
            {
                summa = 0;
                for (int i = 0; i < 10; i++)
                {
                    summa += arr[i] * kordajad2[i];
                }
                jaak = summa % 11;

                if (jaak == 10)
                {
                    jaak = 0;
                }
            }

            if (jaak == arr[10])
            {
                Console.WriteLine("Kontroll number soobib.");
                return true;
            }
            else
            {
                Console.WriteLine("Viga isikukoodiga.");
                return false;
            }
        }
    }
}
