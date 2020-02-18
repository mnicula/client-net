using ReportPortal.Client.Abstractions.Responses;
using ReportPortal.Client.Converters;
using System;
using System.Runtime.Serialization;
using Xunit;

namespace ReportPortal.Client.IntegrationTests.Serialization
{
    public class ModelSerialization
    {
        public ModelSerialization()
        {
            ModelSerializerAssemblyResolver.Init();
        }

        [Fact]
        public void ShouldThrowExceptionIfIncorrectJson()
        {
            var json = "<abc />";
            var exp = Assert.ThrowsAny<Exception>(() => ModelSerializer.Deserialize<MessageResponse>(json));
            Assert.Contains(json, exp.Message);
            Assert.NotNull(exp.InnerException);
        }

        [Fact]
        public void AAA()
        {
            //Newtonsoft.Json.
        }

        [Fact]
        public void ShouldDeserializeWithEscapedNewLine()
        {
            for (int i = 0; i < 5000; i++)
            {
                var json = "{\"P1\": \"abc\\nabc\"}";
                var a = ModelSerializer.Deserialize<A>(json);

                Assert.Equal("abc\nabc", a.P1);
            }
        }

        [DataContract]
        class A
        {
            [DataMember]
            public string P1 { get; set; }
        }
    }
}
