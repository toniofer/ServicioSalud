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
using System.Reflection;
using System.Xml.Serialization;
using System.Data.SqlTypes;
namespace GeneXus.Programs {
   [Serializable]
   public class SdtTreeNodeCollection_TreeNode : GxUserType
   {
      public SdtTreeNodeCollection_TreeNode( )
      {
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public SdtTreeNodeCollection_TreeNode( IGxContext context )
      {
         this.context = context;
         constructorCallingAssembly = Assembly.GetCallingAssembly() ;
         initialize();
      }

      public override short readxml( GXXMLReader oReader ,
                                     String sName )
      {
         short GXSoapError = 1 ;
         sTagName = oReader.Name ;
         if ( oReader.IsSimple == 0 )
         {
            GXSoapError = oReader.Read() ;
            nOutParmCount = 0 ;
            while ( ( ( StringUtil.StrCmp(oReader.Name, sTagName) != 0 ) || ( oReader.NodeType == 1 ) ) && ( GXSoapError > 0 ) )
            {
               readOk = 0 ;
               if ( StringUtil.StrCmp(oReader.LocalName, "Id") == 0 )
               {
                  gxTv_SdtTreeNodeCollection_TreeNode_Id = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Name") == 0 )
               {
                  gxTv_SdtTreeNodeCollection_TreeNode_Name = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Link") == 0 )
               {
                  gxTv_SdtTreeNodeCollection_TreeNode_Link = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "LinkTarget") == 0 )
               {
                  gxTv_SdtTreeNodeCollection_TreeNode_Linktarget = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Expanded") == 0 )
               {
                  gxTv_SdtTreeNodeCollection_TreeNode_Expanded = (bool)(Convert.ToBoolean(((StringUtil.StrCmp(oReader.Value, "true")==0)||(StringUtil.StrCmp(oReader.Value, "1")==0) ? 1 : 0))) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "DynamicLoad") == 0 )
               {
                  gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload = (bool)(Convert.ToBoolean(((StringUtil.StrCmp(oReader.Value, "true")==0)||(StringUtil.StrCmp(oReader.Value, "1")==0) ? 1 : 0))) ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Icon") == 0 )
               {
                  gxTv_SdtTreeNodeCollection_TreeNode_Icon = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "IconWhenSelected") == 0 )
               {
                  gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected = oReader.Value ;
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               if ( StringUtil.StrCmp(oReader.LocalName, "Nodes") == 0 )
               {
                  if ( gxTv_SdtTreeNodeCollection_TreeNode_Nodes == null )
                  {
                     gxTv_SdtTreeNodeCollection_TreeNode_Nodes = new GxObjectCollection( context, "TreeNodeCollection.TreeNode", "taller041", "SdtTreeNodeCollection_TreeNode", "GeneXus.Programs");
                  }
                  if ( ( oReader.IsSimple == 0 ) || ( oReader.AttributeCount > 0 ) )
                  {
                     GXSoapError = gxTv_SdtTreeNodeCollection_TreeNode_Nodes.readxml(oReader, "Nodes") ;
                  }
                  if ( GXSoapError > 0 )
                  {
                     readOk = 1 ;
                  }
                  GXSoapError = oReader.Read() ;
               }
               nOutParmCount = (short)(nOutParmCount+1) ;
               if ( readOk == 0 )
               {
                  context.sSOAPErrMsg = context.sSOAPErrMsg + "Error reading " + sTagName + StringUtil.NewLine( ) ;
                  GXSoapError = (short)(nOutParmCount*-1) ;
               }
            }
         }
         return GXSoapError ;
      }

      public override void writexml( GXXMLWriter oWriter ,
                                     String sName ,
                                     String sNameSpace )
      {
         if ( String.IsNullOrEmpty(StringUtil.RTrim( sName)) )
         {
            sName = "TreeNodeCollection.TreeNode" ;
         }
         if ( String.IsNullOrEmpty(StringUtil.RTrim( sNameSpace)) )
         {
            sNameSpace = "taller041" ;
         }
         oWriter.WriteStartElement(sName);
         if ( StringUtil.StrCmp(StringUtil.Left( sNameSpace, 10), "[*:nosend]") != 0 )
         {
            oWriter.WriteAttribute("xmlns", sNameSpace);
         }
         else
         {
            sNameSpace = StringUtil.Right( sNameSpace, (short)(StringUtil.Len( sNameSpace)-10)) ;
         }
         oWriter.WriteElement("Id", StringUtil.RTrim( gxTv_SdtTreeNodeCollection_TreeNode_Id));
         oWriter.WriteElement("Name", StringUtil.RTrim( gxTv_SdtTreeNodeCollection_TreeNode_Name));
         oWriter.WriteElement("Link", StringUtil.RTrim( gxTv_SdtTreeNodeCollection_TreeNode_Link));
         oWriter.WriteElement("LinkTarget", StringUtil.RTrim( gxTv_SdtTreeNodeCollection_TreeNode_Linktarget));
         oWriter.WriteElement("Expanded", StringUtil.RTrim( StringUtil.BoolToStr( gxTv_SdtTreeNodeCollection_TreeNode_Expanded)));
         oWriter.WriteElement("DynamicLoad", StringUtil.RTrim( StringUtil.BoolToStr( gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload)));
         oWriter.WriteElement("Icon", StringUtil.RTrim( gxTv_SdtTreeNodeCollection_TreeNode_Icon));
         oWriter.WriteElement("IconWhenSelected", StringUtil.RTrim( gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected));
         if ( gxTv_SdtTreeNodeCollection_TreeNode_Nodes != null )
         {
            String sNameSpace1 ;
            if ( StringUtil.StrCmp(sNameSpace, "taller041") == 0 )
            {
               sNameSpace1 = "[*:nosend]" + "taller041" ;
            }
            else
            {
               sNameSpace1 = "taller041" ;
            }
            gxTv_SdtTreeNodeCollection_TreeNode_Nodes.writexml(oWriter, "Nodes", sNameSpace1);
         }
         oWriter.WriteEndElement();
         return  ;
      }

      public override void ToJSON( )
      {
         AddObjectProperty("Id", (Object)(gxTv_SdtTreeNodeCollection_TreeNode_Id));
         AddObjectProperty("Name", (Object)(gxTv_SdtTreeNodeCollection_TreeNode_Name));
         AddObjectProperty("Link", (Object)(gxTv_SdtTreeNodeCollection_TreeNode_Link));
         AddObjectProperty("LinkTarget", (Object)(gxTv_SdtTreeNodeCollection_TreeNode_Linktarget));
         AddObjectProperty("Expanded", (Object)(gxTv_SdtTreeNodeCollection_TreeNode_Expanded));
         AddObjectProperty("DynamicLoad", (Object)(gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload));
         AddObjectProperty("Icon", (Object)(gxTv_SdtTreeNodeCollection_TreeNode_Icon));
         AddObjectProperty("IconWhenSelected", (Object)(gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected));
         if ( gxTv_SdtTreeNodeCollection_TreeNode_Nodes != null )
         {
            AddObjectProperty("Nodes", (Object)(gxTv_SdtTreeNodeCollection_TreeNode_Nodes));
         }
         return  ;
      }

      public String gxTpr_Id
      {
         get {
            return gxTv_SdtTreeNodeCollection_TreeNode_Id ;
         }

         set {
            gxTv_SdtTreeNodeCollection_TreeNode_Id = (String)(value) ;
         }

      }

      public void gxTv_SdtTreeNodeCollection_TreeNode_Id_SetNull( )
      {
         gxTv_SdtTreeNodeCollection_TreeNode_Id = "" ;
         return  ;
      }

      public bool gxTv_SdtTreeNodeCollection_TreeNode_Id_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Name
      {
         get {
            return gxTv_SdtTreeNodeCollection_TreeNode_Name ;
         }

         set {
            gxTv_SdtTreeNodeCollection_TreeNode_Name = (String)(value) ;
         }

      }

      public void gxTv_SdtTreeNodeCollection_TreeNode_Name_SetNull( )
      {
         gxTv_SdtTreeNodeCollection_TreeNode_Name = "" ;
         return  ;
      }

      public bool gxTv_SdtTreeNodeCollection_TreeNode_Name_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Link
      {
         get {
            return gxTv_SdtTreeNodeCollection_TreeNode_Link ;
         }

         set {
            gxTv_SdtTreeNodeCollection_TreeNode_Link = (String)(value) ;
         }

      }

      public void gxTv_SdtTreeNodeCollection_TreeNode_Link_SetNull( )
      {
         gxTv_SdtTreeNodeCollection_TreeNode_Link = "" ;
         return  ;
      }

      public bool gxTv_SdtTreeNodeCollection_TreeNode_Link_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Linktarget
      {
         get {
            return gxTv_SdtTreeNodeCollection_TreeNode_Linktarget ;
         }

         set {
            gxTv_SdtTreeNodeCollection_TreeNode_Linktarget = (String)(value) ;
         }

      }

      public void gxTv_SdtTreeNodeCollection_TreeNode_Linktarget_SetNull( )
      {
         gxTv_SdtTreeNodeCollection_TreeNode_Linktarget = "" ;
         return  ;
      }

      public bool gxTv_SdtTreeNodeCollection_TreeNode_Linktarget_IsNull( )
      {
         return false ;
      }

      public bool gxTpr_Expanded
      {
         get {
            return gxTv_SdtTreeNodeCollection_TreeNode_Expanded ;
         }

         set {
            gxTv_SdtTreeNodeCollection_TreeNode_Expanded = value ;
         }

      }

      public void gxTv_SdtTreeNodeCollection_TreeNode_Expanded_SetNull( )
      {
         gxTv_SdtTreeNodeCollection_TreeNode_Expanded = false ;
         return  ;
      }

      public bool gxTv_SdtTreeNodeCollection_TreeNode_Expanded_IsNull( )
      {
         return false ;
      }

      public bool gxTpr_Dynamicload
      {
         get {
            return gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload ;
         }

         set {
            gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload = value ;
         }

      }

      public void gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload_SetNull( )
      {
         gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload = false ;
         return  ;
      }

      public bool gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Icon
      {
         get {
            return gxTv_SdtTreeNodeCollection_TreeNode_Icon ;
         }

         set {
            gxTv_SdtTreeNodeCollection_TreeNode_Icon = (String)(value) ;
         }

      }

      public void gxTv_SdtTreeNodeCollection_TreeNode_Icon_SetNull( )
      {
         gxTv_SdtTreeNodeCollection_TreeNode_Icon = "" ;
         return  ;
      }

      public bool gxTv_SdtTreeNodeCollection_TreeNode_Icon_IsNull( )
      {
         return false ;
      }

      public String gxTpr_Iconwhenselected
      {
         get {
            return gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected ;
         }

         set {
            gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected = (String)(value) ;
         }

      }

      public void gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected_SetNull( )
      {
         gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected = "" ;
         return  ;
      }

      public bool gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected_IsNull( )
      {
         return false ;
      }

      public IGxCollection gxTpr_Nodes
      {
         get {
            if ( gxTv_SdtTreeNodeCollection_TreeNode_Nodes == null )
            {
               gxTv_SdtTreeNodeCollection_TreeNode_Nodes = new GxObjectCollection( context, "TreeNodeCollection.TreeNode", "taller041", "SdtTreeNodeCollection_TreeNode", "GeneXus.Programs");
            }
            return gxTv_SdtTreeNodeCollection_TreeNode_Nodes ;
         }

         set {
            gxTv_SdtTreeNodeCollection_TreeNode_Nodes = value ;
         }

      }

      public void gxTv_SdtTreeNodeCollection_TreeNode_Nodes_SetNull( )
      {
         gxTv_SdtTreeNodeCollection_TreeNode_Nodes = null ;
         return  ;
      }

      public bool gxTv_SdtTreeNodeCollection_TreeNode_Nodes_IsNull( )
      {
         if ( gxTv_SdtTreeNodeCollection_TreeNode_Nodes == null )
         {
            return true ;
         }
         return false ;
      }

      public void initialize( )
      {
         gxTv_SdtTreeNodeCollection_TreeNode_Id = "" ;
         gxTv_SdtTreeNodeCollection_TreeNode_Name = "" ;
         gxTv_SdtTreeNodeCollection_TreeNode_Link = "" ;
         gxTv_SdtTreeNodeCollection_TreeNode_Linktarget = "" ;
         gxTv_SdtTreeNodeCollection_TreeNode_Icon = "" ;
         gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected = "" ;
         sTagName = "" ;
         return  ;
      }

      protected short readOk ;
      protected short nOutParmCount ;
      protected String gxTv_SdtTreeNodeCollection_TreeNode_Id ;
      protected String gxTv_SdtTreeNodeCollection_TreeNode_Name ;
      protected String gxTv_SdtTreeNodeCollection_TreeNode_Link ;
      protected String gxTv_SdtTreeNodeCollection_TreeNode_Linktarget ;
      protected String gxTv_SdtTreeNodeCollection_TreeNode_Icon ;
      protected String gxTv_SdtTreeNodeCollection_TreeNode_Iconwhenselected ;
      protected String sTagName ;
      protected bool gxTv_SdtTreeNodeCollection_TreeNode_Expanded ;
      protected bool gxTv_SdtTreeNodeCollection_TreeNode_Dynamicload ;
      protected Assembly constructorCallingAssembly ;
      protected IGxContext context ;
      protected IGxCollection gxTv_SdtTreeNodeCollection_TreeNode_Nodes=null ;
   }

}
