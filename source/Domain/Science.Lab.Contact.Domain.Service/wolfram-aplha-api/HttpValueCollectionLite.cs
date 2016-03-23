using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace WolframAlpha.Api.v2
{
    internal class HttpValueCollectionLite : Dictionary<string, string>
    {

        public HttpValueCollectionLite(string s)
            : base(StringComparer.OrdinalIgnoreCase)
        {
            FillFromString(s);
        }

        private void FillFromString(string s)
        {
            //Following algorithm from the ReferenceSource's HttpValueCollection.
            //Assumes the string is already properly encoded.

            var length = s != null ? s.Length : 0;
            int index = 0;
            int startIndex;
            int equalsIndex;
            char currentChar;
            string name;
            string value;
            bool addedNull = false;

            while (index < length)
            {
                startIndex = index;
                equalsIndex = -1;

                while (index < length)
                {
                    //Look for ='s and &'s
                    currentChar = s[index];
                    if (currentChar == '=')
                    {
                        if (equalsIndex < 0)
                            equalsIndex = index;
                    }
                    else if (currentChar == '&')
                    {
                        break;
                    }

                    index++;
                }

                name = null;
                value = null;

                if (equalsIndex > -1)
                {
                    //name=value
                    name = s.Substring(startIndex, equalsIndex - startIndex);
                    value = s.Substring(equalsIndex + 1, index - equalsIndex - 1);
                }
                else
                {
                    //No equals encountered, assume NULL name and use value.
                    value = s.Substring(startIndex, index - startIndex);
                    addedNull = true;
                }

                System.Diagnostics.Debug.Assert(!this.ContainsKey(name));
                this.Add(name, value);

                //Trailing &
                if (!addedNull && index == length - 1 && s[index] == '&')
                {
                    this.Add(null, string.Empty);
                }

                index++;
            }
        }

    }
}