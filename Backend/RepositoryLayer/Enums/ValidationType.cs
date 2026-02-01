using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RepositoryLayer.Enums
{
    public enum ValidationType
    {
        UNKNOWN = 0,
        REQUIRED = 1,
        MIN_LENGTH = 2,
        MAX_LENGTH = 3,
        MINIMUM_VALUE_INT = 4,
        MAXIMUM_VALUE_INT = 5,
        PATTERN = 6,
        MINIMUM_VALUE_FLOAT = 7,
        MAXIMUM_VALUE_FLOAT = 8,
        MINIMUM_TIME_DAYS = 9,
        MINIMUM_TIME_WEEKS = 10,
        MINIMUM_TIME_MONTHS = 11,
        MINIMUM_TIME_YEARS = 12,
        MAXIMUM_TIME_DAYS = 13,
        MAXIMUM_TIME_WEEKS = 14,
        MAXIMUM_TIME_MONTHS = 15,
        MAXIMUM_TIME_YEARS = 16,
        DATE_NOT_EQUAL = 17,
        DATE_MUST_BE_EARLIER = 18,
        DATE_MUST_BE_LATER = 19,
    }

}