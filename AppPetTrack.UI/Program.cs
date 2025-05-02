using AppPetTrack.CORE.Enums;
using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.UnitOfWork;
using AppPetTrack.SERVICE.Concretes;
using AppPetTrack.SERVICE.Contracts;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace AppPetTrack.UI
{
    internal class Program
    {
        static void Main(string[] args)
        {
            AppPetTrackDbContext context = new AppPetTrackDbContext();
            IManagerRepo managerRepo = new ManagerRepo(context);

            IPetOwnerService petOwnerService = new PetOwnerService(managerRepo);
            IPetService petService = new PetService(managerRepo);
            IVetAppointmentService vetAppointmentService = new VetAppointmentService(managerRepo);
            ITrackerDeviceService trackerService = new TrackerDeviceService(managerRepo);
            IHealthRecordService healthRecordService = new HealthRecordService(managerRepo);
            IActivityLogService activityLogService = new ActivityLogService(managerRepo);
            IAlertService alertService = new AlertService(managerRepo);
            bool isRunning = true;

            while (isRunning)
            {
                Console.WriteLine("***************MyPaw'a Hoşgeldiniz***************");
                Console.WriteLine("Oturum Açmak İçin [1] Admin girişi için: (userName: admin), password(admin)");
                Console.WriteLine("Kayıt Olmak Açmak İçin [2]");
                Console.WriteLine("Çıkış Yapmak İçin [0]");
                string giris = Console.ReadLine();
                switch (giris)
                {
                    case "1":
                        Console.WriteLine("Kullanıcı Adı Giriniz");
                        string userName = Console.ReadLine();
                        Console.WriteLine("Şifre Giriniz");
                        string password = Console.ReadLine();
                        
                        
                        if (userName == "admin" && password == "admin")
                        {
                            Console.WriteLine("Admin Girişi Başarılı");
                            Console.WriteLine("Admin İşlemleri İçin [1]");
                            Console.WriteLine("Çıkış Yapmak İçin [0]");
                            string adminSecim = Console.ReadLine();
                            if (adminSecim == "1")
                            {
                                Console.WriteLine("Oturum Açıldı,Lütfen İşlem Yapmak İstediğiniz Kategoriyi Seçiniz.");
                                Console.WriteLine("Evcil Hayvan Sahibi İşlemleri İçin [1]");
                                Console.WriteLine("Evcil Hayvan İşlemleri İçin [2]");
                                Console.WriteLine("Veteriner Randevu İşlemleri İçin [3]");
                                Console.WriteLine("Tracker Cihazı İşlemleri İçin [4]");
                                Console.WriteLine("Sağlık Kaydı İşlemleri İçin [5]");
                                Console.WriteLine("Aktivite Kaydı İşlemleri İçin [6]");
                                Console.WriteLine("Uyarı İşlemleri İçin [7]");
                                Console.WriteLine("Çıkış Yapmak İçin [0]");
                                string secim1 = Console.ReadLine();
                                switch (secim1)
                                {
                                    case "0":
                                        Console.WriteLine("Çıkış Yapılıyor...");
                                        isRunning = false;
                                        break;
                                    case "1":
                                        PetOwnerProcessAdmin(petOwnerService, context);
                                        break;
                                    case "2":
                                        PetProcessAdmin(petService,context);
                                        break;
                                    case "3":
                                        VetAppointmentProcessAdmin(vetAppointmentService, context);
                                        break;
                                    case "4":
                                        TrackerDeviceProcessAdmin(trackerService, context);
                                        break;
                                    case "5":
                                        HealthRecordtProcessAdmin(healthRecordService, context);
                                        break;
                                    case "6":
                                        ActivityLogProcessAdmin(activityLogService, context);
                                        break;
                                    case "7":
                                        AlertProcessAdmin(alertService, context);
                                        break;
                                    default:
                                        break;
                                }
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Çıkış Yapılıyor...");
                                break;
                            }
                        }
                        else if (petOwnerService.CheckAccount(userName, password) == false)
                        {
                            Console.WriteLine("\nKullanıcı Adı veya Şifre Hatalı");
                            Console.WriteLine("Lütfen Tekrar Deneyiniz");
                            Console.Clear();
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Kullanıcı Girişi Başarılı");
                        }
                        while (true)
                        {
                            PetOwner petOwner = petOwnerService.GetByUserName(userName);
                            int id = petOwner.Id;
                            Console.WriteLine("Oturum Açıldı,Lütfen İşlem Yapmak İstediğiniz Kategoriyi Seçiniz.");
                            Console.WriteLine("Evcil Hayvan Sahibi İşlemleri İçin [1]");
                            Console.WriteLine("Evcil Hayvan İşlemleri İçin [2]");
                            Console.WriteLine("Veteriner Randevu İşlemleri İçin [3]");
                            Console.WriteLine("Tracker Cihazı İşlemleri İçin [4]");
                            Console.WriteLine("Sağlık Kaydı İşlemleri İçin [5]");
                            Console.WriteLine("Aktivite Kaydı İşlemleri İçin [6]");
                            Console.WriteLine("Uyarı İşlemleri İçin [7]");
                            Console.WriteLine("Çıkış Yapmak İçin [0]");
                            string secim = Console.ReadLine();
                            switch (secim)
                            {
                                case "0":
                                    Console.WriteLine("Çıkış Yapılıyor...");
                                    break;
                                case "1":
                                    PetOwnerProcess(petOwnerService, id);
                                    break;
                                case "2":
                                    PetProcess(petService, id, context);
                                    break;
                                case "3":
                                    VetAppointmentProcess(vetAppointmentService, id, context);
                                    break;
                                case "4":
                                    TrackerDeviceProcess(trackerService, id, context);
                                    break;
                                case "5":
                                    HealthRecordtProcess(healthRecordService, id, context);
                                    break;
                                case "6":
                                    ActivityLogProcess(activityLogService, id, context);
                                    break;
                                case "7":
                                    AlertProcess(alertService, id, context);
                                    break;
                                default:
                                    break;
                            }
                        }
                        break;
                    case "2":
                        Console.WriteLine("Kullanıcı Adı Giriniz");
                        string userName1 = Console.ReadLine();
                        Console.WriteLine("Şifre Giriniz");
                        string password1 = Console.ReadLine();
                        Console.WriteLine("Ad Giriniz");
                        string firstName = Console.ReadLine();
                        Console.WriteLine("Soyad Giriniz");
                        string lastName = Console.ReadLine();
                        Console.WriteLine("Telefon Numarası Giriniz");
                        string phoneNumber = Console.ReadLine();
                        Console.WriteLine("Adres Giriniz");
                        string address = Console.ReadLine();
                        Console.WriteLine("E-posta Adresi Giriniz");
                        string email = Console.ReadLine();
                        petOwnerService.Add(userName1, password1, firstName, lastName, phoneNumber, address, email);
                        Console.WriteLine("Kayıt Başarıyla Tamamlandı");
                        break;
                    case "0":
                        Console.WriteLine("Çıkış yapılıyor...");
                        Thread.Sleep(1000);
                        Console.Clear();
                        return;
                    default:
                        Console.WriteLine("Hatalı tuşlama yaptınız geri döndürülüyorsunuz");
                        Thread.Sleep(1000);
                        Console.Clear();
                        break;
                }
            }
        }



        #region KullanıcıIslemleri
        public static void PetOwnerProcess(IPetOwnerService petOwnerService, int id)
        {
            MethodInfo[] methodInfos = typeof(IPetOwnerService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                if (i == 0 || i == 2 || i == 5 || i == 6 || i == 7)
                    continue;

                if (methodInfos[i] == methodInfos[4])
                {
                    Console.WriteLine(i + 1 + " - Delete Account");
                }
                else
                {
                    Console.WriteLine(i + 1 + " - " + methodInfos[i].Name);
                }
                Console.WriteLine("9 - Geri Dön");
            }
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "2":
                    Console.WriteLine("Lütfen evcil hayvan sahibinin adını giriniz");
                    string firstName1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin soyadını giriniz");
                    string lastName1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin telefon numarasını giriniz");
                    string phoneNumber1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin adresini giriniz");
                    string address1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin e-posta adresini giriniz");
                    string email1 = Console.ReadLine();
                    petOwnerService.Update(id, firstName1, lastName1, phoneNumber1, address1, email1);

                    break;
                case "4":
                    Console.WriteLine("Hesabını Silmek İstediğinizden Emin misiniz?\n[Evet] - [Hayır]");
                    string sil = Console.ReadLine().ToLower();
                    if (sil == "evet")
                    {
                        petOwnerService.SoftDelete(id);
                        Console.WriteLine("Hesabınız Başarıyla Silinmiştir");
                    }
                    else
                    {
                        Console.WriteLine("Hesabınız Silinmedi");
                    }
                    break;
                case "5":
                    var petOwner = petOwnerService.Get(id);
                    Console.WriteLine(petOwner.ToString());
                    break;
                case "9":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Hatalı tuşlama yaptınız geri döndürülüyorsunuz");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
            }
        }

        public static void PetProcess(IPetService petService, int id, AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(IPetService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                if (i == 2 || i == 5 || i == 6 || i == 7)
                    continue;
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("9 - AllPets");
            Console.WriteLine("10 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    Console.WriteLine("Lütfen evcil hayvanınızın adını giriniz");
                    string name = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın türünü seçiniz");
                    MemberInfo[] memberInfo = typeof(PetSpecies).GetMembers();
                    for (int i = 0; i < memberInfo.Length; i++)
                    {
                        Console.WriteLine(i + 1 + " " + memberInfo[i].Name);
                    }
                    PetSpecies species = (PetSpecies)int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın cinsini giriniz");
                    string breed = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın doğum tarihini giriniz.Örneğin:(2023,10,10)");
                    DateTime birtDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın aşı bilgilerini giriniz");
                    string vaccieInformation = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın kilosunu giriniz");
                    double weight = double.Parse(Console.ReadLine());
                    petService.Add(id, name, species, breed, birtDate, vaccieInformation, weight);
                    break;
                case "2":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");
                    int id1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın adını giriniz");
                    string name1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın türünü seçiniz");
                    MemberInfo[] memberInfo1 = typeof(PetSpecies).GetMembers();
                    for (int i = 0; i < memberInfo1.Length; i++)
                    {
                        Console.WriteLine(i + 1 + " " + memberInfo1[i].Name);
                    }
                    PetSpecies species1 = (PetSpecies)int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın cinsini giriniz");
                    string breed1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın doğum tarihini giriniz.Örneğin:(2023,10,10)");
                    DateTime birtDate1 = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın aşı bilgilerini giriniz");
                    string vaccieInformation1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın kilosunu giriniz");
                    double weight1 = double.Parse(Console.ReadLine());
                    petService.Update(id1, name1, species1, breed1, birtDate1, vaccieInformation1, weight1);
                    break;
                case "4":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id2 = int.Parse(Console.ReadLine());
                    petService.Delete(id2);
                    break;
                case "5":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    var pet = petService.Get(id3);
                    break;
                case "9":
                    PrintPetsByOwnerId(id, context);
                    break;
                case "10":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Hatalı tuşlama yaptınız geri döndürülüyorsunuz");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
            }

        }

        public static void VetAppointmentProcess(IVetAppointmentService appointmentService, int id, AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos1 = typeof(IVetAppointmentService).GetMethods();

            for (int i = 0; i < methodInfos1.Length; i++)
            {
                if (i == 2 || i == 5 || i == 6 || i == 7)
                    continue;
                Console.WriteLine(i + 1 + " " + methodInfos1[i].Name);
            }
            Console.WriteLine("9 - AllAppointments");
            Console.WriteLine("10 - Geri Dön");

            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();

            switch (result)
            {
                case "1":

                    Console.WriteLine("Klinik adını giriniz");
                    string clinicName = Console.ReadLine();
                    Console.WriteLine("Lütfen veteriner adını giriniz");
                    string veterinarianName = Console.ReadLine();
                    Console.WriteLine("Lütfen randevu tarihi giriniz");
                    DateTime appointmentDate = DateTime.Parse(Console.ReadLine());
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Lütfen Randevuyu hangi hayvana eklemek istiyorsanız id sini girin.");
                    int petId = int.Parse(Console.ReadLine());
                    appointmentService.Add(petId, clinicName, veterinarianName, appointmentDate);

                    break;
                case "2":
                    PrintAppointmentsByOwnerId(id, context);
                    Console.WriteLine("Güncellemek istediğiniz randevu Id'sini giriniz: ");
                    int id1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Güncellemek istediğiniz petId'yi giriniz: ");
                    int id2 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Klinik adını giriniz");
                    string clinicName1 = Console.ReadLine();
                    Console.WriteLine("Lütfen veteriner adını giriniz");
                    string veterinarianName1 = Console.ReadLine();
                    Console.WriteLine("Lütfen randevu tarihi giriniz");
                    DateTime appointmentDate1 = DateTime.Now;
                    appointmentService.Update(id, id2, clinicName1, veterinarianName1, appointmentDate1);
                    break;
                case "4":
                    PrintAppointmentsByOwnerId(id, context);
                    Console.WriteLine("Silmek istediğiniz randevu id'sini giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    appointmentService.SoftDelete(id3);
                    break;
                case "5":
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id4 = int.Parse(Console.ReadLine());
                    var vetAppointment = appointmentService.Get(id4);
                    Console.WriteLine(vetAppointment.ToString());
                    break;//Yapamadım.
                case "9":
                    PrintAppointmentsByOwnerId(id, context);
                    break;
                case "10":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Hatalı tuşlama yaptınız geri döndürülüyorsunuz");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
            }
        }

        public static void TrackerDeviceProcess(ITrackerDeviceService trackerDeviceService, int id,AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(ITrackerDeviceService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                if (i == 2 || i == 5 || i == 6 || i == 7)
                    continue;
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("9 - AllTrackerDevices");
            Console.WriteLine("10 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");

            string result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Lütfen evcil hayvanınızın Id'sini giriniz");
                    int petId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın bulunduğu konumu giriniz");
                    string location = Console.ReadLine();
                    DateTime loggedAt = DateTime.Now;
                    trackerDeviceService.Add(petId,loggedAt, location);
                    break;
                case "2":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Güncellemek istediğiniz evcil hayvanınızın Id'sini giriniz: ");
                    int petId1 = int.Parse(Console.ReadLine());
                    PrintTrackerDeviceByPetId(id, context);
                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");
                    int id4 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen güncellemek istediğiniz evcil hayvanınızın bulunduğu konumu giriniz");
                    string location1 = Console.ReadLine();
                    DateTime loggedAt1 = DateTime.Now;
                    trackerDeviceService.Update(id4, loggedAt1, location1);
                    break;
                case "4":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Silmek istediğiniz takip cihazının üzerinde bulunduğu hayvanınızın id'sini giriniz.");
                    int petId2 = int.Parse(Console.ReadLine());
                    PrintTrackerDeviceByPetId(petId2, context);
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz");
                    int id2 = int.Parse(Console.ReadLine());
                    trackerDeviceService.SoftDelete(id2);
                    break;
                case "5":
                    PrintPetsByOwnerId(id, context);

                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    var trackerDevices = trackerDeviceService.Get(id3);
                    Console.WriteLine(trackerDevices.ToString());
                    break;
                case "9":
                    PrintTrackerDeviceByOwnerId(id, context);
                    break;
                case "10":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Hatalı tuşlama yaptınız geri döndürülüyorsunuz");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
            }
        }

        public static void HealthRecordtProcess(IHealthRecordService healthrecordService, int id, AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(IHealthRecordService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                if (i == 2 || i == 5 || i == 6 || i == 7)
                    continue;
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("9 - AllHealthRecords");
            Console.WriteLine("10 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Sağlık kaydı ekleyeceğiniz hayvanınızın id'sini giriniz.");
                    int petId = int.Parse(Console.ReadLine());
                    MemberInfo[] memberInfo = typeof(HealthType).GetMembers();
                    for (int i = 0; i < memberInfo.Length; i++)
                    {
                        Console.WriteLine(i + 1 + " " + memberInfo[i].Name);
                    }
                    Console.WriteLine("Lütfen belirtmek istediğiniz durumu seçiniz(örnek:1)");
                    HealthType healthType = (HealthType)int.Parse(Console.ReadLine());
                    Console.WriteLine("Yaptığınız seçimi açıklayınız.(örnek: 1 seçildiyse - Kuduz)");
                    string description = Console.ReadLine();
                    healthrecordService.Add(petId, healthType, description, DateTime.Now);
                    break;
                case "2":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Güncellemek istediğiniz hayvanınızın Id'sini giriniz: ");
                    int petId1 = int.Parse(Console.ReadLine());
                    MemberInfo[] memberInfo1 = typeof(HealthType).GetMembers();
                    for (int i = 0; i < memberInfo1.Length; i++)
                    {
                        Console.WriteLine(i + 1 + " " + memberInfo1[i].Name);
                    }
                    Console.WriteLine("Lütfen belirtmek istediğiniz durumu seçiniz(örnek:1)");
                    HealthType healthType1 = (HealthType)int.Parse(Console.ReadLine());
                    Console.WriteLine("Yaptığınız seçimi açıklayınız.(örnek: 1 seçildiyse - Kuduz)");
                    string description1 = Console.ReadLine();
                    healthrecordService.Update(petId1, healthType1, description1, DateTime.Now);
                    break;
                case "4":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Sağlık kaydının silinmesini istediğiniz hayvanınızın id'sini giriniz.");
                    int id2 = int.Parse(Console.ReadLine());
                    healthrecordService.SoftDelete(id2);
                    break;
                case "5":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    var healthRecord = healthrecordService.Get(id3);
                    Console.WriteLine(healthRecord.ToString());
                    break;
                case "9":
                    PrintHealthRecordByOwnerId(id, context);
                    break;
                case "10":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Hatalı tuşlama yaptınız geri döndürülüyorsunuz");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
            }
        }

        public static void ActivityLogProcess(IActivityLogService activityLogService, int id, AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(IActivityLogService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                if (i == 2 || i == 5 || i == 6 || i == 7)
                    continue;
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("9 - AllActivityLogs");
            Console.WriteLine("10 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    PrintTrackerDeviceByOwnerId(id, context);
                    Console.WriteLine("Lütfen işlem yapmak istediğiniz takip cihazınızın Id'sini giriniz");
                    int trackerId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen yürüyüş zaman aralığını giriniz.Örneğin:(1:30)");
                    TimeSpan walkingTime = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen koşu zaman aralığını giriniz.Örneğin:(1:30)");
                    TimeSpan runTime = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen uyku zaman aralığını giriniz.Örneğin:(1:30)");
                    TimeSpan sleepTime = TimeSpan.Parse(Console.ReadLine());
                    activityLogService.Add(trackerId, DateTime.Now, walkingTime, runTime, sleepTime);
                    break;
                case "2":
                    PrintActivityLogByOwnerId(id, context);
                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");
                    int id4 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen yürüyüş zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan walkingTime1 = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen koşu zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan runTime1 = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen uyku zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan sleepTime1 = TimeSpan.Parse(Console.ReadLine());
                    activityLogService.Update(id4, DateTime.Now, walkingTime1, runTime1, sleepTime1);
                    break;
                case "4":
                    PrintActivityLogByOwnerId(id, context);
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz");
                    int id2 = int.Parse(Console.ReadLine());
                    activityLogService.SoftDelete(id2);
                    break;
                case "5":
                    PrintActivityLogByOwnerId(id, context);
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    var activityLog = activityLogService.Get(id3);
                    Console.WriteLine(activityLog.ToString());
                    break;
                case "9":
                    PrintActivityLogByOwnerId(id, context);
                    break;
                case "10":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Hatalı tuşlama yaptınız geri döndürülüyorsunuz");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
            }

        }

        public static void AlertProcess(IAlertService alertService, int id, AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(IAlertService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                if (i == 2 || i == 5 || i == 6)
                    continue;
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("8 - AllAlerts");
            Console.WriteLine("9 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Lütfen işlem yapmak istediğiniz evcil hayvanınızın Id'sini giriniz");
                    int petId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın vücut ısısını giriniz. (28,2)");
                    double bodyTempature = double.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın sabit kaldığı toplam süreyi giriniz.(1:30)");
                    TimeSpan inactivity = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın kaçtı mı?(ture / false)");  //???????
                    bool escape = bool.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın kilosunu giriniz.");
                    double weight = double.Parse(Console.ReadLine());
                    alertService.Add(petId, bodyTempature, inactivity, escape, weight);
                    break;
                case "2":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Güncellemek istediğiniz evcil hayvanınızın Id'sini giriniz: ");
                    int id1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın vücut ısısını giriniz. (28,2)");
                    double bodyTempature1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın sabit kaldığı toplam süreyi giriniz.");
                    TimeSpan inactivity1 = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın kaçtı mı?");  //???????
                    bool escape1 =bool.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın kilosunu giriniz.");
                    double weight1 = double.Parse(Console.ReadLine());
                    alertService.Update(id, bodyTempature1, inactivity1, escape1, weight1);
                    break;
                case "4":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Uyarısını silmek istediğiniz evcil hayvanınızın Id'sini giriniz: ");
                    int id2 = int.Parse(Console.ReadLine());
                    alertService.SoftDelete(id2);
                    break;
                case "5":
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Uyarısını görmek istediğiniz evcil hayvanınızın Id'sini giriniz: ");
                    int id3 = int.Parse(Console.ReadLine());
                    var alert = alertService.Get(id3);
                    Console.WriteLine(alert.ToString());
                    break;
                case "8":
                    PrintAlertByOwnerId(id, context);
                    break;
                case "9":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    Console.WriteLine("Hatalı tuşlama yaptınız geri döndürülüyorsunuz");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
            }
        }

        #endregion



        #region AdminIslemleri
        public static void PetOwnerProcessAdmin(IPetOwnerService petOwnerService, AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(IPetOwnerService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                if (i == 0)
                    continue;
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("9 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "2":
                    GetAllPetOwners(context);
                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvan sahibinin adını giriniz");
                    string firstName1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin soyadını giriniz");
                    string lastName1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin telefon numarasını giriniz");
                    string phoneNumber1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin adresini giriniz");
                    string address1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin e-posta adresini giriniz");
                    string email1 = Console.ReadLine();
                    petOwnerService.Update(id, firstName1, lastName1, phoneNumber1, address1, email1);

                    break;
                case "3":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id1 = int.Parse(Console.ReadLine());
                    petOwnerService.Delete(id1);

                    break;
                case "4":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id2 = int.Parse(Console.ReadLine());
                    petOwnerService.SoftDelete(id2);
                    break;
                case "5":
                    GetAllPetOwners(context);
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    var petOwner = petOwnerService.Get(id3);
                    break;
                case "6":
                    var allPetOwners = petOwnerService.GetAllTrack();
                    foreach (var item in allPetOwners)
                    {
                        Console.WriteLine(item.ToString());
                    }

                    break;
                case "7":
                    var allPetOwners1 = petOwnerService.GetAllNoTrack();
                    foreach (var item in allPetOwners1)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "8":
                    Console.WriteLine("Lütfen aramak istediğiniz ismi giriniz");
                    string name = Console.ReadLine();
                    var petOwnerByName = petOwnerService.GetByName(name);
                    foreach (var item in petOwnerByName)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "9":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    break;
            }
        }
        public static void ActivityLogProcessAdmin(IActivityLogService activityLogService, AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(IActivityLogService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                if (i == 0)
                    continue;
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("9 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "2":
                    GetAllPetOwners(context);
                    Console.WriteLine("Güncellemek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int id = int.Parse(Console.ReadLine());
                    PrintActivityLogByOwnerId(id, context);
                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");
                    int id1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen yürüyüş zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan walkingTime1 = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen koşu zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan runTime1 = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen uyku zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan sleepTime1 = TimeSpan.Parse(Console.ReadLine());
                    activityLogService.Update(id1, DateTime.Now, walkingTime1, runTime1, sleepTime1);
                    break;
                case "3":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int id2 = int.Parse(Console.ReadLine());
                    PrintActivityLogByOwnerId(id2, context);
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int logId = int.Parse(Console.ReadLine());
                    activityLogService.Delete(logId);
                    break;
                case "4":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int id3 = int.Parse(Console.ReadLine());
                    PrintActivityLogByOwnerId(id3, context);
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int logId2 = int.Parse(Console.ReadLine());
                    activityLogService.SoftDelete(logId2);
                    break;
                case "5":
                    GetAllPetOwners(context);
                    Console.WriteLine("Görmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int id4 = int.Parse(Console.ReadLine());
                    PrintActivityLogByOwnerId(id4, context);
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int logId3 = int.Parse(Console.ReadLine());
                    var activityLog = activityLogService.Get(logId3);
                    Console.WriteLine(activityLog.ToString());
                    break;
                case "6":
                    var allActivityLogs = activityLogService.GetAllTrack();
                    foreach (var item in allActivityLogs)

                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "7":

                    var allActivityLogs1 = activityLogService.GetAllNoTrack();
                    foreach (var item in allActivityLogs1)
                    {
                        Console.WriteLine(item.ToString());
                    }

                    break;
                case "8":
                    Console.WriteLine("Lütfen tarih aralığını giriniz.Örneğin:(2023,10,10)");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    var activityLogByDate = activityLogService.GetByDate(date);
                    foreach (var item in activityLogByDate)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "9":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    break;
            }

        }
        public static void AlertProcessAdmin(IAlertService alertService,AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(IAlertService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("8 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    GetAllPetOwners(context);
                    Console.WriteLine("Lütfen işlem yapmak istediğiniz evcil hayvan sahibinin Id'sini giriniz");
                    int id = int.Parse(Console.ReadLine());
                    PrintPetsByOwnerId(id, context);
                    Console.WriteLine("Lütfen işlem yapmak istediğiniz evcil hayvanınızın Id'sini giriniz");
                    int petId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın vücut ısısını giriniz. (28,2)");
                    double bodyTempature = double.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın sabit kaldığı toplam süreyi giriniz.");
                    TimeSpan inactivity = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın kaçtı mı?");
                    bool escape =bool.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın kilosunu giriniz.");
                    double weight = double.Parse(Console.ReadLine());
                    alertService.Add(petId,bodyTempature, inactivity, escape, weight);
                    break;
                case "2":
                    GetAllPetOwners(context);
                    Console.WriteLine("Güncellemek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int id1 = int.Parse(Console.ReadLine());
                    PrintPetsByOwnerId(id1, context);
                    Console.WriteLine("Güncellemek istediğiniz evcil hayvanınızın Id'sini giriniz: ");
                    int petId1 = int.Parse(Console.ReadLine());
                    double bodyTempature1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın sabit kaldığı toplam süreyi giriniz.");
                    TimeSpan inactivity1 = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın kaçtı mı?");  //???????
                    bool escape1 =bool.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın kilosunu giriniz.");
                    double weight1 = double.Parse(Console.ReadLine());
                    alertService.Update(petId1, bodyTempature1, inactivity1, escape1, weight1);
                    break;
                case "3":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int id2 = int.Parse(Console.ReadLine());
                    PrintPetsByOwnerId(id2, context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvanınızın Id'sini giriniz: ");
                    int petId2 = int.Parse(Console.ReadLine());
                    alertService.Delete(petId2);
                    break;
                case "4":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int id3 = int.Parse(Console.ReadLine());
                    PrintPetsByOwnerId(id3, context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvanınızın Id'sini giriniz: ");
                    int petId3 = int.Parse(Console.ReadLine());
                    alertService.SoftDelete(petId3);
                    break;
                case "5":
                    GetAllPetOwners(context);
                    Console.WriteLine("Görmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int id4 = int.Parse(Console.ReadLine());
                    PrintPetsByOwnerId(id4, context);
                    Console.WriteLine("Görmek istediğiniz evcil hayvanınızın Id'sini giriniz: ");
                    int petId5 = int.Parse(Console.ReadLine());
                    var alert = alertService.Get(petId5);
                    Console.WriteLine(alert.ToString());


                    break;
                case "6":
                    var allAlerts = alertService.GetAllTrack();
                    foreach (var item in allAlerts)
                    {
                        Console.WriteLine(item.ToString());
                    }

                    break;
                case "7":
                    var allAlerts1 = alertService.GetAllNoTrack();
                    foreach (var item in allAlerts1)
                    {
                        Console.WriteLine(item.ToString());
                    }

                    break;
                case "8":
                    Console.WriteLine("Geri Dönülüyor...");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    break;
            }
        }
        public static void HealthRecordtProcessAdmin(IHealthRecordService healthrecordService,AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(IHealthRecordService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("9 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    MemberInfo[] memberInfo = typeof(HealthType).GetMembers();
                    for (int i = 0; i < memberInfo.Length; i++)
                    {
                        Console.WriteLine(i + 1 + " " + memberInfo[i].Name);
                    }
                    GetAllPetOwners(context);
                    Console.WriteLine("Sağlık kaydı ekleyeceğiniz hayvanın sahibinin id'sini giriniz.");
                    int petOwnerId = int.Parse(Console.ReadLine());
                    PrintHealthRecordByOwnerId(petOwnerId, context);
                    Console.WriteLine("Sağlık kaydı ekleyeceğiniz sağlık kaydının id'sini giriniz.");
                    int petId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen belirtmek istediğiniz durumu seçiniz(örnek:1)");
                    HealthType healthType = (HealthType)int.Parse(Console.ReadLine());
                    Console.WriteLine("Yaptığınız seçimi açıklayınız.(örnek: 1 seçildiyse - Kuduz)");
                    string description = Console.ReadLine();
                    healthrecordService.Add(petId,healthType, description, DateTime.Now);
                    break;
                case "2":
                    GetAllPetOwners(context);
                    Console.WriteLine("Güncellemek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId1 = int.Parse(Console.ReadLine());
                    PrintHealthRecordByOwnerId(petOwnerId1, context);
                    Console.WriteLine("Güncellemek istediğiniz sağlık kaydının Id'sini giriniz: ");
                    int petId1 = int.Parse(Console.ReadLine());
                    MemberInfo[] memberInfo1 = typeof(HealthType).GetMembers();
                    for (int i = 0; i < memberInfo1.Length; i++)
                    {
                        Console.WriteLine(i + 1 + " " + memberInfo1[i].Name);
                    }
                    Console.WriteLine("Lütfen belirtmek istediğiniz durumu seçiniz(örnek:1)");
                    HealthType healthType1 = (HealthType)int.Parse(Console.ReadLine());
                    Console.WriteLine("Yaptığınız seçimi açıklayınız.(örnek: 1 seçildiyse - Kuduz)");
                    string description1 = Console.ReadLine();
                    healthrecordService.Update(petId1, healthType1, description1, DateTime.Now);
                    break;
                case "3":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId2 = int.Parse(Console.ReadLine());
                    PrintHealthRecordByOwnerId(petOwnerId2, context);
                    Console.WriteLine("Silmek istediğiniz sağlık kaydının Id'sini giriniz: ");
                    int petId2 = int.Parse(Console.ReadLine());
                    healthrecordService.Delete(petId2);
                    break;
                case "4":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId3 = int.Parse(Console.ReadLine());
                    PrintHealthRecordByOwnerId(petOwnerId3, context);
                    Console.WriteLine("Silmek istediğiniz sağlık kaydının Id'sini giriniz: ");
                    int petId3 = int.Parse(Console.ReadLine());
                    healthrecordService.SoftDelete(petId3);
                    break;
                case "5":
                    GetAllPetOwners(context);
                    Console.WriteLine("Görmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId4 = int.Parse(Console.ReadLine());
                    PrintHealthRecordByOwnerId(petOwnerId4, context);
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    var healthRecord = healthrecordService.Get(id3);
                    Console.WriteLine(healthRecord.ToString());
                    break;
                case "6":
                    var allHealthRecords = healthrecordService.GetAllTrack();
                    foreach (var item in allHealthRecords)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "7":
                    var allHealthRecords1 = healthrecordService.GetAllNoTrack();
                    foreach (var item in allHealthRecords1)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "8":
                    MemberInfo[] memberInfo2 = typeof(HealthType).GetMembers();
                    for (int i = 0; i < memberInfo2.Length; i++)
                    {
                        Console.WriteLine(i + 1 + " " + memberInfo2[i].Name);
                    }
                    Console.WriteLine("Lütfen belirtmek istediğiniz durumu seçiniz(örnek:1)");
                    HealthType healthType2 = (HealthType)int.Parse(Console.ReadLine());
                    var healthRecordByHealthType = healthrecordService.GetByHealthType(healthType2);
                    foreach (var item in healthRecordByHealthType)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "9":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    break;
            }
        }
        public static void PetProcessAdmin(IPetService petService,AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(IPetService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("9 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    GetAllPetOwners(context);
                    Console.WriteLine("Lütfen evcil hayvan sahibinin Id'sini giriniz");
                    int petOwnerId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın adını giriniz");
                    string name = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın türünü seçiniz");
                    MemberInfo[] memberInfo = typeof(PetSpecies).GetMembers();
                    for (int i = 0; i < memberInfo.Length; i++)
                    {
                        Console.WriteLine(i + 1 + " " + memberInfo[i].Name);
                    }
                    PetSpecies species = (PetSpecies)int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın cinsini giriniz");
                    string breed = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın doğum tarihini giriniz.Örneğin:(2023,10,10)");
                    DateTime birtDate = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın aşı bilgilerini giriniz");
                    string vaccieInformation = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın kilosunu giriniz");
                    double weight = double.Parse(Console.ReadLine());
                    petService.Add(petOwnerId,name, species, breed, birtDate, vaccieInformation, weight);
                    break;
                case "2":
                    GetAllPetOwners(context);
                    Console.WriteLine("Güncellemek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId1 = int.Parse(Console.ReadLine());
                    PrintPetsByOwnerId(petOwnerId1, context);
                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın adını giriniz");
                    string name1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın türünü seçiniz");
                    MemberInfo[] memberInfo1 = typeof(PetSpecies).GetMembers();
                    for (int i = 0; i < memberInfo1.Length; i++)
                    {
                        Console.WriteLine(i + 1 + " " + memberInfo1[i].Name);
                    }
                    PetSpecies species1 = (PetSpecies)int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın cinsini giriniz");
                    string breed1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın doğum tarihini giriniz.Örneğin:(2023,10,10)");
                    DateTime birtDate1 = DateTime.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın aşı bilgilerini giriniz");
                    string vaccieInformation1 = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvanınızın kilosunu giriniz");
                    double weight1 = double.Parse(Console.ReadLine());
                    petService.Update(id, name1, species1, breed1, birtDate1, vaccieInformation1, weight1);
                    break;
                case "3":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId2 = int.Parse(Console.ReadLine());
                    PrintPetsByOwnerId(petOwnerId2, context);
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id1 = int.Parse(Console.ReadLine());
                    petService.Delete(id1);
                    break;
                case "4":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId3 = int.Parse(Console.ReadLine());
                    PrintPetsByOwnerId(petOwnerId3, context);
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id2 = int.Parse(Console.ReadLine());
                    petService.SoftDelete(id2);

                    break;
                case "5":
                    GetAllPetOwners(context);
                    Console.WriteLine("Görmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId4 = int.Parse(Console.ReadLine());
                    PrintPetsByOwnerId(petOwnerId4, context);
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    var pet = petService.Get(id3);
                    break;
                case "6":
                    var allPets = petService.GetAllTrack();
                    foreach (var item in allPets)
                    {
                        Console.WriteLine(item.ToString());
                    }

                    break;
                case "7":
                    var allPets1 = petService.GetAllNoTrack();
                    foreach (var item in allPets1)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "8":
                    Console.WriteLine("Lütfen aramak istediğiniz ismi giriniz");
                    string name2 = Console.ReadLine();
                    var petByName = petService.GetByName(name2);
                    foreach (var item in petByName)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "9":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    break;
            }
        }
        public static void VetAppointmentProcessAdmin(IVetAppointmentService appointmentService,AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos1 = typeof(IVetAppointmentService).GetMethods();
            for (int i = 0; i < methodInfos1.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos1[i].Name);
            }
            Console.WriteLine("9 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    GetAllPets(context);
                    Console.WriteLine("Lütfen evcil hayvanınızın Id'sini giriniz");
                    int petId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Klinik adını giriniz");
                    string clinicName = Console.ReadLine();
                    Console.WriteLine("Lütfen veteriner adını giriniz");
                    string veterinarianName = Console.ReadLine();
                    Console.WriteLine("Lütfen randevu tarihi giriniz");
                    DateTime appointmentDate = DateTime.Parse(Console.ReadLine());
                    appointmentService.Add(petId,clinicName, veterinarianName, appointmentDate);
                    break;
                case "2":
                    GetAllPetOwners(context);
                    Console.WriteLine("Güncellemek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId = int.Parse(Console.ReadLine());
                    PrintAppointmentsByOwnerId(petOwnerId, context);
                    Console.WriteLine("Güncellemek istediğiniz evcil hayvanınızın Id'sini giriniz: ");
                    int petId1 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Güncellemek istediğiniz randevunun Id'sini giriniz: ");
                    int appointmentId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Klinik adını giriniz");
                    string clinicName1 = Console.ReadLine();
                    Console.WriteLine("Lütfen veteriner adını giriniz");
                    string veterinarianName1 = Console.ReadLine();
                    Console.WriteLine("Lütfen randevu tarihi giriniz");
                    DateTime appointmentDate1 = DateTime.Now;
                    appointmentService.Update(appointmentId,petId1, clinicName1, veterinarianName1, appointmentDate1);
                    break;
                case "3":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId1 = int.Parse(Console.ReadLine());
                    PrintAppointmentsByOwnerId(petOwnerId1, context);
                    Console.WriteLine("Silmek istediğiniz randevunuzun Id'sini giriniz: ");
                    int petId2 = int.Parse(Console.ReadLine());
                    appointmentService.Delete(petId2);
                    break;
                case "4":
                    GetAllPetOwners(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId2 = int.Parse(Console.ReadLine());
                    PrintAppointmentsByOwnerId(petOwnerId2, context);
                    Console.WriteLine("Silmek istediğiniz randevunuzun Id'sini giriniz: ");
                    int petId3 = int.Parse(Console.ReadLine());
                    appointmentService.SoftDelete(petId3);
                    break;
                case "5":
                    GetAllPetOwners(context);
                    Console.WriteLine("Görmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petOwnerId3 = int.Parse(Console.ReadLine());
                    PrintAppointmentsByOwnerId(petOwnerId3, context);
                    Console.WriteLine("Görmek istediğiniz randevunuzun Id'sini giriniz: ");
                    int petId4 = int.Parse(Console.ReadLine());
                    var vetAppointment = appointmentService.Get(petId4);
                    Console.WriteLine(vetAppointment.ToString());
                    break;
                case "6":
                    var allVetAppointment = appointmentService.GetAllTrack();
                    foreach (var item in allVetAppointment)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "7":
                    var allVetAppointment1 = appointmentService.GetAllNoTrack();
                    foreach (var item in allVetAppointment1)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "8":
                    Console.WriteLine("Lütfen getirmek istediğiniz klinik adını giriniz");
                    string clinicName3 = Console.ReadLine();
                    var appointmentByClinicName = appointmentService.GetByClinicName(clinicName3);
                    foreach (var item in appointmentByClinicName)
                    {
                        Console.WriteLine(item);
                    }
                    break;
                case "9":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    break;

            }
        }
        public static void TrackerDeviceProcessAdmin(ITrackerDeviceService trackerDeviceService,AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(ITrackerDeviceService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("9 - Geri Dön");
            Console.WriteLine("Lütfen seçiminizi yapınız");

            string result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    GetAllPets(context);
                    Console.WriteLine("Lütfen evcil hayvanınızın Id'sini giriniz");
                    int petId = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen evcil hayvanınızın bulunduğu konumu giriniz");
                    string location = Console.ReadLine();
                    DateTime loggedAt = DateTime.Now;
                    trackerDeviceService.Add(petId,loggedAt, location);
                    break;
                case "2":
                    GetAllPets(context);
                    Console.WriteLine("Güncellemek istediğiniz evcil hayvan Id'sini giriniz: ");
                    int petId1 = int.Parse(Console.ReadLine());
                    PrintTrackerDeviceByPetId(petId1, context);
                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen güncellemek istediğiniz evcil hayvanınızın bulunduğu konumu giriniz");
                    string location1 = Console.ReadLine();
                    DateTime loggedAt1 = DateTime.Now;
                    trackerDeviceService.Update(id, loggedAt1, location1);
                    break;
                case "3":
                    GetAllPets(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petId2 = int.Parse(Console.ReadLine());
                    PrintTrackerDeviceByPetId(petId2, context);
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id1 = int.Parse(Console.ReadLine());
                    trackerDeviceService.Delete(id1);
                    break;
                case "4":
                    GetAllPets(context);
                    Console.WriteLine("Silmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petId3 = int.Parse(Console.ReadLine());
                    PrintTrackerDeviceByPetId(petId3, context);
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz");
                    int id2 = int.Parse(Console.ReadLine());
                    trackerDeviceService.SoftDelete(id2);
                    break;
                case "5":
                    GetAllPets(context);
                    Console.WriteLine("Görmek istediğiniz evcil hayvan sahibinin Id'sini giriniz: ");
                    int petId4 = int.Parse(Console.ReadLine());
                    PrintTrackerDeviceByPetId(petId4, context);
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    var trackerDevices = trackerDeviceService.Get(id3);
                    Console.WriteLine(trackerDevices.ToString());
                    break;
                case "6":
                    var allTrackerDevices = trackerDeviceService.GetAllTrack();
                    foreach (var item in allTrackerDevices)

                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "7":

                    var allTrackerDevices1 = trackerDeviceService.GetAllNoTrack();
                    foreach (var item in allTrackerDevices1)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "8":
                    Console.WriteLine("Lütfen tarih aralığını giriniz.Örneğin:(2023,10,10)");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    var loggedAtDate = trackerDeviceService.GetByDate(date);
                    foreach (var item in loggedAtDate)
                    {
                        Console.WriteLine(item.ToString());
                    }
                    break;
                case "9":
                    Console.WriteLine("Geri dönülüyor");
                    Thread.Sleep(1000);
                    Console.Clear();
                    return;
                default:
                    break;
            }
        }
        #endregion




        #region Kullanışı metodlar
        public static ICollection<Pet> GetPetsByOwnerId(int ownerId, AppPetTrackDbContext context)
        {
            return context.Pets
                .Include(p => p.PetOwner) // PetOwner ile ilişkiyi dahil et
                .Where(p => p.PetOwnerId == ownerId)
                .ToList();
        }

        public static void PrintPetsByOwnerId(int ownerId, AppPetTrackDbContext context)
        {
            var pets = GetPetsByOwnerId(ownerId, context);

            if (pets == null || !pets.Any())
            {
                Console.WriteLine($"ID'si {ownerId} olan sahip için evcil hayvan bulunamadı.");
                return;
            }

            Console.WriteLine($"Sahip ID'si {ownerId} olan kullanıcının evcil hayvanları:");
            Console.WriteLine(new string('=', 40));

            foreach (var pet in pets)
            {
                Console.WriteLine(pet); // Özelleştirilmiş ToString() kullanılıyor
                Console.WriteLine(new string('-', 40)); // Her evcil hayvan arasında ayırıcı çizgi
            }
        }

        public static void PrintAppointmentsByOwnerId(int ownerId, AppPetTrackDbContext context)
        {
            var pets = GetPetsByOwnerId(ownerId, context);

            if (pets == null || !pets.Any())
            {
                Console.WriteLine($"ID'si {ownerId} olan sahip için evcil hayvan bulunamadı.");
                return;
            }

            var petIds = pets.Select(p => p.Id).ToList();
            var appointments = context.VetAppointments
                .Where(a => petIds.Contains(a.PetId))
                .ToList();

            if (appointments == null || !appointments.Any())
            {
                Console.WriteLine($"ID'si {ownerId} olan sahibin evcil hayvanlarına ait veteriner randevusu bulunamadı.");
                return;
            }

            Console.WriteLine($"Sahip ID'si {ownerId} olan kullanıcının veteriner randevuları:");
            Console.WriteLine(new string('=', 40));

            foreach (var appointment in appointments)
            {
                Console.WriteLine(appointment); // Özelleştirilmiş ToString çalışacak
                Console.WriteLine(new string('-', 40)); // Her randevu arasında ayırıcı çizgi
            }
        }

        public static void PrintHealthRecordByOwnerId(int ownerId, AppPetTrackDbContext context)
        {
            var pets = GetPetsByOwnerId(ownerId, context);
            if (pets == null || !pets.Any())
            {
                Console.WriteLine($"ID'si {ownerId} olan sahip için evcil hayvan bulunamadı.");
                return;
            }
            var petIds = pets.Select(p => p.Id).ToList();
            var healthRecords = context.HealthRecords
                .Where(a => petIds.Contains(a.PetId))
                .ToList();
            if (healthRecords == null || !healthRecords.Any())
            {
                Console.WriteLine($"ID'si {ownerId} olan sahibin evcil hayvanlarına ait sağlık kaydı bulunamadı.");
                return;
            }
            Console.WriteLine($"Sahip ID'si {ownerId} olan kullanıcının sağlık kayıtları:");
            Console.WriteLine(new string('=', 40));
            foreach (var healthRecord in healthRecords)
            {
                Console.WriteLine(healthRecord); // Özelleştirilmiş ToString çalışacak
                Console.WriteLine(new string('-', 40)); // Her randevu arasında ayırıcı çizgi
            }
        }

        public static void PrintAlertByOwnerId(int ownerId, AppPetTrackDbContext context)
        {
            var pets = GetPetsByOwnerId(ownerId, context);
            if (pets == null || !pets.Any())
            {
                Console.WriteLine($"ID'si {ownerId} olan sahip için evcil hayvan bulunamadı.");
                return;
            }
            var petIds = pets.Select(p => p.Id).ToList();
            var alerts = context.Alerts
                .Where(a => petIds.Contains(a.PetId))
                .ToList();
            if (alerts == null || !alerts.Any())
            {
                Console.WriteLine($"ID'si {ownerId} olan sahibin evcil hayvanlarına ait uyarı bulunamadı.");
                return;
            }
            Console.WriteLine($"Sahip ID'si {ownerId} olan kullanıcının uyarıları:");
            Console.WriteLine(new string('=', 40));
            foreach (var alert in alerts)
            {
                Console.WriteLine(alert); // Özelleştirilmiş ToString çalışacak
                Console.WriteLine(new string('-', 40)); // Her randevu arasında ayırıcı çizgi
            }
        }

        public static void PrintActivityLogByOwnerId(int ownerId, AppPetTrackDbContext context)
        {
            var pets = GetPetsByOwnerId(ownerId, context);
            if (pets == null || !pets.Any())
            {
                Console.WriteLine($"ID'si {ownerId} olan sahip için evcil hayvan bulunamadı.");
                return;
            }

            var petIds = pets.Select(p => p.Id).ToList();

            var trackerDevices = context.TrackerDevices
                .Where(t => petIds.Contains(t.PetId))
                .ToList();

            var trackerDeviceIds = trackerDevices.Select(td => td.Id).ToList();

            var activityLogs = context.ActivityLogs
                .Where(a => trackerDeviceIds.Contains(a.TrackerDeviceId))
                .ToList();

            Console.WriteLine($"Sahip ID'si {ownerId} olan kullanıcının aktivite kayıtları:");
            Console.WriteLine(new string('=', 40));

            foreach (var activityLog in activityLogs)
            {
                Console.WriteLine(activityLog); // ToString() burada çalışacak
                Console.WriteLine(new string('-', 40));
            }
        }

        public static void PrintTrackerDeviceByPetId(int petId, AppPetTrackDbContext context)
        {
            var trackerDevices = context.TrackerDevices
                .Where(t => t.PetId == petId)
                .ToList();
            if (trackerDevices == null || !trackerDevices.Any())
            {
                Console.WriteLine($"ID'si {petId} olan evcil hayvan için takip cihazı bulunamadı.");
                return;
            }
            Console.WriteLine($"ID'si {petId} olan evcil hayvanın takip cihazları:");
            Console.WriteLine(new string('=', 40));
            foreach (var trackerDevice in trackerDevices)
            {
                Console.WriteLine(trackerDevice); // Özelleştirilmiş ToString çalışacak
                Console.WriteLine(new string('-', 40)); // Her randevu arasında ayırıcı çizgi
            }
        }

        public static void PrintTrackerDeviceByOwnerId(int ownerId, AppPetTrackDbContext context)
        {
            var pets = GetPetsByOwnerId(ownerId, context);
            if (pets == null || !pets.Any())
            {
                Console.WriteLine($"ID'si {ownerId} olan sahip için evcil hayvan bulunamadı.");
                return;
            }
            var petIds = pets.Select(p => p.Id).ToList();
            var trackerDevices = context.TrackerDevices
                .Where(t => petIds.Contains(t.PetId))
                .ToList();
            if (trackerDevices == null || !trackerDevices.Any())
            {
                Console.WriteLine($"ID'si {ownerId} olan sahibin evcil hayvanlarına ait takip cihazı bulunamadı.");
                return;
            }
            Console.WriteLine($"Sahip ID'si {ownerId} olan kullanıcının takip cihazları:");
            Console.WriteLine(new string('=', 40));
            foreach (var trackerDevice in trackerDevices)
            {
                Console.WriteLine(trackerDevice); // Özelleştirilmiş ToString çalışacak
                Console.WriteLine(new string('-', 40)); // Her randevu arasında ayırıcı çizgi
            }
        }

        public static void GetAllPetOwners(AppPetTrackDbContext context)
        {
            var petOwners = context.PetOwners.ToList();

            if (petOwners == null || !petOwners.Any())
            {
                Console.WriteLine("Evcil hayvan sahibi bulunamadı.");
                return;
            }
            Console.WriteLine("Evcil hayvan sahipleri:");
            Console.WriteLine(new string('=', 40));
            foreach (var petOwner in petOwners)
            {
                Console.WriteLine(petOwner);
                Console.WriteLine(new string('-', 40));
            }

        }

        public static void GetAllPets(AppPetTrackDbContext context)
        {
            var pets = context.Pets.ToList();
            if (pets == null || !pets.Any())
            {
                Console.WriteLine("Evcil hayvan bulunamadı.");
                return;
            }
            Console.WriteLine("Evcil hayvanlar:");
            Console.WriteLine(new string('=', 40));
            foreach (var pet in pets)
            {
                Console.WriteLine(pet);
                Console.WriteLine(new string('-', 40));
            }
        }

        #endregion




    }
}
