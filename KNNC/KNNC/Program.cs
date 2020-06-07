using System;
using System.Collections.Generic;

namespace KNNC
{
    class Program
    {
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


            knn.calculateKnn(testList);
            Console.WriteLine("Hello World!");


        }
    }
}
