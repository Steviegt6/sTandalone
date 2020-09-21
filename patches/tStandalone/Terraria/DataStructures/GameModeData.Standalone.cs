namespace Terraria.DataStructures
{
	partial class GameModeData
	{
		public static readonly GameModeData MasterModeReloaded = new GameModeData {
			Id = -1,
			IsExpertMode = true,
			IsMasterMode = true,
			EnemyMaxLifeMultiplier = ExpertMode.EnemyMaxLifeMultiplier * 1.05f,
			EnemyDamageMultiplier = ExpertMode.EnemyDamageMultiplier * 1.05f,
			DebuffTimeMultiplier = ExpertMode.DebuffTimeMultiplier * 1.05f,
			KnockbackToEnemiesMultiplier = 0.8f,
			TownNPCDamageMultiplier = 2.5f,
			EnemyDefenseMultiplier = 1.1f,
			EnemyMoneyDropMultiplier = 3f
		};
	}
}
