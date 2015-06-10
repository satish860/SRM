using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SRM.Domain
{
    public interface ICommandHandler<in Tinput>
    {
        Task Execute(Tinput input);
    }
}
