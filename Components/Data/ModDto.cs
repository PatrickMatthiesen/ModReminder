using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModReminder.Components.Data;

public record ModDto
{
    public long Hash { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

    public string VendorName { get; set; }
}