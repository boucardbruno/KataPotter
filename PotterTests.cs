using NFluent;
using NUnit.Framework;

namespace PotterTest
{
    public class PotterTests
    {
        private ShoppingBasket _shoppingBasket;

        [SetUp]
        public void SetUp()
        {
            _shoppingBasket = new ShoppingBasket();
        }

        [Test]
        public void Should_pay_8_euros_when_buy_one_book()
        {
            _shoppingBasket.Add(1);

            Check.That(_shoppingBasket.Price()).IsEqualTo(8.0);
        }

        [Test]
        public void Should_pay_16_euros_when_buy_twice_same_books()
        {
            _shoppingBasket.Add(1);
            _shoppingBasket.Add(1);

            Check.That(_shoppingBasket.Price()).IsEqualTo(16.0);
        }

        [Test]
        public void Should_pay_15_2_euros_with_discount_05_percent_when_buy_two_distincts_books()
        {
            _shoppingBasket.Add(1);
            _shoppingBasket.Add(2);

            Check.That(_shoppingBasket.Price()).IsEqualTo(15.2);
        }
        [Test]
        public void Should_pay_with_discount_10_percent_when_buy_three_distincts_books()
        {
            _shoppingBasket.Add(1);
            _shoppingBasket.Add(2);
            _shoppingBasket.Add(3);

            Check.That(_shoppingBasket.Price()).IsEqualTo(21.6);
        }

        [Test]
        public void Should_pay_25_6_euros_with_discount_20_percent_when_buy_four_disctinct_books()
        {
            _shoppingBasket.Add(1);
            _shoppingBasket.Add(2);
            _shoppingBasket.Add(3);
            _shoppingBasket.Add(4);

            Check.That(_shoppingBasket.Price()).IsEqualTo(25.6);
        }

        [Test]
        public void Should_pay_33_6_with_discount_25_percent_when_buy_five_potter_books()
        {
            _shoppingBasket.Add(1);
            _shoppingBasket.Add(2);
            _shoppingBasket.Add(3);
            _shoppingBasket.Add(4);
            _shoppingBasket.Add(5);

            Check.That(_shoppingBasket.Price()).IsEqualTo(33.6);
        }

        [Test]
        public void Should_pay_29_6_euro_with_discount_10_percent_when_three_distinct_books_and_one_identical()
        {
            _shoppingBasket.Add(1);
            _shoppingBasket.Add(2);
            _shoppingBasket.Add(3);

            _shoppingBasket.Add(3);

            Check.That(_shoppingBasket.Price()).IsEqualTo(29.6);
        }

        [Test]
        public void Should_run_acceptance_test()
        {
            _shoppingBasket.Add(1);
            _shoppingBasket.Add(1);

            _shoppingBasket.Add(2);
            _shoppingBasket.Add(2);

            _shoppingBasket.Add(3);
            _shoppingBasket.Add(3);

            _shoppingBasket.Add(4);
            _shoppingBasket.Add(5);

            Check.That(_shoppingBasket.Price()).IsEqualTo(51.20);
        }
    }
}
