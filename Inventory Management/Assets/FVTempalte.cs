using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inventory_Management.Model;
using Inventory_Management.Services;

namespace Inventory_Management.Assets
{
    public class FVTempalte : IFVTempalte
    {
        private readonly IConfigServices _configServices = new ConfigServices();
        private Config config;
        public FVTempalte()
        {
            config = _configServices.GetConfig();
        }
        public string CreateFVInHtml(Order order)
        {
            var content = new StringBuilder();
            content.Append(
            @"<html lang='pl'>
                <head>
                    <meta charset='utf-8'>
                    <title>faktura</title>
                    <style>
			            body
			            {
				            margin:50px 0px; padding:0px;
				            text-align:center;
			            }
				            
			            #Content {
				            max-width:1000px;
				            text-align:left;
				            padding:15px;
				            border:1px dashed #333;
				            background-color:#eee;
				            
				            display: inline-block;
				            margin: 1em;
			            }


			            #div-1a
			            {
				            border: 1px solid black;
				            width:333px;
				            background-color: #bababa;
				            
				            margin: 25px 0px 15px 15px;
				            float:left;
				            
				            padding-top: 100px;
				            text-align:center;
			            }
			            #div-1b
			            {
				            border: 1px solid black;
				            width:275px;
				            background-color: #bababa; 
				            margin: 25px 0px 15px 15px;
				            padding: 10px;
				            float:left;
				            text-align:center;
			            }

			            #div-1d
			            {
				            border: 1px solid black;
				            width:240px;
				            background-color: #bababa; 
				            margin: 25px 15px 15px 15px;
				            padding: 10px;
				            float:left;
				            text-align:center;
			            }
			            #div-1c
			            {
				            border: 1px solid black;
				            clear:both;
				            background-color: #bababa;
				            margin: 15px 0px 15px 15px;
				            width:450px;    
				            float:left;
			            }
			            #div-1e
			            {
				            border: 1px solid black;
				            background-color: #bababa;
				            margin: 15px 0px 15px 15px;
				            width:450px;    
				            float:left;
			            }
			            #div-1f
			            {
				            border: 1px solid black;
				            clear:both;
				            background-color: #bababa;
				            width:900px;    
				            float:left;
				            
				            padding: 10px;
					            
				            margin: 15px 0px 15px 15px;
			            }
			            #table
			            {
				            margin: 0px auto;
				            border: 2px solid black;
				            border-collapse: collapse;
					            
				            display: inline-block;
				            margin: 1em;
				            clear:both;
			            /*    left: 200px;*/
			            }

			            #div-sum
			            {
				            margin: 0px auto;
				            border: 1px solid black;
				            max-width:1000px;
				            text-align:left;
				            padding:15px;
				            background-color:#bababa;
				             
				            float:left;
				            clear:both;
				            display: inline-block;
				            margin: 1em;
			            }

			            #div-odb
			            {
				            border: 1px solid black;
				            width:333px;
				            text-align:center;
				            padding:15px;
				            margin: 25px 0px 15px 15px;
				            background-color:#bababa;
				            float:left;
				            clear:both;
				            padding-top: 100px;

			            }
			            #div-wys
			            {
				            border: 1px solid black;
				            width:333px;
				            text-align:center;
				            padding:15px;
				            margin: 25px 0px 15px 15px;
				            background-color:#bababa;
					            padding-top: 100px;
				            float:left;
			            }
		            </style>
                </head>
                
                <body>
			            <div id='Content'>
				            <div>
				             <div id='div-1b'>
						            <p><b>Faktura</b></p>
					            </div>
					            
					            <div id='div-1d'>");

            content.Append(@"<p><b>Nr: " +DateTime.Now.Minute + "/" +DateTime.Now.Hour +"/" + DateTime.Now.Day +"/"+ DateTime.Now.Month + "/" + DateTime.Now.Year+ @" </b></p>
					</div><br />
					<div id='div-1c'>
							Sprzedawca: <b>" + config.Name + @"</b> <br />
							Adres: <b>" + config.Address + @"</b><br />
							NIP: <b>" + config.Nip + @"</b>

					</div>
					<div id='div-1e'>
							Nabywca: <b>" + order.Client.Name + @"</b><br />
							Adres: <b>" + order.Client.Address + @"</b><br />
							NIP: " + order.Client.NIP + @"
					</div>");
            content.Append(@"<div id='div-1f'>
						Sposob płatności: <b>" + order.Payment + @"</b><br />
						Termin płatności: <b>" + order.DateOfBuy + @"</b><br />
						Numer konta: <b>" + config.BankAccount + @"</b>
					</div>
					
				</div>");
            content.Append(@"<div>
			<br>
			<table border='1' id='table' >
				<tr style='background-color: #bababa;'>
					<th>Lp.</th>
					<th>Nazwa</th>
					<th>Ilość</th>
					<th>Cena netto</th>
					<th>Stawka VAT</th>
					<th>Wartość brutto</th>
				</tr>");
            var lp = 0;
            foreach (var item in order.Items)
            {
                content.Append(@"
                        <tr>
					<td>" + lp+ @"</td>
					<td>" + item.Name + @"</td>
					<td>" + item.Count + @"</td>
					<td>" + GetNettoPrice(item) + @"</td>
					<td>" + item.Tax + @"</td>
					<td>" + item.Price + @"</td>                
				</tr>
                    ");
                lp++;
            }

            content.Append(@"</table>
			
			</div>
			
				<div id='div-sum'>
					<p>Razem do zapłaty: <b> " + GetTotalCost(order) + @"</b></p>
                       </ div >

                <div id = 'div-odb'>
 
                <p> Podpis odbiorcy </p>
	
                </div>
	

                <div id = 'div-wys'>
	 
                <p> Podpis wystawiającego </p>
		
                </div>
		

                </div>
		
                </body>
                </html>");
            

            return content.ToString();
        }

        private double GetTotalCost(Order order) => order.Items.Sum(x => x.Count * x.Price);
        private double GetNettoPrice(Item item) => item.Price - (item.Price * (item.Tax / 100 ));
    }
}
