using System;

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

        public double Length { get; private set; }
        public double Width { get; private set; }
        public double Height { get; private set; }
        public double Weight { get; private set; }

        public double GetSize()
        {
            return Length * Width * Height;
        }
    }

    public class Cart
    {
        public double shippingFee(string shipper, Product product)
        {
            switch (shipper)
            {
                case "black cat":
                     return CalculateFeeByBlackCat(product);
                case "hsinchu":
                {
                    return CalculateFeeByHsinchu(product);
                }
                case "post office":
                {
                    return CalculateFeeByPostOffice(product);
                }
                default:
                    throw new Exception("shipper not exist");
            }
        }

        public static double CalculateFeeByPostOffice(Product product)
        {
            double feeByWeight = 80 + product.Weight * 10;
            double size = product.GetSize();
            double feeBySize = size * 0.00002 * 1100;
            return feeByWeight < feeBySize ? feeByWeight : feeBySize;
        }

        public static double CalculateFeeByHsinchu(Product product)
        {
            var size = product.GetSize();
            if (product.Length > 100 || product.Width > 100 || product.Height > 100)
            {
                return size * 0.00002 * 1100 + 500;
            }
            else
            {
                return size * 0.00002 * 1200;
            }
        }

        public static double CalculateFeeByBlackCat(Product product)
        {
            return product.Weight > 20 ? 500 : 100 + product.Weight * 10;
        }
    }
}