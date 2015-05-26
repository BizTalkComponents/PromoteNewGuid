using System;
using BizTalkComponents.Utils;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Winterdom.BizTalk.PipelineTesting;

namespace BizTalkComponents.PipelineComponents.PromoteNewGuid.Tests.UnitTests
{
    [TestClass]
    public class PromoteNewGuidTests
    {
        [TestMethod]
        public void TestPromoteNewGuid()
        {

            var pipeline = PipelineFactory.CreateEmptySendPipeline();

            var component = new PromoteNewGuid
            {
                DestinationProperty = "http://tempuri.org#Property"
            };

            pipeline.AddComponent(component, PipelineStage.PreAssemble);

            var message = MessageHelper.Create("<test></test>");

            var output = pipeline.Execute(message);
            Guid g;
            Assert.IsTrue(Guid.TryParse(output.Context.Read(new ContextProperty("http://tempuri.org#Property")) as string,out g));
        }
    }
}
