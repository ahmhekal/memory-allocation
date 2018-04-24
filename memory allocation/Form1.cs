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

        }
        

        private void nump_TextChanged(object sender, EventArgs e)
        {
            submit2.Visible = true;
        }

     

        private void submit2_Click(object sender, EventArgs e)
        {
           
            FontFamily ff = new FontFamily("Arial");
            System.Drawing.Font font = new System.Drawing.Font(ff, 10);
            System.Drawing.Font bigfont = new System.Drawing.Font(ff, 12);
            Graphics g;
            g = this.CreateGraphics();
            SolidBrush sbgreen = new SolidBrush(Color.Green);
            int height = Sortedholes[num_holes - 1].address + Sortedholes[num_holes - 1].size;
            MessageBox.Show(height.ToString());
            g.FillRectangle(sbgreen, 80, 150, 100,300);
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

           /* if (comboBox1.Text == "First fit")
            {
                int allocated = 0;
                List<hole> Sortedholes = holes.OrderBy(o => o.address).ToList();
                for (int i = 0; i < num_processes; i++)
                {
                    allocated = 0;
                    for (int j = 0; j < num_holes; j++)
                    {
                        if (Sortedholes[j].size >= processes[i].size)
                        {
                            Sortedholes[j].size -= processes[i].size;
                            allocated = 1;
                            break;

                        }
                        MessageBox.Show(allocated.ToString());
                    }






                }
            }
            */
        }

        private void Form1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        


    }
}
