using SecretCommunicator.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using SecretCommunicator.Data.Interfaces;
using SecretCommunicator.Models.Library;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;
using Telerik.JustMock;
using System.Collections.Generic;

namespace SecretCommunicator.UnitTests
{
    [TestClass()]
    public class ChannelControllerTest
    {
        private void SetupChannelControllerPost(ChannelController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:2943/api/channel");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "channel");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        private void SetupChannelControllerGet(ChannelController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:2943/api/channel");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "channel");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        private void SetupChannelControllerDelete(ChannelController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost:2943/api/channel");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "channel");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        private void SetupChannelControllerPut(ChannelController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:2943/api/channel");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "channel");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        [TestMethod()]
        public void PostChannelTest()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository>();
            List<Message> messages = new List<Message>();
            messages.Add(new Message(){ Title="some", Content="some", Type = MessageTypes.Text});
            var value = new Channel()
            {
                Name = "someChannel",
                Password = "somePassword",
                CreatedDateTime = DateTime.Now,
                NumberOfMessages = 1,
                Messages = messages
                
            };

            Mock.Arrange(() => repository.Create(Arg.IsAny<Channel>()))
                 .DoInstead(() => isItemAdded = true)
                 .Returns(value);

            var controller = new ChannelController(repository);
            SetupChannelControllerPost(controller);
            controller.Post(value);
            Assert.IsTrue(isItemAdded);
        }

        [TestMethod()]
        public void GetChannelTest()
        {
            var repository = Mock.Create<IRepository>();
            var value = new Channel()
            {
                Id = "1235123123",
                Name = "someChannel",
                Password = "somePassword",
                CreatedDateTime = DateTime.Now
            };

            Mock.Arrange<Channel>(
                () => repository.Find<Channel>(c => c.Id == value.Id, null))
                .IgnoreArguments()
                .Returns(value)
                .MustBeCalled();

            var target = new ChannelController(repository);
            var result = target.Get(value.Id);
            Assert.AreEqual(result.Id, value.Id);
        }

        //public void PutChannelTest()
        //{
        //    bool isItemAdded = false;
        //    var repository = Mock.Create<IRepository>();
        //    var value = new Channel()
        //    {
        //    };

        //    Mock.Arrange(() => repository.Update(Arg.IsAny<Channel>()))
        //         .DoInstead(() => isItemAdded = true)
        //         .Returns(value);

        //    var controller = new ChannelController(repository);
        //    SetupChannelControllerPut(controller);
        //    controller.Post(value);
        //    Assert.IsTrue(isItemAdded);
        //}

        //public void DeleteChannelTest()
        //{
        //    bool isItemAdded = false;
        //    var repository = Mock.Create<IRepository>();
        //    var value = new Channel()
        //    {
        //    };

        //    Mock.Arrange(() => repository.Create(Arg.IsAny<Channel>()))
        //         .DoInstead(() => isItemAdded = true)
        //         .Returns(value);

        //    var controller = new ChannelController(repository);
        //    SetupChannelControllerDelete(controller);
        //    controller.Post(value);
        //    Assert.IsTrue(isItemAdded);
        //}
    }
}
