# OOP-Project
This repo is about a music application with OOP concepts


Projemi, bir müzik oynatma uygulaması simülasyonu olarak tasarladım. Kullanıcılar sisteme "Standart Kullanıcı" veya "Sanatçı" olarak giriş yapabilir ve her rolün kendine özgü özellikleri bulunmaktadır. Projemi, Object-Oriented Programming (OOP) prensipleri (kapsülleme, kalıtım, çok biçimlilik ve soyutlama) kullanılarak geliştirdim. Aslında özetle; Kullanıcıların şarkı çalma, şarkı ekleme (sadece sanatçılar için) ve mevcut şarkı listesini görüntüleme işlemlerini gerçekleştirebileceği bir komut satırı tabanlı uygulamadır.


Algoritma:
Başlangıç:
Kullanıcıyı karşıla.
Kullanıcıdan kullanıcı adı al.
Kullanıcı türünü sor (Sanatçı mı? Evet/Hayır).
Kullanıcı türü belirle:

Eğer kullanıcı "Evet" yanıtını verirse, Sanatçı sınıfını oluştur.
Eğer kullanıcı "Hayır" yanıtını verirse, Standart Kullanıcı sınıfını oluştur.
Ana Menüye Geç:

Sonsuz bir döngü başlat.
Kullanıcıya aşağıdaki işlemleri sun:
1 - Şarkı Çal
2 - Şarkı Ekle (Sadece Sanatçılar için)
3 - Şarkı Listesini Görüntüle
4 - Çıkış
Kullanıcı işlem seçimi yapacak:

Kullanıcıdan bir işlem seçmesini iste.
İşlem Seçeneklerine Göre Yapılacaklar:

1 - Şarkı Çalma:

Kullanıcıdan çalmak istediği şarkı adını al.
Şarkı listesinde, kullanıcının yazdığı şarkıyı ara:
Eğer şarkı bulunursa:
Şarkıyı çal.
Eğer şarkı bulunmazsa:
"Üzgünüz, şarkı bulunamadı" mesajı göster.
2 - Şarkı Ekleme (Sanatçılar için):

Eğer kullanıcı Sanatçıysa:
Yeni şarkı bilgilerini al (Şarkı adı, Sanatçı adı, Albüm adı, Süre, Şarkı türü).
Yeni şarkıyı müzik listesine ekle.
"Şarkı listeye eklendi" mesajını göster.
Eğer kullanıcı Standart Kullanıcıysa:
"Bu işlemi sadece sanatçılar gerçekleştirebilir!" mesajını göster.
3 - Şarkı Listesini Görüntüle:

Mevcut şarkı listesini kullanıcıya göster.
4 - Çıkış:

"Çıkış yapılıyor..." mesajını göster ve uygulamayı sonlandır.
Tekrar Ana Menüye Dön:

Kullanıcı işlem seçeneği verdiği sürece döngü devam eder.
Son:

Kullanıcı çıkış yaparsa, uygulamayı sonlandır.
