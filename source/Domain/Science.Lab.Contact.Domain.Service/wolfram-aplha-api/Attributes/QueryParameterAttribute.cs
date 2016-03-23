using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics.Contracts;

namespace WolframAlpha.Api.v2.Attributes
{
    /// <summary>
    /// Query Parameter Attribute.
    /// </summary>
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = true)]
    [System.Diagnostics.DebuggerDisplay("{Name} Required? {Required}")]
    public class QueryParameterAttribute : Attribute
    {

        /// <summary>
        /// Name of the query parameter.
        /// </summary>
        public string Name { get; private set; }
        /// <summary>
        /// Is this parameter required?
        /// </summary>
        public bool Required { get; private set; }

        /// <summary>
        /// Create a new QueryParameterAttribute.
        /// </summary>
        /// <param name="name"></param>
        public QueryParameterAttribute(string name)
            : this(name, false)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", "name");
            Contract.EndContractBlock();
        }
        /// <summary>
        /// Create a new QueryParameterAttribute.
        /// </summary>
        /// <param name="name"></param>
        /// <param name="required"></param>
        public QueryParameterAttribute(string name, bool required)
        {
            if (name == null)
                throw new ArgumentNullException("name");
            if (string.IsNullOrWhiteSpace(name))
                throw new ArgumentException("Name is required.", "name");
            Contract.EndContractBlock();

            this.Name = name;
            this.Required = required;
        }

    }
}