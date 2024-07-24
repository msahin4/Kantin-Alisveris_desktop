# Projenin Konusu
Bu proje, para ile ilişkisi çok da iyi olmayan yaşça küçük öğrencilerin kantin alışverişlerini kolaylaştırmak için tasarlanmıştır. Ayrıca, ebeveynlere de çocuklarının harçlıklarını yönetme ve harcamalarını kontrol etme imkanı sağlar.

# Alışveriş Süreci
Alışveriş yapmak isteyen öğrenci kantine gelir ve görevliye almak istediği ürünleri söyler. Görevli ilgili ürünleri satış listesine ekler ve "SATIŞ" tuşuna basar. Ardından öğrencinin RFID kartını kart okuyucuya okutması beklenir. Kart okuma işleminden sonra kart ID'si alınarak bu ID üzerinden veritabanından bakiye sorgusu ve günlük harcama limiti sorgusu yapılır. Eğer yeterli bakiye varsa ve alışveriş tutarı günlük harcama limitini aşmıyorsa satış işlemi gerçekleşir. Satın alınan ürünler ve öğrencinin yeni bakiyesi veri tabanına kaydedilir.

![Satış Uygulaması](https://github.com/user-attachments/assets/8e3f77fb-3779-40d5-9b97-c2bc21f28e32)


# Veri Tabanı Tasarımı
Öğrencilerin bilgileri, öğrenciye ait kart bilgileri, bu kartla yapılan alışverişler, alışverişlerin detayları ve kantinde satılmakta olan ürünlerin bilgileri veri tabanında tutulmaktadır.

![İlişkisel veri tabanı ](https://github.com/user-attachments/assets/37d2edc2-f15b-4b10-955b-92f549089011)
