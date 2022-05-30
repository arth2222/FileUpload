using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUpload
{
    public partial class Upload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

       

        protected void ButtonUpload_Click(object sender, EventArgs e)
        {
            //Find the path to the Images folder
            string imagesPath = Server.MapPath("~/images");
            //saving the file
            FileUpload1.SaveAs(imagesPath + "\\" + FileUpload1.FileName);
            
            //set label text after upload
        }


        

        
    }
}