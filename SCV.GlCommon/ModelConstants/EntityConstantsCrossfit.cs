namespace SCV.GlCommon.ModelConstants
{
    public static class EntityConstantsCrossfit
    {
        public static class CrossfitClassConstraints
        {
            public const int ClassNameMaxLength = 30;
            public const int ClassNameMinLength = 2;

            public const int ClassDescriptionMaxLength = 2025;
            public const int ClassDescriptionMinLength = 10;

            public const int ClassStartTimeMaxLength = 60;
            public const int ClassStartTimeMinLength = 3;

            public const int TrainerNameMaxLength = 80;
            public const int TrainerNameMinLength = 2;
        }

        public static class CrossfitWorkoutOfTheDayConstraints
        {
            public const int WODNameMaxLength = 15;
            public const int WODNameMinLength = 3;

            //Check if this is correct, as it seems very long for description
            public const int WODDescriptionPlainMaxLength = 4025;
            public const int WODDescriptionPlainMinLength = 10;

            //Check if this is correct, as it seems very long for description
            public const int WODDescriptionHTMLMaxLength = 5025;
            public const int WODDescriptionHTMLMinLength = 10;
        }
    }
}
