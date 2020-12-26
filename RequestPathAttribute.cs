using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DotNet.RestApi.Client
{
    /// <summary>
    /// DEfines the Uri path for Web Rest Api request
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false, Inherited = true)]
    public class RequestPathAttribute : Attribute
    {
        /// <summary>
        /// Gets the uri string path for the request. 
        /// </summary>
        public string RestApiPath { get; }

        /// <summary>
        /// Constructs the class.
        /// </summary>
        /// <param name="path">The request path.</param>
        public RequestPathAttribute(string path)
        {
            RestApiPath = path;
        }

        /// <summary>
        /// Extracts the request path from the object.
        /// </summary>
        /// <param name="restRequest">The request object.</param>
        /// <returns>The request path.</returns>
        public static string GetRestApiPath(object restRequest)
        {
            if (restRequest.GetType().GetCustomAttributes(typeof(RequestPathAttribute), true).FirstOrDefault() is RequestPathAttribute attribute)
            {
                return attribute.RestApiPath;
            }
            return String.Empty;
        }

        /// <summary>
        /// Extracts the request path from the object.
        /// </summary>
        /// <returns>The request path.</returns>
        public static string GetRestApiPath<T>()
        {
            if (typeof(T).GetCustomAttributes(typeof(RequestPathAttribute), true).FirstOrDefault() is RequestPathAttribute attribute)
            {
                return attribute.RestApiPath;
            }
            return String.Empty;
        }

    }
}
