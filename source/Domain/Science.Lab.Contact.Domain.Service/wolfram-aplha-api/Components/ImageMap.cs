using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Xml.Serialization;

namespace WolframAlpha.Api.v2.Components
{
    /// <summary>
    /// Many pods on the Wolfram|Alpha website have HTML image maps associated with them, so that you can click parts of the pod image to execute queries. 
    /// Most table-style pods have this property, so that each element in the table or list can be clicked to trigger a query based on the content of that item.
    /// </summary>
    [XmlRoot("imagemap")]
    [System.Diagnostics.DebuggerDisplay("{DebuggerDisplay,nq}")]
    public class ImageMap
    {

        /// <summary>
        /// Rects.
        /// </summary>
        [XmlElement("rect")]
        public Rect[] Rects { get; set; }

        private string DebuggerDisplay { get { return string.Format("Count: {0}", this.Rects != null ? this.Rects.Length : 0); } }

    }
}