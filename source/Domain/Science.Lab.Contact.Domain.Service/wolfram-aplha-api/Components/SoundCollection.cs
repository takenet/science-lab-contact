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
    /// Some queries generate sounds as part of their output.
    /// </summary>
    [XmlRoot("sounds")]
    [System.Diagnostics.DebuggerDisplay("Count: {Count,nq}")]
    public class SoundCollection
    {

        /// <summary>
        /// Count.
        /// </summary>
        [XmlAttribute("count")]
        public string Count { get; set; }

        /// <summary>
        /// Sounds.
        /// </summary>
        [XmlElement("sound")]
        public Sound[] Sounds { get; set; }

        /// <summary>
        /// Get Sound by index.
        /// </summary>
        /// <param name="i">Inde</param>
        /// <returns>Sound</returns>
        [XmlIgnore()]
        public Sound this[int i]
        {
            get
            {
                Contract.Requires(0 <= i);
                Contract.Requires(i < Sounds.Length);
                
                return Sounds[i];
            }
        }

    }
}