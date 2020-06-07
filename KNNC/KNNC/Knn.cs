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

        public void calculateKnn(List<double> fields)
        {
            ratingSet.AddRange(Data.ratingSet);

            foreach(Rating r in ratingSet)
            {
                r.cosValue = calculateCos(fields, r.fields);
            }

            ratingSet.Sort((a,b) => b.cosValue.CompareTo(a.cosValue));


            foreach (Rating r in ratingSet)
            {
                Console.WriteLine(r.cosValue);
            }

            Console.WriteLine(ratingSet.Count);
        }

        public double calculateCos(List<double> fields1, List<double> fields2)
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
