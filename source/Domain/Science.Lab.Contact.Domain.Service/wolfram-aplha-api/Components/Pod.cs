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
    /// pod elements are subelements of queryresult. Each contains the results for a single pod.
    /// </summary>
    [XmlRoot("pod")]
    [System.Diagnostics.DebuggerDisplay("{Title,nq}")]
    public class Pod
    {

        /// <summary>
        /// The pod title, used to identify the pod.
        /// </summary>
        [XmlAttribute("title")]
        public string Title { get; set; }

        /// <summary>
        /// The name of the scanner that produced this pod. A guide to the type of data it holds.
        /// </summary>
        [XmlAttribute("scanner")]
        public string Scanner { get; set; }

        /// <summary>
        /// This attribute is undocumented at this time.
        /// </summary>
        [XmlAttribute("id")]
        public string Id { get; set; }

        /// <summary>
        /// A number indicating the intended position of the pod in a visual display. These numbers are typically multiples of 100, but it is only relevant that they form an increasing sequence from top to bottom.
        /// </summary>
        [XmlAttribute("position")]
        public string Position { get; set; }

        /// <summary>
        /// true or false depending on whether a serious processing error occurred with this specific pod. If true, there will be an error subelement.
        /// </summary>
        [XmlAttribute("error")]
        public string Error { get; set; }

        /// <summary>
        /// Error details.
        /// </summary>
        [XmlElement("error")]
        public Error ErrorData { get; set; }

        /// <summary>
        /// Although Wolfram|Alpha returns many pods for most queries, there is sometimes the notion of a "primary result" for a given query.
        /// </summary>
        [XmlAttribute("primary")]
        public string Primary { get; set; }

        /// <summary>
        /// The number of subpod elements present.
        /// </summary>
        [XmlAttribute("numsubpods")]
        public string NumSubPods { get; set; }

        /// <summary>
        /// Subpods.
        /// </summary>
        [XmlElement("subpod")]
        public SubPod[] SubPods { get; set; }

        /// <summary>
        /// States.
        /// </summary>
        [XmlElement("states")]
        public StateCollection States { get; set; }

        /// <summary>
        /// Infos.
        /// </summary>
        [XmlElement("infos")]
        public InfoCollection Infos { get; set; }

        /// <summary>
        /// Sounds.
        /// </summary>
        [XmlElement("sounds")]
        public SoundCollection Sounds { get; set; }

        /// <summary>
        /// Get SubPod by index.
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>SubPod</returns>
        [XmlIgnore()]
        public SubPod this[int i]
        {
            get
            {
                Contract.Requires(0 <= i);
                Contract.Requires(i < SubPods.Length);
                
                return SubPods[i];
            }
        }


    }
}