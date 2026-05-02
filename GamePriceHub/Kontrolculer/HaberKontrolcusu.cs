using System;
using System.Collections.Generic;
using GamePriceHub.Modeller;

namespace GamePriceHub.Kontrolculer
{
    public class HaberKontrolcusu
    {
        public List<Haber> HaberleriGetir()
        {
            List<Haber> haberler = new List<Haber>();

            // 1. Haber
            haberler.Add(new Haber
            {
                ID = 1,
                Kategori = "Sağlık",
                Baslik = "Bilgisayar Başından Kalkınca Yapmanız Gereken 10 Hayati Egzersiz",
                Ozet = "Saatlerce oyun oynadıktan sonra bel ve boyun ağrısı çekiyorsanız, bu basit 10 esneme hareketi hayatınızı kurtarabilir.",
                Icerik = "Uzun süreli oyun seansları, omurga sağlığımız için en büyük tehditlerden biridir. Sandalyede sabit bir pozisyonda saatlerce kalmak, kasların kısalmasına ve kan dolaşımının yavaşlamasına neden olur.\r\n\r\nUzmanlar, her 2 saatte bir ayağa kalkıp şu temel esnemeleri yapmanızı öneriyor:\r\n1. Boyun Çevirme: Başınızı yavaşça sağa, sola, öne ve arkaya yatırarak boyun kaslarınızı esnetin.\r\n2. Göğüs Açma: Ellerinizi arkanızda kenetleyin ve göğsünüzü öne doğru çıkarak kürek kemiklerinizi sıkıştırın.\r\n3. Bacak Esnetme: Ayağa kalkın ve bir ayağınızı kalçanıza doğru çekerek üst bacak kaslarınızı rahatlatın.\r\n\r\nBu basit hareketler, uzun vadede fıtık ve duruş bozukluğu riskini %70 oranında azaltmaktadır.",
                ResimURL = "Haber_1.png",
                Tarih = DateTime.Now.ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_1.pdf"
            });

            // 2. Haber
            haberler.Add(new Haber
            {
                ID = 2,
                Kategori = "Donanım",
                Baslik = "E-Sporcuların Sırrı: Doğru Mouse ve Klavye Seçimi Rehberi",
                Ozet = "Profesyonel arenada milisaniyeler önemlidir. Doğru switch ve sensör seçimiyle performansınızı zirveye taşıyın.",
                Icerik = "E-spor arenasında ekipman, oyuncunun vücudunun bir uzantısı gibidir. Bir FPS oyuncusu ile MOBA oyuncusunun ihtiyaç duyduğu donanımlar tamamen farklıdır.\r\n\r\nMouse Seçimi:\r\nOptik sensörlerin kalitesi (örneğin PixArt PMW3389 gibi) ve farenin ağırlığı çok kritiktir. CS:GO veya Valorant gibi düşük hassasiyet (DPI) gerektiren oyunlarda 60-80 gram arası hafif fareler tercih edilerek bilek yorgunluğu minimuma indirilir.\r\n\r\nKlavye Seçimi:\r\nMekanik klavyelerde switch seçimi tepki süresini belirler. Cherry MX Red (Kırmızı) switchler, doğrusal (linear) yapıları sayesinde tuşa basıldığı an komutu iletir ve rekabetçi oyunlar için altın standart kabul edilir.",
                ResimURL = "Haber_2.png",
                Tarih = DateTime.Now.AddDays(-1).ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_2.pdf"
            });

            // 3. Haber
            haberler.Add(new Haber
            {
                ID = 3,
                Kategori = "Sağlık",
                Baslik = "Uzun Oyun Seanslarında Göz Sağlığınızı Nasıl Korursunuz?",
                Ozet = "Mavi ışık filtresi ve 20-20-20 kuralı ile saatlerce ekrana baksanız bile göz yorgunluğunun önüne geçin.",
                Icerik = "Monitörlerden yayılan mavi ışık, göz kuruluğundan uyku bozukluklarına kadar birçok soruna yol açar. Göz kırpma sayımızın ekrana bakarken üçte bire düştüğünü biliyor muydunuz?\r\n\r\nGözleri korumanın en etkili yolu '20-20-20' kuralıdır. Her 20 dakikada bir, 20 feet (yaklaşık 6 metre) uzaklıktaki bir noktaya 20 saniye boyunca odaklanın. Bu işlem, göz kaslarınızın gevşemesini sağlar.\r\n\r\nAyrıca Windows'un 'Gece Işığı' modunu aktif etmek veya mavi ışık filtreli oyuncu gözlükleri kullanmak, korneaya binen yükü ciddi oranda hafifletecektir.",
                ResimURL = "Haber_3.png",
                Tarih = DateTime.Now.AddDays(-2).ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_3.pdf"
            });

            // 4. Haber
            haberler.Add(new Haber
            {
                ID = 4,
                Kategori = "Beslenme",
                Baslik = "Oyuncular İçin Beslenme: Refleksleri Hızlandıran Gıdalar",
                Ozet = "Sadece enerji içeceği ile olmaz! Odaklanmayı artıran ve reaksiyon süresini kısaltan süper gıdaları listeledik.",
                Icerik = "Oyun oynarken en çok yapılan hata, anlık enerji veren şekerli gıdalar ve kafein tüketmektir. Bunlar kısa süreli bir patlama yaratsa da, sonrasında ani bir çöküş (sugar crash) yaşatır.\r\n\r\nBunun yerine beynin odaklanma süresini uzatan gıdalar tüketilmelidir:\r\n- Ceviz ve Badem: İçerdikleri Omega-3 sayesinde beyin sinyallerinin hızlanmasını sağlar.\r\n- Yaban Mersini: Antioksidan deposudur ve uzun seanslarda zihinsel yorgunluğu geciktirir.\r\n- Bitter Çikolata: %70 ve üzeri kakao oranına sahip çikolatalar, doğal kafein ve teobromin içerir, odaklanmayı sarsmadan artırır.",
                ResimURL = "Haber_4.png",
                Tarih = DateTime.Now.AddDays(-3).ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_4.pdf"
            });

            // 5. Haber
            haberler.Add(new Haber
            {
                ID = 5,
                Kategori = "Donanım",
                Baslik = "Ergonomik Oyuncu Koltuğu Gerçekten İşe Yarıyor Mu?",
                Ozet = "Sırt ağrılarına son vermek için ergonomik bir koltuk şart mı, yoksa doğru oturma pozisyonu yeterli mi?",
                Icerik = "Piyasada 'Gaming Chair' (Oyuncu Koltuğu) adı altında satılan birçok ürün, aslında sadece yarış arabası koltuğu tasarımına sahiptir ve ergonomiden uzaktır.\r\n\r\nGerçek bir ergonomik koltukta olması gerekenler şunlardır:\r\n1. Bel Desteği: Omurganın doğal 'S' kıvrımını korumalıdır.\r\n2. Ayarlanabilir Kolçaklar: Bileklerin masaya paralel olmasını sağlayarak karpal tünel riskini azaltır.\r\n\r\nAncak unutmayın, dünyanın en pahalı koltuğunu da alsanız, kambur oturuyorsanız sırt ağrılarından kurtulamazsınız. Monitörün üst sınırı, göz hizanızla tam aynı hizada olmalıdır.",
                ResimURL = "Haber_5.png",
                Tarih = DateTime.Now.AddDays(-4).ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_5.pdf"
            });

            // 6. Haber
            haberler.Add(new Haber
            {
                ID = 6,
                Kategori = "Sağlık",
                Baslik = "Karpal Tünel Sendromundan Korunmak İçin Bilek Egzersizleri",
                Ozet = "Mouse kullanan oyuncuların en büyük korkulu rüyası olan bilek rahatsızlıklarını bu hareketlerle engelleyin.",
                Icerik = "Fareyi pençe (claw) veya parmak ucu (fingertip) tutuşuyla kavrayan oyuncular, bileklerindeki median sinire sürekli baskı uygularlar. Bu da elde uyuşma ve karıncalanmaya (Karpal Tünel) yol açar.\r\n\r\nÖnlem almak çok basittir:\r\nKolunuzu öne doğru düz uzatın, diğer elinizle parmaklarınızı kendinize doğru nazikçe çekerek bileğinizin alt kısmını esnetin. 15 saniye bekleyip aynısını parmakları aşağı bastırarak bileğin üst kısmı için tekrarlayın. Maç aralarında bunu yapmak sizi ameliyat masasından kurtarabilir.",
                ResimURL = "Haber_6.png",
                Tarih = DateTime.Now.AddDays(-5).ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_6.pdf"
            });

            // 7. Haber
            haberler.Add(new Haber
            {
                ID = 7,
                Kategori = "Sağlık",
                Baslik = "Monitör Işığı ve Uyku Düzeni: Gece Oyuncularına Tavsiyeler",
                Ozet = "Gece geç saatlere kadar oyun oynamak uyku kalitenizi mahvedebilir. Melatonin dengenizi geri kazanın.",
                Icerik = "İnsan beyni, mavi ışığı 'güneş ışığı' olarak algılar. Gece 02:00'ye kadar parlak bir monitöre baktığınızda, beyniniz hala gündüz olduğunu zannederek uyku hormonu olan 'Melatonin' salgılamayı durdurur.\r\n\r\nSonuç: Yatağa girseniz bile saatlerce uykuya dalamazsınız. Çözüm olarak; uyumadan en az 1 saat önce oyunu bırakmalı ve monitörünüzde Windows Gece Işığı veya f.lux gibi programlar kullanarak renk sıcaklığını sıcak (sarımsı) tonlara çekmelisiniz.",
                ResimURL = "Haber_7.png",
                Tarih = DateTime.Now.AddDays(-6).ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_7.pdf"
            });

            // 8. Haber
            haberler.Add(new Haber
            {
                ID = 8,
                Kategori = "Donanım",
                Baslik = "Oyunlarda Ping Düşürmek İçin En İyi Ağ Ekipmanları",
                Ozet = "Oyun esnasında yaşanan lag droplarını bitirecek, Wi-Fi 6 destekli router ve ethernet kablosu rehberi.",
                Icerik = "Rekabetçi oyunlarda FPS ne kadar önemliyse, paket kaybı (packet loss) ve ping de o kadar önemlidir. Özellikle Wi-Fi üzerinden oyun oynuyorsanız, dalgalanmalar kaçınılmazdır.\r\n\r\nİlk ve en ucuz kural: Mümkünse mutlaka CAT6 veya CAT7 bir Ethernet kablosu kullanın. Kablo çekmek imkansızsa, QoS (Quality of Service) ayarı bulunan ve oyun trafiğine öncelik tanıyan 'Gaming Router' modellerine geçiş yapın. Bant genişliğini sadece sizin oyununuza ayırarak evdeki diğer indirme işlemlerinin lag yaratmasını engellerler.",
                ResimURL = "Haber_8.png",
                Tarih = DateTime.Now.AddDays(-7).ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_8.pdf"
            });

            // 9. Haber
            haberler.Add(new Haber
            {
                ID = 9,
                Kategori = "Donanım",
                Baslik = "Mekanik Klavye Switch Rehberi: Kırmızı, Mavi, Kahverengi?",
                Ozet = "Sessiz mi, tok sesli mi, yoksa hızlı tepkili mi? Kendi oyun tarzınıza en uygun switch modelini keşfedin.",
                Icerik = "Mekanik klavyeler sadece ses çıkarmak için değildir; tuşun hissiyatı oyun tarzınızı belirler.\r\n\r\n- Mavi Switch: Daktilo gibi 'klik' sesi çıkarır. Bastığınızı kesin olarak hissedersiniz ancak rekabetçi oyunlar ve yayıncılar için gürültülüdür.\r\n- Kırmızı Switch: Doğrusaldır, klik sesi ve hissi yoktur. Çok yumuşaktır ve hızlı tepki verir. FPS oyuncularının favorisidir.\r\n- Kahverengi Switch: İkisinin ortasıdır. Sesi kırmızılar kadar az, basım hissiyatı maviler kadar belirgindir. Hem yazı yazan hem oyun oynayanlar için idealdir.",
                ResimURL = "Haber_9.png",
                Tarih = DateTime.Now.AddDays(-8).ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_9.pdf"
            });

            // 10. Haber
            haberler.Add(new Haber
            {
                ID = 10,
                Kategori = "Sağlık",
                Baslik = "Duruş Bozukluğunu Önleyen Monitör Konumlandırma Taktikleri",
                Ozet = "Boyun fıtığını engellemek için monitörünüzün göz hizanıza tam olarak nasıl konumlandırılması gerektiğini öğrenin.",
                Icerik = "Oyuncuların %80'i monitörlerine yanlış açıdan bakmaktadır. Monitörünüz çok alçaktaysa boynunuzu sürekli öne eğersiniz, bu da 'İleri Baş Postürü' (Forward Head Posture) denilen boyun fıtığının başlangıcına yol açar.\r\n\r\nDoğru konumlandırma kuralı: Monitörün tam ortası DEĞİL, monitörün en üst çerçevesi kaş hizanızla aynı seviyede olmalıdır. Ayrıca monitörünüz, yüzünüze en az bir kol mesafesi (yaklaşık 50-60 cm) uzaklıkta durmalıdır.",
                ResimURL = "Haber_10.png",
                Tarih = DateTime.Now.AddDays(-9).ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_10.pdf"
            });

            // 11. Haber
            haberler.Add(new Haber
            {
                ID = 11,
                Kategori = "E-Spor",
                Baslik = "Günde Sadece 15 Dakika ile Aim Geliştirme Taktikleri",
                Ozet = "Günde sadece 15 dakika ayırarak kas hafızanızı nasıl geliştirebileceğinizi adım adım anlatıyoruz.",
                Icerik = "AimLock veya AimLab gibi programlarda saatler harcamak yerine, istikrarlı bir 15 dakikalık rutin çok daha etkilidir. Kas hafızası (Muscle Memory) yorularak değil, düzenli tekrarla gelişir.\r\n\r\nAntrenmanınızı 3 aşamaya bölün:\r\n1. Flicking (Anlık nişan alma - 5 Dk): Ekranda rastgele beliren hedeflere olabildiğince hızlı tıklayın.\r\n2. Tracking (Takip etme - 5 Dk): Hareket eden bir hedefin üzerinde crosshair'i (nişangahı) sabit tutmaya çalışın.\r\n3. Micro-adjustments (Küçük düzeltmeler - 5 Dk): Birbirine çok yakın küçük hedefler arasında hassas geçişler yapın.",
                ResimURL = "Haber_11.png",
                Tarih = DateTime.Now.AddDays(-10).ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_11.pdf"
            });

            // 12. Haber
            haberler.Add(new Haber
            {
                ID = 12,
                Kategori = "Beslenme",
                Baslik = "Oyun Oynarken Şeker Tüketimi Kan Şekerinizi Nasıl Etkiler?",
                Ozet = "Oyun sırasında tüketilen yüksek şekerli gıdalar, maçın en kritik anında odak kaybı yaşamanıza sebep olabilir.",
                Icerik = "Kritik bir rank maçındasınız ve masanızda kola, cips, jelibon var. Bu basit karbonhidratlar kana anında karışır ve insülin seviyenizi tavan yaptırır. Beyniniz kısa bir süreliğine ekstra hızlı çalışıyor gibi hisseder.\r\n\r\nAncak 45 dakika sonra pankreasınızın salgıladığı yoğun insülin kan şekerini aniden dibe çeker. Buna 'şeker çöküşü' denir. O an elleriniz titrer, refleksleriniz yavaşlar ve odaklanamazsınız. Rekabetçi oyunlarda sabit kan şekeri, sabit performans demektir.",
                ResimURL = "Haber_12.png",
                Tarih = DateTime.Now.AddDays(-11).ToString("dd.MM.yyyy"),
                PdfDosyaAdi = "Haber_12.pdf"
            });

            

            return haberler;
        }
    }
}