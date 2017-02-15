// I, Bobby FIlippopoulos, student number 000338236, certify that this material is my
// original work. No other person's work has been used without due
// acknowledgement and I have not made my work available to anyone else.

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Configuration; // Added for WebConfigurationManager
using System.Data.SqlClient; // Added for SqlConnection, SqlCommand and SqlDataReader
using System.Data; // Added for SqlDbType
using System.Drawing;
using System.Web.UI.DataVisualization.Charting; // Added for Chart classes

public partial class patients : System.Web.UI.Page
{
    /// <summary>
    /// Will gather the current patients for the selecting nursing unit. Will get the nursing unit from the url query string.
    /// </summary>
    /// <param name="sender">Page</param>
    /// <param name="e">Event data</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string NursingUnitID = Request.QueryString.ToString();
            if (NursingUnitID.IndexOf("=") != -1)
            {
                NursingUnitID = NursingUnitID.Substring(NursingUnitID.IndexOf("=") + 1);

                if (NursingUnitID.IndexOf("%2f") != -1)
                {
                    NursingUnitID = NursingUnitID.Replace("%2f", "/");
                }

                if (NursingUnitID.IndexOf("+") != -1)
                {
                    NursingUnitID = NursingUnitID.Replace("+", " ");
                }
            }
            
            Label1.Text = NursingUnitID;


            
        }
    }

    protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
    {

    }
}

