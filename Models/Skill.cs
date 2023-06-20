using System.ComponentModel.DataAnnotations;

namespace MVCCRUD2.Models
{
    public class Skill
    {
        [Key]
        public int SkillId { get; set; }
        public string Java { get; set; }
        public string Python { get; set; }
        public string CPlusPlus { get; set; }
    }
}
