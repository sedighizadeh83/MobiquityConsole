using System.ComponentModel.DataAnnotations;

namespace MobiquityConsole.Entities
{
    public class Item
    {
        public int Id { get; protected set; }

        //weight of an item
        //from requirement weight should be between 0kg and 100kg
        [Range(0, 100,
            ErrorMessage = "Weight of item {0} must be between {1} and {2}.")]
        public decimal Weight { get; protected set; }

        //cost of an item.
        //from requirement cost should be between 0€ and 100€
        [Range(0, 100,
            ErrorMessage = "Cost of item {0} must be between {1} and {2}.")]
        public decimal Cost { get; protected set; }

        protected Item()
        {

        }

        public Item(int id, decimal weight, decimal cost) : this()
        {
            this.Id = id;
            this.Weight = weight;
            this.Cost = cost;
        }

        public void SetWeight(decimal weight)
        {
            this.Weight = weight;
        }
    }
}
