namespace AppPetTrack.SERVICE.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException(string resource, int id) : base($"{resource} (Kullanıcı Id: {id}) bulunamadı! - {DateTime.Now}", "NOT_FOUND")
        {
        }
    }
}
