using Microsoft.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;

namespace EntityWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Yapmak istediğiniz işlemi seçiniz:\n ( Verileri Listele=1, Veri Ekleme=2, Veri Bulma=3)");
                int islem=Convert.ToInt32(Console.ReadLine());
                if (islem == 1)
                {
                    GetAllData();
                }
                else if (islem==2)
                {
                    Console.WriteLine("Ekleme yapmak istediğiniz tabloyu seçiniz:\n(Eğitmen=1, Kurs=2, Öğrenci=3, Personel=4, Sınıf=5)");
                    AddData(Convert.ToInt32(Console.ReadLine()));
                }
                else if (islem == 3)
                {
                    Console.WriteLine("ID'ye göre bulmak için Y/N: ");
                    char bul = Convert.ToChar(Console.ReadLine());
                    if (bul == 'Y' || bul == 'y') 
                    {
                        GetByID(3);
                    }
                    else
                    {
                        GetByName("Fikret");
                    }
                }
                else if(islem == 4)
                {

                }
            } 
        }
        static void AddData(int secim)
        {

            using (var db = new ShopContext())
            {
                if (secim==1)
                {
                    Console.WriteLine("Eğitmen adı giriniz: ");
                    string EAd = Console.ReadLine();
                    Console.WriteLine("Eğitmen soyadı giriniz: ");
                    string ESoyad = Console.ReadLine();
                    Console.WriteLine("Eğitmen yaşını giriniz: ");
                    int EYas = Convert.ToInt32(Console.ReadLine());
                    var egit = new Egitmen()
                    {
                        Name = EAd,
                        LastName = ESoyad,
                        Yas = EYas

                    };
                    db.egitmen.AddRange(egit);
                }
                else if (secim==2)
                {
                    Console.WriteLine("Kurs adı giriniz: ");
                    string KAd = Console.ReadLine();
                    var kur = new Kurs()
                    {
                        Name = KAd

                    };
                    db.kurs.AddRange(kur);
                }
                else if (secim==3)
                {
                    Console.WriteLine("Öğrenci adı giriniz: ");
                    string OAd = Console.ReadLine();
                    Console.WriteLine("Öğrenci soyadı giriniz: ");
                    string OSoyad = Console.ReadLine();
                    Console.WriteLine("Öğrenci yaşını giriniz: ");
                    int OYas = Convert.ToInt32(Console.ReadLine());
                    var ogr = new Ogrenci()
                    {
                        Name = OAd,
                        LastName = OSoyad,
                        Yas = OYas

                    };
                    db.ogrenci.AddRange(ogr);
                }
                else if (secim==4)
                {
                    Console.WriteLine("Personel adı giriniz: ");
                    string PAd = Console.ReadLine();
                    Console.WriteLine("Personel soyadı giriniz: ");
                    string PSoyad = Console.ReadLine();
                    var per = new Personel()
                    {
                        Name = PAd,
                        LastName = PSoyad

                    };
                    db.personel.AddRange(per);
                }
                else if (secim==5)
                {
                    Console.WriteLine("Sınıf no giriniz: ");
                    int SNo = Convert.ToInt32(Console.ReadLine());
                    Console.WriteLine("Sınıf tahtası var mı yok mu giriniz: ");
                    string STahtas = Console.ReadLine();
                    Console.WriteLine("Sınıf projeksiyonu var mı yok mu giriniz: ");
                    string SProjeksiyon = Console.ReadLine();
                    Console.WriteLine("Sınıfta bilgisayar var mı yok mu giriniz: ");
                    string SBilgisayar = Console.ReadLine();
                    var sın = new Sınıf()
                    {
                        No = SNo,
                        Tahta = STahtas,
                        Projeksiyon = SProjeksiyon,
                        Bilgisayar = SBilgisayar

                    };
                    db.sınıf.AddRange(sın);
                }
                db.SaveChanges();
                Console.WriteLine("Veri eklendi...");
            }
        }
        static void GetAllData()
        {
            using (var context = new ShopContext())
            {
                Console.WriteLine("Verilerini getirmek istediğiniz tabloyu seçiniz:\n(Eğitmen=1, Kurs=2, Öğrenci=3, Personel=4, Sınıf=5)");
                int data = Convert.ToInt32(Console.ReadLine());
                if(data==1) 
                { 
                    var table = context.egitmen.ToList();
                    foreach (var e in table)
                    {
                        Console.WriteLine($"Ad: {e.Name} Soyad: {e.LastName} Yaş: {e.Yas}" );
                    }
                }
                else if (data == 2) 
                { 
                    var table = context.kurs.ToList();
                    foreach (var e in table)
                    {
                        Console.WriteLine($"Ad: {e.Name}");
                    }
                }
                else if (data == 3) 
                { 
                    var table = context.ogrenci.ToList();
                    foreach (var e in table)
                    {
                        Console.WriteLine($"Ad: {e.Name} Soyad: {e.LastName} Yaş: {e.Yas}");
                    }
                }
                else if (data == 4) 
                { 
                    var table = context.personel.ToList();
                    foreach (var e in table)
                    {
                        Console.WriteLine($"Ad: {e.Name} Soyad: {e.LastName}");
                    }
                }
                else if (data == 5) 
                { 
                    var table = context.sınıf.ToList();
                    foreach (var e in table)
                    {
                        Console.WriteLine($"No: {e.No} Tahta: {e.Tahta} Projeksiyon: {e.Projeksiyon} Bilgisayar: {e.Bilgisayar}");
                    }
                }

                
            }
        }
        static void GetByID(int id)
        {
            using (var context = new ShopContext())
            {
                Console.WriteLine("ID'sini bulmak istediğiniz kişinin tablosunu seçiniz:\n(Eğitmen=1, Kurs=2, Öğrenci=3, Personel=4, Sınıf=5)");
                int data = Convert.ToInt32(Console.ReadLine());
                if (data == 1)
                {
                    var egitmen = context.egitmen.Where(e => e.EgitmenId == id).FirstOrDefault();
                    Console.WriteLine($"Ad: {egitmen.Name} Soyad: {egitmen.LastName} Yaş: {egitmen.Yas}");
                }
                else if (data == 2)
                {
                    var kurs = context.kurs.Where(e => e.KursId == id).FirstOrDefault();
                    Console.WriteLine($"Ad: {kurs.Name}");
                }
                else if (data == 3)
                {
                    var ogrenci = context.ogrenci.Where(e => e.OgrenciId == id).FirstOrDefault();
                    Console.WriteLine($"Ad: {ogrenci.Name} Soyad: {ogrenci.LastName} Yaş: {ogrenci.Yas}");
                }
                else if (data == 4)
                {
                    var personel = context.personel.Where(e => e.PersonelId == id).FirstOrDefault();
                    Console.WriteLine($"Ad: {personel.Name} Soyad: {personel.LastName}");
                }
                else if (data == 5)
                {
                    var sınıf = context.sınıf.Where(e => e.SınıfId == id).FirstOrDefault();
                    Console.WriteLine($"No: {sınıf.No} Tahta: {sınıf.Tahta} Projeksiyon: {sınıf.Projeksiyon} Bilgisayar: {sınıf.Bilgisayar}");
                }
            }
        }
        static void GetByName(string name)
        {
            using (var context = new ShopContext())
            {
                Console.WriteLine("İsmini bulmak istediğiniz kişinin tablosunu seçiniz:\n(Eğitmen=1, Kurs=2, Öğrenci=3, Personel=4, Sınıf=5)");
                int data = Convert.ToInt32(Console.ReadLine());
                if (data == 1)
                {
                    var egitmen = context.egitmen.Where(e => e.Name == name).FirstOrDefault();
                    Console.WriteLine($"Ad: {egitmen.Name} Soyad: {egitmen.LastName} Yaş: {egitmen.Yas}");
                }
                else if (data == 3)
                {
                    var ogrenci = context.ogrenci.Where(e => e.Name == name).FirstOrDefault();
                    Console.WriteLine($"Ad: {ogrenci.Name} Soyad: {ogrenci.LastName} Yaş: {ogrenci.Yas}");
                }
                else if (data == 4)
                {
                    var personel = context.personel.Where(e => e.Name == name).FirstOrDefault();
                    Console.WriteLine($"Ad: {personel.Name} Soyad: {personel.LastName}");
                }
            }
        }

    }
}