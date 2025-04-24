using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPetTrack.SERVICE.Exceptions
{
    public abstract class AppException : Exception
    {
        public string? ErroCode { get; }

        protected AppException(string message, string? errorCode = null) : base(message)
        {
            ErroCode = errorCode;
        }
    }
}
