using System.Collections;
using System.Data;

namespace AdresDefteri
{
    public enum KisiTipi
    {
        Musteri = 1,
        Personel = 2,
        Paydas = 3
    }

    internal class Program
    {
        /*
         * Adres defteri
         * ----------------------------------
         * 
         * Kişi bilgileri, müşteriler, personeller, paydaşlar
         * Bu kişiler kaydedilebilecek
         * Arama
         * Tümünü görüntüle
         * Dosyaya kaydet, dosyadan oku
         * 
         * */

        static void Main(string[] args)
        {
            string secim;

            //if()
            IAdresDefteri adresDefteri = new AdresDefteri();

            while (true)
            {
                Console.WriteLine("Adres defterine hoşgeldiniz");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("1) Arama");
                Console.WriteLine("2) Tüm defteri görüntüle");
                Console.WriteLine("3) Yeni kayıt");
                Console.WriteLine("4) Sil");
                Console.WriteLine("Diğer: Çıkış");
                Console.Write("Lütfen yapmak istediğiniz işlemi seçin: ");
                secim = Console.ReadLine();

                if (secim == "1") //arama
                {
                    Console.Clear();
                    Console.WriteLine("Arama");
                    Console.WriteLine("----------------------");
                    Console.Write("Lütfen aranacak kelimeyi girin: ");
                    string aranacak = Console.ReadLine();

                    adresDefteri.Arama(aranacak);
                }
                else if (secim == "2") //tümünü görüntüle
                {
                    Console.Clear();
                    Console.WriteLine("Tümünü görüntüleme");
                    Console.WriteLine("----------------------");

                    adresDefteri.TumunuGoruntule();
                }
                else if (secim == "3") //yeni kayıt
                {
                    Console.Clear();
                    Console.WriteLine("Yeni kayıt ekleme");
                    Console.WriteLine("----------------------");

                    string kisiSecim;
                    Console.Write("Lütfen ne tür kişi eklemek istediğinizi seçin (1 -> Müşteri, 2 -> Personel, 3 -> Paydaş): ");
                    kisiSecim = Console.ReadLine();
                    bool sonuc = false;

                    if (kisiSecim == "1")
                    {
                        Musteri musteri = new Musteri();

                        Console.Write("Adı Soyadı *: ");
                        musteri.AdiSoyadi = Console.ReadLine();

                        Console.Write("Telefon: ");
                        musteri.Telefon = Console.ReadLine();

                        Console.Write("Adres *: ");
                        musteri.Adres = Console.ReadLine();

                        Console.Write("Sipariş Sayısı: ");
                        musteri.SiparisSayisi = Convert.ToInt32(Console.ReadLine());

                        sonuc = adresDefteri.Ekle(musteri);
                    }
                    else if (kisiSecim == "2")
                    {
                        Personel personel = new Personel();

                        Console.Write("Adı Soyadı *: ");
                        personel.AdiSoyadi = Console.ReadLine();

                        Console.Write("Telefon *: ");
                        personel.Telefon = Console.ReadLine();

                        Console.Write("Adres: ");
                        personel.Adres = Console.ReadLine();

                        Console.Write("Departman *: ");
                        personel.Departman = Console.ReadLine();

                        sonuc = adresDefteri.Ekle(personel);
                    }
                    else if (kisiSecim == "3")
                    {
                        Paydas paydas = new Paydas();

                        Console.Write("Adı Soyadı *: ");
                        paydas.AdiSoyadi = Console.ReadLine();

                        Console.Write("Telefon: ");
                        paydas.Telefon = Console.ReadLine();

                        Console.Write("Adres: ");
                        paydas.Adres = Console.ReadLine();

                        Console.Write("Şirket *: ");
                        paydas.Sirket = Console.ReadLine();

                        paydas.IsimYaz();

                        sonuc = adresDefteri.Ekle(paydas);
                    }

                    if (sonuc == true)
                        Console.WriteLine("Kişi adres defterine eklendi");
                    else
                        Console.WriteLine("Girilen bilgiler hatalıdır, lütfen zorunlu alanları doldurun");
                }
                else if (secim == "4")
                {
                    Console.Clear();
                    Console.WriteLine("Silme");
                    Console.WriteLine("----------------------");
                    Console.Write("Lütfen silinecek kişi adını giriniz: ");
                    string silinecek = Console.ReadLine();

                    adresDefteri.Sil(silinecek);

                    Console.WriteLine("Kişi silindi");
                }
                else
                    break;

                //Ahmet ahmet = new Ahmet();
                //adresDefteri.Ekle2(ahmet);

                //Ayse ayse = new Ayse();
                //adresDefteri.Ekle2(ayse);

                Console.ReadLine();
                Console.Clear();
            }
        }
    }
}