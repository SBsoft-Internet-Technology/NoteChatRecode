using NoteChatRecode_Common.Core.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteChatRecode_Common.Message.Messages
{
    public class TextMessage : MessageBase
    {
        public string Text;
        public TextMessage(string text,User sender)
        {
            this.sender = sender;
            
            Text = text;
        }
        public override string GetStringJson()
        {
            return $"{{\"Type\":\"text\",\"Text\":\"{Text}\"}}";
        }
    }
}
