// Decompiled with JetBrains decompiler
// Type: MR6100Demo.Properties.Resources
// Assembly: MR6100Demo, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 1873F71C-3ADE-4CD3-9129-535384741D4F
// Assembly location: Z:\zaaferani\Desktop\book gate\MR6100Demo.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace MR6100Demo.Properties
{
  [CompilerGenerated]
  [DebuggerNonUserCode]
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  internal class Resources
  {

      private static global::System.Resources.ResourceManager resourceMan;

      private static global::System.Globalization.CultureInfo resourceCulture;

      [global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode")]
    //private static ResourceManager resourceMan;
    //private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

      /// <summary>
      ///   Returns the cached ResourceManager instance used by this class.
      /// </summary>
      [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) MR6100Demo.Properties.Resources.resourceMan, (object) null))
          MR6100Demo.Properties.Resources.resourceMan = new ResourceManager("MR6100Demo.Properties.Resources", typeof (MR6100Demo.Properties.Resources).Assembly);
        return MR6100Demo.Properties.Resources.resourceMan;
      }
    }

      /// <summary>
      ///   Overrides the current thread's CurrentUICulture property for all
      ///   resource lookups using this strongly typed resource class.
      /// </summary>
      [global::System.ComponentModel.EditorBrowsableAttribute(global::System.ComponentModel.EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get { return MR6100Demo.Properties.Resources.resourceCulture; }
      set { MR6100Demo.Properties.Resources.resourceCulture = value; }
    }

      /// <summary>
      ///   Looks up a localized resource of type System.Drawing.Bitmap.
      /// </summary>
    internal static Bitmap green { 
        get {
            return (Bitmap) MR6100Demo.Properties.Resources.ResourceManager.GetObject("green", MR6100Demo.Properties.Resources.resourceCulture);
        }
    }

    /// <summary>
    ///   Looks up a localized resource of type System.Drawing.Bitmap.
    /// </summary>
    internal static Bitmap red {
        get
        {
            return (Bitmap)MR6100Demo.Properties.Resources.ResourceManager.GetObject("red", MR6100Demo.Properties.Resources.resourceCulture);
        }
    }
  }
}
