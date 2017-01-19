namespace BLL.Interface.Entities
{
    public class BllInvite
    {
        public int Id { get; set; }
        public int IdFrom { get; set; }
        public int IdTo { get; set; }
        public bool? Response { get; set; }
    }
}