namespace SCV.GlCommon
{
    public static class RoleConstants
    {
        public const string Admin = "Admin";
        public const string Manager = "Manager";
        public const string Trainer = "Trainer";
        public const string User = "User";

        public const string AdminOrManager = Admin + "," + Manager;
        public const string AdminManagerTrainer = Admin + "," + Manager + "," + Trainer;
    }
}
