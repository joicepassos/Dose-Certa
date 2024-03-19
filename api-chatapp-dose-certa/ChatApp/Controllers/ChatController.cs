using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

using ChatApp.Hubs;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

    
        [HttpPost("send")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> SendMessage([FromBody] MessageDto messageDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest("Invalid message format.");
            }

            await _hubContext.Clients.All.SendAsync("ReceiveMessage", messageDto.User, messageDto.Message);
            return Ok();
        }
    }

    public class MessageDto
    {
        public string? User { get; set; }
        public string? Message { get; set; }

        public MessageDto(string user, string msgText)
        {
            User = user;
            Message = msgText;
        }
    }

    public class UserDto
    {
        public int UserId { get; set; }
        public string? Username { get; set; }
    }
}
