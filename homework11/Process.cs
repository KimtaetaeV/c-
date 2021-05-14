using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.MySqlClient;
using System.Data;

namespace homework8
{

    [DbConfigurationType(typeof(MySql.Data.EntityFramework.MySqlEFConfiguration))]
    public class OrdergContext : DbContext
    {
        public OrdergContext() : base("OrderDataBase")
        {
            Database.SetInitializer(
                new DropCreateDatabaseIfModelChanges<OrdergContext>()
                );
        }

        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrderDetails { get; set; }

    }

    [Serializable]
    public class OrderService
    {

        public List<Order> orderlist = new List<Order>();

        public void Export()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream f1 = new FileStream("order.xml", FileMode.Create))
            {
                xml.Serialize(f1, this.orderlist);
            }
            //Console.WriteLine("序列化完成");

        }

        public void Import()
        {
            XmlSerializer xml = new XmlSerializer(typeof(List<Order>));
            using (FileStream f1 = new FileStream("order.xml", FileMode.Open))
            {
                List<Order> orders = (List<Order>)xml.Deserialize(f1);
                foreach (Order o in orders)
                {
                    Console.WriteLine(o);
                }
                //Console.WriteLine("反序列化完成");
            }
        }


        public OrderService() { }

        public List<Order> ShowOrders()
        {
            orderlist.Sort();

            return orderlist;
        }

        public void ModifyOrder(Order order)
        {
            DeleteOrder(order.OrderID);
            orderlist.Add(order);
            //database
            using(var db=new OrdergContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }

        }


        public void DeleteOrder(int orderID)
        {
           
            //database
            using(var connect=new OrdergContext())
            {
                var order = connect.Orders.Include("OrderDetails").FirstOrDefault(o => o.OrderID == orderID);
                if (order != null)
                {
                    connect.Orders.Remove(order);
                    connect.SaveChanges();
                }
            }
        }


        public void AddOrder(Order order)
        {
            if (orderlist.Contains(order))
            {
                throw new Exception($"订单号为{order.OrderID}的订单已存在！");
            }
            else
            {
                orderlist.Add(order);
            }
            //database
            using(var db=new OrdergContext())
            {
                db.Orders.Add(order);
                db.SaveChanges();
            }
        }


        public List<Order> SelectByCustomer(string customer)
        {
            //database
            using(var connect=new OrdergContext())
            {
                var query1 = connect.Orders
                             .Where(o => o.Customer.Equals(customer));
                return query1.ToList();
            }   
        }

        public List<Order> SelectByOrderID(int id)
        {
            //database
            using (var connect = new OrdergContext())
            {
                var query1 = connect.Orders
                             .Where(o => o.OrderID==id);
                return query1.ToList();
            }
        }

        public List<Order> SelectByMoney(double money)
        {
            //database
            using (var connect = new OrdergContext())
            {
                var query1 = connect.Orders
                             .Where(o => o.Money==money);
                return query1.ToList();
            }
        }

    }

    //单个订单
    [Serializable]
    [Table("Orders")]
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

        public void AddDetail( OrderDetail orderDetail)
        {
            if (this.orderDetails == null)
            {
                orderDetails = new List<OrderDetail>();
            }

            //orderDetails.Add(orderDetail);
            //数据库
            using(var db=new OrdergContext())
            {
                //this.orderDetails.Add(orderDetail);
                orderDetail.OrderID = this.OrderID;
                this.orderDetails.Add(orderDetail);
                //db.Entry(orderDetail).State = EntityState.Added;
                this.Money = getMoney();
                db.OrderDetails.Add(orderDetail);
                this.Money = getMoney();
                db.SaveChanges();
            }
        
        /*
            String connetStr = "server=127.0.0.1;port=3306;user=root;password=cyx123456; database=OrderDB;";
            MySqlConnection conn = new MySqlConnection(connetStr);

            conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句

            orderDetail.OrderID = this.OrderID;
            this.orderDetails.Add(orderDetail);

            string sql = $"update Orders set Money={this.getMoney()} where OrderID = {this.OrderID}";

            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
            {

                using (DataTable ds = new DataTable())
                {
                    
                    dataAdapter.Fill(ds);
                    //this.dataGridView1.DataSource = ds;
                }
            }
            conn.Close();
        */
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

    //明细
    [Serializable]
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

