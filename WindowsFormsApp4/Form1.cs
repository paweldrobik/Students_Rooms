using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Data.Entity;

namespace WindowsFormsApp4
{
    public partial class Form1 : Form
    {
        bool searchClick = false;
        int _skipper = 0;
        int _query = 0;
        int id1;
        int id2;
        int id3;
        int id4;
        int id5;
        int id6;
        int id7;
        public Form1()
        {
            InitializeComponent();
            this.Text = "Students Rooms";

            using (var context = new PokojeEntities2())
            {
                

                var query = context.DanePokojow.OrderBy(x => x.NazwaPokoju).LongCount();
                _query = (int)query;

                var query1 = context.DanePokojow.OrderBy(x => x.NazwaPokoju).FirstOrDefault();
                label6.Text = $"Nazwa Mieszkania: {query1.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query1.LiczbaMiejsc}/{ query1.WolneMiejsca} \nAneks kuchenny: { query1.ŁaziekaWPokoju}";
                id1 = query1.IDPokoju.Value;

                var query2 = context.DanePokojow.OrderBy(x => x.NazwaPokoju).Skip(3).FirstOrDefault();
                label7.Text = $"Nazwa Mieszkania: {query2.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query2.LiczbaMiejsc}/{ query2.WolneMiejsca} \nAneks kuchenny: { query2.ŁaziekaWPokoju}";
                id2 = query2.IDPokoju.Value;

                var query3 = context.DanePokojow.OrderBy(x => x.NazwaPokoju).Skip(6).FirstOrDefault();
                label8.Text = $"Nazwa Mieszkania: {query3.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query3.LiczbaMiejsc}/{ query3.WolneMiejsca} \nAneks kuchenny: { query3.ŁaziekaWPokoju}";
                id3 = query3.IDPokoju.Value;

                var query4 = context.DanePokojow.OrderBy(x => x.NazwaPokoju).Skip(9).FirstOrDefault();
                label9.Text = $"Nazwa Mieszkania: {query4.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query4.LiczbaMiejsc}/{ query4.WolneMiejsca} \nAneks kuchenny: { query4.ŁaziekaWPokoju}";
                id4 = query4.IDPokoju.Value;

                var query5 = context.DanePokojow.OrderBy(x => x.NazwaPokoju).Skip(12).FirstOrDefault();
                label10.Text = $"Nazwa Mieszkania: {query5.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query5.LiczbaMiejsc}/{ query5.WolneMiejsca} \nAneks kuchenny: { query5.ŁaziekaWPokoju}";
                id5 = query5.IDPokoju.Value;

                var query6 = context.DanePokojow.OrderBy(x => x.NazwaPokoju).Skip(15).FirstOrDefault();
                label11.Text = $"Nazwa Mieszkania: {query6.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query6.LiczbaMiejsc}/{ query6.WolneMiejsca} \nAneks kuchenny: { query6.ŁaziekaWPokoju}";
                id6 = query6.IDPokoju.Value;

                var query7 = context.DanePokojow.OrderBy(x => x.NazwaPokoju).Skip(18).FirstOrDefault();
                label12.Text = $"Nazwa Mieszkania: {query7.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query7.LiczbaMiejsc}/{ query7.WolneMiejsca} \nAneks kuchenny: { query7.ŁaziekaWPokoju}";
                id7 = query7.IDPokoju.Value;
            }

            comboBox1.Text = "Bielsko-Biała";
            comboBox4.Text = "1";
            comboBox3.Text = "1";
            comboBox2.Text = "tak";
        }
        
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            searchClick = true;
            SearchMetchode(0);
            
            
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            if (searchClick)
            {
                if (_skipper >= 7)
                {
                    SearchMetchode(-7);
                }
                else
                {
                    MessageBox.Show("Jesteś na pierwszej stronie");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (searchClick)
            {
                if ((_query - 7) > _skipper)
                {
                    SearchMetchode(7);
                }
                else
                {
                    MessageBox.Show("Brak większej ilości pokoii");

                }
            }




        }



        private void SearchMetchode(int X)
        {
            using (var context = new PokojeEntities2())
            {
                var item = comboBox1.SelectedItem;
                var item2 = Int32.Parse(comboBox4.Text);

                var item3 = comboBox2.SelectedItem;
                var item4 = Int32.Parse(comboBox3.Text);
                
                _skipper += X;

                var query = context.DanePokojow
                    .Where(x => x.Miasto == item && x.LiczbaMiejsc == item2 && x.WolneMiejsca == item4 && x.ŁaziekaWPokoju == item3)
                    .OrderBy(x => x.NazwaPokoju).LongCount();
                _query = (int)query;


                var query1 = context.DanePokojow
                    .Where(x => x.Miasto == item && x.LiczbaMiejsc == item2 && x.WolneMiejsca == item4 && x.ŁaziekaWPokoju == item3)
                    .OrderBy(x => x.NazwaPokoju).Skip(_skipper).FirstOrDefault();
                if (query1 != null)
                {
                    label6.Text = $"Nazwa Mieszkania: {query1.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query1.LiczbaMiejsc}/{ query1.WolneMiejsca} \nAneks kuchenny: { query1.ŁaziekaWPokoju}";
                    id1 = query1.IDPokoju.Value;
                }
                else
                    label6.Text = "";

                var query2 = context.DanePokojow
                    .Where(x => x.Miasto == item && x.LiczbaMiejsc == item2 && x.WolneMiejsca == item4 && x.ŁaziekaWPokoju == item3)
                    .OrderBy(x => x.NazwaPokoju).Skip(_skipper + 1).FirstOrDefault();
                if (query2 != null)
                {
                    label7.Text = $"Nazwa Mieszkania: {query2.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query2.LiczbaMiejsc}/{ query2.WolneMiejsca} \nAneks kuchenny: { query2.ŁaziekaWPokoju}";
                    id2 = query2.IDPokoju.Value;
                }
                else
                    label7.Text = "";

                var query3 = context.DanePokojow
                    .Where(x => x.Miasto == item && x.LiczbaMiejsc == item2 && x.WolneMiejsca == item4 && x.ŁaziekaWPokoju == item3)
                    .OrderBy(x => x.NazwaPokoju).Skip(_skipper + 2).FirstOrDefault();
                if (query3 != null)
                {
                    label8.Text = $"Nazwa Mieszkania: {query3.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query3.LiczbaMiejsc}/{ query3.WolneMiejsca} \nAneks kuchenny: { query3.ŁaziekaWPokoju}";
                    id3 = query3.IDPokoju.Value;
                }
                else
                    label8.Text = "";

                var query4 = context.DanePokojow
                    .Where(x => x.Miasto == item && x.LiczbaMiejsc == item2 && x.WolneMiejsca == item4 && x.ŁaziekaWPokoju == item3)
                    .OrderBy(x => x.NazwaPokoju).Skip(_skipper + 3).FirstOrDefault();
                if (query4 != null)
                {
                    label9.Text = $"Nazwa Mieszkania: {query4.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query4.LiczbaMiejsc}/{ query4.WolneMiejsca} \nAneks kuchenny: { query4.ŁaziekaWPokoju}";
                    id4 = query4.IDPokoju.Value;
                }
                else
                    label9.Text = "";

                var query5 = context.DanePokojow
                    .Where(x => x.Miasto == item && x.LiczbaMiejsc == item2 && x.WolneMiejsca == item4 && x.ŁaziekaWPokoju == item3)
                    .OrderBy(x => x.NazwaPokoju).Skip(_skipper + 4).FirstOrDefault();
                if (query5 != null)
                {
                    label10.Text = $"Nazwa Mieszkania: {query5.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query5.LiczbaMiejsc}/{ query5.WolneMiejsca} \nAneks kuchenny: { query5.ŁaziekaWPokoju}";
                    id5 = query5.IDPokoju.Value;
                }
                else
                    label10.Text = "";

                var query6 = context.DanePokojow
                    .Where(x => x.Miasto == item && x.LiczbaMiejsc == item2 && x.WolneMiejsca == item4 && x.ŁaziekaWPokoju == item3)
                    .OrderBy(x => x.NazwaPokoju).Skip(_skipper + 5).FirstOrDefault();
                if (query6 != null)
                {
                    label11.Text = $"Nazwa Mieszkania: {query6.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query6.LiczbaMiejsc}/{ query6.WolneMiejsca} \nAneks kuchenny: { query6.ŁaziekaWPokoju}";
                    id6 = query6.IDPokoju.Value;
                }
                else
                    label11.Text = "";

                var query7 = context.DanePokojow
                    .Where(x => x.Miasto == item && x.LiczbaMiejsc == item2 && x.WolneMiejsca == item4 && x.ŁaziekaWPokoju == item3)
                    .OrderBy(x => x.NazwaPokoju).Skip(_skipper + 6).FirstOrDefault();
                if (query7 != null)
                {
                    label12.Text = $"Nazwa Mieszkania: {query7.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query7.LiczbaMiejsc}/{ query7.WolneMiejsca} \nAneks kuchenny: { query7.ŁaziekaWPokoju}";
                    id7 = query7.IDPokoju.Value;
                }
                else
                    label12.Text = "";

            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
            label6.Text = "";
            label7.Text = "";
            label8.Text = "";
            label9.Text = "";
            label10.Text = "";
            label11.Text = "";
            label12.Text = "";
            using (var context = new PokojeEntities2())
            {
                var query1 = context.DanePokojow
                    .Where(x => x.NazwaPokoju == textBox2.Text).OrderBy(x => x.NazwaPokoju).FirstOrDefault();
                if (query1 != null)
                {
                    label6.Text = $"Nazwa Mieszkania: {query1.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query1.LiczbaMiejsc}/{ query1.WolneMiejsca} \nAneks kuchenny: { query1.ŁaziekaWPokoju}";
                    id1 = query1.IDPokoju.Value;
                }
                else
                    label6.Text = "";

                var query2 = context.DanePokojow
                    .Where(x => x.NazwaPokoju == textBox2.Text).OrderBy(x => x.NazwaPokoju).Skip(1).FirstOrDefault();
                if (query2 != null)
                {
                    label7.Text = $"Nazwa Mieszkania: {query2.NazwaPokoju} \nLiczba pokoi / wolne pokoje: " +
                        $"{query2.LiczbaMiejsc}/{ query2.WolneMiejsca} \nAneks kuchenny: { query2.ŁaziekaWPokoju}";
                    id2 = query2.IDPokoju.Value;
                }
                else
                    label7.Text = "";
            }
        }

        private void textBox2_Enter(object sender, EventArgs e)
        {
            if(textBox2.Text == "Wyszukaj...")
            textBox2.Text = "";
        }

        private void label6_DoubleClick(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(id1);
            form2.Show();
}
        private void label7_DoubleClick(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(id2);
            form2.Show();
        }
        private void label8_DoubleClick(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(id3);
            form2.Show();
        }

        private void label9_DoubleClick(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(id4);
            form2.Show();
        }

        private void label10_DoubleClick(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(id5);
            form2.Show();
        }

        private void label11_DoubleClick(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(id6);
            form2.Show();
        }

        private void label12_DoubleClick(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(id7);
            form2.Show();
        }



        private void label6_MouseEnter(object sender, EventArgs e)
        {
            label6.BackColor = Color.Bisque;
        }

        private void label6_MouseLeave(object sender, EventArgs e)
        {
            label6.BackColor = SystemColors.ActiveBorder;
        }

        private void label7_MouseEnter(object sender, EventArgs e)
        {
            label7.BackColor = Color.Bisque;
        }

        private void label7_MouseLeave(object sender, EventArgs e)
        {
            label7.BackColor = SystemColors.ActiveBorder;
        }

        private void label8_MouseEnter(object sender, EventArgs e)
        {
            label8.BackColor = Color.Bisque;
        }

        private void label8_MouseLeave(object sender, EventArgs e)
        {
            label8.BackColor = SystemColors.ActiveBorder;
        }

        private void label9_MouseEnter(object sender, EventArgs e)
        {
            label9.BackColor = Color.Bisque;
        }

        private void label9_MouseLeave(object sender, EventArgs e)
        {
            label9.BackColor = SystemColors.ActiveBorder;
        }

        private void label10_MouseEnter(object sender, EventArgs e)
        {
            label10.BackColor = Color.Bisque;
        }

        private void label10_MouseLeave(object sender, EventArgs e)
        {
            label10.BackColor = SystemColors.ActiveBorder;
        }

        private void label11_MouseEnter(object sender, EventArgs e)
        {
            label11.BackColor = Color.Bisque;
        }

        private void label11_MouseLeave(object sender, EventArgs e)
        {
            label11.BackColor = SystemColors.ActiveBorder;
        }

        private void label12_MouseEnter(object sender, EventArgs e)
        {
            label12.BackColor = Color.Bisque;
        }

        private void label12_MouseLeave(object sender, EventArgs e)
        {
            label12.BackColor = SystemColors.ActiveBorder;
        }

        
    }
}
