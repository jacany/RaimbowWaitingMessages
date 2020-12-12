using Exiled.API.Interfaces;
using System.ComponentModel;

namespace RaimbowWaitingMessages
{
    public sealed class Config : IConfig
    {
        [Description("Is the plugin enabled?")]
        public bool IsEnabled { get; set; } = true;

        [Description("The hint in Waiting For Players screen (use <color=%raimbow%> for a raimbow color (remember to close it with </color>))")]
        public string WaitingTextText { get; set; } = "\n\n\n\n<b>discord.gg/yourdiscord</b>\n<color=%raimbow%><b>My Pretty\nRaimbow Server Name</b></color>";
    }
}