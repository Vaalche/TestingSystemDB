using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingSystemDB
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new TestingSystemEntities())
            {
                var users = db.users
                    .ToList();
                foreach (var user in users)
                {
                    Console.WriteLine(user.nickname);
                }
            }
        }
    }
}
