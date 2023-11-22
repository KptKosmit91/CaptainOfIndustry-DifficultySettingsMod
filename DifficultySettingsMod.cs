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
		GameDifficultyConfig,
		IslandMapDifficultyConfig
	}

	public sealed class DifficultySettingsMod : IMod
	{
		public static bool Applied = false;

		public string Name => "KK91 - Difficulty Settings Mod";

		public int Version => 1;

		public bool IsUiOnly => true; // true i guess? 

        public DifficultySettingsMod(CoreMod coreMod, BaseMod baseMod)
		{
			if (Applied == true)
			{
				// not needed tbh.
				// throw new Exception("<color=#ff3c00>More Diff Settings Values already initialized, you can remove the mod from this save to play it</color>");
				Log.Info($"{Name}: patches already applied, skipping");

				return;
			}

			Log.Info($"{Name}: will apply diff setting patches");

			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.ExtraContractsProfitInfo), startValue: 0, endValue: 1000, step: 20,
				additionalOptions: new Percent[] { 10.Percent(), 30.Percent() }); // additionals for compatibility with vanilla

			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.TreesGrowthInfo), startValue: -90, endValue: 200, step: 10,
				additionalOptions: new Percent[] { 300.Percent(), 400.Percent(), 500.Percent(), 1000.Percent(), 2000.Percent(), 3000.Percent(), 5000.Percent() } );

			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.ExtraStartingMaterialInfo), startValue: 0, endValue: 1000, step: 20);
			
			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.MaintenanceDiffInfo), startValue: -100, endValue: 200, step: 10,
				additionalOptions: new Percent[] { -99.Percent() });

			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.FuelConsumptionDiffInfo), startValue: -100, endValue: 100, step: 10,
				additionalOptions: new Percent[] { -99.Percent() });

			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.RainYieldDiffInfo), startValue: -90, endValue: 1000, step: 10);
			
			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.BaseHealthDiffInfo), startValue: -50, endValue: 1000, step: 25);
			
			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.ResourceMiningDiffInfo), startValue: -50, endValue: 2500, step: 50, 
				additionalOptions: new Percent[] { -10.Percent(), 10.Percent(), 30.Percent(), 3000.Percent(), 3500.Percent(), 4000.Percent(), 5000.Percent() }); // additionals for compatibility with vanilla + new
			
			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.SettlementConsumptionDiffInfo), startValue: -100, endValue: 200, step: 20,
				additionalOptions: new Percent[] { -99.Percent() });

			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.WorldMinesReservesInfo), startValue: -100, endValue: 250, step: 10, 
				additionalOptions: new Percent[] { -99.Percent(), 300.Percent(), 400.Percent(), 500.Percent(), 1000.Percent(), 2000.Percent(), 5000.Percent(), Percent.MaxValue });
			
			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.FarmYieldInfo), startValue: -90, endValue: 200, step: 10);

			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.UnityProductionDiffInfo), startValue: -90, endValue: 200, step: 10,
				additionalOptions: new Percent[] { -99.Percent(), 220.Percent(), 240.Percent(), 260.Percent(), 280.Percent(), 300.Percent(), 350.Percent(), 400.Percent(), 500.Percent(), 1000.Percent() });

			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.PowerProductionDiffInfo), startValue: -80, endValue: 500, step: 10,
				additionalOptions: new Percent[] { 1000.Percent() });

			PatchOptionsListAuto(SettingType.GameDifficultyConfig, nameof(GameDifficultyConfig.ConstructionCostsDiffInfo), startValue: -95, endValue: 100, step: 5,
				additionalOptions: new Percent[] { 120.Percent(), 140.Percent(), 160.Percent(), 180.Percent(), 200.Percent(), 250.Percent(), 300.Percent(), 400.Percent(), 500.Percent() });



			PatchOptionsListAuto(SettingType.IslandMapDifficultyConfig, nameof(IslandMapDifficultyConfig.MineableResourceSizeBonusInfo), startValue: -1000, endValue: 1000, step: 10,
				additionalOptions: new Percent[] { -25.Percent(), 25.Percent() }); // vanilla compat

			PatchOptionsListAuto(SettingType.IslandMapDifficultyConfig, nameof(IslandMapDifficultyConfig.CellHeightsBiasInfo), startValue: -1000, endValue: 1000, step: 10,
				additionalOptions: new Percent[] { -25.Percent(), 25.Percent() }); // vanilla compat


			// testing
			/*
			PatchOptionsList(SettingType.DifficultyConfig, nameof(GameDifficultyConfig.ExtraStartingMaterialInfo),
				0.Percent(),
				10.Percent(),
				20.Percent(),
				30.Percent(),
				40.Percent(),
				50.Percent(),
				60.Percent(),
				70.Percent(),
				80.Percent()
				);

			PatchOptionsList(SettingType.DifficultyConfig, nameof(GameDifficultyConfig.BaseHealthDiffInfo),
				0.Percent(),
				420.Percent(),
				666.Percent(),
				420691337.Percent()
				);
			*/


			Log.Info($"{Name}: setting patches applied");

			Applied = true;

			// 1000 iq
			throw new Exception("<color=#00ff00>Intentional crash, new setting values now available in the New Game menu!</color>");
		}

		private void PatchOptionsListAuto(SettingType settingType, string diffInfoName, int startValue = 0, int endValue = 100, int step = 10, Percent[] additionalOptions = null)
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
			PatchOptionsList(settingType, diffInfoName, percents.OrderBy(x => x.RawValue).ToArray());
		}

		private void PatchOptionsList(SettingType settingType, string diffInfoName, params Percent[] newOptions)
        {
			Mafi.Log.Info($"Applying patches to {settingType}.{diffInfoName}");

			Type type = typeof(GameDifficultyConfig);
			Type diffType = typeof(DiffSettingInfo<Percent, GameDifficultyConfig>);

			if(settingType == SettingType.IslandMapDifficultyConfig)
            {
				type = typeof(IslandMapDifficultyConfig);
				diffType = typeof(DiffSettingInfo<Percent, IslandMapDifficultyConfig>);
			}


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


		public void RegisterPrototypes(ProtoRegistrator reg)
		{
		}

        public void ChangeConfigs(Lyst<IConfig> configs)
        {
        }

        public void RegisterDependencies(DependencyResolverBuilder depBuilder, ProtosDb protosDb, bool gameWasLoaded)
        {
        }

        public void Initialize(DependencyResolver resolver, bool gameWasLoaded)
        {
        }
    }
}
