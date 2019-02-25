using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RedApple.DomainNet35.Dto.socket
{
    public class WebSocketMessageDto:IDtoNet35
    {
        public string Detail { get; set; }
        public string Message { get; set; }
    }
}
