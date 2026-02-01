export enum ValidationType {
    UNKNOWN = "UNKNOWN",
    REQUIRED = "REQUIRED",
    MIN_LENGTH = "MIN_LENGTH",
    MAX_LENGTH = "MAX_LENGTH",
    MINIMUM_VALUE_INT = "MINIMUM_VALUE_INT",
    MAXIMUM_VALUE_INT = "MAXIMUM_VALUE_INT",
    PATTERN = "PATTERN",
    MINIMUM_VALUE_FLOAT = "MINIMUM_VALUE_FLOAT",
    MAXIMUM_VALUE_FLOAT = "MAXIMUM_VALUE_FLOAT",
    MINIMUM_TIME_DAYS = "MINIMUM_TIME_DAYS",
    MINIMUM_TIME_WEEKS = "MINIMUM_TIME_WEEKS",
    MINIMUM_TIME_MONTHS = "MINIMUM_TIME_MONTHS",
    MINIMUM_TIME_YEARS = "MINIMUM_TIME_YEARS",
    MAXIMUM_TIME_DAYS = "MAXIMUM_TIME_DAYS",
    MAXIMUM_TIME_WEEKS = "MAXIMUM_TIME_WEEKS",
    MAXIMUM_TIME_MONTHS = "MAXIMUM_TIME_MONTHS",
    MAXIMUM_TIME_YEARS  = "MAXIMUM_TIME_YEARS",
    DATE_NOT_EQUAL = "DATE_NOT_EQUAL",
    DATE_MUST_BE_EARLIER = "DATE_MUST_BE_EARLIER",
    DATE_MUST_BE_LATER = "DATE_MUST_BE_LATER"
}

export const minimumTimeMap: Map<ValidationType, string> = new Map<ValidationType, string>([
    [ValidationType.MINIMUM_TIME_DAYS, 'days'],
    [ValidationType.MINIMUM_TIME_WEEKS, 'weeks'],
    [ValidationType.MINIMUM_TIME_MONTHS, 'months'],
    [ValidationType.MINIMUM_TIME_YEARS, 'years'],
]);

export const maximumTimeMap: Map<ValidationType, string> = new Map<ValidationType, string>([
    [ValidationType.MAXIMUM_TIME_DAYS, 'days'],
    [ValidationType.MAXIMUM_TIME_WEEKS, 'weeks'],
    [ValidationType.MAXIMUM_TIME_MONTHS, 'months'],
    [ValidationType.MAXIMUM_TIME_YEARS, 'years'],
]);
