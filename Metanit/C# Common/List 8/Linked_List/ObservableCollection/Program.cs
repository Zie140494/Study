using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObservableCollection
{
    class Program
    {
        static void Main(string[] args)
        {
            ObservableCollection<User> users = new ObservableCollection<User>
            {
                new User {Name = "Vasya"},
                new User {Name = "Petya"},
                new User {Name = "Lexa"}
            };

            users.CollectionChanged += Users_Collection_Changed;

            users.Add(new User { Name = "Denis"});
            users.RemoveAt(1);
            users[0] = new User { Name = "Leva" };
            Console.ReadLine();
        }

        private static void Users_Collection_Changed(object sender, NotifyCollectionChangedEventArgs e)
        {
            switch (e.Action)
            {
                case NotifyCollectionChangedAction.Add:
                    User new_User = (User)e.NewItems[0];
                    Console.WriteLine("Добавлен пользователь "+new_User.Name);
                    break;
                case NotifyCollectionChangedAction.Remove:
                    User del_User = (User)e.OldItems[0];
                    Console.WriteLine("Удален пользователь " + del_User.Name);
                    break;
                case NotifyCollectionChangedAction.Replace:
                    new_User = (User)e.NewItems[0];
                    del_User = (User)e.OldItems[0];
                    Console.WriteLine(string.Format("Пользлватель {0}, заменен пользователем {1}", del_User.Name, new_User.Name));
                    break;

            }
                
        }
    }
    class User
    {
        public string Name { get; set; }
    }
}
