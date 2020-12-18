﻿using System;

namespace strategy_practice
{
    public class Cart
    {
        public double shippingFee(string shipper, double length, double width, double height, double weight)
        {
            switch (shipper)
            {
                case "black cat":
                     return weight > 20 ? 500 : 100 + weight * 10;
                case "hsinchu":
                {
                    double size = length * width * height;
                    if (length > 100 || width > 100 || height > 100) {
                        return size * 0.00002 * 1100 + 500;
                    } else {
                        return size * 0.00002 * 1200;
                    }
                }
                case "post office":
                {
                    double feeByWeight = 80 + weight * 10;
                    double size = length * width * height;
                    double feeBySize = size * 0.00002 * 1100;
                    return feeByWeight < feeBySize ? feeByWeight : feeBySize;
                }
                default:
                    throw new Exception("shipper not exist");
            }
        }
 
    }
}