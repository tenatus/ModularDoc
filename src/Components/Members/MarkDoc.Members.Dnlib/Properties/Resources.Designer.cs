﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MarkDoc.Members.Dnlib.Properties {
    using System;
    
    
    /// <summary>
    ///   A strongly-typed resource class, for looking up localized strings, etc.
    /// </summary>
    // This class was auto-generated by the StronglyTypedResourceBuilder
    // class via a tool like ResGen or Visual Studio.
    // To add or remove a member, edit your .ResX file then rerun ResGen
    // with the /str option, or rebuild your VS project.
    [global::System.CodeDom.Compiler.GeneratedCodeAttribute("System.Resources.Tools.StronglyTypedResourceBuilder", "16.0.0.0")]
    [global::System.Diagnostics.DebuggerNonUserCodeAttribute()]
    [global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    internal class Resources {
        
        private static global::System.Resources.ResourceManager resourceMan;
        
        private static global::System.Globalization.CultureInfo resourceCulture;
        
        [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
        internal Resources() {
        }
        
        /// <summary>
        ///   Returns the cached ResourceManager instance used by this class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Resources.ResourceManager ResourceManager {
            get {
                if (object.ReferenceEquals(resourceMan, null)) {
                    global::System.Resources.ResourceManager temp = new global::System.Resources.ResourceManager("MarkDoc.Members.Dnlib.Properties.Resources", typeof(Resources).Assembly);
                    resourceMan = temp;
                }
                return resourceMan;
            }
        }
        
        /// <summary>
        ///   Overrides the current thread's CurrentUICulture property for all
        ///   resource lookups using this strongly typed resource class.
        /// </summary>
        [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
        internal static global::System.Globalization.CultureInfo Culture {
            get {
                return resourceCulture;
            }
            set {
                resourceCulture = value;
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Resolved accessor was null.
        /// </summary>
        internal static string accessorNull {
            get {
                return ResourceManager.GetString("accessorNull", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid property accessor type.
        /// </summary>
        internal static string accessorTypeInvalid {
            get {
                return ResourceManager.GetString("accessorTypeInvalid", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Linking types before they are resolved and if none are resolved is not possible..
        /// </summary>
        internal static string linkBeforeAllResolvedForbidden {
            get {
                return ResourceManager.GetString("linkBeforeAllResolvedForbidden", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type is not generic.
        /// </summary>
        internal static string notGeneric {
            get {
                return ResourceManager.GetString("notGeneric", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Member is not a property.
        /// </summary>
        internal static string notProperty {
            get {
                return ResourceManager.GetString("notProperty", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Type is not tuple.
        /// </summary>
        internal static string notTuple {
            get {
                return ResourceManager.GetString("notTuple", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Previously resolved types have been materialized. Cannot resolve more types..
        /// </summary>
        internal static string resolveAfterMaterializeForbidden {
            get {
                return ResourceManager.GetString("resolveAfterMaterializeForbidden", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to The provided object for resolution is of an unsupported type. Please verify whether this component is compatible..
        /// </summary>
        internal static string sourceNotTypeSignature {
            get {
                return ResourceManager.GetString("sourceNotTypeSignature", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Subject not supported.
        /// </summary>
        internal static string subjectNotSupported {
            get {
                return ResourceManager.GetString("subjectNotSupported", resourceCulture);
            }
        }
        
        /// <summary>
        ///   Looks up a localized string similar to Invalid variance attribute value.
        /// </summary>
        internal static string varianceInvalid {
            get {
                return ResourceManager.GetString("varianceInvalid", resourceCulture);
            }
        }
    }
}
