using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Enums
{
    public enum PropertyType
    {
        UNKNOWN = 0,
        STRING = 1,
        NUMBER = 2,
        BOOLEAN = 3,
        STRING_ARRAY = 4,
        NUMBER_ARRAY = 5,
        BOOLEAN_ARRAY = 6,
        OBJECT = 7,
        OBJECT_ARRAY = 8,
        FORM_ARRAY = 9,
        DATE = 10
    }

}