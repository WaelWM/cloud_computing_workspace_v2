using System.ComponentModel.DataAnnotations;

namespace MVCFlowerShopWeek3.Models
{
    public class Flower
    {
        [Key]// Primary key
        public int FlowerId { get; set; }

        public string FlowerName { get; set; }

        public string FlowerType { get; set;}

        public decimal FlowerPrice { get; set;}

        public DateTime FlowerPurchasedDate { get; set;}


    }
}
