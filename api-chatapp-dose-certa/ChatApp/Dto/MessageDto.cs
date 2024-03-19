using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ChatApp.ReqDto

{
    public class MessageDto
    {
        public string? User { get; set; }
        public string? Message { get; set; }

        public MessageDto(string user, string message)
        {
            User = user;
            Message = message;
        }
    }
}
