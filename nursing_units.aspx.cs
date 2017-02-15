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


public partial class nursing_units : System.Web.UI.Page
{
    /// <summary>
    /// Gets the query string from the URL for the required nursing units.
    /// Opens the connection with the CHDB database and selects the required information that will be imported into the data chart.
    /// Will also send the query string information for patients.
    /// </summary>
    /// <param name="sender">Page</param>
    /// <param name="e">Event data</param>
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            string floor = Request.QueryString.ToString();
            if (floor.IndexOf("=") != -1)
            {
                floor = floor.Substring(floor.IndexOf("=") + 1);

                if (floor.IndexOf("%2f") != -1)
                {
                    floor = floor.Replace("%2f", "/");
                }

                if (floor.IndexOf("+") != -1)
                {
                    floor = floor.Replace("+", " ");
                }
            }

            if (floor == "1")
            {
                // Add title
                Chart1.Titles.Add("Number of Current Patients on 1st Floor");
                Chart1.Titles[1].Font = new Font("SansSerif", 20, FontStyle.Bold);
            }
            else if(floor == "2")
            {
                // Add title
                Chart1.Titles.Add("Number of Current Patients on 2nd Floor");
                Chart1.Titles[1].Font = new Font("SansSerif", 20, FontStyle.Bold);
            }
            else
            {
                // Add title
                Chart1.Titles.Add("Number of Current Patients on 3rd Floor");
                Chart1.Titles[1].Font = new Font("SansSerif", 20, FontStyle.Bold);
            }
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
                    cmd.CommandText = "SELECT NursingUnitID, COUNT(*) AS Patients FROM Admissions WHERE SUBSTRING(NursingUnitID, 1, 1) IN('" + floor + "') AND DischargeDate IS NULL GROUP BY NursingUnitID";
                    SqlDataReader reader = cmd.ExecuteReader();

                    // Rename series1
                    Chart1.Series["Series1"].Name = "Floor";

                    // Bind chart to data source
                    // reader = data source
                    // Category = The name of the column that will supply the X-values for the data points
                    // Sales = Name of the field for Y values
                    Chart1.Series["Floor"].Points.DataBindXY(reader, "NursingUnitID", reader, "Patients");

                    // Set series preview and drill down
                    foreach (Series series in Chart1.Series)
                    {
                        for (int pointIndex = 0; pointIndex < series.Points.Count; pointIndex++)
                        {
                            series.Points[pointIndex].Url = "patients.aspx?category=" + series.Points[pointIndex].AxisLabel;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                lblError.Text = ex.Message;
            }
        }
    }

    protected void Chart1_Load1(object sender, EventArgs e)
    {

    }
}

