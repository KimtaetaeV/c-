using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace homework5
{
    class Program
    {
        //测试
        static void Main(string[] args)
        {
            OrderDetail od1 = new OrderDetail("香蕉", 10.0, 4);
            OrderDetail od2= new OrderDetail("铅笔", 2.0, 6);
            OrderDetail od3 = new OrderDetail("保温杯", 40.5, 1);
            OrderDetail od4 = new OrderDetail("鲜花", 15.0, 4);
            OrderDetail od5 = new OrderDetail("台灯", 30.0, 2);
            Order order1 = new Order(2001,"十月一日","王小明");
            Order order2 = new Order(2003, "十月五日", "王小明");
            Order order3 = new Order(2022, "十一月一日", "李二百");
            order1.orderDetails.Add(od1);
            order1.orderDetails.Add(od2);
            order2.orderDetails.Add(od3);
            order3.orderDetails.Add(od4);
            order3.orderDetails.Add(od5);
            OrderService service = new OrderService();
            List<Order> orders = new List<Order>();
            { orders.Add(order1); orders.Add(order2); orders.Add(order3); }
            service.orderlist = orders;

            int choose = 0;
            while (choose != 6)
            {
                Console.WriteLine("选择服务类型：1展示订单，2查询订单，3修改订单，4删除订单 5增加订单 6结束操作");
                choose = Int32.Parse(Console.ReadLine());
                try
                {
                    switch (choose)
                    {
                        case 1: service.PrintOrder(); break;
                        case 2:
                            Console.WriteLine("1.由客户名查询 2.由订单号查询，3.由订单总金额查询");
                            int choose2 = Int32.Parse(Console.ReadLine());
                            service.SelectOrder(choose2); break;
                        case 3: service.ModifyOrder(); break;
                        case 4: service.Delete(); break;
                        case 5: service.AddOrder(); break;
                        case 6: break;
                        default: Console.WriteLine("输入不合法！"); break;
                    }
                }catch(Exception e) { Console.WriteLine(e); }
                }
        }
    }

    //订单服务
    public class OrderService
    {
        public List<Order> orderlist = new List<Order>();


        public void ModifyOrder()
        {
            Console.WriteLine("输入要修改的订单号");
            int id = Int32.Parse(Console.ReadLine());
            int index = -1;
            foreach (Order o in orderlist)
            {
                if (o.OrderID == id) index = orderlist.IndexOf(o);
            }
            if (index == -1)
            {
                Exception e4 = new Exception("订单号不存在！");
                throw e4;
            }
            Console.WriteLine("输入1修改订单，输入2修改订单明细");
            int select = Int32.Parse(Console.ReadLine());
            switch (select)
            {
                case 1:
                    Console.WriteLine("输入添加的订单号：");
                    int id2 = Int32.Parse(Console.ReadLine().ToString());
                    Console.WriteLine("输入添加的客户名称：");
                    string name = Console.ReadLine().ToString();
                    Console.WriteLine("输入添加的订单日期：");
                    string date = Console.ReadLine().ToString();
                    Order order = new Order(id2, name, date);
                    orderlist[index] = order;
                    Console.WriteLine("订单已修改！");
                    break;
                case 2:
                    Console.WriteLine("输入添加的订单明细的商品名称：");
                    string name2 = Console.ReadLine().ToString();
                    Console.WriteLine("输入添加的订单明细的商品单价：");
                    double price = Double.Parse(Console.ReadLine().ToString());
                    Console.WriteLine("输入添加的订单明细的商品数量：");
                    int number = Int32.Parse(Console.ReadLine().ToString());
                    OrderDetail orderdetail = new OrderDetail(name2, price, number); 
                    orderlist[index].orderDetails.RemoveAll(delegate (OrderDetail item) { return true; });
                    orderlist[index].orderDetails.Add(orderdetail);
                    Console.WriteLine("明细已修改！");
                    break;
                default: Console.WriteLine("输入参数不正确！"); break;
            }
        }

        public void Delete()
        {
            Console.WriteLine("输入要删除的订单号");
            int id = Int32.Parse(Console.ReadLine());
            int index = -1;
            foreach(Order o in orderlist)
            {
                if (o.OrderID == id) index = orderlist.IndexOf(o);
            }
            if (index == -1)
            {
                Exception e3 = new Exception("订单号不存在！");
                throw e3;
            }
            Console.WriteLine("输入1删除订单，输入2删除订单明细");
            int select = Int32.Parse(Console.ReadLine());
            switch (select)
            {
                case 1:orderlist.RemoveAt(index);Console.WriteLine("删除成功！"); break;
                case 2:orderlist[index].orderDetails.RemoveAll(delegate (OrderDetail item) { return true; }) ; break;
                default:Console.WriteLine("输入参数不正确！");break;
            }
        }

        public void PrintOrder()
        {

            var query = orderlist
                .OrderByDescending(order => order.OrderID);
            foreach(Order o in orderlist)
            {
                Console.WriteLine(o.ToString());
                o.PrintDetail();
            }
        }
        public void AddOrder()
        {
            bool same = false;
            bool judge = false;
            Console.WriteLine("输入添加的订单号：");
            int id = Int32.Parse(Console.ReadLine().ToString());
            Console.WriteLine("输入添加的客户名称：");
            string name = Console.ReadLine().ToString();
            Console.WriteLine("输入添加的订单日期：");
            string date = Console.ReadLine().ToString();
            Order order = new Order(id, name, date);
            foreach(Order o1 in orderlist)
            {
                if (o1.Equals(order))
                {
                    same = true;
                    Exception e1 = new Exception("订单id重复");
                    throw e1;
                }
            }
            if (!same) orderlist.Add(order);
            while (!same && !judge)
            {
                Console.WriteLine("输入添加的订单明细的商品名称：");
                string name2 = Console.ReadLine().ToString();
                Console.WriteLine("输入添加的订单明细的商品单价：");
                double price = Double.Parse( Console.ReadLine().ToString());
                Console.WriteLine("输入添加的订单明细的商品数量：");
                int number =Int32.Parse( Console.ReadLine().ToString());
                OrderDetail orderdetail = new OrderDetail(name2, price, number);
                foreach(OrderDetail o2 in order.orderDetails)
                {
                    if (o2.Equals(orderdetail))
                    {
                        same = true;
                        Exception e2 = new Exception("订单明细重复！");
                        throw e2;
                    }
                }
                if (!same) order.orderDetails.Add(orderdetail);
                Console.WriteLine("添加成功！");
                Console.WriteLine("是否继续添加？(1:是；2：否)");
                int judge1 = Int32.Parse(Console.ReadLine());
                if (judge1 == 2) Console.WriteLine("操作结束！");
                judge = judge1 == 1 ? false : true;
            }
        }

        public void SelectOrder(int i)
        {
            switch (i)
            {
                case 1:
                    Console.WriteLine("输入要查询的客户名称");
                    string name = Console.ReadLine().ToString();
                    var query1 = from order1 in orderlist
                                 where order1.customer.Equals(name)
                                orderby order1.money
                                select order1;
                    List<Order> list1 = query1.ToList();
                    if (list1.Count == 0) { Console.WriteLine($"不存在姓名为{name}的用户！"); }
                    else
                    foreach(Order o in list1)
                    {
                        Console.WriteLine(o.ToString());
                        o.PrintDetail();

                    }
                        break;
                case 2:
                    Console.WriteLine("输入要查询的订单号");
                    string id = Console.ReadLine().ToString();
                    var query2 = from order2 in orderlist
                                 where order2.OrderID == Int32.Parse(id)
                                 orderby order2.money
                                select order2;
                    List<Order> list2 = query2.ToList();
                    foreach (Order o in list2)
                    {
                        Console.WriteLine(o.ToString());
                        o.PrintDetail();

                    }
                    break;
                case 3:
                    Console.WriteLine("输入要查询的订单金额");
                    string money2 = Console.ReadLine().ToString();
                    var query3 = from order3 in orderlist
                                 where order3.money == Int32.Parse(money2)
                                 select order3;
                    List<Order> list3 = query3.ToList();
                    foreach (Order o in list3)
                    {
                        Console.WriteLine(o.ToString());
                        o.PrintDetail();

                    }
                    break;
                default:break;
            }

            
        }
    }

    //单个订单
    public class Order
    {
        public int OrderID;
        public string orderDate;
        public string customer;
        public double money;
        public List<OrderDetail> orderDetails = new List<OrderDetail>();

        
        public Order(int id,string date,string customer) {
            this.OrderID = id;
            this.customer = customer;
            this.orderDate = date;
        }

        public Order() { }
  
        public double getMoney()
        {
            double m = 0;
            foreach(OrderDetail order in orderDetails)
            {
                m += order.getallPrice();
            }
            this.money = m;
            return this.money;
        }

        public override bool Equals(Object obj)
        {
            Order order = obj as Order;
            return this.OrderID == order.OrderID;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public new string ToString()
        {
            return $"订单号：{OrderID}\n订单日期：{orderDate}\n订单金额：{getMoney()}";
        }

        public void PrintDetail()
        {
            foreach(OrderDetail o in orderDetails)
            {
                Console.WriteLine( o.ToString());
                
            }
        }
        
    }

    //明细
    public class OrderDetail
    {
        public string goodsname;
        public double price;
        private int number;
        public int Number {
            get => number;
            set
            { if (value < 0) Console.WriteLine("输入不合法");
                else number = value;
            }
        }
        public OrderDetail(string name,double price,int number)
        {
            goodsname = name;
            this.number = number;
            this.price = price;
        }
        public OrderDetail() { }

        public double getallPrice()
        {
            return price * number;
        }

        public override bool Equals(Object obj)
        {
            OrderDetail orderdetail = obj as OrderDetail;
            return this.goodsname == orderdetail.goodsname && this.price == orderdetail.price && this.Number == orderdetail.Number;

        }

        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        public  new string ToString()
        {
            return $"商品名：{goodsname}，单价：{price}，数量：{Number},总价：{getallPrice()}";
        }

    }
}
