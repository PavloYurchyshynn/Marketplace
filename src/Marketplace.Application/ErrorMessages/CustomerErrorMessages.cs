using System;

namespace Marketplace.Application.ErrorMessages
{
    public class CustomerErrorMessages
    {
        public const string UserAlreadyExists = "User already exists!";
        public const string UserCreationFailed = "User creation failed! Please check user details and try again.";
        public const string UserUpdatingFailed = "User updating failed! Please try again.";
        public const string UserNotFound = "User not found";
        public const string UserDeletingFailed = "User deleting failed! Please try again.";
        public const string ProductsNotFound = "Products not found";
        public const string ProductWithIdNotFound = "Product with this id not found";
        public const string ProductDoesNotBelong = "The selected product does not belong to you";
    }
}
