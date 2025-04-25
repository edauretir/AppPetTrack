using System.Reflection;
using AppPetTrack.CORE.Enums;
using AppPetTrack.REPO.Context;
using AppPetTrack.REPO.UnitOfWork;
using AppPetTrack.SERVICE.Concretes;
using AppPetTrack.SERVICE.Contracts;

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

            Console.WriteLine("***************MyPaw'a Hoşgeldiniz***************");
            Console.WriteLine("Lütfen seçiminizi yapınız");
            Console.WriteLine("1.ActivityLog\n2.Alert\n3.HealthRecord\n4.Pet\n5.PetOwner\n6.TrackerDevice\n7.VetAppoinment\n8.Exit");
            string result = Console.ReadLine();
            switch (result)
            {
                case "1":
                    ActivityLogProcess(activityLogService);
                    break;
                case "2":
                    AlertProcess(alertService);
                    break;
                case "3":
                    HealthRecordtProcess(healthRecordService);
                    break;
                case "4":
                    PetProcess(petService);
                    break;
                case "5":
                    PetOwnerProcess(petOwnerService);
                    break;
                case "6":
                    TrackerDeviceProcess(trackerService);
                    break;
                case "7":
                    VetAppointmentProcess(vetAppointmentService);
                    break;
                case "8":
                    break;

                default:
                    break;
            }

        }
        public static void ActivityLogProcess(IActivityLogService activityLogService)
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

        public static void AlertProcess(IAlertService alertService)
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

        public static void HealthRecordtProcess(IHealthRecordService healthrecordService)
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

        public static void PetOwnerProcess(IPetOwnerService petOwnerService)
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

        public static void PetProcess(IPetService petService)
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

        public static void VetAppointmentProcess(IVetAppointmentService appointmentService)

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


        public static void TrackerDeviceProcess(ITrackerDeviceService trackerDeviceService)
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
    }
}
