using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectManager.Data
{
    public class DataConstants
    {
        public const int ProjectNameMaxLength = 30;
        public const int ProjectNameMinLength = 2;

        public const int TownNameMinLength = 3;
        public const int TownNameMaxLength = 30;

        public const int TypeNameMinLength = 3;
        public const int TypeNameMaxLength = 30;

        public const int StatusNameMinLength = 3;
        public const int StatusNameMaxLength = 20;

        public const int EmployeeNameMinLength = 2;
        public const int EmployeeNameMaxLength = 30;

        public const int MaterialNameMaxLength = 200;

        public const string DateRegEx = @"(^-?\d{1,3}\.$)|(^-?\d{1,3}$)|(^-?\d{0,3}\.\d{1,2}$)";
        public const string NamesErrorMsg = "The {0} must be between {2} and {1} characters long.";
    }
}
