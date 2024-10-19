using Microsoft.Xna.Framework;
using Terraria.ModLoader;
using Terraria.UI.Chat;

namespace HideChat
{
	public class HideChat : Mod
	{
		public override void Load()
		{
			// Hook no método SetContents da classe ChatMessageContainer
			On_ChatMessageContainer.SetContents += ChatMessageContainer_SetContents;
		}

		private void ChatMessageContainer_SetContents(On_ChatMessageContainer.orig_SetContents orig, ChatMessageContainer self, string text, Color color, int widthLimitInPixels)
		{
			{
			// Chama o método original
			orig(self, text, color, widthLimitInPixels);

			if (Config.Instance.DisableChat)
				// Agora, vamos manipular a flag CanBeShownWhenChatIsClosed
				// Como CanBeShownWhenChatIsClosed é uma propriedade derivada de _timeLeft, ajustamos _timeLeft para garantir que seja false
				self.GetType().GetField("_timeLeft", System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic)
					?.SetValue(self, 0);  // Força o _timeLeft a 0, o que faz com que CanBeShownWhenChatIsClosed seja false}
			}
		}
	}
}
