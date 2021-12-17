using Core.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace Business.Constants
{
    public static class Messages
    {
        public static string DeletedItem = "This item deleted";
        public static string ValidProductNameAndPrice = "This is valid price and name";
        public static string InvalidProductNameOrPrice = "This is not valid price or name";
        public static string ReturnDateIsNull = "You can not rent this car";
        public  static string ReturnDateIsNotNull="You can rent this car";
        public static string EmailNotExist="write your correct email";
        public static string Created = "Item created";
        public static string Success = "this process is success";
        public static string AuthorizationDenied = "AuthorizationDenied";
    }
}
