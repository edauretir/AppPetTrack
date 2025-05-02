namespace AppPetTrack.SERVICE.Exceptions
{
    public class ValidationException : AppException
    {
        public ValidationException(string field, string message) : base($"{field} alanı geçersiz: {message} - {DateTime.Now}", "VALIDATION_ERROR")
        {
        }
    }
}
