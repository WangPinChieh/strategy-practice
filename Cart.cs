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
    }

    public class Cart
    {
        public double shippingFee(string shipper, Product product)
        {
            switch (shipper)
            {
                case "black cat":
                     return product.Weight > 20 ? 500 : 100 + product.Weight * 10;
                case "hsinchu":
                {
                    double size = product.Length * product.Width * product.Height;
                    if (product.Length > 100 || product.Width > 100 || product.Height > 100) {
                        return size * 0.00002 * 1100 + 500;
                    } else {
                        return size * 0.00002 * 1200;
                    }
                }
                case "post office":
                {
                    double feeByWeight = 80 + product.Weight * 10;
                    double size = product.Length * product.Width * product.Height;
                    double feeBySize = size * 0.00002 * 1100;
                    return feeByWeight < feeBySize ? feeByWeight : feeBySize;
                }
                default:
                    throw new Exception("shipper not exist");
            }
        }
 
    }
}