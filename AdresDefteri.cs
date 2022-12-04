using System.Collections;
using System.Text.Json;

namespace AdresDefteri
{
    public interface IAdresDefteri
    {
        bool Ekle(Kisi kisi);
        void Sil(string aranacak);
        void Arama(string aranacak);
        void TumunuGoruntule();
    }

    public class AdresDefteri : IAdresDefteri
    {
        public List<Kisi> Liste { get; set; }
        private static string DosyaYoluMusteriler = Environment.CurrentDirectory + "\\musteri.txt";
        private static string DosyaYoluPersoneller = Environment.CurrentDirectory + "\\personel.txt";
        private static string DosyaPaydaslar = Environment.CurrentDirectory + "\\paydas.txt";
        public AdresDefteri()
        {
            Liste = new List<Kisi>();
            DosyadanOku();
        }

        //public void Ekle2(IKisi kisi)
        //{

        //}

        public bool Ekle(Kisi kisi)
        {
            if (kisi.IsValid())
            {
                Liste.Add(kisi);
                DosyayaKaydet();

                return true;
            }

            return false;
        }

        public void Sil(string aranacak)
        {
            for (int i = 0; i < Liste.Count; i++)
            {
                if (Liste[i].AdiSoyadi.ToLower() == aranacak.ToLower())
                    Liste.RemoveAt(i);
            }

            DosyayaKaydet();
        }

        public void Arama(string aranacak)
        {
            foreach (Kisi kisi in Liste)
            {
                if(kisi.AdiSoyadi.ToLower().Contains(aranacak.ToLower()))
                {
                    Console.WriteLine("Adı Soyadı: " + kisi.AdiSoyadi);
                    Console.WriteLine("Telefon: " + kisi.Telefon);
                    Console.WriteLine("Adres: " + kisi.Adres);
                    Console.WriteLine("-------------------------------");
                    Console.WriteLine("");
                }
            }
        }

        public void TumunuGoruntule()
        {
            foreach (Kisi kisi in Liste)
            {
                Console.WriteLine("Adı Soyadı: " + kisi.AdiSoyadi);
                Console.WriteLine("Telefon: " + kisi.Telefon);
                Console.WriteLine("Adres: " + kisi.Adres);
                Console.WriteLine("-------------------------------");
                Console.WriteLine("");
            }
        }

        private void DosyayaKaydet()
        {
            ArrayList musteriler = new ArrayList();
            ArrayList personeller = new ArrayList();
            ArrayList paydaslar = new ArrayList();

            foreach (var item in Liste)
            {
                if (item.GetType() == typeof(Musteri))
                    musteriler.Add(item);
                else if (item.GetType() == typeof(Personel))
                    personeller.Add(item);
                else
                    paydaslar.Add(item);
            }

            File.WriteAllText(DosyaYoluMusteriler, JsonSerializer.Serialize(musteriler));
            File.WriteAllText(DosyaYoluPersoneller, JsonSerializer.Serialize(personeller));
            File.WriteAllText(DosyaPaydaslar, JsonSerializer.Serialize(paydaslar));
        }

        private void DosyadanOku()
        {
            if (File.Exists(DosyaYoluMusteriler))
            {
                string dosya = File.ReadAllText(DosyaYoluMusteriler);

                if (string.IsNullOrWhiteSpace(dosya) == false)
                {
                    var liste = JsonSerializer.Deserialize<Musteri[]>(dosya);
                    Liste.AddRange(liste);
                }
            }

            if (File.Exists(DosyaYoluPersoneller))
            {
                string dosya = File.ReadAllText(DosyaYoluPersoneller);

                if (string.IsNullOrWhiteSpace(dosya) == false)
                {
                    var liste = JsonSerializer.Deserialize<Personel[]>(dosya);
                    Liste.AddRange(liste);
                }
            }

            if (File.Exists(DosyaPaydaslar))
            {
                string dosya = File.ReadAllText(DosyaPaydaslar);

                if (string.IsNullOrWhiteSpace(dosya) == false)
                {
                    var liste = JsonSerializer.Deserialize<Paydas[]>(dosya);
                    Liste.AddRange(liste);
                }
            }
        }
    }
}