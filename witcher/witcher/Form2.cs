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
    public partial class Form2 : Form
    {
        Class1 c;
        public Form2(Class1 a)
        {
            c = a;
            InitializeComponent();
            start();
            feltolt();
            button1.Click += (s, e) => {
                for (int i = 0; i < listView1.Items.Count; i++)
                {
                    if (listView1.Items[i].Selected)
                    {
                        listView1.Items[i].Remove();
                        c.Datas.RemoveAt(i);
                        i--;
                    }
                }
            };
            button2.Click += (s, e) => {
                listView1.Items.Clear();
                c.Datas.Clear();
            };
            button3.Click += (s, e) => {
                StreamWriter k = new StreamWriter("save.txt");
                foreach (var item in c.Datas)
                {
                    k.WriteLine(item.BigMissionType + ";" + item.BigMissionNumber + ";" +
                        item.LitteMissonType + ";" + item.LitteMissonNumber + ";" +
                        item.ItemType + ";" + item.ItemNumber + ";" +
                        item.MurderedPeopleType + ";" + item.MurderedPeopleNumber + ";" +
                        item.CollectedGold);
                }
                k.Close();
            };
            button4.Click += (s, e) => {
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
            button5.Click += (s, e) => {
                Application.Exit();
            };
        }

        private void feltolt()
        {
            listView1.Items.Clear();
            foreach (var item in c.Datas)
            {
                string[] temp = {
                    item.BigMissionType,
                    item.BigMissionNumber.ToString(),
                    item.LitteMissonType,
                    item.LitteMissonNumber.ToString(),
                    item.ItemType,
                    item.ItemNumber.ToString(),
                    item.MurderedPeopleType,
                    item.MurderedPeopleNumber.ToString(),
                    item.CollectedGold.ToString()};
                ListViewItem items = new ListViewItem(temp);
                listView1.Items.Add(items);
            }
        }
        private void start()
        {
            button1.Text = "Delete";
            button2.Text = "Clear";
            button3.Text = "Export";
            button4.Text = "Import";
            button5.Text = "Exit";
            columnHeader1.Text = "BigMissionName";
            columnHeader2.Text = "BigMissionNumeber";
            columnHeader3.Text = "LittleMissionName";
            columnHeader4.Text = "LittleMissionNumber";
            columnHeader5.Text = "ItemName";
            columnHeader6.Text = "TtemNumber";
            columnHeader7.Text = "PeopleType";
            columnHeader8.Text = "PeopleNumber";
            columnHeader9.Text = "Gold";
            listView1.View = View.Details;
        }
    }
}
