namespace SCV.Data.Common
{
    public static class EntityConstantsEvent
    {
        public const int TitleMaxLength = 40;
        public const int TitleMinLength = 3;

        //Checking if the Description Max Length is enough for a detailed description
        public const int DescriptionMaxLength = 525;
        public const int DescriptionMinLength = 3;

        public const int LocationMaxLength = 85;
        public const int LocationMinLength = 5;

        public const int ImageUrlMaxLength = 2048;
        public const int ImageUrlMinLength = 5;

        //Make the default image URL a constant if you have a specific one in mind
        //public const string DefaultImageUrl = "https://example.com/default-event-image.jpg";
    }
}
