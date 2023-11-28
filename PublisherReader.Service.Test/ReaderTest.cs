using PublisherReader.Service.Entities;
using System.Reflection.PortableExecutable;

namespace PublisherReader.Service.Test
{
    [TestFixture]
    public class ReaderTest
    {
        private Readers _sut;

        [SetUp]
        public void Setup()
        {
            _sut = new Readers();
        }


        [Test]
        public void Add_non_existing_new_reader_should_add_that_reader()
        {
            //Act
            _sut.AddReader("Pablo");

            //Assert
            Assert.IsTrue(_sut.ListReaders().Contains("reader: Pablo"));
        }

        [Test]
        public void Add_existing_new_reader_should_not_add_any_reader()
        {
            //Arrange
            _sut.AddReader("Pablo");
            var initalList = _sut.ListReaders();

            //Act
            _sut.AddReader("Pablo");
            var finalList = _sut.ListReaders();

            //Assert
            Assert.That(finalList.Length, Is.EqualTo(initalList.Length));
        }


        [Test]
        public void Remove_existing_reader_should_remove_that_reader()
        {
            //Arrange 
            _sut.AddReader("Pablo");

            //Act
            _sut.RemoveReader("Pablo");

            //Assert
            Assert.IsFalse(_sut.ListReaders().Contains("reader: Pablo"));
        }

        [Test]
        public void Remove_non_existing_reader_should_not_remove_anything()
        {
            //Act
            _sut.RemoveReader("Pablo");

            //Assert
            Assert.IsFalse(_sut.ListReaders().Contains("reader: Pablo"));
        }

        [Test]
        public void List_all_readers_should_return_all_readers()
        {
            //Arrange
            _sut.AddReader("Pablo");
            _sut.AddReader("Juan");
            _sut.AddReader("Alicia");

            //Act
            var result = _sut.ListReaders();

            //Assert
            Assert.IsTrue(result.Contains("reader: Pablo"));
            Assert.IsTrue(result.Contains("reader: Juan"));
            Assert.IsTrue(result.Contains("reader: Alicia"));
        }
    }
}
