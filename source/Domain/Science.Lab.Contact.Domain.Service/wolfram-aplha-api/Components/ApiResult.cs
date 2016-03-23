using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// queryresult is the outer wrapper for all results from the query function.
    /// </summary>
    [XmlRoot("queryresult")]
    public abstract class ApiResult
    {

        /// <summary>
        /// true or false depending on whether the input could be successfully understood. If false there will be no pod subelements.
        /// </summary>
        [XmlAttribute("success")]
        public string Success { get; set; }

        /// <summary>
        /// true or false depending on whether a serious processing error occurred, such as a missing required parameter. If true there will be no pod content, just an error subelement.
        /// </summary>
        [XmlAttribute("error")]
        public string Error { get; set; }

        /// <summary>
        /// Error details.
        /// </summary>
        [XmlElement("error")]
        public Error ErrorData { get; set; }

        /// <summary>
        /// The wall-clock time in seconds required to generate the output.
        /// </summary>
        [XmlAttribute("timing")]
        public string Timing { get; set; }

        /// <summary>
        /// The time in seconds required by the parsing phase.
        /// </summary>
        [XmlAttribute("parsetiming")]
        public string ParseTiming { get; set; }

        /// <summary>
        /// The version specification of the API on the server that produced this result.
        /// </summary>
        [XmlAttribute("version")]
        public string Version { get; set; }

        /// <summary>
        /// Warnings.
        /// </summary>
        [XmlElement("warnings")]
        public WarningCollection Warnings { get; set; }

        /// <summary>
        /// Assumptions.
        /// </summary>
        [XmlElement("assumptions")]
        public AssumptionsCollection Assumptions { get; set; }

    }
}