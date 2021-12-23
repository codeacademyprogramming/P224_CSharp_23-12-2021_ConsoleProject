using System;
using RestaurantManagement.Enums;
using RestaurantManagement.Models;
using RestaurantManagement.Services;

namespace RestaurantManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            RestaurantManager restaurantManager = new RestaurantManager();

            do
            {
                Console.WriteLine("-------------------------Restaurant Management---------------------------");
                Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                Console.WriteLine("1 - Menular Uzerinde Emeliyyatlar:");
                Console.WriteLine("2 - Sifarisler Uzerinde Emeliyyatlar:");
                Console.WriteLine("3 - Sistemden Cix:");
                Console.Write("Daxil Et:");
                string choose = Console.ReadLine();
                int chooseNum;
                int.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1:
                        Console.Clear();
                        MenuOperation(ref restaurantManager);
                        break;
                    case 2:
                        Console.Clear();
                        OrderOperation(ref restaurantManager);
                        break;
                    case 3:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun Daxil Et");
                        break;
                }

            } while (true);

        }

        static void MenuOperation(ref RestaurantManager restaurantManager)
        {
            do
            {
                Console.WriteLine("-------------------------Menu Emeliyyatlari---------------------------");
                Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                Console.WriteLine("1 - Yeni item elave et:");
                Console.WriteLine("2 - Item uzerinde duzelis et:");
                Console.WriteLine("3 - Item sil:");
                Console.WriteLine("4 - Butun Item-lari goster:");
                Console.WriteLine("5 - Categoriyasina gore menu item-lari goster:");
                Console.WriteLine("6 - Qiymet araligina gore menu item-lar goster:");
                Console.WriteLine("7 - Menu item-lar arasinda ada gore axtaris et (search):");
                Console.WriteLine("8 - Esas menuya qayit:");
                Console.Write("Daxil Et:");
                string choose = Console.ReadLine();
                int chooseNum;
                int.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1:
                        Console.Clear();
                        AddMenuItem(ref restaurantManager);
                        break;
                    case 2:
                        Console.Clear();
                        EditMenuItem(ref restaurantManager);
                        break;
                    case 3:
                        Console.Clear();
                        RemoveMenuItem(ref restaurantManager);
                        break;
                    case 4:
                        Console.Clear();
                        ShowAllListMenuItem(ref restaurantManager);
                        break;
                    case 5:
                        Console.Clear();
                        GetMenuItemsByCategory(ref restaurantManager);
                        break;
                    case 6:
                        Console.Clear();
                        GetMenuItemsByPriceInterval(ref restaurantManager);
                        break;
                    case 7:
                        Console.Clear();
                        SearchMenuItem(ref restaurantManager);
                        break;
                    case 8:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun Daxil Et");
                        break;
                }

            } while (true);
        }

        static void AddMenuItem(ref RestaurantManager restaurantManager)
        {
            Console.Write("Menu-nun Adini Daxil Et: ");
            string name = Console.ReadLine();
            bool checkName = true;
            int count = 0;
            while (checkName)
            {
                foreach (MenuItem item in restaurantManager.MenuItems)
                {
                    if (item.Name.ToLower() == name.ToLower())
                    {
                        count++;
                    }
                }

                if (count > 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Adda Menu Artiq Movcuddur");
                    Console.Write("Duzgun Ad Daxil Et: ");
                    name = Console.ReadLine();
                }
                else
                {
                    checkName = false;
                }

                count = 0;
            }

            Console.Write("Menu-nun Qiymetini Daxil Et: ");
            string price = Console.ReadLine();
            double priceNum;

            while (!double.TryParse(price, out priceNum) || priceNum <= 0)
            {
                Console.WriteLine("Duzgun Qiymet Daxil Et:");
                price = Console.ReadLine();
            }

            Console.WriteLine("Kategoriyalar: ");

            string[] categories = Enum.GetNames(typeof(Category));
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i} {categories[i]}");
            }

            Console.WriteLine("Kategoriyani Nomresini Daxil Et:");
            string category = Console.ReadLine();
            int categoryNum;

            while (!int.TryParse(category, out categoryNum) || categoryNum < 0 || categoryNum >= categories.Length)
            {
                Console.WriteLine("Duzgun Kategoriya Nomresi Daxil Et:");
                category = Console.ReadLine();
            }

            Category selectedCategory = (Category)categoryNum;

            restaurantManager.AddMenuItem(name, priceNum, selectedCategory);
        }

        static void EditMenuItem(ref RestaurantManager restaurantManager)
        {
            if (restaurantManager.MenuItems.Length <= 0)
            {
                Console.WriteLine("Siyahi Bosdur. Once Daxil Edin");
                return;
            }

            foreach (MenuItem item in restaurantManager.MenuItems)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------------");
            }

            Console.Write("Duzelis Etmek Isdediyniz Menunun Nomresini Daxil Et");
            string menuItemNo = Console.ReadLine();
            bool checkMenuItemNo = true;
            int count = 0;

            while (checkMenuItemNo)
            {
                foreach (MenuItem item in restaurantManager.MenuItems)
                {
                    if (item.No.ToLower() == menuItemNo.ToLower())
                    {
                        count++;
                    }
                }

                if (count <= 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Nomrede Menu Movcud Deyil");
                    Console.Write("Duzgun Menu Nomresi Daxil Et: ");
                    menuItemNo = Console.ReadLine();
                }
                else
                {
                    checkMenuItemNo = false;
                }

                count = 0;
            }

            Console.Write("Menu-nun Adini Daxil Et: ");
            string name = Console.ReadLine();
            bool checkName = true;
            int countName = 0;
            while (checkName)
            {
                foreach (MenuItem item in restaurantManager.MenuItems)
                {
                    if (item.Name.ToLower() == name.ToLower())
                    {
                        countName++;
                    }
                }

                if (countName > 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Adda Menu Artiq Movcuddur");
                    Console.Write("Duzgun Ad Daxil Et: ");
                    name = Console.ReadLine();
                }
                else
                {
                    checkName = false;
                }

                countName = 0;
            }

            Console.Write("Menu-nun Qiymetini Daxil Et: ");
            string price = Console.ReadLine();
            double priceNum;

            while (!double.TryParse(price, out priceNum) || priceNum <= 0)
            {
                Console.WriteLine("Duzgun Qiymet Daxil Et:");
                price = Console.ReadLine();
            }

            Console.WriteLine("Kategoriyalar: ");

            string[] categories = Enum.GetNames(typeof(Category));
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i} {categories[i]}");
            }

            Console.WriteLine("Kategoriyani Nomresini Daxil Et:");
            string category = Console.ReadLine();
            int categoryNum;

            while (!int.TryParse(category, out categoryNum) || categoryNum < 0 || categoryNum >= categories.Length)
            {
                Console.WriteLine("Duzgun Kategoriya Nomresi Daxil Et:");
                category = Console.ReadLine();
            }

            Category selectedCategory = (Category)categoryNum;

            restaurantManager.EditMenuItem(menuItemNo.ToUpper(), name, priceNum, selectedCategory);

        }

        static void RemoveMenuItem(ref RestaurantManager restaurantManager)
        {
            if (restaurantManager.MenuItems.Length <= 0)
            {
                Console.WriteLine("Siyahi Bosdur. Once Daxil Edin");
                return;
            }

            foreach (MenuItem item in restaurantManager.MenuItems)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------------");
            }

            Console.Write("Silmek Isdediyniz Menunun Nomresini Daxil Et");
            string menuItemNo = Console.ReadLine();
            bool checkMenuItemNo = true;
            int count = 0;

            while (checkMenuItemNo)
            {
                foreach (MenuItem item in restaurantManager.MenuItems)
                {
                    if (item.No.ToLower() == menuItemNo.ToLower())
                    {
                        count++;
                    }
                }

                if (count <= 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Nomrede Menu Movcud Deyil");
                    Console.Write("Duzgun Menu Nomresi Daxil Et: ");
                    menuItemNo = Console.ReadLine();
                }
                else
                {
                    checkMenuItemNo = false;
                }

                count = 0;
            }

            restaurantManager.RemoveMenuItem(menuItemNo.ToUpper());
        }

        static void ShowAllListMenuItem(ref RestaurantManager restaurantManager)
        {
            if (restaurantManager.MenuItems.Length <= 0)
            {
                Console.WriteLine("Siyahi Bosdur. Once Daxil Edin");
                return;
            }

            foreach (MenuItem item in restaurantManager.MenuItems)
            {
                Console.WriteLine(item);
                Console.WriteLine("------------------------------------");
            }
        }

        static void GetMenuItemsByCategory(ref RestaurantManager restaurantManager)
        {
            Console.WriteLine("Kategoriyalar: ");

            string[] categories = Enum.GetNames(typeof(Category));
            for (int i = 0; i < categories.Length; i++)
            {
                Console.WriteLine($"{i} {categories[i]}");
            }

            Console.WriteLine("Kategoriyani Nomresini Daxil Et:");
            string category = Console.ReadLine();
            int categoryNum;

            while (!int.TryParse(category, out categoryNum) || categoryNum < 0 || categoryNum >= categories.Length)
            {
                Console.WriteLine("Duzgun Kategoriya Nomresi Daxil Et:");
                category = Console.ReadLine();
            }

            Category selectedCategory = (Category)categoryNum;

            MenuItem[] selectedMenuItems = restaurantManager.GetMenuItemsByCategory(selectedCategory);

            if (selectedMenuItems.Length <= 0)
            {
                Console.WriteLine("Secdiyniz Kategoriyada Menu Yoxdur");
                return;
            }

            foreach (MenuItem item in selectedMenuItems)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("-----------------------------");
                }
            }
        }

        static void GetMenuItemsByPriceInterval(ref RestaurantManager restaurantManager)
        {

        start:
            Console.Write("Baslangic Qiymetini Daxil Et: ");
            string startPrice = Console.ReadLine();
            double startPriceNum;

            while (!double.TryParse(startPrice, out startPriceNum) || startPriceNum <= 0)
            {
                Console.WriteLine("Duzgun Qiymet Daxil Et:");
                startPrice = Console.ReadLine();
            }

            Console.Write("Son Qiymetini Daxil Et: ");
            string endPrice = Console.ReadLine();
            double endPriceNum;

            while (!double.TryParse(endPrice, out endPriceNum) || endPriceNum <= 0)
            {
                Console.WriteLine("Duzgun Qiymet Daxil Et:");
                endPrice = Console.ReadLine();
            }

            if (startPriceNum > endPriceNum)
            {
                Console.WriteLine("Baslangic Qiymet Son Qiymetden Boyuk Ola Bilmez");
                goto start;
            }

            MenuItem[] selectedMenuItems = restaurantManager.GetMenuItemsByPriceInterval(startPriceNum, endPriceNum);

            if (selectedMenuItems.Length <= 0)
            {
                Console.WriteLine("Daxil Etdiyniz Intervaldan Hecne Tapilmadi");
                goto start;
            }

            foreach (MenuItem item in selectedMenuItems)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("------------------------------------------------");
                }
            }
        }

        static void SearchMenuItem(ref RestaurantManager restaurantManager)
        {
            Console.Write("Deyeri Daxil Edin: ");
            string search = Console.ReadLine();

            check:
            if (String.IsNullOrWhiteSpace(search))
            {
                Console.WriteLine("Bos Ola Bilmez");
                Console.WriteLine("Duzgun Daxil Et");
                search = Console.ReadLine();
                goto check;
            }

            MenuItem[] selectedMenuItems = restaurantManager.SearchMenuItem(search);

            if (selectedMenuItems.Length < 0)
            {
                Console.WriteLine("Hec Bir Melumat Tapilmadi");
                return;
            }

            foreach (MenuItem item in selectedMenuItems)
            {
                if (item != null)
                {
                    Console.WriteLine(item);
                    Console.WriteLine("-----------------------------------");
                }
            }
        }

        static void OrderOperation(ref RestaurantManager restaurantManager)
        {
            do
            {
                Console.WriteLine("-------------------------Sifaris Emeliyyatlari---------------------------");
                Console.WriteLine("Etmek Isdediyniz Emeliyyatin Qarsisindaki Nomreni Daxil Edin:");
                Console.WriteLine("1 - Yeni sifaris elave etmek:");
                Console.WriteLine("2 - Sifarisin legvi:");
                Console.WriteLine("3 - Item sil:");
                Console.WriteLine("4 - Butun Item-lari goster:");
                Console.WriteLine("5 - Categoriyasina gore menu item-lari goster:");
                Console.WriteLine("6 - Qiymet araligina gore menu item-lar goster:");
                Console.WriteLine("7 - Menu item-lar arasinda ada gore axtaris et (search):");
                Console.WriteLine("8 - Esas menuya qayit:");
                Console.Write("Daxil Et:");
                string choose = Console.ReadLine();
                int chooseNum;
                int.TryParse(choose, out chooseNum);
                switch (chooseNum)
                {
                    case 1:
                        Console.Clear();
                        AddOrder(ref restaurantManager);
                        break;
                    case 2:
                        Console.Clear();
                        RemoveOrder(ref restaurantManager);
                        break;
                    case 3:
                        Console.Clear();
                        RemoveMenuItem(ref restaurantManager);
                        break;
                    case 4:
                        Console.Clear();
                        ShowAllListMenuItem(ref restaurantManager);
                        break;
                    case 5:
                        Console.Clear();
                        GetMenuItemsByCategory(ref restaurantManager);
                        break;
                    case 6:
                        Console.Clear();
                        GetMenuItemsByPriceInterval(ref restaurantManager);
                        break;
                    case 7:
                        Console.Clear();
                        SearchMenuItem(ref restaurantManager);
                        break;
                    case 8:
                        return;
                    default:
                        Console.Clear();
                        Console.WriteLine("Duzgun Daxil Et");
                        break;
                }

            } while (true);
        }

        static void AddOrder(ref RestaurantManager restaurantManager)
        {
            if (restaurantManager.MenuItems.Length <= 0)
            {
                Console.WriteLine("Siyahi Bosdur. Once Daxil Et");
                return;
            }

            OrderItem[] orderItems = new OrderItem[0];

            bool check = true;

            while (check)
            {
                foreach (MenuItem item in restaurantManager.MenuItems)
                {
                    if (item != null)
                    {
                        Console.WriteLine(item);
                        Console.WriteLine("----------------------------------------");
                    }
                }

                Console.Write("Menunun Kodunu Daxil Et: ");
                string menuItemNo = Console.ReadLine();

                bool checkMenuItemNo = true;
                MenuItem menuItem = null;

                while (checkMenuItemNo)
                {
                    foreach (MenuItem item in restaurantManager.MenuItems)
                    {
                        if (item.No.ToLower() == menuItemNo.ToLower())
                        {
                            menuItem = item;
                        }
                    }

                    if (menuItem == null)
                    {
                        Console.WriteLine("Daxil Etdiyniz Nomrede Menu Movcud Deyil");
                        Console.Write("Duzgun Menu Nomresi Daxil Et: ");
                        menuItemNo = Console.ReadLine();
                    }
                    else
                    {
                        checkMenuItemNo = false;
                    }
                }

                Console.Write("Sayini Daxil Et: ");
                string menuItemCount = Console.ReadLine();
                int menuItemCountNum;

                while (!int.TryParse(menuItemCount, out menuItemCountNum) || menuItemCountNum <= 0)
                {
                    Console.WriteLine("Duzgun Say Daxil Et:");
                    menuItemCount = Console.ReadLine();
                }

                OrderItem orderItem = new OrderItem(menuItem, menuItemCountNum);
                Array.Resize(ref orderItems, orderItems.Length + 1);
                orderItems[orderItems.Length - 1] = orderItem;

                Console.WriteLine("Basqa Isdeyiniz Varmi? (He/Yox)");
                string answer = Console.ReadLine();

                checkAnswer:
                if (answer.ToLower() == "he")
                {
                    check = true;
                }
                else if (answer.ToLower() == "yox")
                {
                    check = false;
                }
                else
                {
                    Console.Write("Duzgun Daxil Et");
                    answer = Console.ReadLine();
                    goto checkAnswer;
                }
            }

            restaurantManager.AddOrder(orderItems, DateTime.UtcNow.AddHours(+4));
        }

        static void RemoveOrder(ref RestaurantManager restaurantManager)
        {
            if (restaurantManager.Orders.Length <= 0)
            {
                Console.WriteLine("Siyahi Bosdur. Once Daxil Edin");
                return;
            }

            foreach (Order item in restaurantManager.Orders)
            {
                if (item !=  null)
                {
                    Console.WriteLine(item);
                }
            }

            Console.Write("Silmek Isdediyniz Orderin Nomresini Daxil Et");
            checkNo:
            string orderNo = Console.ReadLine();
            int orderNoNum;

            while (!int.TryParse(orderNo, out orderNoNum) || orderNoNum <= 0)
            {
                Console.WriteLine("Duzgun Nomre Daxil Et:");
                orderNo = Console.ReadLine();
            }

            bool checkOrderNo = true;
            int count = 0;

            while (checkOrderNo)
            {
                foreach (Order item in restaurantManager.Orders)
                {
                    if (item.No == orderNoNum)
                    {
                        count++;
                    }
                }

                if (count <= 0)
                {
                    Console.WriteLine("Daxil Etdiyniz Nomrede Sifaris Movcud Deyil");
                    Console.Write("Duzgun Sifaris Nomresi Daxil Et: ");
                    goto checkNo;
                }
                else
                {
                    checkOrderNo = false;
                }

                count = 0;
            }

            restaurantManager.RemoveOrder(orderNoNum);
        }
    }
}
