using System;
using System.Collections.Generic;

namespace Chronique
{
    public abstract class BaseModel
    {
        public BaseModel()
        {
            Id = ++pId + "";
        }

        private static int pId = 0;
        public string Id { get; set; }
    }
}
