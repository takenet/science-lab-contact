using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// AssumptionValue.
    /// </summary>
    [XmlRoot("value")]
    [System.Diagnostics.DebuggerDisplay("{Name,nq}")]
    public class AssumptionValue
    {

        /// <summary>
        /// Name.
        /// </summary>
        [XmlAttribute("name")]
        public string Name { get; set; }

        /// <summary>
        /// Desc.
        /// </summary>
        [XmlAttribute("desc")]
        public string Desc { get; set; }

        /// <summary>
        /// Input.
        /// </summary>
        [XmlAttribute("input")]
        public string Input { get; set; }

    }
}