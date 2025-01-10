using System;
using System.Collections.Generic;
using System.Linq;

// Şarkı Türü ENUM
public enum SarkiTuru
{
    Pop,
    Rock,
    Jazz,
    Klasik,
    Rap
}

// Şarkı sınıfı (Encapsulation ile)
public class Muzik
{
    public string ParcaAdi { get; set; }
    public string Sanatci { get; set; }
    public string Album { get; set; }
    public double Sure { get; set; }
    public SarkiTuru Tur { get; set; } // Şarkı türü

    public Muzik(string parcaAdi, string sanatci, string album, double sure, SarkiTuru tur)
    {
        ParcaAdi = parcaAdi;
        Sanatci = sanatci;
        Album = album;
        Sure = sure;
        Tur = tur;
    }

    public override string ToString()
    {
        return $"{ParcaAdi} - {Sanatci} ({Sure} dk) [{Tur}]";
    }
}

// Temel Kullanıcı sınıfı (Abstract ve Polymorphism)
// SOYUT
public abstract class Kullanici
{
    //property-otomatik özellik
    public string KullaniciAdi { get; set; }

    //constructor-yapıcı metot
    public Kullanici(string kullaniciAdi)
    {
        KullaniciAdi = kullaniciAdi;
    }

    public abstract void ParcaCal(Muzik parca);
}

// Standart Kullanıcı sınıfı (Inheritance)
public class StandartKullanici : Kullanici
{
    public StandartKullanici(string kullaniciAdi) : base(kullaniciAdi) { }

    public override void ParcaCal(Muzik parca)
    {
        Console.WriteLine($"{KullaniciAdi}, şu an çalan şarkı: {parca.ParcaAdi} - {parca.Sanatci}");
    }
}

// Sanatçı sınıfı (Inheritance)
public class Sanatci : Kullanici
{
    public Sanatci(string kullaniciAdi) : base(kullaniciAdi) { }

    public void SarkiEkle(List<Muzik> muzikListesi, Muzik yeniSarki)
    {
        muzikListesi.Add(yeniSarki);
        Console.WriteLine($"Sanatçı {KullaniciAdi}, {yeniSarki.ParcaAdi} adlı şarkıyı listeye ekledi.");
    }

    public override void ParcaCal(Muzik parca)
    {
        Console.WriteLine($"{KullaniciAdi}, şu an çalan şarkı: {parca.ParcaAdi} - {parca.Sanatci}");
    }
}

// Program sınıfı
public class Program
{
    static void Main(string[] args)
    {
        // Şarkı listesi
        List<Muzik> muzikListesi = new List<Muzik>
        {
            new Muzik("Viva La Vadi", "Son Feci Bisiklet", "1", 4.5, SarkiTuru.Rock),
            new Muzik("The Night We Met", "Lord Huron", "2", 3.8, SarkiTuru.Jazz),
            new Muzik("Bodrum", "Teoman", "En Güzel Hikayem", 3.5, SarkiTuru.Rock)
        };
        Console.WriteLine("That’s What She Played Müzik Uygulamasına Hoş Geldiniz:)");
        // Kullanıcı giriş
        Console.WriteLine("Lütfen kullanıcı adınızı giriniz:");
        string kullaniciAdi = Console.ReadLine();

        Console.WriteLine("Sanatçı mısınız? (E/H):");
        string sanatciMi = Console.ReadLine();

        Kullanici aktifKullanici;

        if (sanatciMi.Equals("E", StringComparison.OrdinalIgnoreCase))
        {
            aktifKullanici = new Sanatci(kullaniciAdi);
            Console.WriteLine("Sanatçı olarak giriş yaptınız.");
        }
        else
        {
            aktifKullanici = new StandartKullanici(kullaniciAdi);
            Console.WriteLine("Standart kullanıcı olarak giriş yaptınız.");
        }

        // Ana döngü
        while (true)
        {
            Console.WriteLine("\nLütfen bir işlem seçin:");
            Console.WriteLine("1 - Şarkı Çal");
            Console.WriteLine("2 - Şarkı Ekle (Sadece Sanatçılar için)");
            Console.WriteLine("3 - Şarkı Listesini Görüntüle");
            Console.WriteLine("4 - Çıkış");

            string secim = Console.ReadLine();

            switch (secim)
            {
                case "1":
                    // Şarkı çalma
                    Console.WriteLine("Çalmak istediğiniz şarkının adını yazınız:");
                    string sarkiAdi = Console.ReadLine();

                    var secilenSarki = muzikListesi.FirstOrDefault(m =>
                        string.Equals(m.ParcaAdi, sarkiAdi, StringComparison.OrdinalIgnoreCase));

                    if (secilenSarki != null)
                    {
                        aktifKullanici.ParcaCal(secilenSarki);
                    }
                    else
                    {
                        Console.WriteLine("Üzgünüz,şarkı bulunamadı:(");
                    }
                    break;

                case "2":
                    // Şarkı ekleme (sadece sanatçılar için)
                    if (aktifKullanici is Sanatci sanatci)
                    {
                        Console.WriteLine("Lütfen yeni şarkı bilgilerini girin:)");
                        Console.Write("Şarkı Adı: ");
                        string yeniParcaAdi = Console.ReadLine();

                        Console.Write("Sanatçı Adı: ");
                        string yeniSanatciAdi = Console.ReadLine();

                        Console.Write("Albüm Adı: ");
                        string yeniAlbumAdi = Console.ReadLine();

                        Console.Write("Süre (dakika): ");
                        double yeniSure = double.Parse(Console.ReadLine());

                        Console.Write("Şarkı Türü (Pop, Rock, Jazz, Klasik, Rap): ");
                        SarkiTuru yeniTur = (SarkiTuru)Enum.Parse(typeof(SarkiTuru), Console.ReadLine(), true);

                        var yeniSarki = new Muzik(yeniParcaAdi, yeniSanatciAdi, yeniAlbumAdi, yeniSure, yeniTur);
                        sanatci.SarkiEkle(muzikListesi, yeniSarki);
                    }
                    else
                    {
                        Console.WriteLine("Üzgünüz:( Bu işlemi sadece sanatçılar gerçekleştirebilir!");
                    }
                    break;

                case "3":
                    // Şarkı listesini görüntüleme
                    Console.WriteLine("\nMevcut Şarkılar:");
                    foreach (var muzik in muzikListesi)
                    {
                        Console.WriteLine($"- {muzik}");
                    }
                    break;

                case "4":
                    // Çıkış
                    Console.WriteLine("Çıkış yapılıyor! Hoşça kalın:)");
                    return;

                default:
                    Console.WriteLine("Geçersiz seçim:(. Lütfen tekrar deneyin!!");
                    break;
            }
        }
        
    }
}

