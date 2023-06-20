using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCRUD2.Models
{
    public class EmpSkill
    {
        [Key]
        public int EmpSkillId { get; set; }

        public int EmpId { get; set; }

        [ForeignKey("EmpId")]
        public Employee Employee { get; set; } = default!;

        public int SkillId { get; set; }

        [ForeignKey("SkillId")]
        public Skill Skill { get; set; } = default!;
    }
}
