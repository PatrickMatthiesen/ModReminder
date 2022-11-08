using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ModReminder.Server
{
    public partial class world_sql_content_50f67b17bc243f7570787a58395230dbContext : DbContext
    {
        public world_sql_content_50f67b17bc243f7570787a58395230dbContext()
        {
        }

        public world_sql_content_50f67b17bc243f7570787a58395230dbContext(DbContextOptions<world_sql_content_50f67b17bc243f7570787a58395230dbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<DestinyAchievementDefinition> DestinyAchievementDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyActivityDefinition> DestinyActivityDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyActivityGraphDefinition> DestinyActivityGraphDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyActivityModeDefinition> DestinyActivityModeDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyActivityModifierDefinition> DestinyActivityModifierDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyActivityTypeDefinition> DestinyActivityTypeDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyArtifactDefinition> DestinyArtifactDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyBondDefinition> DestinyBondDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyBreakerTypeDefinition> DestinyBreakerTypeDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyChecklistDefinition> DestinyChecklistDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyClassDefinition> DestinyClassDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyCollectibleDefinition> DestinyCollectibleDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyDamageTypeDefinition> DestinyDamageTypeDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyDestinationDefinition> DestinyDestinationDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyEnergyTypeDefinition> DestinyEnergyTypeDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyEquipmentSlotDefinition> DestinyEquipmentSlotDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyEventCardDefinition> DestinyEventCardDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyFactionDefinition> DestinyFactionDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyGenderDefinition> DestinyGenderDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyHistoricalStatsDefinition> DestinyHistoricalStatsDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyInventoryBucketDefinition> DestinyInventoryBucketDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyInventoryItemDefinition> DestinyInventoryItemDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyItemCategoryDefinition> DestinyItemCategoryDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyItemTierTypeDefinition> DestinyItemTierTypeDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyLocationDefinition> DestinyLocationDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyLoreDefinition> DestinyLoreDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyMaterialRequirementSetDefinition> DestinyMaterialRequirementSetDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyMedalTierDefinition> DestinyMedalTierDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyMetricDefinition> DestinyMetricDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyMilestoneDefinition> DestinyMilestoneDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyObjectiveDefinition> DestinyObjectiveDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyPlaceDefinition> DestinyPlaceDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyPlugSetDefinition> DestinyPlugSetDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyPowerCapDefinition> DestinyPowerCapDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyPresentationNodeDefinition> DestinyPresentationNodeDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyProgressionDefinition> DestinyProgressionDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyProgressionLevelRequirementDefinition> DestinyProgressionLevelRequirementDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyRaceDefinition> DestinyRaceDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyRecordDefinition> DestinyRecordDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyReportReasonCategoryDefinition> DestinyReportReasonCategoryDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyRewardSourceDefinition> DestinyRewardSourceDefinitions { get; set; } = null!;
        public virtual DbSet<DestinySackRewardItemListDefinition> DestinySackRewardItemListDefinitions { get; set; } = null!;
        public virtual DbSet<DestinySandboxPatternDefinition> DestinySandboxPatternDefinitions { get; set; } = null!;
        public virtual DbSet<DestinySandboxPerkDefinition> DestinySandboxPerkDefinitions { get; set; } = null!;
        public virtual DbSet<DestinySeasonDefinition> DestinySeasonDefinitions { get; set; } = null!;
        public virtual DbSet<DestinySeasonPassDefinition> DestinySeasonPassDefinitions { get; set; } = null!;
        public virtual DbSet<DestinySocketCategoryDefinition> DestinySocketCategoryDefinitions { get; set; } = null!;
        public virtual DbSet<DestinySocketTypeDefinition> DestinySocketTypeDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyStatDefinition> DestinyStatDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyStatGroupDefinition> DestinyStatGroupDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyTalentGridDefinition> DestinyTalentGridDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyTraitCategoryDefinition> DestinyTraitCategoryDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyTraitDefinition> DestinyTraitDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyUnlockDefinition> DestinyUnlockDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyVendorDefinition> DestinyVendorDefinitions { get; set; } = null!;
        public virtual DbSet<DestinyVendorGroupDefinition> DestinyVendorGroupDefinitions { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlite("Data Source=C:\\Users\\patr7\\Desktop\\Ting\\My projects\\maui\\ModReminder\\Server\\SQLite_Manifests\\world_content_108869.22.09.24.1900-2-bnet.46665\\world_sql_content_50f67b17bc243f7570787a58395230db.content");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<DestinyAchievementDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyActivityDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyActivityGraphDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyActivityModeDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyActivityModifierDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyActivityTypeDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyArtifactDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyBondDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyBreakerTypeDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyChecklistDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyClassDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyCollectibleDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyDamageTypeDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyDestinationDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyEnergyTypeDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyEquipmentSlotDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyEventCardDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyFactionDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyGenderDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyInventoryBucketDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyInventoryItemDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyItemCategoryDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyItemTierTypeDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyLocationDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyLoreDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyMaterialRequirementSetDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyMedalTierDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyMetricDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyMilestoneDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyObjectiveDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyPlaceDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyPlugSetDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyPowerCapDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyPresentationNodeDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyProgressionDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyProgressionLevelRequirementDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyRaceDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyRecordDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyReportReasonCategoryDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyRewardSourceDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinySackRewardItemListDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinySandboxPatternDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinySandboxPerkDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinySeasonDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinySeasonPassDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinySocketCategoryDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinySocketTypeDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyStatDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyStatGroupDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyTalentGridDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyTraitCategoryDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyTraitDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyUnlockDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyVendorDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            modelBuilder.Entity<DestinyVendorGroupDefinition>(entity =>
            {
                entity.Property(e => e.Id).ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
