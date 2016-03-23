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
    /// queryresult is the outer wrapper for all results from the query function.
    /// </summary>
    [XmlRoot("queryresult")]
    public class QueryResult : ApiResult
    {

        /// <summary>
        /// Categories and types of data represented in the results.
        /// </summary>
        [XmlAttribute("datatypes")]
        public string DataTypes { get; set; }

        /// <summary>
        /// The number of pods that are missing because they timed out (see the scantimeout query parameter).
        /// </summary>
        [XmlAttribute("timedout")]
        public string TimedOut { get; set; }

        /// <summary>
        /// Whether the parsing stage timed out (try a longer parsetimeout parameter if true)
        /// </summary>
        [XmlAttribute("parsetimedout")]
        public string ParseTimedOut { get; set; }

        /// <summary>
        /// A URL to use to recalculate the query and get more pods.
        /// </summary>
        [XmlAttribute("recalculate")]
        public string Recalculate { get; set; }

        /// <summary>
        /// The number of pods.
        /// </summary>
        [XmlAttribute("numpods")]
        public string NumPods { get; set; }
        
        /// <summary>
        /// Pods.
        /// </summary>
        [XmlElement("pod")]
        public Pod[] Pods { get; set; }

        /// <summary>
        /// Sources.
        /// </summary>
        [XmlElement("sources")]
        public SourceCollection Sources { get; set; }

        /// <summary>
        /// Generalization.
        /// </summary>
        [XmlElement("generalization")]
        public Generalization Generalization { get; set; }

        /// <summary>
        /// DidYouMeans.
        /// </summary>
        [XmlElement("didyoumeans")]
        public DidYouMeansCollection DidYouMeans { get; set; }

        /// <summary>
        /// LanguageMsg.
        /// </summary>
        [XmlElement("languagemsg")]
        public LanguageMsg LanguageMsg { get; set; }

        /// <summary>
        /// Tips.
        /// </summary>
        [XmlElement("tips")]
        public TipsCollection Tips { get; set; }

        /// <summary>
        /// FutureTopic.
        /// </summary>
        [XmlElement("futuretopic")]
        public FutureTopic FutureTopic { get; set; }

        /// <summary>
        /// RelatedExamples.
        /// </summary>
        [XmlElement("relatedexamples")]
        public RelatedExamplesCollection RelatedExamples { get; set; }

        /// <summary>
        /// ExamplePage
        /// </summary>
        [XmlElement("examplepage")]
        public ExamplePage ExamplePage { get; set; }

        /// <summary>
        /// Get pod by index.
        /// </summary>
        /// <param name="i">index</param>
        /// <returns>Pod</returns>
        [XmlIgnore()]
        public Pod this[int i]
        {
            get
            {
                Contract.Requires(0 <= i);
                Contract.Requires(i < Pods.Length);
                
                return Pods[i];
            }
        }

    }
}