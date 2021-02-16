using System;
using System.Threading.Tasks;
using GraphQL.Samples.Schemas.Chat;
using Microsoft.AspNetCore.Mvc;

namespace GraphqlDemo.Controllers
{
    [ApiController]
    public class MessagesController : ControllerBase
    {
        private readonly IChat _chat;
        public MessagesController(IChat chat)
        {
            _chat = chat;
        }

        private static bool processing = false;

        [Route("/api/messagestream/toggle")]
        [HttpGet]
        public async Task<ActionResult> Start()
        {

            processing = !processing;

            var i = 0;
            do
            {
                _chat.AddMessage(new ReceivedMessage
                {
                    Content = $"Hi Coder! ({i})",
                    SentAt = DateTime.Now,
                    FromId = "ajz"
                }
            );
            i++;
            // not soo fast
            await Task.Delay(2000);
            } while (processing);

            return Ok();
        }

    }
}
