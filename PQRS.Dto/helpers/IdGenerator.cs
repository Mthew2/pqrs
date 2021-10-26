using System;
using System.Collections.Generic;
using System.Text;

namespace PQRS.Dto.helpers
{
    public static class IdGenerator
    {

        private static int quejaID;

        public static int QuejaID
        {
            get { return quejaID++; }
        }
    }
}


