using System.ComponentModel.DataAnnotations.Schema;

namespace MVCCRUD2.Models.ViewModel
{
    public class UpdateEmployeeViewModel
    {
        public int EmpId { get; set; }
        public int SkillId { get; set; } 
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime DOB { get; set; }
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public char RecStatus { get; set; } = 'A';

        public string Java { get; set; } = default!;

        [ForeignKey(nameof(Java))]
        public Skill skill1 { get; set; } = default!;
        public string Python { get; set; } = default!;

        [ForeignKey(nameof(Python))]
        public Skill skill2 { get; set; } = default!;
        public string CPlusPlus { get; set; } = default!;
              
        [ForeignKey(nameof(CPlusPlus))]
        public Skill skill3 { get; set; } = default!;
    }
}
