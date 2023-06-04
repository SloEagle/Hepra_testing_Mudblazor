using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Records
{
    public record Provider(int Id, string Name, string SID, string Url);
}
