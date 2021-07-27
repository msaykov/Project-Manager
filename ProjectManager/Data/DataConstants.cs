﻿namespace ProjectManager.Data
{
    public class DataConstants
    {
        public class Project
        {
            public const int ProjectNameMaxLength = 30;
            public const int ProjectNameMinLength = 2;
            public const int ProjectDescriptionMinLength = 10;
            public const int ProjectDescriptionMaxLength = 1000;
        }

        public class Material
        {
            public const int MaterialNameMaxLength = 100;
            public const int MaterialNameMinLength = 2;
        }
        

        public const int TownNameMinLength = 3;
        public const int TownNameMaxLength = 30;

        public const int TypeNameMinLength = 3;
        public const int TypeNameMaxLength = 30;

        public const int StatusNameMinLength = 3;
        public const int StatusNameMaxLength = 20;

        public const int EmployeeNameMinLength = 2;
        public const int EmployeeNameMaxLength = 30;

        public const string DateRegEx = @"(^-?\d{1,3}\.$)|(^-?\d{1,3}$)|(^-?\d{0,3}\.\d{1,2}$)";
        public const string NamesErrorMsg = "The {0} must be between {2} and {1} characters long.";
    }
}
