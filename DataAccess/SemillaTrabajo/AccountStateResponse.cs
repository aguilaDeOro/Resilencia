namespace DataAccess.SemillaTrabajo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class AccountStateResponse<T>
    {
        public AccountStateResponse(bool success, T data, string message)
        {
            Success = success;
            Data = data;
            Message = message;
        }

        public bool Success { get; set; }

        public T Data { get; set; }

        public string Message { get; set; }
    }
}
