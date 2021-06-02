using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

using System.Data;

namespace OrderApi.Models
{
    public class Order : IComparable<Order>
    {
        [Key]
        public int OrderID { get; set; }
        public string OrderDate { get; set; }
        public string Customer { get; set; }
        public double Money { get; set; }

        public List<OrderDetail> orderDetails { get; set; }


        public double getMoney()
        {
            double m = 0;
            if (orderDetails != null)

            {
                orderDetails.ForEach(od => m += od.GetallPrice());
            }
            return m;
        }
        public Order(int id, string date, string customer)
        {
            this.OrderID = id;
            this.Customer = customer;
            this.OrderDate = date;
            this.Money = getMoney();
        }

        public void AddDetail(OrderDetail orderDetail)
        {
            if (this.orderDetails == null)
            {
                orderDetails = new List<OrderDetail>();
            }

        }

        public Order() { }

        public override string ToString()
        {
            string order = $"\n订单id：{OrderID}\n订单日期：{OrderDate}\n订单客户：{Customer}\n订单金额：{Money}";
            orderDetails.ForEach(o => order += "\n\t" + o.ToString());
            return order;
        }

        public override bool Equals(Object obj)
        {
            Order order = obj as Order;
            return this.OrderID == order.OrderID && this.OrderDate == order.OrderDate && this.Customer == order.Customer && this.Money == order.Money;

        }

        public override int GetHashCode()
        {
            return OrderID;
        }

        public int CompareTo(Order other)
        {
            Order o = other as Order;
            return this.OrderID - o.OrderID;
            throw new NotImplementedException();
        }
    }
}
