using System;
using System.Collections.Generic;

namespace KNNC
{
    class Program
    {
        static List<double> fields = new List<double>();
        static List<Rating> results = null;
        static int k = 0;

        static void Main(string[] args)
        {

            Data data = new Data();
            Knn knn = new Knn();

            List<double> testList = new List<double>();

            testList.Add(0.5);
            testList.Add(0.7);
            testList.Add(0.8);
            testList.Add(0.3);
            testList.Add(0.2);
            testList.Add(0.8);
            testList.Add(0.9);

            init();

            results = knn.calculateKnn(fields, k);
            if(results[0].cosValue < 0.5)
            {
                askLowCos();
            }

            Console.WriteLine("Oteller listeleniyor...");
            listResults();



        }

        static void askLowCos()
        {
            Console.WriteLine("Tercihlerinize uygun restoran yok gibi. Yine de listelemek ister misiniz ?");
            string answer = Console.ReadLine();
            if (answer == "evet")
            {
                listResults();
            }
            else if (answer == "hayır")
            {
                again();
            }
            else
            {
                askLowCos();
            }
        }

        static void listResults()
        {
            foreach(Rating r in results)
            {
                Console.WriteLine(r.hotelId + " - " + r.cosValue);
            }
        }
        static void init()
        {
            Console.WriteLine("Lütfen değerleri 0-10 arası bir değerde puanlayınız.");
            askField("ortam_��kl���");
            askField("ortam_temizli�i");
            askField("yemek_kalitesi");
            askField("hizmet_kalitesi");
            askField("fiyat_uygunlu�u");
            askField("ula��m_kolayl���");
            askField("ara�_park_olana��");
            askK();
        }
        static void again()
        {
            Console.WriteLine("Lütfen kıstas tercih puanlarınızı gözden geçirip yenileyiniz");
            init();
        }

        static void askField(string field)
        {
            Console.WriteLine(field + " değerini girin");

            string ifield = Console.ReadLine();

            try
            {
                double dfield = int.Parse(ifield) * 1.0 / 10;
                if(int.Parse(ifield) < 1)
                {
                    Console.WriteLine("Değerlendirme 1 den düşük olamaz");
                    return;
                }
                if (int.Parse(ifield) > 10)
                {
                    Console.WriteLine("Değerlendirme 10 dan büyük olamaz");
                    return;
                }
                fields.Add(dfield);
                
            } catch (Exception e)
            {
                Console.WriteLine("Lütfen 1-10 numalarından birini kullanın");
                askField(field);
            }
        }

        static void askK()
        {
            Console.WriteLine("Kaç tane restoran önerisi istiyorsunuz ?");
            string field = Console.ReadLine();
            try
            {

                if (int.Parse(field) < 1)
                {
                    Console.WriteLine("Restoran sayısı 1 den düşük olamaz");
                    askK();
                    return;
                }
                if (int.Parse(field) > 10)
                {
                    Console.WriteLine("Restoran sayısı 15 dan büyük olamaz");
                    askK();
                    return;
                }

                k = int.Parse(field);
            }
            catch (Exception e)
            {
                Console.WriteLine("Lütfen 1-15 numalarından birini kullanın");
            }
        }
    }
}
