using System;
using System.Collections.Generic;
using System.IO;

namespace KNNC
{
    public class Rating
    {
        public string hotelId;
        public double  style, cleaning, food, service, price, location, parking;

        public Rating(string hotelId, double style, double cleaning, double food, double service, double price, double location, double parking)
        {
            this.hotelId = hotelId;
            this.style = style;
            this.cleaning = cleaning;
            this.food = food;
            this.service = service;
            this.price = price;
            this.location = location;
            this.parking = parking;
        }
    }



    public class Data
    {
        public static List<Rating> ratingSet = new List<Rating>();

        public Data()
        {


            var rating = File.ReadLines("restoran-oneri.txt"); //veriler okundu
            List<string> ratingList = new List<string>();

            ratingList.AddRange(rating);

            ratingList.RemoveAt(0); //datanın ilk satırının atılması

            foreach (string line in ratingList)
            {
                String[] array = line.Split(','); //virgülden sonra ayrım

                Rating r = new Rating(array[0], parseFloat(array[1]), parseFloat(array[2]),
                parseFloat(array[3]), parseFloat(array[4]), parseFloat(array[5]), parseFloat(array[6]), parseFloat(array[7]));

                ratingSet.Add(r);
            }




        }

        double parseFloat(string r)
        {
            double result = 0;

            if(r != "?")
            {
                result = int.Parse(r) * 1.0 / 10;
            }

            Console.WriteLine(result);
            return result;
        }
    }
}
