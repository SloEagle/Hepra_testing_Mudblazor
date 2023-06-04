using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Records
{
    public record Sms(int Id, string Sender, string Reciever, string Body);
}
