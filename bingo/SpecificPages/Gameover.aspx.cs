using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace bingo.SpecificPages
{
    public partial class gameover : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            #region Variables
            string sScore = "";
            int nScore = 0;
            #endregion Variables


            if (!IsPostBack)
            {
                sScore = Request.QueryString["score"];

                if (!string.IsNullOrWhiteSpace(sScore)) {
                    bool bScore = int.TryParse(sScore, out nScore);
                }
                else
                {
                    nScore = 0;
                }

                DisplayBadge(nScore);
                Score.Text = nScore.ToString();
            }
        }

        /* 
         * Takes int parameter Score      
         * Displays corresponding badge image and text acccording to scrore conditions
         */
        public void DisplayBadge(int pScore)
        {
            if (pScore >= 80)
            {
                TxtCongrats.InnerHtml = "<h3>Awesome, you are a Tarantino expert!</h3><br/><h4>This golden cup is just for you! </h4>";
                BadgeImg.ImageUrl = "/Images/cup_gold.png";
            }
            else if (pScore > 50 && pScore < 80)
            {
                TxtCongrats.InnerHtml = "<h3>Great, you are almost a champion! </h3><br/><h4> And you win Silver Cup</h4>";
                BadgeImg.ImageUrl = "/Images/cup_silver.png";
                BadgeImgCont.Attributes.Add("style", "background-color: #e6cf8b");
            } else
            {
                TxtCongrats.InnerHtml = "<h3>May we offer you a cup of coffee? </h3><br/><h4>To enjoy your next film break </h4>";
                BadgeImg.ImageUrl = "/Images/cup_coffee.png";
                BadgeImgCont.Attributes.Add("style", "padding: 15px 0px 0px 20px");
            }
        }


        /* 
         * Allows to strat a new game     
         * Redirects to Home page
         */
        public void BtnPlayClicked(object sender, EventArgs args)
        {
            Response.Redirect("Home.aspx");
        }
    }
}