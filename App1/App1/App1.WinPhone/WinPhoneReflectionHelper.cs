using System;
using System.Reflection;
using App1.Infrastructure.Interfaces;
using App1.WinPhone;

[assembly: Xamarin.Forms.Dependency(typeof(WinPhoneReflectionHelper))]
namespace App1.WinPhone
{
    public class WinPhoneReflectionHelper : IReflectionHelper
    {
        /// <summary>
        /// Get <see cref="MethodInfo"/> for the given type.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="methodName">The name of the method.</param>
        /// <returns>Returns method info.</returns>
        public MethodInfo GetMethodInfo(Type type, string methodName)
        {
            //MethodInfo methodInfo = type.GetMethod(methodName, BindingFlags.NonPublic | BindingFlags.Instance);
            MethodInfo methodInfo = type.GetTypeInfo().GetDeclaredMethod(methodName);
            return methodInfo;
        }
    }
}
