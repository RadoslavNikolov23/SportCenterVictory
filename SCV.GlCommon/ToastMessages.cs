namespace SCV.GlCommon
{
    public static class ToastMessages
    {
        //Base Messages
        public const string ErrorMessageBaseSomethingWentWrong = "Something went wrong. Try again later!";


        //EmailSender Messages
        public const string SuccessMessageEmailSend = "Your message has been sent successfully!";
        public const string ErrorMessageEmailSend = "Message was not sent. Try again later!";


        //UserFeedback Messages
        public const string SuccessMessageUserFeedbackSuccessfulAdd = "User Feedback added successfully";
        public const string ErrorMessageUserFeedbackCannotCreate = "User Feedback could not be created. Please try again.";
        public const string ErrorMessageInvalidUserFeedback = "Invalid User Feedback. Please review the feedback!.";
        public const string ErrorMessageCannotApproveUserFeedback = "Could not approve User Feedback. Please try again.";
        public const string SuccessMessageApproveUserFeedback = "User Feedback status changed successfully!";


        //Crossfit Messages
        public const string SuccessMessageCrossfitClassCreated = "CrossFit Classes added successfully!";
        public const string ErrorMessageCrossfitClassCannotCreate = "CrossFit Class could not be created. Please try again.";
        public const string SuccessMessageUpdateCrossfitClass = "CrossFit Class {0} updated successfully!";
        public const string ErrorMessageCannotUpdateCrossfitClass = "CrossFit Class {0} was not updated! Please try again!";
        public const string SuccessMessageJoinedCrossfitClass = "CrossFit Class joined successfully!";
        public const string SuccessMessageRemovedCrossfitClass = "CrossFit Class removed successfully!";
        public const string ErrorMessageCrossfitClassCannotDelete = "CrossFit Class could not be found and deleted!";
        public const string ErrorMessageCrossfitClassCannotFind= "CrossFit Class could not be found. Please try again.";
        public const string SuccessMessageDeleteCrossfitClass = "CrossFit Class {0} successfully!";


        //Event Messages
        public const string SuccessMessageAddEvent = "Event added successfully!";
        public const string ErrorMessageCannotCreateEvent = "Event could not be created. Please try again.";
        public const string ErrorMessageCannotFindEvent = "Event could not be found. Please try again.";
        public const string SuccessMessageUpdateEvent = "Event {0} updated successfully!";
        public const string ErrorMessageCannotUpdateEvent = "Event {0} was not updated! Please try again!";
        public const string SuccessMessageDeleteEvent = "Event is {0} successfully!";
        public const string SuccessMessageJoinedEvent = "Event joined successfully!";
        public const string SuccessRemovedJoinedEvent = "Event removed successfully!";



        //Exercise Messages
        public const string ErrorMessageCannotCreateExercise = "Exercise could not be created. Please try again.";
        public const string SuccessMessageCreatedExercise = "Exercise added successfully!";
        public const string ErrorMessageCannotFindExercise = "Exercise could not be found. Please try again.";
        public const string SuccessMessageUpdateExercise = "Exercise {0} updated successfully!";
        public const string ErrorMessageCannotUpdateExercise = "Exercise {0} was not updated successfully! Please try again!";
        public const string SuccessMessageDeleteExercise = "Exercise is {0} successfully!";

        //Workout Messages
        public const string SuccessMessageCreatedWorkoutPlan = "Workout Plan added successfully!";
        public const string ErrorMessageCannotCreateWorkoutPlan = "Workout Plan could not be created. Please try again.";
        public const string SuccessMessageUpdateWorkoutPlan = "Workout Plan {0} updated successfully!";
        public const string ErrorMessageCannotUpdateWorkoutPlan = "Workout Plan {0} updated successfully!";
        public const string ErrorMessageCannotFindWorkoutPlan = "Workout Plan could not be found. Please try again.";
        public const string SuccessMessageDeleteWorkoutPlan = "Workout Plan is {0} successfully!";
        public const string SuccessMessageWorkoutPlanExerciseUpdate = "Exercises updated successfully.";
        public const string ErrorMessageWorkoutPlanExerciseCannotUpdate = "Exercises was not updated! Try again later!";


        //Store Messages
        public const string SuccessMessageOrderPlaced = "Your order was placed successfully!";
        public const string SuccessMessageProductCreated = "Product added successfully!";
        public const string ErrorMessageCannotCreateProduct = "Product could not be created. Please try again.";
        public const string ErrorMessageCannotFindProduct = "Product could not be found. Please try again.";
        public const string SuccessMessageProductUpdate = "Product {0} updated successfully!";
        public const string ErrorMessageProductCannotUpdate = "Product {0} was not updated! Please try again!";
        public const string SuccessMessageDeleteProduct = "Product is {0} successfully!";
        public const string ErrorMessageCannotApproveOrder = "Order could not be approved. Please try again.";
        public const string SuccessMessageApproveOrder = "Order status updated successfully!";
        public const string ErrorMessageCannotCreateMembership = "Membership could not be created. Please try again.";
        public const string ErrorMessageMembershipAdded = "Membership added successfully!";
        public const string ErrorMessageCannotFindMembership = "Membership could not be found. Please try again.";
        public const string SuccessMessageUpdateMembership = "Membership {0} updated successfully!";
        public const string ErrorMessageCannotUpdateMembership = "Membership {0} was not updated! Please try again later!";
        public const string SuccessMessageCannotUpdateMembership = "Membership {0} was not updated! Please try again!";
        public const string SuccessMessageDeleteMembership = "Membership is {0} successfully!";


        //Trainer Messages
        public const string ErrorMessageCannotCreateTrainer = "Trainer Bio could not be created. Please try again.";
        public const string SuccessMessageCreatedTrainer = "Trainer Bio added successfully!";
        public const string ErrorMessageCannotFindTrainer = "Trainer could not be found or is not a trainer. Please try again";
        public const string ErrorMessageNotAuthorizeToEdit = "You are not authorized to edit this Trainer Bio.";
        public const string SuccessMessageUpdateTrainer = "Trainer Bio updated successfully.";
        public const string ErrorMessagecannotUpdateTrainer = "Trainer Bio was not updated! Please try again!";
        public const string SuccessMessageTrainerDeleted = "Trainer is {0} successfully!";
        public const string SuccessMessageJoinedTrainer = "Trainer added successfully!";
        public const string SuccessMessageRemovedTrainer = "Trainer removed successfully!";




        //UserManagement Messages
        public const string SuccessMessageAssinRoleUser = "User assigned to role successfully";
        public const string ErrorMessageUserDoesNotExist = "User does not exist!";

        public const string SuccessMessageRemoveRoleUser = "User removed from the given role {0} successfully!";
        public const string SuccessMessageDeleteUser = "User deleted successfully!";

    }
}
