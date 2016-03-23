using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// The imagemap element returns information that you can use to identify clickable areas within the pod and the queries that should be issued if those areas are clicked. 
    /// Each rect subelement identifies a separate region. The coordinates are based on (0, 0) being the top-left corner of the pod.
    /// </summary>
    [XmlRoot("rect")]
    [System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class Rect
    {

        /// <summary>
        /// Left.
        /// </summary>
        [XmlAttribute("left")]
        public string Left { get; set; }

        /// <summary>
        /// Top.
        /// </summary>
        [XmlAttribute("top")]
        public string Top { get; set; }

        /// <summary>
        /// Right.
        /// </summary>
        [XmlAttribute("right")]
        public string Right { get; set; }

        /// <summary>
        /// Bottom.
        /// </summary>
        [XmlAttribute("bottom")]
        public string Bottom { get; set; }

        /// <summary>
        /// The query attribute gives the query input, and it is already URL-encoded for direct use in a subsequent query URL.
        /// </summary>
        [XmlAttribute("query")]
        public string Query { get; set; }

        /// <summary>
        /// The assumptions attribute gives an assumption value you would include in the query to ensure that it is interpreted as desired.
        /// </summary>
        [XmlAttribute("assumptions")]
        public string Assumptions { get; set; }

        /// <summary>
        /// The title attribute is a text string that shows the query in a readable form, which you might want to display as a tooltip when the mouse hovers over the region.
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        private string DebuggerDisplay { get { return string.Format("{0} {1} {2} {3} {4}", Title, Left, Top, Right, Bottom); } }

    }
}