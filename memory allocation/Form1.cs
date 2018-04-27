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
        int num_holes;
        List<hole> holes = new List<hole>();
        List<process> processes = new List<process>();
        List<process> allocated_processes = new List<process>();
        List<hole> Sortedholes;
        List<process> waiting_list = new List<process>();

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
            datagridview1.Columns["Column1"].ReadOnly = true;

            datagridview1.Columns.Add("Column2", "Hole Size");
            datagridview1.Columns.Add("Column3", "Hole starting address");

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
        //not allowing overlap
        // more colors
        // if the user enters un-existed process to deallocate

        private void nump_TextChanged(object sender, EventArgs e)
        {
            submit2.Visible = true;
        }

     

        private void submit2_Click(object sender, EventArgs e)
        {
            button3.Visible = true;
            int n;
            bool isNumeric = int.TryParse(numh.Text, out n);
            bool isNumeric2 = int.TryParse(memorysize.Text, out n);
            if ( (!isNumeric) || (! isNumeric2) )
            {
                MessageBox.Show("You have to enter valid number of holes and memory size");
                return;
            }
            int numhh= Int32.Parse(numh.Text);
            int memory_sizee= Int32.Parse(memorysize.Text);
            if (numhh <= 0 || memory_sizee <= 0)
            {
                MessageBox.Show("You have to enter a valid positive number of holes and memory size");
                return;
            }
           
             holes.Clear();
            
            for (int i = 0; i < num_holes; i++)
            {
                if ((datagridview1.Rows[i].Cells[1].Value==null) || (datagridview1.Rows[i].Cells[2].Value==null))
                {
                    MessageBox.Show("You have to enter a valid address and size of holes");
                    return;
                }
                bool isNumeric3 = int.TryParse(datagridview1.Rows[i].Cells[1].Value.ToString(), out n);
                bool isNumeric4 = int.TryParse(datagridview1.Rows[i].Cells[2].Value.ToString(), out n);
                if ((!isNumeric3) || (!isNumeric4))
                {
                    MessageBox.Show("You have to enter a valid address and size of holes");
                    return;
                }
                int tempsize = Int32.Parse(datagridview1.Rows[i].Cells[1].Value.ToString());
                int tempaddress = Int32.Parse(datagridview1.Rows[i].Cells[2].Value.ToString());
                if (tempsize > 0 && tempaddress >= 0)
                {
                    hole temphole = new hole();
                    temphole.size = tempsize;
                    temphole.address = tempaddress;
                    holes.Add(temphole);
                }
                else
                {
                    MessageBox.Show("You have to enter a valid address and size of holes");
                    return;
                }
            }
          

                Sortedholes = holes.OrderBy(o => o.address).ToList();
            /////////////---------Removing overlap ---------/////////////
                for (int i = 0; i < Sortedholes.Count-1; i++)
                {
                    if ((Sortedholes[i].address + Sortedholes[i].size) > (Sortedholes[i + 1].address))
                    {
                        MessageBox.Show("Overlapping between holes is not allowed !");
                        return;
                    }
 
                }
            //////////////////////*-------------------------------////////

            
            

            int done = 0;
            int indx =0;
            while (done==0)
            {
                done = 1;
                for (int i = 0; i < Sortedholes.Count()-1; i++)
                {
                    
                    if (Sortedholes[i].address + Sortedholes[i].size == Sortedholes[i + 1].address)
                    {
                        
                        done = 0;
                        int temp_size=Sortedholes[i].size+Sortedholes[i + 1].size;
                        for (int k = 0; k < holes.Count(); k++)
                        {
                            if (holes[k].address == Sortedholes[i].address)
                                holes[k].size = temp_size;

                            if (holes[k].address == Sortedholes[i + 1].address)
                                indx = k;

                        }
                        holes.RemoveAt(indx);
                        Sortedholes = holes.OrderBy(o => o.address).ToList();
                        break;
                    }
                }
            
            
            }
            
            Sortedholes = holes.OrderBy(o => o.address).ToList();

            int holesheight = Sortedholes[Sortedholes.Count() - 1].address + Sortedholes[Sortedholes.Count() - 1].size;
            int height = Int32.Parse(memorysize.Text);

            if (holesheight > height)
                MessageBox.Show("Memory size isn't enough for all holes !");
            else
            {
                label7.Visible = true;
                label8.Visible = true;
                label9.Visible = true;
                label10.Visible = true;

                float factor = (float)430 / height;
                //MessageBox.Show(height.ToString());
                Bitmap image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                Graphics g;
                g = Graphics.FromImage(image);
                g.FillRectangle(Brushes.Black, 0,10, 100, height * factor);
                FontFamily ff = new FontFamily("Arial");
                System.Drawing.Font font = new System.Drawing.Font(ff, 10);
                for (int i = 0; i < Sortedholes.Count(); i++)
                {
                    g.FillRectangle(Brushes.White, 0, (Sortedholes[i].address) * factor + 10, 100, Sortedholes[i].size * factor);
                    g.DrawString(Sortedholes[i].address.ToString(), font, Brushes.Black, new PointF(101, Sortedholes[i].address * factor + 2));
                    g.DrawString((Sortedholes[i].address + Sortedholes[i].size).ToString(), font, Brushes.Black, new PointF(101, (Sortedholes[i].address + Sortedholes[i].size) * factor + 2));
                   
                }
                label1.Visible = false;
                numh.Visible = false;
                datagridview1.Visible = false;
                submit2.Visible = true;
                label5.Visible = false;
                memorysize.Visible = false;
                label2.Visible = true;
                comboBox1.Visible = true;
                label4.Visible = true;
                textBox1.Visible = true;
                deallocate.Visible = true;
                pictureBox1.Visible = true;
       
             
                pictureBox1.Image = image;
                submit2.Visible = false;
                label1.Visible = false;
                label3.Visible = true;
                process_size.Visible = true;
                button1.Visible = true;
            }

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
            int n;
            bool isNumeric = int.TryParse(process_size.Text, out n);
            if ((!isNumeric))
            {
                MessageBox.Show("You have to enter valid process size to allocate");
                return;
            }
            int processsize = Int32.Parse(process_size.Text);
            if (processsize <= 0)
            {
                MessageBox.Show("You have to enter valid positive process size to allocate");
                return;
            }


            if (comboBox1.Text == "First fit")
                Sortedholes = holes.OrderBy(o => o.address).ToList();
            else if (comboBox1.Text == "Best fit")
                Sortedholes = holes.OrderBy(o => o.size).ToList();
            else
            { MessageBox.Show("You have to choose allocation type!");
            return;

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
                Bitmap image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                Graphics g;
                g = Graphics.FromImage(image);
                int height = Int32.Parse(memorysize.Text);
                float factor =(float) 430 / height;
                //MessageBox.Show(Sortedholes[0].size.ToString());
                g.FillRectangle(Brushes.Black, 0, 10, 100, 430);
                for (int i = 0; i < Sortedholes.Count(); i++)
                {
                    g.FillRectangle(Brushes.White, 0, (Sortedholes[i].address) * factor + 10, 100, Sortedholes[i].size * factor);
                    g.DrawString(Sortedholes[i].address.ToString(), font, Brushes.Black, new PointF(101, Sortedholes[i].address * factor + 2));
                    g.DrawString((Sortedholes[i].address + Sortedholes[i].size).ToString(), font, Brushes.Black, new PointF(101, (Sortedholes[i].address + Sortedholes[i].size) * factor + 2));
                }
                int color = 0;
                for (int i = 0; i < allocated_processes.Count(); i++)
                {
                    if(allocated_processes[i].name%6==0)
                         g.FillRectangle(Brushes.GreenYellow, 0, allocated_processes[i].start_adress * factor +10, 100, allocated_processes[i].size * factor);
                    else if (allocated_processes[i].name % 6 == 1)
                        g.FillRectangle(Brushes.MediumAquamarine, 0, allocated_processes[i].start_adress * factor + 10, 100, allocated_processes[i].size * factor);
                    else if (allocated_processes[i].name % 6 == 2)
                        g.FillRectangle(Brushes.Orange, 0, allocated_processes[i].start_adress * factor + 10, 100, allocated_processes[i].size * factor);
                    else if (allocated_processes[i].name % 6 == 3)
                        g.FillRectangle(Brushes.DeepSkyBlue, 0, allocated_processes[i].start_adress * factor + 10, 100, allocated_processes[i].size * factor);
                    else if (allocated_processes[i].name % 6 == 4)
                        g.FillRectangle(Brushes.Pink, 0, allocated_processes[i].start_adress * factor + 10, 100, allocated_processes[i].size * factor);

                    else
                        g.FillRectangle(Brushes.Violet, 0, allocated_processes[i].start_adress * factor + 10, 100, allocated_processes[i].size * factor);
                    double y = (allocated_processes[i].start_adress + 0.5 * allocated_processes[i].size) * factor;
                    g.DrawString("p" + allocated_processes[i].name.ToString() + ", Size = " + allocated_processes[i].size.ToString(), font, Brushes.Black, new PointF(4, (float)y));
                    g.DrawString(allocated_processes[i].start_adress.ToString(), font, Brushes.Black, new PointF(101, allocated_processes[i].start_adress * factor + 2));
                    g.DrawString((allocated_processes[i].start_adress + allocated_processes[i].size).ToString(), font, Brushes.Black, new PointF(101, (allocated_processes[i].start_adress + allocated_processes[i].size) * factor + 2));
                   
                    color++;

                }
                if (allocated == 1)
                {
                    SolidBrush brush;

                    if (tempprocess.name % 6 == 0)
                        brush = new SolidBrush(Color.GreenYellow);
                    else if (tempprocess.name % 6 == 1)
                        brush = new SolidBrush(Color.MediumAquamarine);
                    else if (tempprocess.name % 6 == 2)
                        brush = new SolidBrush(Color.Orange);
                    else if (tempprocess.name % 6 == 3)
                        brush = new SolidBrush(Color.DeepSkyBlue);
                    else if (tempprocess.name % 6 == 4)
                        brush = new SolidBrush(Color.Pink);
                    else
                        brush = new SolidBrush(Color.Violet);

                    g.FillRectangle(brush, 0, Sortedholes[j].address * factor + 10, 100, tempprocess.size * factor);
                    pictureBox1.Image = image;
                    Sortedholes[j].size -= tempprocess.size;
                    Sortedholes[j].address += tempprocess.size;

                    double y = (tempprocess.start_adress + 0.5 * tempprocess.size) * factor;
                    g.DrawString("p" + tempprocess.name.ToString() + ", Size = " + tempprocess.size.ToString(), font, Brushes.Black, new PointF(4, (float)y));
                    g.DrawString(tempprocess.start_adress.ToString(), font, Brushes.Black, new PointF(101, tempprocess.start_adress * factor + 2));
                    g.DrawString((tempprocess.start_adress+tempprocess.size).ToString(), font, Brushes.Black, new PointF(101, (tempprocess.start_adress+tempprocess.size) * factor + 2));

                    if (Sortedholes[j].size == 0)
                    {
                        
                        for (int k = 0; k < holes.Count; k++)
                        {
                            if (holes[k].address == Sortedholes[j].address)
                            {
                                holes.RemoveAt(k);
                                break;
                            }

                        }
                        Sortedholes.RemoveAt(j);
                    }
                        if (comboBox1.Text == "First fit")
                            Sortedholes = holes.OrderBy(o => o.address).ToList();
                        else if (comboBox1.Text == "Best fit")
                            Sortedholes = holes.OrderBy(o => o.size).ToList();
                }
                else
                {
                    MessageBox.Show("Sorry, Allocation Failed. No Enough Memory" + "\n" + "The process will be added to the waiting queue to be allocated whenever it is possible" );
                    waiting_list.Add(tempprocess);
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
            int n;
            bool isNumeric = int.TryParse(textBox1.Text, out n);
            if ((!isNumeric))
            {
                MessageBox.Show("You have to enter valid process name to allocate");
                return;
            }
            int processsize = Int32.Parse(textBox1.Text);
            if (processsize <= 0)
            {
                MessageBox.Show("You have to enter valid process name to allocate");
                return;
            }

            
            int index=Int32.Parse(textBox1.Text);
            hole temphole=new hole();
            bool found_allocated = false; //check if process which we want to deallocat is already allocated
            for (int i = 0; i < allocated_processes.Count(); i++)
            {
                if (allocated_processes[i].name == index)
                {
                    index = i;
                    found_allocated = true;
                    break;
                }
            }

            if (!found_allocated)
            {
                MessageBox.Show("No process has this name");
                return;
            }
            else
            {

                temphole.size = allocated_processes[index].size;
                temphole.address = allocated_processes[index].start_adress;
                int found1 = 0;
                int found2 = 0;
                int k1, k2;
                for (k1 = 0; k1 < holes.Count(); k1++)
                {
                    if ((holes[k1].address + holes[k1].size) == allocated_processes[index].start_adress)
                    {
                        found1++;
                        break;
                    }
                }

                for (k2 = 0; k2 < holes.Count(); k2++)
                {
                    if ((holes[k2].address) == allocated_processes[index].start_adress + allocated_processes[index].size)
                    {
                        found2++;
                        break;
                    }
                }
                if (found1 != 0 && found2 != 0)
                {
                    temphole.size = holes[k1].size + allocated_processes[index].size + holes[k2].size;
                    temphole.address = holes[k1].address;
                    holes[k2].size = 0;
                    holes.RemoveAt(k1);

                }
                else if (found1 != 0)
                {
                    temphole.size = allocated_processes[index].size + holes[k1].size;
                    temphole.address = holes[k1].address;
                    holes.RemoveAt(k1);
                }
                else if (found2 != 0)
                {
                    temphole.size = allocated_processes[index].size + holes[k2].size;
                    temphole.address = allocated_processes[index].start_adress;
                    holes.RemoveAt(k2);
                }

                holes.Add(temphole);
                allocated_processes.RemoveAt(index);

                if (comboBox1.Text == "First fit")
                    Sortedholes = holes.OrderBy(o => o.address).ToList();
                else if (comboBox1.Text == "Best fit")
                    Sortedholes = holes.OrderBy(o => o.size).ToList();
                int done = 0;
                while (done == 0)
                {
                    done = 1;
                    for (int i = 0; i < waiting_list.Count(); i++)
                    {
                        for (int j = 0; j < Sortedholes.Count(); j++)
                        {
                            if (waiting_list[i].size <= Sortedholes[j].size)
                            {
                                waiting_list[i].start_adress = Sortedholes[j].address;
                                Sortedholes[j].size -= waiting_list[i].size;
                                Sortedholes[j].address += waiting_list[i].size;
                                if (Sortedholes[j].size == 0)
                                {

                                    for (int f = 0; f < holes.Count; f++)
                                    {
                                        if (holes[f].address == Sortedholes[j].address)
                                        {
                                            holes.RemoveAt(f);
                                            break;
                                        }

                                    }
                                    Sortedholes.RemoveAt(j);
                                }
                                allocated_processes.Add(waiting_list[i]);
                                waiting_list.RemoveAt(i);


                                Sortedholes = holes.OrderBy(o => o.address).ToList();

                                done = 0;
                                break;
                            }

                        }
                        if (done == 0)
                            break;
                    }

                }
                if (comboBox1.Text == "First fit")
                    Sortedholes = holes.OrderBy(o => o.address).ToList();
                else if (comboBox1.Text == "Best fit")
                    Sortedholes = holes.OrderBy(o => o.size).ToList();

                FontFamily ff = new FontFamily("Arial");
                System.Drawing.Font font = new System.Drawing.Font(ff, 10);
                Bitmap image = new Bitmap(pictureBox1.ClientSize.Width, pictureBox1.ClientSize.Height);
                Graphics g;
                g = Graphics.FromImage(image);
                int height = Int32.Parse(memorysize.Text);
                float factor = (float)430 / height;
                //MessageBox.Show(Sortedholes[0].size.ToString());
                g.FillRectangle(Brushes.Black, 0, 10, 100, 430);
                //g.DrawString("MEMORY", font, Brushes.White, new PointF(30, 160));
                for (int i = 0; i < Sortedholes.Count(); i++)
                {
                    g.FillRectangle(Brushes.White, 0, (Sortedholes[i].address) * factor + 10, 100, Sortedholes[i].size * factor);
                    g.DrawString(Sortedholes[i].address.ToString(), font, Brushes.Black, new PointF(101, Sortedholes[i].address * factor + 2));
                    g.DrawString((Sortedholes[i].address + Sortedholes[i].size).ToString(), font, Brushes.Black, new PointF(101, (Sortedholes[i].address + Sortedholes[i].size) * factor + 2));
                }
                int color = 0;
                for (int i = 0; i < allocated_processes.Count(); i++)
                {
                    if (allocated_processes[i].name % 6 == 0)
                        g.FillRectangle(Brushes.GreenYellow, 0, allocated_processes[i].start_adress * factor + 10, 100, allocated_processes[i].size * factor);
                    else if (allocated_processes[i].name % 6 == 1)
                        g.FillRectangle(Brushes.MediumAquamarine, 0, allocated_processes[i].start_adress * factor + 10, 100, allocated_processes[i].size * factor);
                    else if (allocated_processes[i].name % 6 == 2)
                        g.FillRectangle(Brushes.Orange, 0, allocated_processes[i].start_adress * factor + 10, 100, allocated_processes[i].size * factor);
                    else if (allocated_processes[i].name % 6 == 3)
                        g.FillRectangle(Brushes.DeepSkyBlue, 0, allocated_processes[i].start_adress * factor + 10, 100, allocated_processes[i].size * factor);
                    else if (allocated_processes[i].name % 6 == 4)
                        g.FillRectangle(Brushes.Pink, 0, allocated_processes[i].start_adress * factor + 10, 100, allocated_processes[i].size * factor);

                    else
                        g.FillRectangle(Brushes.Violet, 0, allocated_processes[i].start_adress * factor + 10, 100, allocated_processes[i].size * factor);

                    double y = (allocated_processes[i].start_adress + 0.5 * allocated_processes[i].size) * factor ;
                    g.DrawString("p" + allocated_processes[i].name.ToString() +", Size = " + allocated_processes[i].size.ToString(), font, Brushes.Black, new PointF(4, (float)y));
                    g.DrawString(allocated_processes[i].start_adress.ToString(), font, Brushes.Black, new PointF(101, allocated_processes[i].start_adress * factor + 2));
                    g.DrawString((allocated_processes[i].start_adress + allocated_processes[i].size).ToString(), font, Brushes.Black, new PointF(101, (allocated_processes[i].start_adress + allocated_processes[i].size) * factor + 2));
                    color++;

                }
                pictureBox1.Image = image;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            button3.Visible = false;
            label2.Visible = false;
            label3.Visible = false;
            label4.Visible = false;
            label7.Visible = false;
            label8.Visible = false;
            label9.Visible = false;
            label10.Visible = false;
            pictureBox1.Visible = false;
            process_size.Visible = false;
            textBox1.Visible = false;
            comboBox1.Visible = false;
            button1.Visible = false;
            deallocate.Visible = false;

            datagridview1.Visible = true;
            numh.Visible = true;
            memorysize.Visible = true;
            label1.Visible = true;
            label5.Visible = true;
            submit2.Visible = true;


            holes.Clear();
            processes.Clear();
            allocated_processes.Clear();
            Sortedholes.Clear(); 
            waiting_list.Clear();
        }





        


    }
}
