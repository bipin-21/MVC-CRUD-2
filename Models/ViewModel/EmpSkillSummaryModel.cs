namespace MVCCRUD2.Models.ViewModel
{
    public class EmpSkillSummaryModel
    {
        public int EmpId { get; set; }
        public string Username { get; set; } = default!;
        public string Password { get; set; } = default!;
        public string Email { get; set; } = default!;
        public DateTime DOB { get; set; }
        public string Phone { get; set; } = default!;
        public string Address { get; set; } = default!;
        public string Gender { get; set; } = default!;
        public char RecStatus { get; set; } = 'A';
        public string Java { get; set; }
        public string Python { get; set; }
        public string CPlusPlus { get; set; }
    }
}
