using System;

namespace HQF.Tutorial.DesignPattern.DoubleDispatch
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            // 有两辆车需要销售，一辆是普通轿车，而另一辆则是奔驰
            Vehicle vehicle = new Vehicle();
            Vehicle benz = new Benz();

            // 向普通销售询问这两辆车的折扣
            var seller = new Seller();
            Console.WriteLine("Seller Vehicle{0}", seller.GetDiscountRate(vehicle));
            Console.WriteLine("Seller Vehicle{0}", seller.GetDiscountRate(benz));

            // 向销售经理询问这两辆车的折扣
            var manager = new SellerManager();
            Console.WriteLine("SellerManager Vehicle{0}", manager.GetDiscountRate(vehicle));
            Console.WriteLine("SellerManager Vehicle{0}", manager.GetDiscountRate(benz));

            Console.Read();
        }
    }

    // 普通汽车，折扣为0.03
    public class Vehicle
    {
        public virtual double GetBaseDiscountRate()
        {
            return 0.03;
        }
    }

    // 由于是奔驰特销商，因此可以得到更大的折扣
    public class Benz : Vehicle
    {
        public override double GetBaseDiscountRate()
        {
            return 0.06;
        }
    }


    // 普通的销售人员，只能按照公司规定的折扣进行销售
    internal class Seller
    {
        public virtual double GetDiscountRate(Vehicle vehicle)
        {
            return vehicle.GetBaseDiscountRate();
        }

        public virtual double GetDiscountRate(Benz benz)
        {
            return benz.GetBaseDiscountRate();
        }
    }

    // 销售经理，可以针对奔驰提供额外的优惠
    internal class SellerManager : Seller
    {
        public override double GetDiscountRate(Vehicle vehicle)
        {
            return vehicle.GetBaseDiscountRate();
        }

        public override double GetDiscountRate(Benz benz)
        {
            return benz.GetBaseDiscountRate() * 1.1;
        }
    }


}