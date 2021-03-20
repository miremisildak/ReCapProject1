using Business.concrete;
using Core.Entities;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using System;
using System.Collections.Generic;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {


            CarTest();
            CarManager carManager = new CarManager(new EfCarDal());
            ColorManager colorManager = new ColorManager(new EfColorDal());
            BrandManager brandManager = new BrandManager(new EfBrandDal());

            Console.WriteLine("List:");
            foreach (Car car in carManager.GetAll().Data)
            {
                Console.WriteLine("Car Id: {0} --- Brand Id: {1} --- Color Id: " +
                    "{2} --- Daily Price: {3} --- Description: {4}", car.Id, car.BrandId,
                    car.ColorId, car.DailyPrice, car.Descriptions);
            }

            //DetailTestTest(carManager);

            //AddTest(colorManager, brandManager);

            //ColorGetAll(colorManager);
            //BrandGetAll(brandManager);

            //GetBtId(carManager, brandManager);

        }

        private static void GetBtId(CarManager carManager, BrandManager brandManager)
        {
            foreach (var item in carManager.GetCarsByBrandId(2).Data)
            {
                Console.WriteLine(item.Descriptions);
            }

            Console.WriteLine("Brand Id:{0}", brandManager.GetById(2));
        }

        private static void BrandGetAll(BrandManager brandManager)
        {
            foreach (var brand in brandManager.GetAll().Data)
            {

                Console.WriteLine("Brand Id: {0} --- Brand Name: {1}"
                                    , brand.BrandId, brand.BrandName);
            }
        }

        private static void ColorGetAll(ColorManager colorManager)
        {
            foreach (var color in colorManager.GetAll().Data)
            {

                Console.WriteLine("Color Id: {0} --- Color Name: {1}"
                                    , color.ColorId, color.ColorName);
            }
        }

        private static void AddTest(ColorManager colorManager, BrandManager brandManager)
        {
            brandManager.Add(new Brand { BrandName = "Honda" });
            colorManager.Add(new Color { ColorName = "Grey" });
            colorManager.Deleted(new Color { ColorId = 1002 });
            brandManager.Deleted(new Brand { BrandId = 1002 });
            brandManager.Deleted(new Brand { BrandId = 1003 });
            brandManager.Update(new Brand { BrandId = 1004 });
        }

        private static void DetailTest(CarManager carManager)
        {
            Console.WriteLine("Details:");
            List<CarDetailDto> carDetailDtos = carManager.GetCarDetails().Data;

            foreach (CarDetailDto carDetailDto in carDetailDtos)
            {
                Console.WriteLine("Araç: {0} -- Marka: {1} -- Renk: {2} -- Günlük Fiyatı: {3} TL", carDetailDto.CarName,
                    carDetailDto.BrandName.Trim(),
                    carDetailDto.ColorName.Trim(),
                    carDetailDto.DailyPrice);
            }
        }

        private static void CarTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());
            foreach (var car in carManager.GetAll().Data)
            {

                Console.WriteLine(car.DailyPrice);
                Console.WriteLine(car.ModelYear);
            }

        }
    }
        }