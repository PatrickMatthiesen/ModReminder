﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ModReminder.Server
{
    [Table("DestinyProgressionDefinition")]
    public partial class DestinyProgressionDefinition
    {
        [Key]
        [Column("id")]
        public long Id { get; set; }
        [Column("json")]
        public byte[]? Json { get; set; }
    }
}