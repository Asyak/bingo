using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bingo.SpecificPages
{
    public partial class Error : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        /* 
         * Allows to reset the page in case of an error       
         * Redirects to Home Page
         */
        public void BtnResetClicked(object sender, EventArgs args)
        {
            Response.Redirect("Home.aspx");
        }
    }
}