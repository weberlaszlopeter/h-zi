using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace witcher
{
    public class Class1
    {
        public struct w
        {
            public string BigMissionType {get;set;}
            public int BigMissionNumber { get; set; }

            public string LitteMissonType { get; set; }
            public int LitteMissonNumber { get; set; }

            public string ItemType { get; set; }
            public int ItemNumber { get; set; }

            public string MurderedPeopleType { get; set; }
            public int MurderedPeopleNumber { get; set; }

            public int CollectedGold { get; set; }
        }
        public List<w> Datas = new List<w>();
        public List<string> BigMN = new List<string>();
        public List<string> LittleMN = new List<string>();
        public List<string> item = new List<string>();
        public List<string> MPeople = new List<string>();

        public void AddBM()
        {
            BigMN.Add("Mission_1");
            BigMN.Add("Mission_2");
            BigMN.Add("Mission_3");
            BigMN.Add("Mission_4");
        }
        public void AddLM()
        {
            LittleMN.Add("lMission_1");
            LittleMN.Add("lMission_2");
            LittleMN.Add("lMission_3");
            LittleMN.Add("lMission_4");
        }
        public void AddItem()
        {
            item.Add("item1");
            item.Add("item2");
            item.Add("item3");
            item.Add("item4");
        }
        public void AddMp()
        {
            MPeople.Add("Pt_1");
            MPeople.Add("Pt_2");
            MPeople.Add("Pt_3");
            MPeople.Add("Pt_4");
        }
    
        public double ConvertBM(int index)
        {
            switch (index)
            {
                case 0: return 800;
                case 1: return 1000;
                case 2: return 1200;
                case 3: return 1400;
                default: return 0;
            }
        }
        public double ConvertLM(int index)
        {
            switch (index)
            {
                case 0: return 200;
                case 1: return 300;
                case 2: return 350;
                case 3: return 400;
                default: return 0;
            }
        }
        public double ConvertItem(int index)
        {
            switch (index)
            {
                case 0: return 80;
                case 1: return 70;
                case 2: return 100;
                case 3: return 140;
                default: return 0;
            }
        }
        public double ConvertMP(int index)
        {
            switch (index)
            {
                case 0: return 8000;
                case 1: return 10000;
                case 2: return 12000;
                case 3: return 14000;
                default: return 0;
            }
        }
        
        public void Addw(string bmt,decimal bmn,string lmt, decimal lmn,string itemt, decimal itemn,string mpt,
            decimal mpn, decimal goldcollect)
        {
            Datas.Add(new w
            {
                BigMissionType = bmt,
                BigMissionNumber = Convert.ToInt32(bmn),
                LitteMissonType  =lmt,
                LitteMissonNumber = Convert.ToInt32(lmn),
                ItemType = itemt,
                ItemNumber = Convert.ToInt32(itemn),
                MurderedPeopleType = mpt,
                MurderedPeopleNumber = Convert.ToInt32(mpn),
                CollectedGold = Convert.ToInt32(goldcollect)
            });
        }
        public double AllCGold(int bmt,decimal bmn, int lmt, decimal lmn, int itemt, decimal itemn, int mpt,
            decimal mpn, decimal goldcollect)
        {
            double all = ConvertBM(bmt) * Convert.ToDouble(bmn) + ConvertLM(lmt) * Convert.ToDouble(lmn) + ConvertItem(itemt)
                * Convert.ToDouble(itemt) + ConvertMP(mpt) * Convert.ToDouble(mpn) + Convert.ToDouble(goldcollect);
            return all;
        }
    }
}
