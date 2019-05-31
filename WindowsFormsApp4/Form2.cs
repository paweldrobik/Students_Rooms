using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp4
{
    public partial class Form2 : Form
    {
        public Form2(int X)
        {
            InitializeComponent();

            var z = pictureBox1.Width;
            var y = pictureBox1.Height;
            

            using (var context = new PokojeEntities2())
            {
                var query1 = context.DanePokojow
                    .Where(x => x.IDPokoju == X).FirstOrDefault();
                if (query1 != null)
                {
                    label1.Text = "Nazwa pokoju:\n" + query1.NazwaPokoju
                        + "\n\nMiasto: \n" + query1.Miasto
                        + "\n\nAdres: \n" + query1.Adres
                        + "\n\nLiczba pokoi:\n" + query1.LiczbaMiejsc
                        + "\n\nWolne pokoje:\n" + query1.WolneMiejsca
                        + "\n\nAneks kuchenny:\n" + query1.ŁaziekaWPokoju
                        + "\n\nTelefon: \n" + query1.Telefon;

                    this.Text = query1.NazwaPokoju;

                    try
                    {
                        Bitmap img = new Bitmap($"Images/{X}.jpg");
                        var imageHeight = img.Height;
                        var imageWidth = img.Width;
                        this.ClientSize = new Size(imageWidth + 133, imageHeight);
                        pictureBox1.Image = img;
                    }
                    catch
                    {
                        Bitmap img = new Bitmap($"Images/0.jpg");
                        var imageHeight = img.Height;
                        var imageWidth = img.Width;
                        this.ClientSize = new Size(imageWidth + 133, imageHeight);
                        pictureBox1.Image = img;
                    }
                    

                    
                }
                else
                    label1.Text = "";
                
            }

        }
    }
}
