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
    /// Used when the link is a popup window showing a table of unit abbreviations used in the pod alongside their long names.
    /// </summary>
    [XmlRoot("units")]
    [System.Diagnostics.DebuggerDisplay("Count: {Count,nq}")]
    public class UnitsCollection
    {

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// Each row is represented as a unit element giving the short and long names of the unit.
        /// </summary>
        [XmlElement("unit")]
        public Unit[] Units { get; set; }

        /// <summary>
        /// Wolfram|Alpha creates nicely rendered images of these units tables, so there is also an img element that points to the URL for the image of the entire table.
        /// </summary>
        [XmlElement("img")]
        public Image[] Imgs { get; set; }

        /// <summary>
        /// Get Unit by index.
        /// </summary>
        /// <param name="i">Index</param>
        /// <returns>Unit</returns>
        [XmlIgnore()]
        public Unit this[int i]
        {
            get
            {
                Contract.Requires(0 <= i);
                Contract.Requires(i < Units.Length);
                
                return Units[i];
            }
        }

    }
}