using RealEstate;

List<Ad> ads = Ad.LoadFromCsv("realestates.csv");

double osszeg = 0;
int fszdarab = 0;
foreach (Ad ad in ads)
{
    if (ad.Floors == 0)
    {
        fszdarab++;
        osszeg += ad.Area;
    }
}Console.WriteLine($"1. Földszinti ingatlanok átlagos alapterülete:{(osszeg / fszdarab):0.00} m2");

double mesvarX = 47.4164220114023;
double mesvarY = 19.066342425796986;


