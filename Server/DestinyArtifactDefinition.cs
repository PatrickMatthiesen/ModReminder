﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModReminder.Server
{
    [Table("DestinyArtifactDefinition")]
    public partial class DestinyArtifactDefinition
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("json")]
        public byte[]? Json { get; set; }
    }
}
