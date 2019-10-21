using Newtonsoft.Json;
using SlackAPI.Tests.Configuration;
using SlackAPI.Tests.Helpers;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace SlackAPI.Tests
{
    [Collection("Integration tests")]
    public class JsonBlocks
    {
        private readonly IntegrationFixture fixture;

        public JsonBlocks(IntegrationFixture fixture)
        {
            this.fixture = fixture;
        }

        [Fact]
        public void CreateSectionBlockFromJson()
        {
            IBlock[] block = SlackMother.Block;
            string currentDirectory = Directory.GetCurrentDirectory();

            // when
            var json = LoadJson(@"Helpers/SingleSectionBlock.json");
            IBlock[] jsonBlock = JsonBlockConverter.CreateBlocksFromJson(json);

            // then
            string expected = JsonConvert.SerializeObject(block);
            string actual = JsonConvert.SerializeObject(jsonBlock);
            Assert.Equal(expected, actual);
        }

      

        private dynamic LoadJson(string fileName)
        {
            using (StreamReader r = new StreamReader(fileName))
            {
                string jsonString = r.ReadToEnd();
                return JsonConvert.DeserializeObject<dynamic>(jsonString);
            }
        }
    }
}