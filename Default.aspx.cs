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

/*
 1. Run the Default.aspx on internet explorer.
 2. Select the first drill down (bar 1)
 3. You will be directed to The nursing units age
 4. Select the first drill down (1NORTH)
 5. Return to the main page
 6. Select the second drill down (bar 2)
 7. Select the first drill down (2EAST)
 8. Return to the main page
 9. Select the third drill down (bar 3)
 10. Select the first drill down (3EAST)
 11. Return to the main page
 
 */
public partial class _Default : System.Web.UI.Page
{
    /// <summary>
    /// Opens the connection with the CHDB database and selects the required information that will be imported into the data chart.
    /// Will also send the query string information for nursing units.
    /// </summary>
    /// <param name="sender">Page</param>
    /// <param name="e">Event data</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        //create the connection string
        String con_string = WebConfigurationManager.ConnectionStrings["CHDBConnectionString"].ConnectionString;

        //open connection with con_string
        SqlConnection con = new SqlConnection(con_string);

        //create the sql command for read
        SqlCommand cmd = new SqlCommand();

        cmd.Connection = con;

       
         try
            {
                using (con)
                {
                    con.Open();
                    cmd.CommandText = "SELECT SUBSTRING(NursingUnitID, 1, 1) AS Floor, COUNT(*) AS Patients FROM Admissions WHERE SUBSTRING(NursingUnitID, 1, 1) IN ('1', '2', '3') AND DischargeDate IS NULL GROUP BY SUBSTRING(NursingUnitID, 1, 1)";
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Rename series1
                    Chart1.Series["Series1"].Name = "Floor";

                    // Bind chart to data source
                    // reader = data source
                    // Category = The name of the column that will supply the X-values for the data points
                    // Sales = Name of the field for Y values
                    Chart1.Series["Floor"].Points.DataBindXY(reader, "Floor", reader, "Patients");

                    // Set series preview and drill down
                    foreach (Series series in Chart1.Series)
                    {
                        for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                        {
                            series.Points[pointIndex].Url = "nursing_units.aspx?category=" + series.Points[pointIndex].AxisLabel;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
    }

    protected void Chart1_Load(object sender, EventArgs e)
    {

    }
}

