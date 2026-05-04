using Mafi;
using Mafi.Base;
using Mafi.Collections;
using Mafi.Core;
using Mafi.Core.Game;
using Mafi.Core.Map;
using Mafi.Core.Mods;
using Mafi.Core.Prototypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DifficultySettingsMod
{
	internal enum SettingType
	{
		GameDifficultyConfig
	}

	public sealed class DifficultySettingsMod : DataOnlyMod
	{
		public static bool Applied = false;

        public DifficultySettingsMod(ModManifest manifest) : base(manifest)
		{
            string logName = manifest.DisplayName;

			if (Applied == true)
			{
				Log.Info($"{logName}: patches already applied, skipping");

				return;
			}

			Log.Info($"{logName}: will apply diff setting patches");

			try
			{
				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.ExtraContractsProfitInfo), startValue: -90, endValue: 1000, step: 10,
					additionalOptions: new Percent[] { 10.Percent(), 30.Percent() }); // additionals for compatibility with vanilla

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.TreesGrowthInfo), startValue: -90, endValue: 200, step: 10,
					additionalOptions: new Percent[] { -50.Percent(), -25.Percent(), 25.Percent(), 50.Percent(), 300.Percent(), 400.Percent(), 500.Percent(), 1000.Percent(), 2000.Percent(), 3000.Percent(), 5000.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.ExtraStartingMaterialInfo), startValue: -80, endValue: 1000, step: 10,
					additionalOptions: new Percent[] { -100.Percent(), -99.Percent(), -95.Percent(), -90.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.MaintenanceDiffInfo), startValue: -100, endValue: 200, step: 10,
					additionalOptions: new Percent[] { -99.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.FuelConsumptionDiffInfo), startValue: -100, endValue: 100, step: 10,
					additionalOptions: new Percent[] { -99.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.RainYieldDiffInfo), startValue: -90, endValue: 1000, step: 10);

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.BaseHealthDiffInfo), startValue: -75, endValue: 1000, step: 25);

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.ResourceMiningDiffInfo), startValue: -50, endValue: 2500, step: 50,
					additionalOptions: new Percent[] { -75.Percent(), -25.Percent(), -15.Percent(), -10.Percent(), 10.Percent(), 15.Percent(), 25.Percent(), 30.Percent(), 3000.Percent(), 3500.Percent(), 4000.Percent(), 5000.Percent() }); // additionals for compatibility with vanilla + new

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.SettlementConsumptionDiffInfo), startValue: -100, endValue: 300, step: 10,
					additionalOptions: new Percent[] { -99.Percent(), 400.Percent(), 500.Percent(), 750.Percent(), 1000.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.SettlementFoodConsumptionDiffInfo), startValue: -100, endValue: 300, step: 10,
					additionalOptions: new Percent[] { -99.Percent(), 400.Percent(), 500.Percent(), 750.Percent(), 1000.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.WorldMinesReservesInfo), startValue: -100, endValue: 250, step: 10,
					additionalOptions: new Percent[] { -99.Percent(), 300.Percent(), 400.Percent(), 500.Percent(), 1000.Percent(), 2000.Percent(), 5000.Percent(), Percent.MaxValue });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.FarmYieldInfo), startValue: -90, endValue: 400, step: 10,
					additionalOptions: new Percent[] { -50.Percent(), -25.Percent(), 25.Percent(), 50.Percent(), 500.Percent(), 750.Percent(), 1000.Percent(), 1500.Percent(), 2000.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.UnityProductionDiffInfo), startValue: -90, endValue: 200, step: 10,
					additionalOptions: new Percent[] { -99.Percent(), 220.Percent(), 240.Percent(), 260.Percent(), 280.Percent(), 300.Percent(), 350.Percent(), 400.Percent(), 500.Percent(), 1000.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.SolarPowerDiffInfo), startValue: -80, endValue: 500, step: 10,
					additionalOptions: new Percent[] { -25.Percent(), 25.Percent(), 1000.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.ConstructionCostsDiffInfo), startValue: -100, endValue: 100, step: 5,
					additionalOptions: new Percent[] { 120.Percent(), 140.Percent(), 160.Percent(), 180.Percent(), 200.Percent(), 250.Percent(), 300.Percent(), 400.Percent(), 500.Percent() });



				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.ResearchCostDiffInfo), startValue: -100, endValue: 100, step: 5,
					additionalOptions: new Percent[] { -99.Percent(), 120.Percent(), 140.Percent(), 160.Percent(), 180.Percent(), 200.Percent(), 250.Percent(), 300.Percent(), 400.Percent(), 500.Percent(), 1000.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.DiseaseMortalityDiffInfo), startValue: -100, endValue: 100, step: 5,
					additionalOptions: new Percent[] { -99.Percent(), 120.Percent(), 140.Percent(), 160.Percent(), 180.Percent(), 200.Percent(), 250.Percent(), 300.Percent(), 400.Percent(), 500.Percent(), 1000.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.PollutionDiffInfo), startValue: -100, endValue: 200, step: 5,
					additionalOptions: new Percent[] { -99.Percent(), 250.Percent(), 300.Percent(), 400.Percent(), 500.Percent(), 1000.Percent(), 2000.Percent(), 5000.Percent(), 100000.Percent() });

				UpdateOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.QuickActionsCostInfo), startValue: -100, endValue: 200, step: 5,
					additionalOptions: new Percent[] { -99.Percent(), 250.Percent(), 300.Percent(), 400.Percent(), 500.Percent(), 1000.Percent(), 2000.Percent() });

			}
			catch (Exception e)
			{
                Log.Error($"{logName}: Exception while updating lists\n{e}");
            }

            Log.Info($"{logName}: setting patches applied");

			Applied = true;
		}

		private void UpdateOptionsListAuto(SettingType settingType, string diffInfoName, int startValue = 0, int endValue = 100, int step = 10, Percent[] additionalOptions = null)
		{
			if (step == 0)
			{
				throw new InvalidOperationException($"<color=#ff0000>Incorrect PatchOptionsListAuto setup for {diffInfoName}. `step` cannot be equal to 0</color>");
			}

			if (step < 0)
			{
				throw new InvalidOperationException($"<color=#ff0000>Incorrect PatchOptionsListAuto setup for {diffInfoName}. `step` cannot be negative</color>");
			}

			if (startValue > endValue) 
			{
				throw new InvalidOperationException($"<color=#ff0000>Incorrect PatchOptionsListAuto setup for {diffInfoName}. `startValue` cannot be greater than `endValue`</color>");
			}

			List<Percent> percents = new List<Percent>();
			for (int i = startValue; i <= endValue; i += step)
            {
				percents.Add(i.Percent());
            }

			if(additionalOptions != null && additionalOptions.Length > 0)
            {
				percents.AddRange(additionalOptions);
            }

			// order the array so it all appears properly in the dropdown list
			UpdateOptionsList(settingType, diffInfoName, percents.OrderBy(x => x.RawValue).ToArray());
		}

		private void UpdateOptionsList(SettingType settingType, string diffInfoName, params Percent[] newOptions)
        {
			Mafi.Log.Info($"Applying updates to {settingType}.{diffInfoName}");

			Type type = typeof(GameDifficultyConfig);
			Type diffType = typeof(DiffSettingInfo<Percent>);


			var diffInfoField = type.GetField(diffInfoName,
				BindingFlags.Public |
				BindingFlags.NonPublic |
				BindingFlags.Static);

			if(diffInfoField == null)
            {
				Mafi.Log.Error($"GetProperty returned null.\n  listName: {diffInfoName}");
				return;
			}

			var optionsField = diffType.GetField("Options");
			optionsField.SetValue(diffInfoField.GetValue(null), newOptions); // replaces the Options array of the DiffSettingInfo. diffInfoProp.GetValue(null) gets the value of the static 'diffInfoName' field

			Mafi.Log.Info($"new options applied to {diffInfoName}");
		}

        public override void RegisterPrototypes(ProtoRegistrator registrator)
        {
        }
    }
}
