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
        List<process> allocated_processes = new List<process>();
        List<hole> Sortedholes;
        List<hole>  sizesortedholes;

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

          
            label1.Text = "Number of Processes";
            numh.Visible = false;
            datagridview1.Visible = false;
            nump.Visible = true;
            submit.Visible = false;
            submit2.Visible = true;
            label5.Visible = false;
            memorysize.Visible = false;

            for (int i = 0; i < num_holes; i++)
            {

                int tempsize = Int32.Parse(datagridview1.Rows[i].Cells[1].Value.ToString());
                int tempaddress = Int32.Parse(datagridview1.Rows[i].Cells[2].Value.ToString());

                hole temphole = new hole();


                temphole.size = tempsize;
                temphole.address = tempaddress;
                
                holes.Add(temphole);                
            }
           //MessageBox.Show(Sortedholes[0].size.ToString());


        }
        

        private void nump_TextChanged(object sender, EventArgs e)
        {
            submit2.Visible = true;
        }

     

        private void submit2_Click(object sender, EventArgs e)
        {

                Sortedholes = holes.OrderBy(o => o.address).ToList();
    
            label2.Visible = true;
            comboBox1.Visible = true;
            label4.Visible = true;
            textBox1.Visible = true;
            deallocate.Visible = true;
            pictureBox1.Visible = true;
            FontFamily ff = new FontFamily("Arial");
            System.Drawing.Font font = new System.Drawing.Font(ff, 10);
            System.Drawing.Font bigfont = new System.Drawing.Font(ff, 12);
            Bitmap image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Graphics g;
            g = Graphics.FromImage(image);
            //SolidBrush sbgreen = new SolidBrush(Color.Green);
            //int height = Sortedholes[Sortedholes.Count() - 1].address + Sortedholes[Sortedholes.Count() - 1].size;
            int height = Int32.Parse(memorysize.Text);
            float factor = (float)430 / height;
            //MessageBox.Show(height.ToString());
            g.FillRectangle(Brushes.Black, 0, 0, 100,height*factor+20);
            //g.DrawString("Memory", font, Brushes.White, new PointF(30, 160));

            for (int i = 0; i < Sortedholes.Count(); i++)
            {
                g.FillRectangle(Brushes.White, 0, (Sortedholes[i].address)*factor, 100, Sortedholes[i].size * factor);
            }
            pictureBox1.Image = image;
            submit2.Visible = false;
            label1.Visible = false;
            label3.Visible = true;
            process_size.Visible = true;
            button1.Visible = true;
            nump.Visible = false;

        }

       
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }



        int count = 0;
        private void button1_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text == "First fit")
                Sortedholes = holes.OrderBy(o => o.address).ToList();
            else if (comboBox1.Text == "Best fit")
            {
                Sortedholes = holes.OrderBy(o => o.size).ToList();
            }
         

            count++;
                process tempprocess = new process();


                tempprocess.size = Int32.Parse(process_size.Text);
                tempprocess.name = count;
                processes.Add(tempprocess);
                
            
            /*************************************/

          
            
              
                int allocated = 0;

                
               
            int j;
                for (j = 0; j < Sortedholes.Count(); j++)
                {
                    if (Sortedholes[j].size >= tempprocess.size)
                    {
                       // 
                        allocated = 1;
                        tempprocess.start_adress = Sortedholes[j].address;
                        allocated_processes.Add(tempprocess);
                        break;

                    }
                }
                //MessageBox.Show(allocated.ToString(;

                FontFamily ff = new FontFamily("Arial");
                System.Drawing.Font font = new System.Drawing.Font(ff, 10);
                System.Drawing.Font bigfont = new System.Drawing.Font(ff, 12);
                Bitmap image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                Graphics g;
                g = Graphics.FromImage(image);
                int height = Int32.Parse(memorysize.Text);
                float factor =(float) 430 / height;
                //MessageBox.Show(Sortedholes[0].size.ToString());
                g.FillRectangle(Brushes.Black, 0, 0, 100, 430);
                //g.DrawString("MEMORY", font, Brushes.White, new PointF(30, 160));
                for (int i = 0; i < Sortedholes.Count(); i++)
                {
                    g.FillRectangle(Brushes.White, 0, (Sortedholes[i].address) * factor, 100, Sortedholes[i].size * factor);
                }
                int color = 0;
                for (int i = 0; i < allocated_processes.Count(); i++)
                {
                    if(color%3==0)
                         g.FillRectangle(Brushes.GreenYellow, 0, allocated_processes[i].start_adress * factor, 100, allocated_processes[i].size * factor);
                    else if(color%3==1)
                        g.FillRectangle(Brushes.Pink, 0, allocated_processes[i].start_adress * factor, 100, allocated_processes[i].size * factor);

                    else
                        g.FillRectangle(Brushes.Purple, 0, allocated_processes[i].start_adress * factor, 100, allocated_processes[i].size * factor);

                    g.DrawString("p"+allocated_processes[i].name.ToString(), font, Brushes.Black, new PointF(101, allocated_processes[i].start_adress*factor));
                    color++;

                }
                if (allocated == 1)
                {

                    g.FillRectangle(Brushes.Green, 0, Sortedholes[j].address * factor, 100, tempprocess.size * factor);
                    pictureBox1.Image = image;
                    Sortedholes[j].size -= tempprocess.size;
                    Sortedholes[j].address += tempprocess.size;
                    g.DrawString("p"+tempprocess.name.ToString(), font, Brushes.Black, new PointF(101, tempprocess.start_adress * factor));

                }
                else
                {
                    MessageBox.Show("Sorry, Allocation Failed. No Enough Memory");
                }

                


            
            
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void datagridview1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void deallocate_Click(object sender, EventArgs e)
        {
            int index=Int32.Parse(textBox1.Text);
            hole temphole=new hole();

            for (int i = 0; i < allocated_processes.Count(); i++)
            {
                if (allocated_processes[i].name == index)
                {
                    index = i;
                    break;
                }
            }
                temphole.size = allocated_processes[index].size;
            temphole.address=allocated_processes[index].start_adress;
            holes.Add(temphole);
            allocated_processes.RemoveAt(index);

            if (comboBox1.Text == "First fit")
                Sortedholes = holes.OrderBy(o => o.address).ToList();
            else if (comboBox1.Text == "Best fit")
                Sortedholes = holes.OrderBy(o => o.size).ToList();


            FontFamily ff = new FontFamily("Arial");
            System.Drawing.Font font = new System.Drawing.Font(ff, 10);
            System.Drawing.Font bigfont = new System.Drawing.Font(ff, 12);
            Bitmap image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
            Graphics g;
            g = Graphics.FromImage(image);
            int height = Int32.Parse(memorysize.Text);
            float factor = (float)430 / height;
            //MessageBox.Show(Sortedholes[0].size.ToString());
            g.FillRectangle(Brushes.Black, 0, 0, 100, 430);
            //g.DrawString("MEMORY", font, Brushes.White, new PointF(30, 160));
            for (int i = 0; i < Sortedholes.Count(); i++)
            {
                g.FillRectangle(Brushes.White, 0, (Sortedholes[i].address) * factor, 100, Sortedholes[i].size * factor);
            }
            int color = 0;
            for (int i = 0; i < allocated_processes.Count(); i++)
            {
                if (color % 3 == 0)
                    g.FillRectangle(Brushes.GreenYellow, 0, allocated_processes[i].start_adress * factor, 100, allocated_processes[i].size * factor);
                else if (color % 3 == 1)
                    g.FillRectangle(Brushes.Pink, 0, allocated_processes[i].start_adress * factor, 100, allocated_processes[i].size * factor);

                else
                    g.FillRectangle(Brushes.Purple, 0, allocated_processes[i].start_adress * factor, 100, allocated_processes[i].size * factor);

                g.DrawString("p" + allocated_processes[i].name.ToString(), font, Brushes.Black, new PointF(101, allocated_processes[i].start_adress * factor));
                color++;

            }
            pictureBox1.Image = image;
        }

        


    }
}
