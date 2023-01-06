namespace QzemApp.Constants
{
    public static class ApiConstants
    {
        // TEST
        public const string BaseApiUrl = "https://wsqzem-test.in-medio.be/";

        // PRODUCTION
        //public const string BaseApiUrl = "https://wsexpressoqzem.qzem.be/";

        // ENDPOINTS
        public const string AuthenticateEndpoint = "api/v1/authenticate";
        public const string ContractsByDateEndpoint = "api/dimonaapp/v1/contracts/date/";
        public const string SaveContractEndpoint = "api/dimonaapp/v1/contracts/saveHours/";
    }
}

    