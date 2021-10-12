using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.Assets;
using Inventory_Management.Model;

namespace Inventory_Management.Services
{
    public class FVServices : IFVServices
    {
        private readonly IFVTempalte _fVTempalte = new FVTempalte();
        public void CreateFV(Order order)
        {
            var html = _fVTempalte.CreateFVInHtml(order);
            var Renderer = new IronPdf.ChromePdfRenderer();
            if (!Directory.Exists("FV"))
                Directory.CreateDirectory("FV");
            // Renderer.RenderHtmlAsPdf(html).SaveAs("FV/FV="+DateTime.Now+".pdf");
             Renderer.RenderHtmlAsPdf(html).SaveAs("FV/FV"+DateTime.Now.Year + DateTime.Now.Month+ DateTime.Now.Day + DateTime.Now.Hour + DateTime.Now.Minute+".pdf");
            
        }
    }
}
