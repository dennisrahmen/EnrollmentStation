namespace EnrollmentStation.Code.Enums
{
    public enum RevokeReason
    {
        CRL_REASON_UNSPECIFIED = 0,
        CRL_REASON_KEY_COMPROMISE = 1,
        CRL_REASON_CA_COMPROMISE = 2,
        CRL_REASON_AFFILIATION_CHANGED = 3,
        CRL_REASON_SUPERSEDED = 4,
        CRL_REASON_CESSATION_OF_OPERATION = 5,
        CRL_REASON_CERTIFICATE_HOLD = 6
    }
}