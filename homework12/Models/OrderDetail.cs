using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data;

namespace OrderApi.Models
{
    [Table("OrderDetails")]
    public class OrderDetail
    {
        [Key]
        public int DetailID { get; set; }
        public string Goodsname { get; set; }
        public double Price { get; set; }
        private int number;

        public int OrderID { get; set; }
        //public Order Order { get; set; }
        public int Number
        {
            get => number;
            set
            {
                if (value < 0) Console.WriteLine("输入不合法");
                else number = value;
            }
        }
        public OrderDetail(int detailID, string goodsname, double price, int number)
        {
            this.DetailID = detailID;
            this.Goodsname = goodsname;
            this.number = number;
            this.Price = price;
        }
        public OrderDetail() { }

        public double GetallPrice()
        {
            return Price * number;
        }

        public override string ToString()
        {
            return $"商品名称：{Goodsname}\n\t单价：{Price}\n\t数量：{number}\n\t总金额：{GetallPrice()}";
        }

        public override bool Equals(Object obj)
        {
            OrderDetail orderdetail = obj as OrderDetail;
            return this.Goodsname == orderdetail.Goodsname && this.Price == orderdetail.Price && this.Number == orderdetail.Number;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }
    }
}
