using Core.Entities.Concrete;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        //intro level ? multi language sport??
       
        public static string ProductAdded = "Product added";
        public static string ProductNameInvalid= "Product name is invalid";
        public static string MaintenanceTime="Maintenance Time";
        public static string ProductsListed ="Products Listed";
        public static string ProductCountOfCategoryError = "maximum 10 products can exist in 1 category ";
        public static string ProductNameAlreadyExists ="Product name already exists";
        public static string CategoryLimitExceded = "Category Limit is exceded max 15 category";
        public static string AuthorizationDenied = "You have not authorisated to do that";
        internal static User UserNotFound;
        internal static User PasswordError;
        internal static string SuccessfulLogin;
        internal static string UserAlreadyExists;
        internal static string AccessTokenCreated;
        internal static string UserRegistered;
    }
}
