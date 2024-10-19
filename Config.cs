using System.ComponentModel;
using Terraria.ModLoader;
using Terraria.ModLoader.Config;

namespace HideChat
{
    public class Config : ModConfig
    {
        public override ConfigScope Mode => ConfigScope.ClientSide;

        public static Config Instance => ModContent.GetInstance<Config>();

        [DefaultValue(true)]
        public bool DisableChat;
    }
}