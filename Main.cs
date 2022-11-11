using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MelonLoader;
using BTD_Mod_Helper;
using BTD_Mod_Helper.Api.Bloons;
using Assets.Scripts.Models.Bloons;
using BTD_Mod_Helper.Extensions;
using BTD_Mod_Helper.Api.Enums;
using Assets.Scripts.Models.Rounds;
using Assets.Scripts.Unity;
using static AllCAMO.Main;
using BTD_Mod_Helper.Api.Scenarios;
using Assets.Scripts.Models.Difficulty;
using Assets.Scripts.Models.Towers.Mods;

[assembly: MelonInfo(typeof(AllCAMO.Main), "All CAMO", "1.0.0", "Diggity")]
[assembly: MelonGame("Ninja Kiwi", "BloonsTD6")]

namespace AllCAMO
{
    public class Main : BloonsTD6Mod
    {



    }
    public class AllCamoRounds : ModRoundSet
    {
        public override string BaseRoundSet => RoundSetType.Default;
        public override int DefinedRounds => 80;
        public override string DisplayName => "All CAMO";
        public override string Icon => VanillaSprites.CamoTargetIcon;

        public override void ModifyRoundModels(RoundModel roundModel, int round)
        {

            foreach (var group in roundModel.groups)
            {
                var bloon = Game.instance.model.GetBloon(group.bloon);
                if (bloon.FindChangedBloonId(bloonModel => bloonModel.isCamo = true, out var camoBloon))
                {
                    group.bloon = camoBloon;
                }
            }

        }

    }
    public class AllCamoMode3 : ModGameMode
    {
        public override string Difficulty => DifficultyType.Hard;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "All CAMO";

        public override string Icon => VanillaSprites.CamoTargetIcon;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.UseRoundSet<AllCamoRounds>();
        }

        public class AllCamoMode2 : ModGameMode
        {
            public override string Difficulty => DifficultyType.Medium;

            public override string BaseGameMode => GameModeType.None;

            public override string DisplayName => "All CAMO";

            public override string Icon => VanillaSprites.CamoTargetIcon;

            public override void ModifyBaseGameModeModel(ModModel gameModeModel)
            {
                gameModeModel.UseRoundSet<AllCamoRounds>();
            }
        }
    }
    public class AllCamoMode1 : ModGameMode
    {
        public override string Difficulty => DifficultyType.Easy;

        public override string BaseGameMode => GameModeType.None;

        public override string DisplayName => "All CAMO";

        public override string Icon => VanillaSprites.CamoTargetIcon;

        public override void ModifyBaseGameModeModel(ModModel gameModeModel)
        {
            gameModeModel.UseRoundSet<AllCamoRounds>();
        }
    }
}