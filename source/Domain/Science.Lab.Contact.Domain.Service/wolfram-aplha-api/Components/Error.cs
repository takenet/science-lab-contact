using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// The error element occurs as either a subelement of queryresult, if there was a failure that prevented any result from being returned, 
    /// or as a subelement of pod, if there was an error that only prevented the result from a given pod from being returned.
    /// </summary>
    [XmlRoot("error")]
    [System.Diagnostics.DebuggerDisplay("{Code,nq}")]
    public class Error
    {

        /// <summary>
        /// The error code, an integer.
        /// </summary>
        [XmlElement("code")]
        public string Code { get; set; }

        /// <summary>
        /// A short message describing the error.
        /// </summary>
        [XmlElement("msg")]
        public string Msg { get; set; }

    }
}