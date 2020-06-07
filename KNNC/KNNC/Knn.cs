using System;
using System.Collections.Generic;
using System.Linq;

namespace KNNC
{
    public class Knn
    {
        public List<Rating> ratingSet =new List<Rating>();
        public Knn()
        {
        }

       
        public List<Rating> calculateKnn(List<double> fields, int k)
        {
            ratingSet.AddRange(Data.ratingSet);

            foreach(Rating r in ratingSet) //otellerle kullanıcının girdiği değerlerde hesaplama
            {
                r.cosValue = calculateCos(fields, r.fields);
            }

            ratingSet.Sort((a,b) => b.cosValue.CompareTo(a.cosValue));

            List<Rating> resultSet = new List<Rating>();

            resultSet.AddRange(ratingSet.GetRange(0, k));

            for (int i = k; i < ratingSet.Count; i++) //en yüksek değer kullanıcının istediği adetten fazla çıkarsa, diğer en yüksek değerler de sonuç listesine eklenir
            {
                if (ratingSet[k].cosValue == ratingSet[0].cosValue)
                {
                    resultSet.Add(ratingSet[k]);
                }
                else
                {
                    break;
                }
            }

            return resultSet;
        }

        public double calculateCos(List<double> fields1, List<double> fields2) //2 adet listedeki değerlendirmelerin kosinüs benzerliğini bulmak
        {
            double part1 = 0, part2, d1 = 0, d2 = 0;

            for(int i = 0;i<fields1.Count;i++)
            {
                part1 += fields1[i] * fields2[i];

                d1 += fields1[i] * fields1[i];
                d2 += fields2[i] * fields2[i];
            }

            part2 = Math.Sqrt(d1) * Math.Sqrt(d2);

            return part1 / part2;
        }
    }
}
