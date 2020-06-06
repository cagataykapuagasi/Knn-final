using System;
using System.Collections.Generic;
using System.IO;

namespace KNNC
{
    public class Rating
    {
        public string hotelId, style, cleaning, food, service, price, location, parking;

        public Rating(string hotelId, string style, string cleaning, string food, string service, string price, string location, string parking)
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
        public List<Rating> ratingSet = new List<Rating>();

        public Data()
        {


            var rating = File.ReadLines("restoran-oneri.txt"); //veriler okundu
            List<string> ratingList = new List<string>();

            ratingList.AddRange(rating);

            ratingList.RemoveAt(0); //datanın ilk satırının atılması

            foreach (string line in ratingList)
            {
                String[] array = line.Split(','); //virgülden sonra ayrım

                Rating r = new Rating(array[0], array[1], array[2],
                array[3], array[4], array[5], array[6], array[7]);

                ratingSet.Add(r);
            }




        }
    }
}
