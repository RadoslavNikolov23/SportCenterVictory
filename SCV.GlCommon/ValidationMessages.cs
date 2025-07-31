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

        public static class Event
        {
            public const string TitleRequired = "Event Title is required.";
            public const string TitleLength = "Event Title must be between {2} and {1} characters long.";

            public const string TypeRequired = "Event Type is required.";

            public const string DescriptionLength = "Event Description must be between {2} and {1} characters long.";
            public const string StartDateRequired = "Event Start Date is required.";

            public const string LocationRequired = "Event Location is required.";
            public const string LocationLength = "Event Location must be between {2} and {1} characters long.";

            public const string ImageUrlInvalid = "Event Image URL is invalid.";
        }

        public static class Trainer
        {
            public const string FirstNameRequired = "Trainer First Name is required.";
            public const string FirstNameLength = "Trainer First Name must be between {2} and {1} characters long.";

            public const string LastNameRequired = "Trainer Last Name is required.";
            public const string LastNameLength = "Trainer Last Name must be between {2} and {1} characters long.";

            public const string EmailRequired = "Trainer Email is required.";
            public const string EmailInvalid = "Trainer Email is invalid.";
            public const string EmailLength = "Trainer Email must be between {2} and {1} characters long.";
           
            public const string PhoneNumberLength = "Trainer Phone Number must be between {2} and {1} characters long.";
            public const string PhoneNumberInvalid = "Trainer Phone Number is invalid.";

            public const string BioRequired = "Trainer Bio is required.";
            public const string BioLength = "Trainer Bio must be between {2} and {1} characters long.";
            
            public const string TrainerSpecialtyRequired = "Trainer Specialty is required.";

            public const string ImageUrlInvalid = "Trainer Image URL is invalid.";
        }

        public static class Membership
        {
            public const string NameRequired = "Membership Name is required.";
            public const string NameLength = "Membership Name must be between {2} and {1} characters long.";

            public const string MembershipTypeRequired = "Membership Type is required.";

            public const string DescriptionRequired = "Membership Description is required.";
            public const string DescriptionLength = "Membership Description must be between {2} and {1} characters long.";

            public const string PriceRequired = "Membership Price is required.";
            public const string PriceInvalid = "Membership Price must be a positive number.";
            public const string PriceRange = "Membership Price must be between {2} and {1}.";

            public const string DurationRequired = "Membership Duration is required.";
            public const string DurationLength = "Membership Duration must be between {2} and {1} characters long.";
        }

        public static class Product
        {
            public const string TitleRequired = "Product Title is required.";
            public const string TitleLength = "Product Title must be between {2} and {1} characters long.";
            
            public const string ProductCategoryRequired = "Product Category is required.";

            public const string QuantityRequired = "Product Quantity is required.";
            public const string QuantityInvalid = "Product Quantity must be a non-negative integer.";
            public const string QuantityRange = "Product Quantity must be between {2} and {1}.";

            public const string DescriptionLength = "Product Description must be between {2} and {1} characters long.";

            public const string PriceRequired = "Product Price is required.";
            public const string PriceInvalid = "Product Price must be a positive number.";
            public const string PriceRange = "Membership Price must be between {2} and {1}.";

            public const string ImageUrlInvalid = "Product Image URL is invalid.";
        }

        public static class UserFeedback
        {
            public const string UserIdRequired = "UserId is required.";

            public const string UserNameRequired = "UserName is required.";
            public const string UserNameLength = "UserName must be between {2} and {1} characters long.";

            public const string FullNameRequired = "User Full Name is required.";
            public const string FullNameLength = "User Full Name  must be between {2} and {1} characters long.";

            public const string FeedbackRequired = "Feedback is required.";
            public const string FeedbackLength = "Feedback must be between {2} and {1} characters long.";

            public const string ImageUrlInvalid = "Event Image URL is invalid.";

        }
    }
}
