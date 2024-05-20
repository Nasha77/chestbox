using System.Collections;
using System.Collections.Generic;

namespace A1
{
    public class Potion : Item
    {
        private string effectType;
        private int effectValue;

        public Potion(string id, string name, string desc, int cost, int sellPrice, string effectType, int effectValue) : base(id, name, desc, "POTION", true, cost, sellPrice)
        {
            this.effectType = effectType;
            this.effectValue = effectValue;
        }

        public string GetEffectType()
        {
            return effectType;
        }

        public int GetEffectValue()
        {
            return effectValue;
        }

        public override string GetStatString()
        {
            return effectType + " +" + effectValue;
        }
    }
}