using System.Collections;
using System.Collections.Generic;

namespace A1
{
    public class Weapon : Item
    {
        private int atk;

        public Weapon(string id, string name, string desc, int cost, int sellPrice, int atk) : base(id, name, desc, "WEAPON", false, cost, sellPrice)
        {
            this.atk = atk;
        }

        public int GetAtk()
        {
            return atk;
        }

        public override string GetStatString()
        {
            return "Atk: " + atk;
        }
    }
}