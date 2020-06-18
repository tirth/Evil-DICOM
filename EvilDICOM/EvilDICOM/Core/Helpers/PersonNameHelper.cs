﻿namespace EvilDICOM.Core.Helpers
{
    // TODO: support prefix, suffix
    public class PersonNameHelper
    {
        public static string GetFirstName(string data)
        {
            return Parse(data)[0];
        }

        public static string SetFirstName(string data, string name)
        {
            var nameParts = Parse(data);
            nameParts[0] = name;
            return FormatName(nameParts[0], nameParts[1], nameParts[2]);
        }

        public static string GetMiddleName(string data)
        {
            return Parse(data)[1];
        }

        public static string SetMiddleName(string data, string name)
        {
            var nameParts = Parse(data);
            nameParts[1] = name;
            return FormatName(nameParts[0], nameParts[1], nameParts[2]);
        }

        public static string GetLastName(string data)
        {
            return Parse(data)[2];
        }

        public static string SetLastName(string data, string name)
        {
            var nameParts = Parse(data);
            nameParts[2] = name;
            return FormatName(nameParts[0], nameParts[1], nameParts[2]);
        }

        public static (string firstName, string middleName, string lastName) ParseName(string unparsedName)
        {
            var parsed = Parse(unparsedName);
            return (parsed[0], parsed[1], parsed[2]);
        }

        private static string[] Parse(string unparsedName)
        {
            if (!string.IsNullOrEmpty(unparsedName))
            {
                var nameParts = unparsedName.Split('^');
                var lastName = nameParts.Length > 0 ? nameParts[0] : string.Empty;
                var firstName = nameParts.Length > 1 ? nameParts[1] : string.Empty;
                var middleName = nameParts.Length > 2 ? nameParts[2] : string.Empty;
                return new[] {firstName, middleName, lastName};
            }
            return new[] {string.Empty, string.Empty, string.Empty};
        }

        private static string FormatName(string firstName, string middleName, string lastName)
        {
            return string.Format("{0}^{1}^{2}", lastName, firstName, middleName);
        }
    }
}