using System.ComponentModel.DataAnnotations;

namespace Lab3.Models
{
    public class RoleFormModel
    {
        [Required, StringLength(100)]
        public string Name { get; set; }

    }
}
