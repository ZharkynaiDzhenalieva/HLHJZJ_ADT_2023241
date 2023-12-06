using HLHJZJ_ADT_2023241.Repository;
using HLHJZJ_ADT_2023241.Logic;
using HLHJZJ_ADT_2023241.Models;
using HLHJZJ_ADT_2023241.Repository;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HLHJZJ_ADT_2023241.Test
{
    [TestFixture]
    public class Tester
    {
        InterestLogic interestLogic;
        ProductLogic productLogic;
        TopicLogic topicLogic;

        [SetUp]
        public void Setup()
        {
            List<Interest> Interests = new List<Interest>();
            List<Topic> Topics = new List<Topic>();
            List<Product> Products = new List<Product>();

            FakeData(out Interests, out Topics, out Products);
            Mock<IRepository<Interest>> mockInterestRepo = new Mock<IRepository<Interest>>();
            Mock<IRepository<Product>> mockProductRepo = new Mock<IRepository<Product>>();
            Mock<IRepository<Topic>> mockTopicRepo = new Mock<IRepository<Topic>>();

            

            mockInterestRepo.Setup(x => x.ReadAll()).Returns(Interests.AsQueryable);
            mockProductRepo.Setup(x => x.ReadAll()).Returns(Products.AsQueryable);
            mockTopicRepo.Setup(x => x.ReadAll()).Returns(Topics.AsQueryable);

            interestLogic = new InterestLogic(mockInterestRepo.Object);
            topicLogic = new TopicLogic(mockTopicRepo.Object);
            productLogic = new ProductLogic(mockProductRepo.Object);

        }


        [Test]
        public void GetOneInterestName()
        {
            Assert.That(interestLogic.Read(1).Name, Is.EqualTo("Cars"));
        }

        [Test]
        public void GetAllInterest_ReturnsExactNumberOfInstances()
        {
            Assert.That(this.interestLogic.ReadAll().Count, Is.EqualTo(4));
        }
        [Test]
        public void GetOneTopicName()
        {
            Assert.That(topicLogic.Read(1).Name, Is.EqualTo("Minions"));
        }

        [Test]
        public void GetAllTopics_ReturnsExactNumberOfInstances()
        {
            Assert.That(this.topicLogic.ReadAll().Count, Is.EqualTo(4));
        }

        [Test]
        public void GetOneProductVendorCode()
        {
            Assert.That(productLogic.Read(1).VendorCode, Is.EqualTo("ghbdtn112"));
        }
         
        [Test]
        public void GetAllProducts_ReturnsExactNumberOfInstances()
        {
            Assert.That(this.productLogic.ReadAll().Count, Is.EqualTo(4));
        }

        private static void FakeData(out List<Interest> Interests, out List<Topic> Topics, out List<Product> Products)
        {
            Topic Topic1 = new Topic() { Id = 1, Name = "Minions" };
            Topic Topic2 = new Topic() { Id = 2, Name = "Marvel" };
            Topic Topic3 = new Topic() { Id = 3, Name = "Avatar" };
            Topic Topic4 = new Topic() { Id = 4, Name = "Harry Potter" };

            Topic1.Products = new List<Product>();
            Topic2.Products = new List<Product>();
            Topic3.Products = new List<Product>();

            Product product1 = new Product() { Id = 1, VendorCode = "ghbdtn112", Cost = 44, Topic_id = 1, Interest_id = 1 };
            Product product2 = new Product() { Id = 2, VendorCode = "hlh223gjk", Cost = 30, Topic_id = 2, Interest_id = 2 };
            Product product3 = new Product() { Id = 3, VendorCode = "abcdef222", Cost = 12, Topic_id = 3, Interest_id = 3 };
            Product product4 = new Product() { Id = 4, VendorCode = "ghijklnm0", Cost = 15, Topic_id = 4, Interest_id = 4 };

            product1.Topic = Topic1;
            product2.Topic = Topic1;
            product3.Topic = Topic2;
            product4.Topic = Topic2;

            product1.Topic_id = Topic1.Id; Topic1.Products.Add(product1);
            product2.Topic_id = Topic1.Id; Topic1.Products.Add(product2);
            product3.Topic_id = Topic2.Id; Topic2.Products.Add(product3);
            product4.Topic_id = Topic2.Id; Topic2.Products.Add(product4);

            Interest interest1 = new Interest() { Id = 1, Name = "Cars" };
            Interest interest4 = new Interest() { Id = 2, Name = "For children" };
            Interest interest2 = new Interest() { Id = 3, Name = "Art" };
            Interest interest3 = new Interest() { Id = 4, Name = "Ships" };
            product1.Interest = interest1;
            product2.Interest = interest2;
            product3.Interest = interest3;
            product4.Interest = interest4;

            product1.Interest_id = interest1.Id; interest1.Products.Add(product1);
            product2.Interest_id = interest2.Id; interest2.Products.Add(product2);
            product3.Interest_id = interest3.Id; interest3.Products.Add(product3);
            product4.Interest_id = interest4.Id; interest4.Products.Add(product4);

            Interests = new List<Interest>();
            Interests.Add(interest1);
            Interests.Add(interest2);
            Interests.Add(interest3);
            Interests.Add(interest4);

            Topics = new List<Topic>();
            Topics.Add(Topic1);
            Topics.Add(Topic2);
            Topics.Add(Topic3);
            Topics.Add(Topic4);

            Products = new List<Product>();
            Products.Add(product1);
            Products.Add(product2);
            Products.Add(product3);
            Products.Add(product4);

        }
    }
}
