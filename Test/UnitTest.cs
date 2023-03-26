using BeautySalon.Collection;
using BeautySalon.Services;
using BeautySalon.Services.Haircuts;

namespace Test
{
    [TestFixture]
    public class Tests<T>
    {
        private LList<T> list = null!;

        [SetUp]
        public void Setup()
        {
            list = new LList<T>();
        }

        [TearDown]
        public void TearDown()
        {
            list.Clear();
        }

        [Test]
        public void CanAddToList()
        {
            Massage massage = new Massage(
                "MassageTest",
                12313.0,
                "Test");

            list.Add(massage);

            Assert.That(list, Has.Count.EqualTo(1));
        }

        [Test]
        public void IsClear()
        {
            HairColoring hairColoring = new HairColoring(
                "HairColoringTest",
                12313.0,
                "Test");

            list.Add(hairColoring);
            list.Clear();

            Assert.IsEmpty(list);
        }

        [Test]
        public void CanRemoveFromList()
        {
            Pompadour haircut = new Pompadour(
                "PompadourTest",
                "Pompadour",
                311.0,
                "Test");

            list.Add(haircut);
            list.Remove((T)(Object)haircut);

            Assert.Contains(haircut, (System.Collections.ICollection?)list);
        }

        [Test]
        public void IsContains()
        {
            Pixie haircut = new Pixie(
                "PixieTest",
                "Pixie",
                1231.0,
                "Test");

            list.Add(haircut);

            Assert.IsTrue(list.Contains((T)(Object)haircut));
        }
    }
}