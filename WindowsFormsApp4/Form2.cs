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
            

            using (var context = new PokojeEntities2())
            {
                var query1 = context.DanePokojow
                    .Where(x => x.IDPokoju == X).FirstOrDefault();
                if (query1 != null)
                {
                    label1.Text = "Nazwa pokoju:\n" + query1.NazwaPokoju
                        + "\n\nMiasto: \n" + query1.Miasto
                        + "\n\nAdres: \n" + query1.Adres
                        + "\n\nLiczba miejsc:\n" + query1.LiczbaMiejsc
                        + "\n\nWolne Miejsca:\n" + query1.WolneMiejsca
                        + "\n\nŁazięka w pokoju:\n" + query1.ŁaziekaWPokoju
                        + "\n\nTelefon: \n" + query1.Telefon;

                    pictureBox1.ImageLocation = ($"Images/{X}.jpg");
                }
                else
                    label1.Text = "";
                
            }

            

            //PictureBox picture = new PictureBox
            //{
            //    Name = "pictureBox",
            //    //Size = new Size(1000, 400),
            //    Location = new Point(150, 100),
            //    ImageLocation = @"1.jpg",
            //    SizeMode = PictureBoxSizeMode.CenterImage
            //};
            //pictureBox1.Controls.Add(picture);


        }


    }
}
