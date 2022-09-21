using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace TestEntityFrameworkMVCProj.Models
{
    public partial class Skill
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        [Column("skillId")]
        public int Id { get; set; }
        [Column("name")]
        public string Name { get; set; }

        public ICollection<SkillMap> SkillMap { get; set; }
    }
}
