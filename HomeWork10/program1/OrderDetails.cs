using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace program2
{   
    [Serializable]
    public class OrderDetails
    {
        public OrderDetails() {
        ID = Guid.NewGuid().ToString();
        }
        [Key]
        public string ID { get; set; }
        public string stuff { get; set; }
        public int num { get; set; }
        public int price { get; set; }
        public OrderDetails(string stuff,int num,int price) {
            this.stuff = stuff;
            this.num = num;
            this.price = price;
            ID = Guid.NewGuid().ToString();
        }
        public override string ToString()
        {
            return "商品名称为" + stuff + "，数量为" + num + "，单价为" + price+"\n";
        }
    }
}
