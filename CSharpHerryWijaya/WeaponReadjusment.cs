using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharpHerryWijaya
{
    public static class WeaponReadjusment
    {
        private static readonly Random random = new Random();
        private static  double Common => random.Next(5000, 10001)/1000d;
        private static double Rare => random.Next(10001, 20001) / 1000d;
        private static double Ultimate => random.Next(20001, 30001) / 1000d;
        private static double Transcendent => random.Next(30001, 40001) / 1000d;
        
        public static (string,double) GeneratePercentage()
        {
            var output = 0;
            output = random.Next(4);
            if (output == 0)
            {
                return ("White",Common);
            }
            else if (output == 1) {
                return ("Blue", Rare);
            }
            else if (output == 2) { 
                return ("Purple", Ultimate);
            }
            else { 
                return ("Yellow", Transcendent);
            }
        }
        public static List<string> Readjusments=new List<string>()
        {
            "Weak Point",
            "Critical Hit Damage",
            "Firearm Atk",
            "Toxic Atk",

            "Critical Hit Rate",
            "Multi Hit Rate",
            "Multi Hit Damage",

            "Fire Rate",
            "Movement Speed",
            "Recoil",
            "Accuracy",
            "Reload Speed",
        };
        
        public static List<String> GenerateReadjustment(List<string> currentList,List<int> checkedBox)
        {
       
            List<string> output =new List<string>( Readjusments);
            foreach (var item in currentList)
            {
                output.Remove(item);
            }
            var momo=new List<string>();
            for (int i = 0; i < 4; i++)
            {
                if (checkedBox[i] == 1)
                {
                    momo.Add("anon");
                }
                else
                {

               
                    int index = random.Next(output.Count);
                string meong = output[index];
                momo.Add(meong);
                output.RemoveAt(index);
                }
            }

            return momo;
        }


    }



}
