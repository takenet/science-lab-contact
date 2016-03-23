using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;
using System.Diagnostics.Contracts;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// The assumptions element is a subelement of queryresult. Its content is a series of assumption elements.
    /// </summary>
    [XmlRoot("assumptions")]
    [System.Diagnostics.DebuggerDisplay("Count: {Count,nq}")]
    public class AssumptionsCollection
    {

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// Assumptions.
        /// </summary>
        [XmlElement("assumption")]
        public Assumption[] Assumptions { get; set; }

        /// <summary>
        /// Get Assumption by index.
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Assumption</returns>
        [XmlIgnore()]
        public Assumption this[int i]
        {
            get
            {
                Contract.Requires(0 <= i);
                Contract.Requires(i < Assumptions.Length);

                return Assumptions[i];
            }
        }

    }
}