using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModReminder.Components.Data;
public class User
{
    public string Id { get; set; }
    [Required]
    public string Name { get; set; }
    public string Email { get; set; }
}
