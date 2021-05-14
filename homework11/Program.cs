using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;

namespace homework8
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());

           /* using (var db = new BloggingContext())
            {
                var blog = new Blog { Url = "", Rating = 3 };
                blog.Posts = new List<Post>()
                {
                    new Post(){Title="tset1",Content="hello"},
                    new Post(){Title="tset2",Content="hello"},
                };
                db.Blogs.Add(blog);
                db.SaveChanges();
            }

            using(var db=new BloggingContext())
            {
                var post = new Post() { Title = "test3", Content = "Hello", BlogId = 1 };
                db.Entry(post).State = EntityState.Added;
                db.SaveChanges();
            }*/
        }
    }
}
