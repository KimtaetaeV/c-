using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MySql.Data.MySqlClient;



namespace homework8
{
    public partial class Form1 : Form
    {
        public OrderService service = new OrderService();
        public List<Order> orders = new List<Order>();
        //public List<Order> orders2 = new List<Order>();
        //public List<OrderDetail> orderDetails = new List<OrderDetail>();
        public int OrderID { get; set; }
        public string Customer { get; set; }

        public string Date { get; set; }
        public Form1()
        {
            //init();
            InitializeComponent();
            IDBox4.DataBindings.Add("Text", this, "OrderID");
            
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex != 0 || e.RowIndex == -1) { return; }
            else
            {
                DataGridViewCell cell = this.dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                if (cell == null || cell.Value.ToString() == "" || cell.Value.ToString() == "0") { return; }
                else
                {
                    String connetStr = "server=127.0.0.1;port=3306;user=root;password=cyx123456; database=OrderDB;";
                    MySqlConnection conn = new MySqlConnection(connetStr);

                    conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句

                    string sql = $"select * from OrderDetails where OrderID={Int32.Parse( cell.Value.ToString())}";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
                    {

                        using (DataTable ds = new DataTable())
                        {
                            dataAdapter.Fill(ds);
                            this.dataGridView2.DataSource = ds;

                        }
                    }
                    conn.Close();
                    
                }
            }
        }

        private void init()
        {
            OrderDetail od1 = new OrderDetail(1, "香蕉", 10.0, 4);
            OrderDetail od2 = new OrderDetail(2, "铅笔", 2.0, 6);
            OrderDetail od3 = new OrderDetail(3, "保温杯", 40.5, 1);
            OrderDetail od4 = new OrderDetail(4, "鲜花", 15.0, 4);
            OrderDetail od5 = new OrderDetail(5, "台灯", 30.0, 2);
            OrderDetail od6 = new OrderDetail(6, "书", 20.0, 5);
            Order order1 = new Order(2001, "十月一日", "王小明");
            Order order2 = new Order(2003, "十月五日", "王小明");
            Order order3 = new Order(2022, "十一月一日", "李二百");
            Order order4 = new Order(2025, "一月二十", "罗小");
            Order order5 = new Order(2008, "一月五日", "孙大");

            using (var db = new OrdergContext()) {
                order1.orderDetails = new List<OrderDetail>()
                {
                    od1,od2
                };
                order1.Money = order1.getMoney();

                order2.orderDetails = new List<OrderDetail>()
                {
                    od3
                };
                order2.Money = order2.getMoney();
                order3.orderDetails = new List<OrderDetail>()
                {
                    od4,od5
                };
                order3.Money = order3.getMoney();
                order4.orderDetails = new List<OrderDetail>()
                {
                    od6
                };
                order4.Money = order4.getMoney();
                db.Orders.Add(order1);
                db.Orders.Add(order2);
                db.Orders.Add(order3);
                db.Orders.Add(order4);
                db.SaveChanges();
            }
            
           /* List<Order> orders1 = new List<Order>();
            { orders1.Add(order1); orders1.Add(order2); orders1.Add(order3); orders1.Add(order4); orders1.Add(order5); }
            service.orderlist = orders1;*/
        }
        private void showAll_btn_Click(object sender, EventArgs e)
        {
            String connetStr = "server=127.0.0.1;port=3306;user=root;password=cyx123456; database=OrderDB;";
            MySqlConnection conn = new MySqlConnection(connetStr);
            
                conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句

                string sql = "select * from Orders";

                using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
                {
                
                using (DataTable ds = new DataTable())
                {
                    dataAdapter.Fill(ds);
                    this.dataGridView1.DataSource = ds;
                    
                }
            }
            conn.Close();
        }

        private void Addorder_btn_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {
                Order order = form2.Tag as Order;
                service.AddOrder(order);

              
            }
        }


        private void delete_btn_Click(object sender, EventArgs e)
        {
            service.DeleteOrder(OrderID);

            String connetStr = "server=127.0.0.1;port=3306;user=root;password=cyx123456; database=OrderDB;";
            MySqlConnection conn = new MySqlConnection(connetStr);

            conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句

            string sql = "select * from Orders";

            using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
            {

                using (DataTable ds = new DataTable())
                {
                    dataAdapter.Fill(ds);
                    this.dataGridView1.DataSource = ds;

                }
            }
            conn.Close();


        }

        private void AddDetail_btn_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            if (form2.ShowDialog() == DialogResult.OK)
            {

                OrderDetail orderDetail = form2.Tag as OrderDetail;
                using (var db = new OrdergContext())
                {
                    var order = db.Orders.SingleOrDefault(o => o.OrderID == form2.OrderID);
                    order.AddDetail(orderDetail);
                   /*
                    String connetStr = "server=127.0.0.1;port=3306;user=root;password=cyx123456; database=OrderDB;";
                    MySqlConnection conn = new MySqlConnection(connetStr);

                    conn.Open();//打开通道，建立连接，可能出现异常,使用try catch语句

                    string sql = $"select price,number as table1 from orderdetails where OrderID = {form2.OrderID}" +
                        $"update Orders set Money= (sum(price*number) from table1) where OrderID = {form2.OrderID}";

                    using (MySqlDataAdapter dataAdapter = new MySqlDataAdapter(sql, conn))
                    {

                        using (DataTable ds = new DataTable())
                        {

                            dataAdapter.Fill(ds);
                        }
                    }
                    conn.Close();
                   */
                }
            }
        }   

        private void select_btn_Click(object sender, EventArgs e)
        {
            switch (selectcomboBox.SelectedIndex) 
            {
                case 0: orders = service.SelectByOrderID(Int32.Parse( selectBox.Text));break;
                case 1:orders = service.SelectByCustomer(selectBox.Text);break;
                case 2:orders = service.SelectByMoney(Convert.ToDouble(selectBox.Text));break;
                default:break;
             }
            dataGridView1.DataSource = orders;
        }

       

        private void modifyOrder_btn_Click_1(object sender, EventArgs e)
        {
            Form2 userDialog = new Form2();
            if (userDialog.ShowDialog() == DialogResult.OK)
            {
                Order order = userDialog.Tag as Order;
                service.ModifyOrder(order);
               
            }
            dataGridView1 .DataSource = service.ShowOrders();
        }

        private void addOrder_btn_Click_1(object sender, EventArgs e)
        {
            Form2 userDialog = new Form2();
            if (userDialog.ShowDialog() == DialogResult.OK)
            {
                Order order = userDialog.Tag as Order;
                service.AddOrder(order);

               // List<Order> temp_list = new List<Order>();
               // service.orderlist.ForEach(o => temp_list.Add(o));
               // dataGridView1.DataSource = temp_list;
            }
        }
    }
}
