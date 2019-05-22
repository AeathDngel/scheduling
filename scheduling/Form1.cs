using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace scheduling
{
    public partial class Form1 : Form
    {
        private int count = 0; //amount of processes
        private int time = 0; //timer time
        process[] p = new process[6];
        private int lowest = int.MaxValue;
        private int temp = 0;
        private int cycle = 1; //test cycle
        private int cycount = 0;
        private int samecounter = 0;
        private int[] same = new int[6];

        public Form1()
        {
            InitializeComponent();

           

           

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            zeroitDaggerCircular1.Visible = false;
            zeroitDaggerCircular2.Visible = false;
            zeroitDaggerCircular3.Visible = false;
            zeroitDaggerCircular4.Visible = false;
            zeroitDaggerCircular5.Visible = false;
            zeroitDaggerCircular6.Visible = false;

            zeroitDaggerCircular1.Percentage = 0;
            zeroitDaggerCircular2.Percentage = 0;
            zeroitDaggerCircular3.Percentage = 0;
            zeroitDaggerCircular4.Percentage = 0;
            zeroitDaggerCircular5.Percentage = 0;
            zeroitDaggerCircular6.Percentage = 0;
        }


        private void button1_Click_1(object sender, EventArgs e)
        {
            if (count < 10)
            {
                p[count] = new process();
                addData();
                addProgressbar();

                count++;
            }
            else { MessageBox.Show("Process limit reached!"); }

        }

        private void zeroitLogPanel1_Load(object sender, EventArgs e)
        {
            
        }
        public void addData() {

            p[count].Name = txtName.Text;
            p[count].Length = Convert.ToInt32(udLength.Value);
            p[count].Priority = Convert.ToInt32(udPriority.Value);
            p[count].Arrivaltime = time;
            p[count].Completed = false;
            p[count].Cycle = false;
           
        }

      

        public void addProgressbar()
        {
           switch (count) {
                case 0: zeroitDaggerCircular1.Visible = true; label1.Text = p[0].toString(); 
                    break;
                case 1:
                    zeroitDaggerCircular2.Visible = true; label2.Text = p[1].toString();
                    break;                                             
                case 2:                                                
                    zeroitDaggerCircular3.Visible = true; label3.Text = p[2].toString();
                    break;                                             
                case 3:                                                 
                    zeroitDaggerCircular4.Visible = true; label4.Text = p[3].toString();
                    break;                                            
                case 4:                                                 
                    zeroitDaggerCircular5.Visible = true; label5.Text = p[4].toString();
                    break;                                             
                case 5:                                                   
                    zeroitDaggerCircular6.Visible = true; label6.Text = p[5].toString();
                    break;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Start();

           

        }
        //Priority
        public void runPriority() {

            for (int i = 0; i < count; i++)
            {
                if (p[i].Completed == false)//if not completed yet
                {
                    if (p[i].Priority < lowest)
                    {
                        temp = i;
                        lowest = p[i].Priority;
         
                    }
                }
            }

            increment(temp);
        }
        //Increment
        public void increment(int inc)
        {

            switch (inc)
            {
                case 0:
                    if (zeroitDaggerCircular1.Percentage < 100) {
                        zeroitDaggerCircular1.Percentage += (100 / p[0].Length); 
                            if (zeroitDaggerCircular1.Percentage >= 100) {
                                p[0].Completed = true; lowest = int.MaxValue;
                        } }
                    break;
                case 1:
                    if (zeroitDaggerCircular2.Percentage < 100)
                    {
                        zeroitDaggerCircular2.Percentage += (100 / p[1].Length);
                        if (zeroitDaggerCircular2.Percentage >= 100)
                        {
                            p[1].Completed = true; lowest = int.MaxValue;
                        }
                    }
                    break;
                case 2:
                    if (zeroitDaggerCircular3.Percentage < 100)
                    {
                        zeroitDaggerCircular3.Percentage += (100 / p[2].Length);
                        if (zeroitDaggerCircular3.Percentage >= 100)
                        {
                            p[2].Completed = true; lowest = int.MaxValue;
                        }
                    }
                    break;
                case 3:
                    if (zeroitDaggerCircular4.Percentage < 100)
                    {
                        zeroitDaggerCircular4.Percentage += (100 / p[3].Length);
                        if (zeroitDaggerCircular4.Percentage >= 100)
                        {
                            p[3].Completed = true; lowest = int.MaxValue;
                        }
                    }
                    break;
                case 4:
                    if (zeroitDaggerCircular5.Percentage < 100)
                    {
                        zeroitDaggerCircular5.Percentage += (100 / p[4].Length);
                        if (zeroitDaggerCircular5.Percentage >= 100)
                        {
                            p[4].Completed = true; lowest = int.MaxValue;
                        }
                    }
                    break;
                case 5:
                    if (zeroitDaggerCircular6.Percentage < 100)
                    {
                        zeroitDaggerCircular6.Percentage += (100 / p[5].Length);
                        if (zeroitDaggerCircular6.Percentage >= 100)
                        {
                            p[5].Completed = true; lowest = int.MaxValue;
                        }
                    }
                    break;
            }


        }
        //Round robin
        public void runRRobin(int quantum) {

            
            
            if (p[cycount].Cycle == true)
            {
               
                    cycount++;
                
            }
           
                if (p[cycount].Completed == false)//if not completed yet
                {
                if (p[cycount].Cycle == false) {
                    increment(cycount);
                    cycle++;
                    if (cycle > quantum) {
                        p[cycount].Cycle = true;
                        cycle = 1;
                    }
                }
            }
            else if (p[cycount].Completed == true)
            {
                p[cycount].Cycle = true;
                cycle = 1;
            }

            if (cycount == count -1)
            {
                cycount = 0;
                for (int i = 0; i < count; i++)
                {
                    p[i].Cycle = false;
                }
            }



        }

        //Multiple queues
        public void runMultiple(int quantum) {

            
            

            //priority
            if (samecounter == 0)
            {
                for (int i = 0; i < count; i++)
                {
                    if (p[i].Completed == false)//if not completed yet
                    {
                        if (p[i].Priority < lowest)
                        {
                            temp = i;
                            lowest = p[i].Priority;

                        }
                    }
                }
                same[0] = temp;
                for (int j = 0; j < count; j++)
                {
                    if (j != temp && p[j].Priority == p[temp].Priority && p[j].Completed == false)
                    {
                        samecounter++;
                        same[samecounter] = j;
                    }
                }
            }


            //if (p[same[cycount]].Completed == false)
            if (cycle > quantum)
            {
                cycount++;
                cycle = 1;
            }
            else {
                cycle++;
            }
            if (cycount > samecounter)
                cycount = 0;

            increment(same[cycount]);

            if (p[same[cycount]].Completed == true)
            {
                samecounter = 0;
                cycle = 1;
                cycount = 0;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

            time++;

            label13.Text = "Time: " + time.ToString() + "s";

            //calculate quantum
            int sum = 0;
            for (int q = 0; q < count; q++)
            {
                sum += p[q].Length;
            }
            int quantum = sum / count;
           

            if (rbtnPriority.Checked)
            {
                label12.Text = String.Empty;
                runPriority();
            }
            else if (rbtnRRobin.Checked)
            {
                label12.Text = "Quantum: " + quantum + "s";
                runRRobin(quantum);
            }
            else if (rbtnMultiple.Checked)
            {
                label12.Text = "Quantum: " + quantum + "s";
                runMultiple(quantum);
            }
        }
    }
}
