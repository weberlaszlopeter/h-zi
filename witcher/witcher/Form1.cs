using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
namespace witcher
{
    public partial class Form1 : Form
    {
        Class1 c;
        public Form1(Class1 a)
        {
            c = a;
            c.AddBM();
            c.AddLM();
            c.AddItem();
            c.AddMp();
            InitializeComponent();
            start();

            foreach (var item in c.BigMN)
            {
                comboBox1.Items.Add(item);
            }
            foreach (var item in c.LittleMN)
            {
                comboBox2.Items.Add(item);
            }
            foreach (var item in c.item)
            {
                comboBox3.Items.Add(item);
            }
            foreach (var item in c.MPeople)
            {
                comboBox4.Items.Add(item);
            }

            button1.Click += (s, e) =>
            {
                c.Addw(
                    comboBox1.SelectedItem.ToString(), numericUpDown1.Value,
                    comboBox2.SelectedItem.ToString(), numericUpDown2.Value,
                    comboBox3.SelectedItem.ToString(), numericUpDown3.Value,
                    comboBox4.SelectedItem.ToString(), numericUpDown4.Value, numericUpDown5.Value);
                Form2 nf = new Form2(c);
                nf.Show();
                this.Hide();
            };
            button2.Click += (s, e) =>
            {
                comboBox1.SelectedIndex = -1;
                comboBox2.SelectedIndex = -1;
                comboBox3.SelectedIndex = -1;
                comboBox4.SelectedIndex = -1;
                numericUpDown1.Value = 0;
                numericUpDown2.Value = 0;
                numericUpDown3.Value = 0;
                numericUpDown4.Value = 0;
                numericUpDown5.Value = 0;
            };
            button3.Click += (s, e) =>
            {
                StreamWriter ki = new StreamWriter("save.txt");
                ki.WriteLine(
                    comboBox1.SelectedItem.ToString() + " " + numericUpDown1.Value + " " +
                    comboBox2.SelectedItem.ToString() + " " + numericUpDown2.Value + " " +
                    comboBox3.SelectedItem.ToString() + " " + numericUpDown3.Value + " " +
                    comboBox4.SelectedItem.ToString() + " " + numericUpDown4.Value + " " + numericUpDown5.Value
                    );
                                
            };
            button4.Click += (s, e) =>
            {
                using (OpenFileDialog open = new OpenFileDialog())
                {
                    open.InitialDirectory = AppDomain.CurrentDomain.BaseDirectory;
                    open.Filter = "txt files (.txt)|.txt|All files (.)|*.*";
                    if (open.ShowDialog() == DialogResult.OK)
                    {
                        var openfile = open.OpenFile();
                        StreamReader r = new StreamReader(openfile);
                        string fejlec = r.ReadLine();
                        while (!r.EndOfStream)
                        {
                            string[] tmp = r.ReadLine().Split(' ');
                            c.Addw(tmp[0], Convert.ToInt32(tmp[1]), tmp[2], Convert.ToInt32(tmp[3])
                                , tmp[4], Convert.ToInt32(tmp[5]), tmp[6], Convert.ToInt32(tmp[7]),
                                Convert.ToInt32(tmp[8]));
                        }
                        r.Close();
                    }
                }
            };
            button5.Click += (s, e) =>
            {
                Application.Exit();
            };
            comboBox1.SelectedValueChanged += (s, e) => { allselectedgold(); };
            comboBox2.SelectedValueChanged += (s, e) => { allselectedgold(); };
            comboBox3.SelectedValueChanged += (s, e) => { allselectedgold(); };
            comboBox4.SelectedValueChanged += (s, e) => { allselectedgold(); };
            numericUpDown1.ValueChanged += (s, e) => { allselectedgold(); };
            numericUpDown2.ValueChanged += (s, e) => { allselectedgold(); };
            numericUpDown3.ValueChanged += (s, e) => { allselectedgold(); };
            numericUpDown4.ValueChanged += (s, e) => { allselectedgold(); };
            numericUpDown5.ValueChanged += (s, e) => { allselectedgold(); };
        }
        private string allselectedgold()
        {
            return textBox1.Text = c.AllCGold(
                comboBox1.SelectedIndex, numericUpDown1.Value,
                comboBox2.SelectedIndex, numericUpDown2.Value,
                comboBox3.SelectedIndex, numericUpDown3.Value,
                comboBox4.SelectedIndex, numericUpDown4.Value,numericUpDown5.Value).ToString();
        }
        private void start()
        {
                label1.Text = "BigMission";
                label2.Text = "LittleMission";
                label3.Text = "ItemCollected";
                label4.Text = "MurderedPeople";
                label5.Text = "CollectedPlusGold";
                label6.Text = "Collected Gold";
                button1.Text = "Add";
                button2.Text = "Clear";
                button3.Text = "Expot";
                button4.Text = "Import";
                button5.Text = "Exit";
        }
    }
}


