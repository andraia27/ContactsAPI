using System.ComponentModel.DataAnnotations.Schema;

namespace ContactsAPI.Models
{
    public class ContactSkillLevel
    {
        public int Id { get; set; }
        public Contact Contact { get; set; }
        public Skill Skill { get; set; }
        public LevelEnum Level { get; set; }

        public int SkillId { get; set; }
        public int ContactId { get; set; }
    }

    public enum LevelEnum
    {
        Discovery = 1,
        Intermediate,
        Confirmed,
        Expert
    }
}
