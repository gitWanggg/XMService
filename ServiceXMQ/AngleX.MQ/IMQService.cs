using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngleX.MQ
{
    public interface IMQService
    {
        void Start(ISerializeable ISer);

        void Stop();
    }
}
