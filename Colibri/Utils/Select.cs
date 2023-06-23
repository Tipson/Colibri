using Microsoft.AspNetCore.Mvc.Localization;
using Synopsis.Models;

namespace Colibri.Utils;

public class Select
{
    
    public static Dictionary<string, dynamic> GetSpeakersTable(IViewLocalizer viewLocalizer, string listPath = "_speakerList")
     {
         Dictionary<string, dynamic> tableElem = new Dictionary<string, dynamic>();
         TableColumn[] columns = new TableColumn[] {
             new TableColumn { caption= viewLocalizer["Name"].Value, id = "name", sort_by = "s_name", procent=25},
             new TableColumn { caption= viewLocalizer["Position"].Value, id = "position", sort_by = "s_position", procent=25},
             new TableColumn { caption= viewLocalizer["Type"].Value, id = "type", sort_by = "s_type", procent=25},
             new TableColumn { caption= "", id = "", sort_by = "", procent=25},
         };
         tableElem["Columns"] = columns;
         tableElem["List"] = listPath;
         tableElem["PageSize"] = 3000;
         tableElem["TableClass"] = "";
         return tableElem;
     }
    
     public static Dictionary<string, dynamic> GetPartnersTable(IViewLocalizer viewLocalizer, string listPath = "_partnerList")
     {
         Dictionary<string, dynamic> tableElem = new Dictionary<string, dynamic>();
         TableColumn[] columns = new TableColumn[] {
             new TableColumn { caption= viewLocalizer["Name"].Value, id = "name", sort_by = "p_name", procent=50},
             new TableColumn { caption= viewLocalizer["Type"].Value, id = "type", sort_by = "p_type", procent=25},
             new TableColumn { caption= "", id = "", sort_by = "", procent=25},
         };
         tableElem["Columns"] = columns;
         tableElem["List"] = listPath;
         tableElem["PageSize"] = 3000;
         tableElem["TableClass"] = "";
         return tableElem;
    }

     public static Dictionary<string, dynamic> GetAgendasTable(IViewLocalizer viewLocalizer, string listPath = "_agendaList")
     {
         Dictionary<string, dynamic> tableElem = new Dictionary<string, dynamic>();
         TableColumn[] columns = new TableColumn[] {
             new TableColumn { caption= viewLocalizer["SpeakersName"].Value, id = "name", sort_by = "p_name", procent=60},
             new TableColumn { caption= viewLocalizer["Topics"].Value, id = "type", sort_by = "p_type", procent=20},
             new TableColumn { caption= viewLocalizer["TimeStart"].Value, id = "type", sort_by = "p_type", procent=10},
             new TableColumn { caption= viewLocalizer["TimeEnd"].Value, id = "type", sort_by = "p_type", procent=10},

         };
         tableElem["Columns"] = columns;
         tableElem["List"] = listPath;
         tableElem["PageSize"] = 3000;
         tableElem["TableClass"] = "";
         return tableElem;
     }
     
     public static Dictionary<string, dynamic> GetSponsorPacksTable(IViewLocalizer viewLocalizer, string listPath = "_sponsorPackList")
     {
         Dictionary<string, dynamic> tableElem = new Dictionary<string, dynamic>();
         TableColumn[] columns = new TableColumn[] {
             new TableColumn { caption= viewLocalizer["Name"].Value, id = "name", sort_by = "p_name", procent=25},
             new TableColumn { caption= viewLocalizer["Description"].Value, id = "type", sort_by = "p_type", procent=20},
             new TableColumn { caption= viewLocalizer["Total Stand"].Value, id = "type", sort_by = "p_type", procent=15},
             new TableColumn { caption= viewLocalizer["Reserved Stand"].Value, id = "type", sort_by = "p_type", procent=15},


             new TableColumn { caption= "", id = "", sort_by = "", procent=25},
         };
         tableElem["Columns"] = columns;
         tableElem["List"] = listPath;
         tableElem["PageSize"] = 3000;
         tableElem["TableClass"] = "";
         return tableElem;
     }
     
     public static Dictionary<string, dynamic> GetLocationsTable(IViewLocalizer viewLocalizer, string listPath = "_locationList")
     {
         Dictionary<string, dynamic> tableElem = new Dictionary<string, dynamic>();
         TableColumn[] columns = new TableColumn[] {
             new TableColumn { caption= viewLocalizer["Name"].Value, id = "name", sort_by = "p_name", procent=25},
             new TableColumn { caption= viewLocalizer["X"].Value, id = "type", sort_by = "p_type", procent=25},
             new TableColumn { caption= viewLocalizer["Y"].Value, id = "type", sort_by = "p_type", procent=25},
             new TableColumn { caption= viewLocalizer["Partner"].Value, id = "type", sort_by = "p_type", procent=25},


             new TableColumn { caption= "", id = "", sort_by = "", procent=25},
         };
         tableElem["Columns"] = columns;
         tableElem["List"] = listPath;
         tableElem["PageSize"] = 3000;
         tableElem["TableClass"] = "";
         return tableElem;
     }
}
