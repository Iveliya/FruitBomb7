using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FruityBomb.Controller
{
    public class FruityBombController
    {
        public Dictionary<string, int> Combination(string name1, string name2, string name3, string name4)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            bool isTrue = false;
            Dictionary<string, int> dic = new Dictionary<string, int>();

            if (!dic.ContainsKey(name1))
            {
                dic[name1] = 1;
            }
            else
            {
                dic[name1]++;
            }
            if (!dic.ContainsKey(name2))
            {
                dic[name2] = 1;
            }
            else
            {
                dic[name2]++;
            }
            if (!dic.ContainsKey(name3))
            {
                dic[name3] = 1;
            }
            else
            {
                dic[name3]++;
            }
            if (!dic.ContainsKey(name4))
            {
                dic[name4] = 1;
            }
            else
            {
                dic[name4]++;
            }
            foreach (var x in dic)
            {
                if (x.Value >= 3)
                {
                    result.Add(x.Key, x.Value);
                }
            }
            return result;



        }

        public double Price(string name1, string name2, string name3, string name4)
        {
            double price = 0;
            var result = Combination(name1, name2, name3, name4);
            string name = null;
            int br = 0;
            foreach (var x in result)
            {
                name = x.Key;
                br = x.Value;
            }
            double cherry = 0.80;
            double bell = 2.40;
            double eggplant = 1.30;
            double watermelon = 1.80;
            if (name == name1)
            {
                price = br * cherry;
            }
            else if (name == name2)
            {
                price = br * bell;
            }
            else if (name == name2)
            {
                price = br * eggplant;
            }
            else if (name == name2)
            {
                price = br * watermelon;
            }
            return price;
        }
        public double Balance(double balance, string name1, string name2, string name3, string name4)
        {
            var price = Price(name1, name2, name3, name4);
            double result = balance - price;
            return result;


        }
    }
}
