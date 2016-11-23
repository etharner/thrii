using System.Collections.Generic;

namespace thrii
{
	public enum BaseNames
	{
		GameSprite,

		MenuNewGame,
		MenuNewGameBackground,
		MenuNewGameText,

		MenuSettings,
		MenuSettingsBackground,
		MenuSettingsText,

		MenuExit,
		MenuExitBackground,
		MenuExitText,

		MenuOptionVolume,
		MenuOptionVolumeBackground,
		MenuOptionVolumeText,
		MenuOptionVolumeLeftButton,
		MenuOptionVolumeRightButton,

		MenuOptionResolution,
		MenuOptionResolutionBackground,
		MenuOptionResolutionText,
		MenuOptionResolutionLeftButton,
		MenuOptionResolutionRightButton,

		MenuOptionGameSize,
		MenuOptionGameSizeBackground,
		MenuOptionGameSizeText,
		MenuOptionGameSizeLeftButton,
		MenuOptionGameSizeRightButton,

		MenuApply,
		MenuApplyBackground,
		MenuApplyText,

		MenuBack,
		MenuBackBackground,
		MenuBackText,

		MenuScore,

		MenuExitToMenu,
		MenuExitToMenuBackground,
		MenuExitToMenuText,

		SessionBackground,

		HudScore,
		HudScoreText,

		HudTime,
		HudTimeText,

		HudGoal,
		HudGoalText,

		Background,
		Text,
		Gem,
		Destroyer
	}

	public class Name
	{
		public BaseNames BaseName;
		public int Id;

		public Name(BaseNames baseName, int id)
		{
			BaseName = baseName;
			Id = id;
		}
	}

	public static class Registrator
	{
		static Dictionary<BaseNames, int> registered = new Dictionary<BaseNames, int>();

		public static Name GenerateName(BaseNames name)
		{
			if (!registered.ContainsKey(name))
			{
				registered[name] = 1;
				return new Name(name, 1);
			}

			registered[name]++;

			return new Name(name, registered[name]);
		}

		public static void RemoveName(BaseNames name)
		{
			registered[name]--;
			if (registered[name] == 0)
			{
				registered.Remove(name);
			}
		}

		public static void ClearNames()
		{
			registered.Clear();
		}
	}
}
