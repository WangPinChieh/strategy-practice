using System;
using System.Collections.Generic;

namespace strategy_practice
{
    public class Product
    {
        public Product(double length, double width, double height, double weight)
        {
            Length = length;
            Width = width;
            Height = height;
            Weight = weight;
        }

        public double Length { get; }
        public double Width { get; }
        public double Height { get; }
        public double Weight { get; }

        public double GetSize()
        {
            return Length * Width * Height;
        }
    }

    public interface IShipper
    {
        double CalculateFee(Product product);
    }

    public class BlackCat : IShipper
    {
        public double CalculateFee(Product product)
        {
            return product.Weight > 20 ? 500 : 100 + product.Weight * 10;
        }
    }

    public class Hsinchu : IShipper
    {
        public double CalculateFee(Product product)
        {
            var size = product.GetSize();
            if (product.Length > 100 || product.Width > 100 || product.Height > 100)
                return size * 0.00002 * 1100 + 500;
            return size * 0.00002 * 1200;
        }
    }

    public class PostOffice : IShipper
    {
        public double CalculateFee(Product product)
        {
            var feeByWeight = 80 + product.Weight * 10;
            var size = product.GetSize();
            var feeBySize = size * 0.00002 * 1100;
            return feeByWeight < feeBySize ? feeByWeight : feeBySize;
        }
    }

    public class Cart
    {
        public double shippingFee(string shipperName, Product product)
        {
            var shippers = new Dictionary<string, IShipper>
            {
                {"black cat", new BlackCat()},
                {"hsinchu", new Hsinchu()},
                {"post office", new PostOffice()},
            };      
            IShipper shipper;
            switch (shipperName)
            {
                case "black cat":
                case "hsinchu":
                case "post office":
                    shipper = shippers[shipperName];
                    break;
                default:
                    throw new Exception("shipper not exist");
            }

            return shipper.CalculateFee(product);
        }
    }
}