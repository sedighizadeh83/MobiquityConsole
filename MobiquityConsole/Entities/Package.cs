using System.ComponentModel.DataAnnotations;

namespace MobiquityConsole.Entities
{
    public class Package
    {
        //items of the package
        //from requirement there could be maximum 15 items to choose from
        //so the maximum number of items in a package could be 15
        [MaxLength(15, ErrorMessage = "The might be up to 15 items you need to choose from.")]
        public List<Item> Items { get; set; } = new List<Item>();

        //total weight of package
        //equals to sum of weight of all items in the package
        //from requirement the maximum weight of package could be 100kg
        [Range(0, 100,
            ErrorMessage = "Weight of package {0} must be between {1} and {2}.")]
        public decimal TotalWeight
        {
            get { return this.Items.Select(x => x.Weight).Sum(); }
        }

        //total cost of package
        //equals to sum of cost of all items in the package
        public decimal TotalCost
        {
            get { return this.Items.Select(x => x.Cost).Sum(); }
        }

        //the nominal capacity of the package
        public decimal Capacity { get; set; }
    }
}
