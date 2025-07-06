namespace SCV.Data.Common
{
    public static class EntityConstantsTrainer
    {
        public const int FirstNameMaxLength = 40;
        public const int FirstNameMinLength = 2;

        public const int LastNameMaxLength = 40;
        public const int LastNameMinLength = 2;

        public const int EmailMaxLength = 320;
        public const int EmailMinLength = 3;

        public const int PhoneNumberMaxLength = 15;
        public const int PhoneNumberMinLength = 4;

        public const int BioMaxLength = 525;
        public const int BioMinLength = 10;

        public const int ImageUrlMaxLength = 2048;
        public const int ImageUrlMinLength = 10;

    }

    public static class EntityConstantsTrainerUser
    {
        public const int AdditionalInformationMaxLength = 500;
        public const int AdditionalInformationMinLength = 0; // Optional field, so no minimum length
    }
}
