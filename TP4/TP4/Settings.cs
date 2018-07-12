using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    sealed class Settings
    {
        private Settings defaultInstance;

        internal Settings DefaultInstance { get => defaultInstance; set => defaultInstance = value; }


    }
}
