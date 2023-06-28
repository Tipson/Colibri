using Colibri.Models;
using Microsoft.AspNetCore.Mvc.Localization;

namespace Colibri.Utils;

public class Select
{
    
    public static Dictionary<string, dynamic> GetPortfoliosTable(IViewLocalizer viewLocalizer, string listPath = "_portfolioList")
    {
         Dictionary<string, dynamic> tableElem = new Dictionary<string, dynamic>();
         TableColumn[] columns = new TableColumn[] {
             new TableColumn { caption= viewLocalizer["Id"].Value, id = "name", sort_by = "s_name", procent=25},
             new TableColumn { caption= viewLocalizer["BrandName"].Value, id = "position", sort_by = "s_position", procent=25},
             new TableColumn { caption= viewLocalizer["Description"].Value, id = "type", sort_by = "s_type", procent=25},
             new TableColumn { caption= "", id = "", sort_by = "", procent=25},
         };
         tableElem["Columns"] = columns;
         tableElem["List"] = listPath;
         tableElem["PageSize"] = 3000;
         tableElem["TableClass"] = "";
         return tableElem;
    }
    
     public static Dictionary<string, dynamic> GetProductsTable(IViewLocalizer viewLocalizer, string listPath = "_productList")
     {
         Dictionary<string, dynamic> tableElem = new Dictionary<string, dynamic>();
         TableColumn[] columns = new TableColumn[] {
             new TableColumn { caption= viewLocalizer["Title"].Value, id = "name", sort_by = "p_name", procent=50},
             new TableColumn { caption= viewLocalizer["Price"].Value, id = "type", sort_by = "p_type", procent=25},
             new TableColumn { caption= "", id = "", sort_by = "", procent=25},
         };
         tableElem["Columns"] = columns;
         tableElem["List"] = listPath;
         tableElem["PageSize"] = 3000;
         tableElem["TableClass"] = "";
         return tableElem;
    }
     
     public static Dictionary<string, dynamic> GetReviewsTable(IViewLocalizer viewLocalizer, string listPath = "_reviewList")
     {
         Dictionary<string, dynamic> tableElem = new Dictionary<string, dynamic>();
         TableColumn[] columns = new TableColumn[] {
             new TableColumn { caption= viewLocalizer["Name"].Value, id = "name", sort_by = "s_name", procent=25},
             new TableColumn { caption= viewLocalizer["Position"].Value, id = "position", sort_by = "s_position", procent=25},
             new TableColumn { caption= viewLocalizer["CompanyName"].Value, id = "type", sort_by = "s_type", procent=25},
             new TableColumn { caption= "", id = "", sort_by = "", procent=25},
         };
         tableElem["Columns"] = columns;
         tableElem["List"] = listPath;
         tableElem["PageSize"] = 3000;
         tableElem["TableClass"] = "";
         return tableElem;
     }

     public static Dictionary<string, dynamic> GetStatisticsTable(IViewLocalizer viewLocalizer, string listPath = "_statisticList")
     {
         Dictionary<string, dynamic> tableElem = new Dictionary<string, dynamic>();
         TableColumn[] columns = new TableColumn[] {
             new TableColumn { caption= viewLocalizer["Name"].Value, id = "name", sort_by = "s_name", procent=25},
             new TableColumn { caption= viewLocalizer["Count Followers"].Value, id = "position", sort_by = "s_position", procent=25},
             new TableColumn { caption= viewLocalizer["Count Views"].Value, id = "type", sort_by = "s_type", procent=25},
             new TableColumn { caption= "", id = "", sort_by = "", procent=25},
         };
         tableElem["Columns"] = columns;
         tableElem["List"] = listPath;
         tableElem["PageSize"] = 3000;
         tableElem["TableClass"] = "";
         return tableElem;
     }
     
     public static Dictionary<string, dynamic> GetTeamMembersTable(IViewLocalizer viewLocalizer, string listPath = "_teamMemberList")
     {
         Dictionary<string, dynamic> tableElem = new Dictionary<string, dynamic>();
         TableColumn[] columns = new TableColumn[] {
             new TableColumn { caption= viewLocalizer["Name"].Value, id = "name", sort_by = "s_name", procent=25},
             new TableColumn { caption= viewLocalizer["Position"].Value, id = "position", sort_by = "s_position", procent=25},
             new TableColumn { caption= viewLocalizer["Linkedin"].Value, id = "type", sort_by = "s_type", procent=25},
             new TableColumn { caption= "", id = "", sort_by = "", procent=25},
         };
         tableElem["Columns"] = columns;
         tableElem["List"] = listPath;
         tableElem["PageSize"] = 3000;
         tableElem["TableClass"] = "";
         return tableElem;
     }
     
}
