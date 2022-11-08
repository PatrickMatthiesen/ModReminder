using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModReminder.Server
{
    [Table("DestinyHistoricalStatsDefinition")]
    public partial class DestinyHistoricalStatsDefinition
    {
        [Key]
        [Column("key")]
        public string Key { get; set; } = null!;
        [Column("json")]
        public byte[]? Json { get; set; }
    }
}
