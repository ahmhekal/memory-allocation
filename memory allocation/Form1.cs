using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace memory_allocation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int num_holes, num_processes;
        List<hole> holes = new List<hole>();
        List<process> processes = new List<process>();
        List<hole> Sortedholes;

        private void Form1_Load(object sender, EventArgs e)
        {
        }
 

        private void numh_TextChanged(object sender, EventArgs e)
        {
            datagridview1.AllowUserToAddRows = false;
            datagridview1.Visible = true;
            datagridview1.DataSource = null;
            datagridview1.Columns.Clear();  //Just make sure things are blank.
            datagridview1.Columns.Add("Column1", "Hole number");
            datagridview1.Columns.Add("Column2", "Hole Size");
            datagridview1.Columns.Add("Column3", "Hole address");
            int n;
            bool isNumeric = int.TryParse(numh.Text, out n);
            if (isNumeric)
                num_holes = Int32.Parse(numh.Text);
            else num_holes = 0;
            datagridview1.Rows.Clear();
            for (int i = 1; i <= num_holes; i++)
            {
                datagridview1.Rows.Add("hole" + (i.ToString()));
            }
            datagridview1.EditMode = DataGridViewEditMode.EditOnKeystroke;

        }

        private void submit_Click(object sender, EventArgs e)
        {

            label2.Visible = true;
            comboBox1.Visible = true;
            label1.Text = "Number of Processes";
            numh.Visible = false;
            datagridview1.Visible = false;
            nump.Visible = true;
            submit.Visible = false;
            submit2.Visible = true;

            for (int i = 0; i < num_holes; i++)
            {

                int tempsize = Int32.Parse(datagridview1.Rows[i].Cells[1].Value.ToString());
                int tempaddress = Int32.Parse(datagridview1.Rows[i].Cells[2].Value.ToString());

                hole temphole = new hole();


                temphole.size = tempsize;
                temphole.address = tempaddress;
                
                holes.Add(temphole);                
            }
           Sortedholes = holes.OrderBy(o => o.address).ToList();
           //MessageBox.Show(Sortedholes[0].size.ToString());

        }
        

        private void nump_TextChanged(object sender, EventArgs e)
        {
            submit2.Visible = true;
        }

     

        private void submit2_Click(object sender, EventArgs e)
        {
            pictureBox1.Visible = true;
            FontFamily ff = new FontFamily("Arial");
            System.Drawing.Font font = new System.Drawing.Font(ff, 10);
            System.Drawing.Font bigfont = new System.Drawing.Font(ff, 12);
            Bitmap image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Graphics g;
            g = Graphics.FromImage(image);
            //SolidBrush sbgreen = new SolidBrush(Color.Green);
            int height = Sortedholes[num_holes - 1].address + Sortedholes[num_holes - 1].size;
            //MessageBox.Show(height.ToString());
            g.FillRectangle(Brushes.Black, 0, 0, 100,347);
            g.DrawString("HOLE", font, Brushes.White, new PointF(30, 160));

            pictureBox1.Image = image;
            label2.Visible = false;
            comboBox1.Visible = false;
            nump.Visible = false;
            submit2.Visible = false;
            label1.Visible = false;
            label3.Visible = true;
            process_size.Visible = true;
            button1.Visible = true;

        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

       

        private void button1_Click(object sender, EventArgs e)
        {
           
                process tempprocess = new process();


                tempprocess.size = Int32.Parse(process_size.Text);

                processes.Add(tempprocess);

            
            /*************************************/

            if (comboBox1.Text == "First fit")
            {
                int allocated = 0;
                List<hole> Sortedholes = holes.OrderBy(o => o.address).ToList();
                int j;
                for (j = 0; j < num_holes; j++)
                {
                    if (Sortedholes[j].size >= tempprocess.size)
                    {
                       // Sortedholes[j].size -= tempprocess.size;
                        allocated = 1;
                        break;

                    }
                }
                //MessageBox.Show(allocated.ToString());

                FontFamily ff = new FontFamily("Arial");
                System.Drawing.Font font = new System.Drawing.Font(ff, 10);
                System.Drawing.Font bigfont = new System.Drawing.Font(ff, 12);
                Bitmap image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                Graphics g;
                g = Graphics.FromImage(image);
                int height = Sortedholes[num_holes - 1].address + Sortedholes[num_holes - 1].size;
                float factor =(float) 347 / height;
                //MessageBox.Show(Sortedholes[0].size.ToString());

                if (allocated == 1)
                {
                    g.FillRectangle(Brushes.Black, 0, 0, 100,347);
                    g.DrawString("HOLE", font, Brushes.White, new PointF(30, 160));
                    g.FillRectangle(Brushes.Green, 0, Sortedholes[j].address*factor , 100, tempprocess.size*factor);
                    pictureBox1.Image = image;
                }

                


            }
            
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        


    }
}
