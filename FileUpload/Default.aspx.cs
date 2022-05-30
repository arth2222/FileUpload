using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace FileUpload
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
                GetImages();
        }

        private void GetImages()
        {
            //get the path where the files are
            string imagesPath = Server.MapPath("~/images");
            var imagesFolder = new DirectoryInfo(imagesPath);

            FileInfo[] files = imagesFolder.GetFiles();//get all the files from the folder
            //we only need the file name to make an url, so we need to add "images/" in front of all the names
            List<string> urls = new List<string>();
            foreach (FileInfo f in files)
                urls.Add("images/" + f.Name);

            DataList1.DataSource = urls;
            DataList1.DataBind();
        }

        protected void DataList1_ItemCommand(object source, DataListCommandEventArgs e)
        {
            Button button = (Button)e.Item.FindControl("ButtonDelete");
            string commandName = button.CommandName;//denne inneholder nå stringen images/<fileName>, som er mer enn vi trenger. Vi trenger kun fileName. Så vi må endre stringen
            string imagesFolder = Server.MapPath("~/images");//vi finner filstien til folderen Images
            //vi må skaffe oss filnavnet uten images/ foran. Så vi trenger det som er etter /  Vi bruker da splitmetoden
            //Vi splitter ved å bruke tegnet / Da får vi en array som inneholder 2 strings. Det som er til venstre for / og det som er til høyre for /
            //Vi trenger kun den som er til høyre, som da ligger på plass 1 i arrayen.
            string fileName = commandName.Split('/')[1];
            File.Delete(imagesFolder + "\\" + fileName);

            //etter fila er slettet, må vi "laste siden" på nytt.
            //Vi kaller på metoden som henter opp bildene og serverer dem på siden:
            GetImages();
        }
    }
}