using Hackathon2.AppCode;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Hackathon2.Hackathon2
{
    public partial class MyWords : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            gvWords.DataSource = Word_dict.getWords().Select(x => new { Word = x.Key, Translation = x.Value }).ToList();
            gvWords.DataBind();

        }
    }
}