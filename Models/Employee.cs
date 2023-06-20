using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCRUD2.Models
{
    public class Employee
    {
        internal object Skill;

        [Key]
        public int EmpId { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime DOB { get; set; }   
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public char RecStatus { get; set; } = 'A';
        
        //public int EmpSkillId { get; set; }
        //[ForeignKey("EmpSkill")]
        //public EmpSkill EmpSkill { get; set; } = default!;
    }
}
