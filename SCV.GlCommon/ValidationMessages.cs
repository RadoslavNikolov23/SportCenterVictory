namespace SCV.GlCommon
{
    public static class ValidationMessages
    { 
        public static class CrossfitClass
        {
            public const string NameRequired = "CrossFit Class Name is required.";
            public const string NameLength = "CrossFit Class Name must be between {2} and {1} characters long.";

            public const string DescriptionRequired = "CrossFit Class Description";
            public const string DescriptionLength = "CrossFit Class Description must be between {2} and {1} characters long.";

            public const string StartTimeRequired = "CrossFit Class Start Time is required.";
            public const string StartTimeLength = "CrossFit Class Start Time must be between {2} and {1} characters long.";

            public const string DayOfWeekRequired = "CrossFit Class Day of Week is required.";

            public const string TrainerNameRequired = "CrossFit Class Trainer Name is required.";
            public const string TrainerNameLength = "CrossFit Class Trainer Name must be between {2} and {1} characters long.";
        }
    }
}
