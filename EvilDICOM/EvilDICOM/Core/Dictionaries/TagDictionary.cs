#region

using System.Collections.Generic;
using EvilDICOM.Core.Element;
using EvilDICOM.Core.Enums;
using EvilDICOM.Core.Interfaces;

#endregion

namespace EvilDICOM.Core.Dictionaries
{
    /// <summary>
    ///     The class is used to look up tags in a dictionary for relevant information such as vr type.
    /// </summary>
    public static partial class TagDictionary
    {
        private const string GROUP_HEADER = "0000";

        /// <summary>
        ///     Finds the appropriate VR for a given tag by looking up the tag in a DICOM dictionary
        /// </summary>
        /// <param name="tag">the tag containing the id to find in the dictionary</param>
        /// <returns></returns>
        public static VR GetVRFromTag(Tag tag)
        {
            if (tag.Element == GROUP_HEADER) return VR.UnsignedLong;
            if (Tags.ContainsKey(tag.CompleteID.ToUpperInvariant()))
            {
                var t = Tags[tag.CompleteID.ToUpperInvariant()];
                var vr = t.VR;
                return VRDictionary.GetVRFromAbbreviation(vr);
            }
            return VR.Unknown;
        }

        /// <summary>
        ///     Adds an entry to the DICOM Dictionary for reading files
        /// </summary>
        /// <typeparam name="T">the type of VR to add</typeparam>
        /// <param name="id">the tag id of the element</param>
        /// <param name="description">the description of the element</param>
        public static void AddEntry<T>(string id, string description) where T : IDICOMElement
        {
            Tags.Add(id, new TagInfo {Description = description, VR = VRDictionary.GetAbbreviationFromType(typeof(T))});
        }

        /// <summary>
        ///     Gets the description of the tag
        /// </summary>
        /// <param name="tag">the tag containing the id</param>
        /// <returns>a string description of the tag in camel case</returns>
        public static string GetDescription(string completeId)
        {
            var element = completeId.Substring(4, 4);
            return element == GROUP_HEADER
                ? string.Format("Group header for group {0}", completeId.Substring(0, 4))
                : Tags.ContainsKey(completeId)
                    ? Tags[completeId].Description
                    : "Unknown Tag";
        }

        /// <summary>
        ///     Gets the description of the tag
        /// </summary>
        /// <param name="tag">the tag containing the id</param>
        /// <returns>a string description of the tag in camel case</returns>
        public static string GetDescription(Tag tag)
        {
            return tag.Element == GROUP_HEADER
                ? string.Format("Group header for group {0}", tag.Group)
                : Tags.ContainsKey(tag.CompleteID)
                    ? Tags[tag.CompleteID].Description
                    : "Unknown Tag";
        }
    }
}