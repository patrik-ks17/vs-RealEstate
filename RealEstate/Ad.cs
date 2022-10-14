using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace RealEstate
{
    internal class Ad
    {
        public int Area { get; set; }
        public Category Category { get; set; }
        public DateTime CreateAt { get; set; }
        public string Description { get; set; }
        public int Floors { get; set; }
        public bool FreeOFCharge { get; set; }
        public int Id { get; set; }
        public string ImageURL { get; set; }
        public string LatLong { get; set; }
        public int Rooms { get; set; }
        public Seller Seller { get; set; }
        
        public double LatLongx 
        { get {
                return double.Parse(LatLong.Split(',')[0]);
            } 
        }
        public double LatLongy
        { get {
                return double.Parse(LatLong.Split(',')[1]);
            }
        }

        public Ad(string sor)
        {
            string[] adatok = sor.Split(';');
            Id = int.Parse(adatok[0]);
            Rooms = int.Parse(adatok[1]);
            LatLong = adatok[2];
            Floors = int.Parse(adatok[3]);
            Area = int.Parse(adatok[4]);
            Description = adatok[5];
            FreeOFCharge = adatok[6] == "1";
            ImageURL = adatok[7];
            CreateAt = DateTime.Parse(adatok[8]);
            Seller = new Seller(int.Parse(adatok[9]), adatok[10], adatok[11]);
            Category = new Category(int.Parse(adatok[12]), adatok[13]);
        }

        public static List<Ad> LoadFromCsv(string filename) {
            string[] beolvas = File.ReadAllLines(filename);
            List<Ad> adList = new List<Ad>();
            for (int i = 1; i < beolvas.Length; i++)
            {
                adList.Add(new Ad(beolvas[i]));
            }
            return adList;
        }
        
        public double DistanceTo(double cx, double cy) {
            return Math.Sqrt(Math.Pow(Math.Abs(cx - LatLongx), 2) + Math.Pow(Math.Abs(cy - LatLongy), 2));
        }
    }
}