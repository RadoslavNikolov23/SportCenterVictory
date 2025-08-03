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

        public static class CrossfitWODConstraints
        {
            public const int WODNameMaxLength = 18;
            public const int WODNameMinLength = 3;

            public const int WODDescriptionPlainMaxLength = 6025;
            public const int WODDescriptionPlainMinLength = 10;

            public const int WODDescriptionHTMLMaxLength = 7025;
            public const int WODDescriptionHTMLMinLength = 10;
        }
    }
}
