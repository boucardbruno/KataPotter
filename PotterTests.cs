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
            _shoppingBasket.Add("Harry Potter and the Philosopher's Stone");

            Check.That(_shoppingBasket.Price()).IsEqualTo(8.0);
        }

        [Test]
        public void Should_pay_16_euros_when_buy_twice_same_books()
        {
            _shoppingBasket.Add("Harry Potter and the Philosopher's Stone");
            _shoppingBasket.Add("Harry Potter and the Philosopher's Stone");

            Check.That(_shoppingBasket.Price()).IsEqualTo(16.0);
        }

        [Test]
        public void Should_pay_15_2_euros_with_5_percent_discount_when_buy_two_distincts_books()
        {
            _shoppingBasket.Add("Harry Potter and the Philosopher's Stone");
            _shoppingBasket.Add("Harry Potter and the Chamber of Secrets");

            Check.That(_shoppingBasket.Price()).IsEqualTo(15.2);
        }
        [Test]
        public void Should_pay_21_6_euros_with_10_percent_discount_when_buy_three_distincts_books()
        {
            _shoppingBasket.Add("Harry Potter and the Philosopher's Stone");
            _shoppingBasket.Add("Harry Potter and the Chamber of Secrets");
            _shoppingBasket.Add("Harry Potter and the Prisoner of Azkaban");

            Check.That(_shoppingBasket.Price()).IsEqualTo(21.6);
        }

        [Test]
        public void Should_pay_25_6_euros_with_20_percent_discount_when_buy_four_disctinct_books()
        {
            _shoppingBasket.Add("Harry Potter and the Philosopher's Stone");
            _shoppingBasket.Add("Harry Potter and the Chamber of Secrets");
            _shoppingBasket.Add("Harry Potter and the Prisoner of Azkaban");
            _shoppingBasket.Add("Harry Potter and the Goblet of Fire");

            Check.That(_shoppingBasket.Price()).IsEqualTo(25.6);
        }

        [Test]
        public void Should_pay_33_6_with_25_percent_discount_when_buy_five_potter_books()
        {
            _shoppingBasket.Add("Harry Potter and the Philosopher's Stone");
            _shoppingBasket.Add("Harry Potter and the Chamber of Secrets");
            _shoppingBasket.Add("Harry Potter and the Prisoner of Azkaban");
            _shoppingBasket.Add("Harry Potter and the Goblet of Fire");
            _shoppingBasket.Add("Harry Potter and the Order of the Phoenix");

            Check.That(_shoppingBasket.Price()).IsEqualTo(30);
        }

        [Test]
        public void Should_pay_29_6_euro_with_10_percent_discount_when_buy_three_distinct_books_and_one_identical()
        {
            _shoppingBasket.Add("Harry Potter and the Philosopher's Stone");
            _shoppingBasket.Add("Harry Potter and the Chamber of Secrets");
            _shoppingBasket.Add("Harry Potter and the Prisoner of Azkaban");

            _shoppingBasket.Add("Harry Potter and the Prisoner of Azkaban");

            Check.That(_shoppingBasket.Price()).IsEqualTo(29.6);
        }

        [Test]
        public void Should_run_acceptance_test()
        {
            _shoppingBasket.Add("Harry Potter and the Philosopher's Stone");
            _shoppingBasket.Add("Harry Potter and the Philosopher's Stone");

            _shoppingBasket.Add("Harry Potter and the Chamber of Secrets");
            _shoppingBasket.Add("Harry Potter and the Chamber of Secrets");

            _shoppingBasket.Add("Harry Potter and the Prisoner of Azkaban");
            _shoppingBasket.Add("Harry Potter and the Prisoner of Azkaban");

            _shoppingBasket.Add("Harry Potter and the Goblet of Fire");

            _shoppingBasket.Add("Harry Potter and the Order of the Phoenix");

            Check.That(_shoppingBasket.Price()).IsEqualTo(51.20);
        }
    }
}
