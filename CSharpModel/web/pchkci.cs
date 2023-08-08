/*
               File: PChkCI
        Description: Check digit Uruguay - C.I.
             Author: GeneXus C# Generator version 10_1_3-34981
       Generated on: 11/22/2010 4:1:11.60
       Program type: Callable routine
          Main DBMS: sqlserver
*/
using System;
using System.Collections;
using GeneXus.Utils;
using GeneXus.Resources;
using GeneXus.Application;
using GeneXus.Metadata;
using GeneXus.Data;
using com.genexus;
using GeneXus.Data.ADO;
using GeneXus.Data.NTier;
using GeneXus.Data.NTier.ADO;
using System.Runtime.Remoting;
using GeneXus.WebControls;
using GeneXus.Http;
using GeneXus.Procedure;
using GeneXus.XML;
using GeneXus.Search;
using GeneXus.Encryption;
using GeneXus.Http.Client;
using System.Threading;
using System.Xml.Serialization;
using System.Data.SqlTypes;
namespace GeneXus.Programs {
   public class pchkci : GXProcedure
   {
      public pchkci( )
      {
         context = new GxContext(  );
         DataStoreUtil.LoadDataStores( context);
         IsMain = true;
         context.SetTheme("GeneXusX");
      }

      public pchkci( IGxContext context )
      {
         this.context = context;
         IsMain = false;
      }

      public void release( )
      {
      }

      public void execute( ref String aP0_VDocNro ,
                           ref String aP1_CDOK )
      {
         this.AV8VDocNro = aP0_VDocNro;
         this.AV9CDOK = aP1_CDOK;
         initialize();
         executePrivate();
         aP0_VDocNro=this.AV8VDocNro;
         aP1_CDOK=this.AV9CDOK;
      }

      public String executeUdp( ref String aP0_VDocNro )
      {
         this.AV8VDocNro = aP0_VDocNro;
         this.AV9CDOK = aP1_CDOK;
         initialize();
         executePrivate();
         aP0_VDocNro=this.AV8VDocNro;
         aP1_CDOK=this.AV9CDOK;
         return AV9CDOK ;
      }

      public void executeSubmit( ref String aP0_VDocNro ,
                                 ref String aP1_CDOK )
      {
         pchkci objpchkci;
         objpchkci = new pchkci();
         objpchkci.AV8VDocNro = aP0_VDocNro;
         objpchkci.AV9CDOK = aP1_CDOK;
         objpchkci.initialize();
         ThreadPool.QueueUserWorkItem( new WaitCallback( objpchkci.executePrivateCatch ));
         aP0_VDocNro=this.AV8VDocNro;
         aP1_CDOK=this.AV9CDOK;
      }

      void executePrivateCatch( object stateInfo )
      {
         try
         {
            executePrivate();
         }
         catch ( Exception e )
         {
            GXUtil.SaveToEventLog( "Design", e);
            throw e ;
         }
      }

      void executePrivate( )
      {
         /* GeneXus formulas */
         /* Output device settings */
         if ( ( NumberUtil.Val( AV8VDocNro, ".") > Convert.ToDecimal( 99999999 )) )
         {
            AV9CDOK = "N" ;
            this.cleanup();
            if (true) return;
         }
         AV10StrDocNro = StringUtil.Substring( AV8VDocNro, 1, 8) ;
         AV15Nro = (int)(NumberUtil.Val( AV10StrDocNro, ".")) ;
         if ( AV15Nro <= 9999999 )
         {
            AV10StrDocNro = StringUtil.Concat( "0", AV10StrDocNro, "") ;
         }
         else
         {
            if ( AV15Nro <= 999999 )
            {
               AV10StrDocNro = StringUtil.Concat( "00", AV10StrDocNro, "") ;
            }
         }
         AV12Suma = (short)(NumberUtil.Val( StringUtil.Substring( AV10StrDocNro, 1, 1), ".")*2) ;
         AV12Suma = (short)(AV12Suma+NumberUtil.Val( StringUtil.Substring( AV10StrDocNro, 2, 1), ".")*9) ;
         AV12Suma = (short)(AV12Suma+NumberUtil.Val( StringUtil.Substring( AV10StrDocNro, 3, 1), ".")*8) ;
         AV12Suma = (short)(AV12Suma+NumberUtil.Val( StringUtil.Substring( AV10StrDocNro, 4, 1), ".")*7) ;
         AV12Suma = (short)(AV12Suma+NumberUtil.Val( StringUtil.Substring( AV10StrDocNro, 5, 1), ".")*6) ;
         AV12Suma = (short)(AV12Suma+NumberUtil.Val( StringUtil.Substring( AV10StrDocNro, 6, 1), ".")*3) ;
         AV12Suma = (short)(AV12Suma+NumberUtil.Val( StringUtil.Substring( AV10StrDocNro, 7, 1), ".")*4) ;
         AV13Cociente = (short)(NumberUtil.Int( (long)(AV12Suma/ (decimal)(10)))) ;
         AV14Resto = (short)(AV12Suma-(AV13Cociente*10)) ;
         if ( AV14Resto != 0 )
         {
            AV11Xdig = (short)(10-AV14Resto) ;
         }
         else
         {
            AV11Xdig = AV14Resto ;
         }
         AV9CDOK = "N" ;
         if ( (Convert.ToDecimal( AV11Xdig ) == NumberUtil.Val( StringUtil.Substring( AV10StrDocNro, 8, 1), ".") ) && ( NumberUtil.Val( StringUtil.Substring( AV8VDocNro, 1, 8), ".") != Convert.ToDecimal( 11111111 )) && ( NumberUtil.Val( StringUtil.Substring( AV8VDocNro, 1, 8), ".") != Convert.ToDecimal( 22222222 )) && ( NumberUtil.Val( StringUtil.Substring( AV8VDocNro, 1, 8), ".") != Convert.ToDecimal( 33333333 )) && ( NumberUtil.Val( StringUtil.Substring( AV8VDocNro, 1, 8), ".") != Convert.ToDecimal( 44444444 )) )
         {
            if ( ( NumberUtil.Val( StringUtil.Substring( AV8VDocNro, 1, 8), ".") < Convert.ToDecimal( 50000000 )) && ( NumberUtil.Val( StringUtil.Substring( AV8VDocNro, 1, 8), ".") != Convert.ToDecimal( 0 )) )
            {
               AV9CDOK = "S" ;
            }
         }
         this.cleanup();
      }

      protected void cleanup( )
      {
         CloseOpenCursors();
         if ( IsMain )
         {
            context.CloseConnections() ;
         }
         exitApplication();
      }

      protected void CloseOpenCursors( )
      {
      }

      public override void initialize( )
      {
         AV10StrDocNro = "" ;
         /* GeneXus formulas. */
         context.Gx_err = 0 ;
      }

      private short AV12Suma ;
      private short AV13Cociente ;
      private short AV14Resto ;
      private short AV11Xdig ;
      private int AV15Nro ;
      private String AV8VDocNro ;
      private String AV9CDOK ;
      private String AV10StrDocNro ;
      private String aP0_VDocNro ;
      private String aP1_CDOK ;
   }

}
