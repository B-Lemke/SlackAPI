using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SlackAPI
{
    public static class JsonBlockConverter
    {
        public static IBlock[] CreateBlocksFromJson(dynamic json)
        {
            var blocks = new List<IBlock>();

            foreach (var block in json.blocks)
            {
                switch (block.type.ToString())
                {
                    case "section":
                        blocks.Add(CreateSectionBlock(block));
                        break;
                    default:

                        break;
                }
            }

            return blocks.ToArray();
        }

        private static IBlock CreateSectionBlock(dynamic blockJson)
        {
            var block = new SectionBlock()
            {
                block_id = blockJson.block_id ?? null,
                text = new Text()
                {
                    type = blockJson.text.type,
                    text = blockJson.text.text,
                    emoji = blockJson.text.emoji ?? null,
                    verbatim = blockJson.text.verbatim ?? null

                },
                fields = blockJson.fields ?? null,
                accessory = blockJson.accessory ?? null
            };

            return block;
        }
    }
}
