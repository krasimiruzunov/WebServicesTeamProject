using System.Collections.Generic;
using System.Linq;
using SecretCommunicator.WebApi.Controllers;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting.Web;
using SecretCommunicator.Data.Interfaces;
using SecretCommunicator.Models.Library;
using System.Net.Http;
using Telerik.JustMock;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.Controllers;
using System.Web.Http.Hosting;

namespace SecretCommunicator.UnitTests
{
    [TestClass()]
    public class MessageControllerTest
    {
        private void SetupMessageControllerPost(MessageController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:2943/api/message");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "message");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        private void SetupMessageControllerGet(MessageController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Get, "http://localhost:2943/api/message");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "message");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        private void SetupMessageControllerDelete(MessageController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Delete, "http://localhost:2943/api/message");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "message");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }

        private void SetupMessageControllerPut(MessageController controller)
        {
            var config = new HttpConfiguration();
            var request = new HttpRequestMessage(HttpMethod.Put, "http://localhost:2943/api/message");
            var route = config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional });

            var routeData = new HttpRouteData(route);
            routeData.Values.Add("id", RouteParameter.Optional);
            routeData.Values.Add("controller", "message");
            controller.ControllerContext = new HttpControllerContext(config, routeData, request);
            controller.Request = request;
            controller.Request.Properties[HttpPropertyKeys.HttpConfigurationKey] = config;
            controller.Request.Properties[HttpPropertyKeys.HttpRouteDataKey] = routeData;
        }
        
        [TestMethod()]
        public void PostMessageTest()
        {
            bool isItemAdded = false;
            var repository = Mock.Create<IRepository>();
            var value = new Message()
            {
                Title = "testTitle",
                Content = "testContent",
                ChannelId = "43242342",
                CreatedDateTime = DateTime.Now.ToString(),
                Status = "add",
                Type = MessageTypes.Text,
            };

            Mock.Arrange(() => repository.Create(Arg.IsAny<Message>()))
                 .DoInstead(() => isItemAdded = true)
                 .Returns(value);

            var controller = new MessageController(repository);
            SetupMessageControllerPost(controller);
            controller.Post(value);
            Assert.IsTrue(isItemAdded);
        }

        [TestMethod()]
        public void GetMessageTest()
        {
            var repository = Mock.Create<IRepository>();
            var value = new Message()
            {
                Title = "testTitle",
                Content = "testContent",
                ChannelId = "43242342",
                CreatedDateTime = DateTime.Now.ToString(),
                Status = "add",
                Type = MessageTypes.Text,
                Id = "1235213432123"
            };

            Mock.Arrange<Message>(
                () => repository.Find<Message>(m => m.Id == value.Id, null))
                .IgnoreArguments()
                .Returns(value)
                .MustBeCalled();

            var target = new MessageController(repository);
            var result = target.Get(value.Id);
            Assert.AreEqual(result.Id, value.Id);
        }

        //public void PutMessageTest()
        //{
        //    bool isItemAdded = false;
        //    var repository = Mock.Create<IRepository>();
        //    var value = new Message()
        //    {
        //        Title = "testTitle",
        //        Content = "testContent",
        //        ChannelId = "43242342",
        //        CreatedDateTime = DateTime.Now.ToString(),
        //        Status = "add",
        //        Type = MessageTypes.Text
        //    };

        //    Mock.Arrange(() => repository.Create(Arg.IsAny<Message>()))
        //         .DoInstead(() => isItemAdded = true)
        //         .Returns(value);

        //    var controller = new MessageController(repository);
        //    SetupMessageControllerPost(controller);
        //    controller.Post(value);
        //    Assert.IsTrue(isItemAdded);
        //}

        //public void DeleteMessageTest()
        //{
        //    bool isItemAdded = false;
        //    var repository = Mock.Create<IRepository>();
        //    var value = new Message()
        //    {
        //        Title = "testTitle",
        //        Content = "testContent",
        //        ChannelId = "43242342",
        //        CreatedDateTime = DateTime.Now.ToString(),
        //        Status = "add",
        //        Type = MessageTypes.Text
        //    };

        //    Mock.Arrange(() => repository.Delete(Arg.IsAny<Message>()))
        //         .DoInstead(() => isItemAdded = true)
        //         .Returns(value);

        //    var controller = new MessageController(repository);
        //    SetupMessageControllerPost(controller);
        //    controller.Post(value);
        //    Assert.IsTrue(isItemAdded);
        //}
    }
}
