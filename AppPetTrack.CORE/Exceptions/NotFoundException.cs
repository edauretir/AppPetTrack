using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppPetTrack.SERVICE.Exceptions
{
    public class NotFoundException : AppException
    {
        public NotFoundException(string resource, int id) : base($"{resource} (Id: {id}) bulunamadı! - {DateTime.Now}", "NOT_FOUND")
        {
        }
    }
}
