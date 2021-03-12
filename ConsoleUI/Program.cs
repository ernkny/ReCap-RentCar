using Business.Concrete;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            //carmanager();
            ////getbrandname();
            ////getbrandnameid();
            //CarDetailGet();
            //UserAdd();
       
            Console.ReadKey();

        }

        private static void UserAdd()
        {
            UserManager userManager = new UserManager(new EfUserDal());
            Users user = new Users();
            user.UserId = 1;
            user.FirstName = "Refik";
            user.LastName = "Kınay";
            user.Email = "eren.kinay.98@windowslive.com";
            user.Password = "Ernkny123123";
            userManager.Add(user);
        }

        private static void CarDetailGet()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var item in carManager.GetCarDetails().Data)
            {
                Console.WriteLine( item.BrandName +"/" +item.DailyPrice);
            }
        }

        private static void getbrandnameid()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            var brandname = brandManager.GetAllByBrandId(2);
            Console.WriteLine(brandname.BrandName);
          
        }

        private static void getbrandname()
        {
            BrandManager brandManager = new BrandManager(new EfBrandDal());
            foreach (var item in brandManager.GetAll())
            {
                Console.WriteLine(item.BrandName);
            }
            
        }

        private static void carmanager()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            var result = carManager.GetCarDetails();
            if (result.Success == true)
            {
                foreach (var cars in carManager.GetbyDailyPrice(100, 200).Data)
                {
                    Console.WriteLine(cars.BrandId);
                }

            }
            else Console.WriteLine(result.Message);
           
            
        }
    }
}
