using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OrderApi.Models
{
    public class OrderService
    {
        public OrderService() { }

        
        
        public void ModifyOrder(Order order,OrderContext db)
        {
            DeleteOrder(order.OrderID,db);

            db.Database.EnsureCreated();
            //database
            
                db.Orders.Add(order);
                db.SaveChanges();
        }


        public void DeleteOrder(int orderID,OrderContext connect)
        {

            //database
  
                var order = connect.Orders.Include("OrderDetails").FirstOrDefault(o => o.OrderID == orderID);
                if (order != null)
                {
                    connect.Orders.Remove(order);
                    connect.SaveChanges();
                }
            
        }


        public void AddOrder(Order order,OrderContext db)
        {
            //database
                db.Orders.Add(order);
                db.SaveChanges();
        }


        public List<Order> SelectByCustomer(string customer,OrderContext connect)
        {
            //database

                var query1 = connect.Orders
                             .Where(o => o.Customer.Equals(customer));
                return query1.ToList();
            
        }

        public Order SelectByOrderID(int id,OrderContext connect)
        {
            //database

                var query1 = connect.Orders
                             .Where(o => o.OrderID == id);
                 List<Order> list= query1.ToList();
            return list.FirstOrDefault();
        }

        public List<Order> SelectByMoney(double money,OrderContext connect)
        {
            //database

                var query1 = connect.Orders
                             .Where(o => o.Money == money);
                return query1.ToList();
            
        }

    }
    

}
