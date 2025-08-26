using Hackathon2.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hackathon2.Hackathon2
{
    public partial class Searchword : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnSerach_Click(object sender, EventArgs e)
        {
            string word =txtWord.Text.Trim();
            if (Word_dict.WordExists(word))
            {
                Response.Redirect($"AddWord.aspx?word={word}");

            }
            else
            {
                Response.Redirect($"ErrorPage.aspx?word={word}");
            }
        }
    }
}