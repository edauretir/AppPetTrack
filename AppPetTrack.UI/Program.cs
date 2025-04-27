using System.Reflection;
using AppPetTrack.CORE.Enums;
using AppPetTrack.CORE.Models;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.UnitOfWork;
using AppPetTrack.SERVICE.Concretes;
using AppPetTrack.SERVICE.Contracts;
using AppPetTrack.SERVICE.Exceptions;
using Microsoft.EntityFrameworkCore;

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

            while (true)
            {
                Console.WriteLine("***************MyPaw'a Hoşgeldiniz***************");
                Console.WriteLine("Oturum Açmak İçin [1]");
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
                        petOwnerService.CheckAccount(userName, password);
                        if (petOwnerService.CheckAccount(userName, password) == false)
                        {
                            Console.WriteLine("\nKullanıcı Adı veya Şifre Hatalı");
                            Console.WriteLine("Lütfen Tekrar Deneyiniz");
                            Console.Clear();
                            break;
                        }
                        else if (userName == "admin" && password == "admin")
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
                                        break;
                                    case "1":
                                        PetOwnerProcessAdmin(petOwnerService);
                                        break;
                                    case "2":
                                        PetProcessAdmin(petService);
                                        break;
                                    case "3":
                                        VetAppointmentProcessAdmin(vetAppointmentService);
                                        break;
                                    case "4":
                                        TrackerDeviceProcessAdmin(trackerService);
                                        break;
                                    case "5":
                                        HealthRecordtProcessAdmin(healthRecordService);
                                        break;
                                    case "6":
                                        ActivityLogProcessAdmin(activityLogService);
                                        break;
                                    case "7":
                                        AlertProcessAdmin(alertService);
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
                        else
                        {
                            Console.WriteLine("Kullanıcı Girişi Başarılı");
                        }
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
                                PetOwnerProcess(petOwnerService,id);
                                break;
                            case "2":
                                PetProcess(petService,id,context);
                                break;
                            case "3":
                                VetAppointmentProcess(vetAppointmentService, id,context);
                                break;
                            case "4":
                                TrackerDeviceProcess(trackerService, id);
                                break;
                            case "5":
                                HealthRecordtProcess(healthRecordService, id,context);
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
                    default:
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
                    return;
            }
        }

        public static void PetProcess(IPetService petService, int id, AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(IPetService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                if (i == 2)
                    continue;
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("9 - Geri Dön");
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
                    break;
                default:
                    break;
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
                    break;
            }
        }

        public static void TrackerDeviceProcess(ITrackerDeviceService trackerDeviceService, int id)
        {
            MethodInfo[] methodInfos = typeof(ITrackerDeviceService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }

            Console.WriteLine("Lütfen seçiminizi yapınız");

            string result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    Console.WriteLine("Lütfen evcil hayvanınızın bulunduğu konumu giriniz");
                    string location = Console.ReadLine();
                    DateTime loggedAt = DateTime.Now;
                    trackerDeviceService.Add(loggedAt, location);
                    break;
                case "2":
                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");
                    int id4 = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen güncellemek istediğiniz evcil hayvanınızın bulunduğu konumu giriniz");
                    string location1 = Console.ReadLine();
                    Console.WriteLine("Lütfen güncellemek istediğiniz evcil hayvanınızın bulunduğu konumdaki zamanı giriniz");
                    DateTime loggedAt1 = DateTime.Now;
                    trackerDeviceService.Update(id4, loggedAt1, location1);
                    break;
                case "3":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id1 = int.Parse(Console.ReadLine());
                    trackerDeviceService.Delete(id1);
                    break;
                case "4":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz");
                    int id2 = int.Parse(Console.ReadLine());
                    trackerDeviceService.SoftDelete(id2);
                    break;
                case "5":
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

                    break;

                default:
                    break;
            }
        } //Sana bıraktım :)

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
                    break;
            }
        }

        public static void ActivityLogProcess(IActivityLogService activityLogService, int id, AppPetTrackDbContext context)
        {
            MethodInfo[] methodInfos = typeof(IActivityLogService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    Console.WriteLine("Lütfen yürüyüş zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan walkingTime = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen koşu zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan runTime = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen uyku zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan sleepTime = TimeSpan.Parse(Console.ReadLine());
                    activityLogService.Add(DateTime.Now, walkingTime, runTime, sleepTime);
                    break;
                case "2":
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
                case "3":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id1 = int.Parse(Console.ReadLine());
                    activityLogService.Delete(id1);
                    break;
                case "4":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz");
                    int id2 = int.Parse(Console.ReadLine());
                    activityLogService.SoftDelete(id2);
                    break;
                case "5":
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    var activityLog = activityLogService.Get(id3);
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

                    break;

                default:
                    break;
            }

        }// Sana bıraktım :)

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
                    Console.WriteLine("Evcil hayvanınızın sabit kaldığı toplam süreyi giriniz.");
                    TimeSpan inactivity = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın kaç kere kaçtığını giriniz.");  //???????
                    string escape = Console.ReadLine();
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
                    Console.WriteLine("Evcil hayvanınızın kaç kere kaçtığını giriniz.");  //???????
                    string escape1 = Console.ReadLine();
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
                    break;
            }
        }

        #endregion
        #region AdminIslemleri
        public static void ActivityLogProcessAdmin(IActivityLogService activityLogService)
        {
            MethodInfo[] methodInfos = typeof(IActivityLogService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }

            Console.WriteLine("Lütfen seçiminizi yapınız");

            string result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    Console.WriteLine("Lütfen yürüyüş zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan walkingTime = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen koşu zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan runTime = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen uyku zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan sleepTime = TimeSpan.Parse(Console.ReadLine());
                    activityLogService.Add(DateTime.Now, walkingTime, runTime, sleepTime);
                    break;
                case "2":
                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen yürüyüş zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan walkingTime1 = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen koşu zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan runTime1 = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen uyku zaman aralığını giriniz.Örneğin:(1,30)");
                    TimeSpan sleepTime1 = TimeSpan.Parse(Console.ReadLine());
                    activityLogService.Update(id, DateTime.Now, walkingTime1, runTime1, sleepTime1);
                    break;
                case "3":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id1 = int.Parse(Console.ReadLine());
                    activityLogService.Delete(id1);
                    break;
                case "4":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz");
                    int id2 = int.Parse(Console.ReadLine());
                    activityLogService.SoftDelete(id2);
                    break;
                case "5":
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    var activityLog = activityLogService.Get(id3);
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

                    break;

                default:
                    break;
            }

        }
        public static void AlertProcessAdmin(IAlertService alertService)
        {
            MethodInfo[] methodInfos = typeof(IAlertService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    Console.WriteLine("Lütfen evcil hayvanınızın vücut ısısını giriniz. (28,2)");
                    double bodyTempature = double.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın sabit kaldığı toplam süreyi giriniz.");
                    TimeSpan inactivity = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın kaç kere kaçtığını giriniz.");  //???????
                    string escape = Console.ReadLine();
                    Console.WriteLine("Evcil hayvanınızın kilosunu giriniz.");
                    double weight = double.Parse(Console.ReadLine());
                    alertService.Add(bodyTempature, inactivity, escape, weight);
                    break;
                case "2":
                    Console.WriteLine("Güncellemek istediğiniz id'yi giriniz.");
                    int id = int.Parse(Console.ReadLine());
                    double bodyTempature1 = double.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın sabit kaldığı toplam süreyi giriniz.");
                    TimeSpan inactivity1 = TimeSpan.Parse(Console.ReadLine());
                    Console.WriteLine("Evcil hayvanınızın kaç kere kaçtığını giriniz.");  //???????
                    string escape1 = Console.ReadLine();
                    Console.WriteLine("Evcil hayvanınızın kilosunu giriniz.");
                    double weight1 = double.Parse(Console.ReadLine());
                    alertService.Update(id, bodyTempature1, inactivity1, escape1, weight1);
                    break;
                case "3":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id1 = int.Parse(Console.ReadLine());
                    alertService.Delete(id1);
                    break;
                case "4":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id2 = int.Parse(Console.ReadLine());
                    alertService.SoftDelete(id2);
                    break;
                case "5":
                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");
                    int id3 = int.Parse(Console.ReadLine());
                    var alert = alertService.Get(id3);
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
                    break;
                default:
                    break;
            }
        }
        public static void HealthRecordtProcessAdmin(IHealthRecordService healthrecordService)
        {
            MethodInfo[] methodInfos = typeof(IHealthRecordService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
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
                    Console.WriteLine("Lütfen belirtmek istediğiniz durumu seçiniz(örnek:1)");
                    HealthType healthType = (HealthType)int.Parse(Console.ReadLine());
                    Console.WriteLine("Yaptığınız seçimi açıklayınız.(örnek: 1 seçildiyse - Kuduz)");
                    string description = Console.ReadLine();
                    healthrecordService.Add(healthType, description, DateTime.Now);
                    break;
                case "2":
                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");
                    int id = int.Parse(Console.ReadLine());
                    MemberInfo[] memberInfo1 = typeof(HealthType).GetMembers();
                    for (int i = 0; i < memberInfo1.Length; i++)
                    {
                        Console.WriteLine(i + 1 + " " + memberInfo1[i].Name);
                    }
                    Console.WriteLine("Lütfen belirtmek istediğiniz durumu seçiniz(örnek:1)");
                    HealthType healthType1 = (HealthType)int.Parse(Console.ReadLine());
                    Console.WriteLine("Yaptığınız seçimi açıklayınız.(örnek: 1 seçildiyse - Kuduz)");
                    string description1 = Console.ReadLine();
                    healthrecordService.Update(id, healthType1, description1, DateTime.Now);
                    break;
                case "3":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id1 = int.Parse(Console.ReadLine());
                    healthrecordService.Delete(id1);
                    break;
                case "4":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id2 = int.Parse(Console.ReadLine());
                    healthrecordService.SoftDelete(id2);
                    break;
                case "5":
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
                    break;
                default:
                    break;
            }
        }
        public static void PetOwnerProcessAdmin(IPetOwnerService petOwnerService)
        {
            MethodInfo[] methodInfos = typeof(IPetOwnerService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
            Console.WriteLine("Lütfen seçiminizi yapınız");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    Console.WriteLine("Lütfen evcil hayvan sahibinin adını giriniz");
                    string firstName = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin soyadını giriniz");
                    string lastName = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin telefon numarasını giriniz");
                    string phoneNumber = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin adresini giriniz");
                    string address = Console.ReadLine();
                    Console.WriteLine("Lütfen evcil hayvan sahibinin e-posta adresini giriniz");
                    string email = Console.ReadLine();
                    petOwnerService.Add(firstName, lastName, phoneNumber, address, email);

                    break;
                case "2":
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
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id1 = int.Parse(Console.ReadLine());
                    petOwnerService.Delete(id1);

                    break;
                case "4":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id2 = int.Parse(Console.ReadLine());
                    petOwnerService.SoftDelete(id2);
                    break;
                case "5":
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
                    break;
                default:
                    break;
            }
        }
        public static void PetProcessAdmin(IPetService petService)
        {
            MethodInfo[] methodInfos = typeof(IPetService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }
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
                    petService.Add(name, species, breed, birtDate, vaccieInformation, weight);
                    break;
                case "2":
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
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id1 = int.Parse(Console.ReadLine());
                    petService.Delete(id1);
                    break;
                case "4":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id2 = int.Parse(Console.ReadLine());
                    petService.SoftDelete(id2);

                    break;
                case "5":
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
                    break;
                default:
                    break;
            }
        }
        public static void VetAppointmentProcessAdmin(IVetAppointmentService appointmentService)

        {

            MethodInfo[] methodInfos1 = typeof(IVetAppointmentService).GetMethods();

            for (int i = 0; i < methodInfos1.Length; i++)

            {

                Console.WriteLine(i + 1 + " " + methodInfos1[i].Name);

            }

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

                    appointmentService.Add(clinicName, veterinarianName, appointmentDate);

                    break;

                case "2":

                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");

                    int id = int.Parse(Console.ReadLine());

                    Console.WriteLine("Klinik adını giriniz");

                    string clinicName1 = Console.ReadLine();

                    Console.WriteLine("Lütfen veteriner adını giriniz");

                    string veterinarianName1 = Console.ReadLine();

                    Console.WriteLine("Lütfen randevu tarihi giriniz");

                    DateTime appointmentDate1 = DateTime.Now;

                    appointmentService.Update(id, clinicName1, veterinarianName1, appointmentDate1);

                    break;

                case "3":

                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");

                    int id1 = int.Parse(Console.ReadLine());

                    appointmentService.Delete(id1);

                    break;

                case "4":

                    Console.WriteLine("Silmek istediğiniz id'yi giriniz");

                    int id2 = int.Parse(Console.ReadLine());

                    appointmentService.SoftDelete(id2);

                    break;

                case "5":

                    Console.WriteLine("Görmek istediğiniz id'yi giriniz");

                    int id3 = int.Parse(Console.ReadLine());

                    var vetAppointment = appointmentService.Get(id3);

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

                    break;

                default:

                    break;

            }
        }
        public static void TrackerDeviceProcessAdmin(ITrackerDeviceService trackerDeviceService)
        {
            MethodInfo[] methodInfos = typeof(ITrackerDeviceService).GetMethods();
            for (int i = 0; i < methodInfos.Length; i++)
            {
                Console.WriteLine(i + 1 + " " + methodInfos[i].Name);
            }

            Console.WriteLine("Lütfen seçiminizi yapınız");

            string result = Console.ReadLine();

            switch (result)
            {
                case "1":
                    Console.WriteLine("Lütfen evcil hayvanınızın bulunduğu konumu giriniz");
                    string location = Console.ReadLine();
                    DateTime loggedAt = DateTime.Now;
                    trackerDeviceService.Add(loggedAt, location);
                    break;
                case "2":
                    Console.WriteLine("Güncellemek istediğiniz Id'yi giriniz: ");
                    int id = int.Parse(Console.ReadLine());
                    Console.WriteLine("Lütfen güncellemek istediğiniz evcil hayvanınızın bulunduğu konumu giriniz");
                    string location1 = Console.ReadLine();
                    Console.WriteLine("Lütfen güncellemek istediğiniz evcil hayvanınızın bulunduğu konumdaki zamanı giriniz");
                    DateTime loggedAt1 = DateTime.Now;
                    trackerDeviceService.Update(id, loggedAt1, location1);
                    break;
                case "3":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz.");
                    int id1 = int.Parse(Console.ReadLine());
                    trackerDeviceService.Delete(id1);
                    break;
                case "4":
                    Console.WriteLine("Silmek istediğiniz id'yi giriniz");
                    int id2 = int.Parse(Console.ReadLine());
                    trackerDeviceService.SoftDelete(id2);
                    break;
                case "5":
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

                    break;

                default:
                    break;
            }
        }
        #endregion


        //Kullanışı metodlar

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
    }
}
