using System;

namespace App1.Infrastructure
{
    /// <summary>
    /// Thic class helps to convert Guid value to non dashed string.
    /// </summary>
    public static class GuidHelper
    {
        /// <summary>
        /// This method returns non dashed string representation of the guid value. 
        /// </summary>
        /// <param name="guid">The Guid value.</param>
        /// <returns></returns>
        public static string ToNonDashedString(this Guid guid)
        {
            string result = guid.ToString("N");
            return result;
        }
    }
}
