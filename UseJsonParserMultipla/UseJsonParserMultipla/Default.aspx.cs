using System;
using System.Collections.Generic;
using System.Data;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UseJsonParserMultipla
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void btn_convert_1_Click(object sender, EventArgs e)
        {
            string JsonStr = "{\"id\":\"1\",\"name\":\"Jack\",\"age\":\"36\"}";

            JsonParser.JParser JP = new JsonParser.JParser();
            DataTable dt = JP.JsonConvert(JsonStr);
        }
    }
}