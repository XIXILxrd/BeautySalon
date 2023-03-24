using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeautySalon.Logger
{
    public interface IPrint
    {
        public interface IPrintLog
        {
            void ToConsole(string message);

            void ToFile(string message);
        }
    }
}
