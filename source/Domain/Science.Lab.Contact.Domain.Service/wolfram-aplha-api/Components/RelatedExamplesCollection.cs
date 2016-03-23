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
    /// Although Wolfram|Alpha cannot understand the query "bear shoe", 
    /// it sees the word "bear" and provides users with information about related examples via the relatedexamples element.
    /// </summary>
    [XmlRoot("relatedexamples")]
    [System.Diagnostics.DebuggerDisplay("Count: {Count,nq}")]
    public class RelatedExamplesCollection
    {

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// RelatedExamples.
        /// </summary>
        [XmlElement("relatedexample")]
        public RelatedExample[] RelatedExamples { get; set; }

        /// <summary>
        /// Get RelatedExample by index.
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>RelatedExample</returns>
        [XmlIgnore()]
        public RelatedExample this[int i]
        {
            get
            {
                Contract.Requires(0 <= i);
                Contract.Requires(i < RelatedExamples.Length);
                
                return RelatedExamples[i];
            }
        }

    }
}