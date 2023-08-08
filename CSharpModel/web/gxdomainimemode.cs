using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Data;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using System.Runtime.Remoting;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Xml.Serialization;
using System.Data.SqlTypes;
namespace GeneXus.Programs {
   public class gxdomainimemode
   {
      private static Hashtable domain = new Hashtable();
      static gxdomainimemode ()
      {
         domain["hiragana"] = "Hiragana";
         domain["full width katakana"] = "FullWidthKatakana";
         domain["full width alphanumeric"] = "FullWidthAlphanumeric";
         domain["half width katakana"] = "HalfWidthKatakana";
         domain["half width alphanumeric"] = "HalfWidthAlphanumeric";
         domain["disabled"] = "Disabled";
         domain["inactive"] = "Inactive";
      }

      public static string getDescription( String key )
      {
         return (string)domain[key];
      }

      public static GxSimpleCollection getValues( )
      {
         GxSimpleCollection value = new GxSimpleCollection();
         ArrayList aKeys = new ArrayList(domain.Keys);
         aKeys.Sort();
         foreach (String key in aKeys)
         {
            value.Add(key);
         }
         return value;
      }

   }

}
