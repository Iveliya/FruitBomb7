using FruityBombData;
using FruityBombData.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;


namespace FruityBomb.Controller
{
    public class FruityBombController
    {
        CazinoDbContext context=new CazinoDbContext();
        public string s11 ="a";
        public string s12 = null;
        public string s13 = null;
        public string s14 = null;
        public Dictionary<string, int> Combination(int id,string name1, string name2, string name3, string name4)
        {
            Dictionary<string, int> result = new Dictionary<string, int>();
            bool isTrue = false;
            Dictionary<string, int> dic = new Dictionary<string, int>();
            //Symbol s1=context.Symbols.FirstOrDefault(x => x.SymbolId==1);
            //Symbol s2=context.Symbols.FirstOrDefault(x => x.SymbolId==2);
            //Symbol s3=context.Symbols.FirstOrDefault(x => x.SymbolId==3);
            //Symbol s4=context.Symbols.FirstOrDefault(x => x.SymbolId==4);
            s11= name1;
            s12= name2;
            s13= name3;
            s14= name4;

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

            int count = 0;
            foreach (var x in dic)
            {
                
                if (x.Value >= 3)
                {
                    result.Add(x.Key, x.Value);
                }
                
            }
            var P=context.Players.FirstOrDefault(x=>x.PlayerId== id);
            int symbolId = P.SymbolId;
            var s=context.Symbols.FirstOrDefault(context=>context.SymbolId== symbolId);
            string newSymbol = null;
            foreach (var x in result)
            {
                newSymbol=x.Key.ToString();
            }
            if (newSymbol!=null)
            {
                int symbolIddd = context.Symbols.FirstOrDefault(s => s.Name == newSymbol).SymbolId;
                P.SymbolId = symbolIddd;
                context.SaveChanges();
            }



            return result;



        }

        public decimal PayOut(int id, decimal bet)
        {

            var player = context.Players.FirstOrDefault(x => x.PlayerId == id);

            decimal price = 0;
            var name1 = s11;
            var name2 = s12;
            var name3 = s13;
            var name4 = s14;
            var result = Combination(id, name1, name2, name3, name4);
            if (result.Count == 0)
            {
                return 0;
            }
            string name = null;
            int br = 0;
            foreach (var x in result)
            {
                name = x.Key;
                br = x.Value;
            }

            Symbol cherry = context.Symbols.FirstOrDefault(x => x.SymbolId == 1);
            Symbol bell = context.Symbols.FirstOrDefault(x => x.SymbolId == 2);
            Symbol eggplant = context.Symbols.FirstOrDefault(x => x.SymbolId == 3);
            Symbol watermelon = context.Symbols.FirstOrDefault(x => x.SymbolId == 4);

            if (name == cherry.Name)
            {
                if (br == 4)
                {
                    price = (br * (cherry.Payout * (int)bet)) * 8;
                }
                else
                price = br * (cherry.Payout * (int)bet);
            }
            else if (name == bell.Name)
            {
                if (br==4)
                {
                    price = (br * (bell.Payout * (int)bet))*8;
                }
                else
                price = br * (bell.Payout * (int)bet);
            }
            else if (name == eggplant.Name)
            {
                if (br == 4)
                {
                    price = (br * (eggplant.Payout * (int)bet)) * 8;
                }
                else
                    price = br * (eggplant.Payout * (int)bet);
            }
            else if (name == watermelon.Name)
            {
                if (br == 4)
                {
                    price = (br * (watermelon.Payout * (int)bet)) * 8;
                }
                else
                    price = br * (watermelon.Payout * (int)bet);
            }
            return price;
        }
        public decimal Balance(int id,decimal balance, decimal bet)
        {
            var price = PayOut(id, bet);
            decimal result = balance - price;
            return result;
            var p = context.Players.FirstOrDefault(x=>x.PlayerId==id);  
            p.Balance = double.Parse(balance.ToString());
            context.SaveChanges();


        }
    }
}
