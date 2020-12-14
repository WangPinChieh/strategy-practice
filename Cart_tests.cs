using NUnit.Framework;

namespace strategy_practice
{
    public class Tests
    {
        private readonly Cart _cart = new Cart();
        private const string BlackCat = "black cat";
        private const string Hsinchu = "hsinchu";
        private const string PostOffice = "post office";

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void black_cat_with_light_weight()
        {
            var shippingFee = _cart.shippingFee(BlackCat, 30, 20, 10, 5);
            feeShouldBe(150, shippingFee);
        }

        [Test]
        public void black_cat_with_heavy_weight()
        {
            var shippingFee = _cart.shippingFee(BlackCat, 30, 20, 10, 50);
            feeShouldBe(500, shippingFee);
        }

        [Test]
        public void hsinchu_with_small_size()
        {
            var shippingFee = _cart.shippingFee(Hsinchu, 30, 20, 10, 50);
            feeShouldBe(144, shippingFee);
        }

        [Test]
        public void hsinchu_with_huge_size()
        {
            var shippingFee = _cart.shippingFee(Hsinchu, 100, 20, 10, 50);
            feeShouldBe(480, shippingFee);
        }

        [Test]
        public void post_office_by_weight()
        {
            var shippingFee = _cart.shippingFee(PostOffice, 100, 20, 10, 3);
            feeShouldBe(110, shippingFee);
        }

        [Test]
        public void post_office_by_size()
        {
            var shippingFee = _cart.shippingFee(PostOffice, 100, 20, 10, 300);
            feeShouldBe(440, shippingFee);
        }

        private void feeShouldBe(double expected, double shippingFee)
        {
            Assert.AreEqual(expected, shippingFee);
        }
    }
}