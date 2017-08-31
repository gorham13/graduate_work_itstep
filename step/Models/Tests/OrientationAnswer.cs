namespace step.Models.Tests
{
    public class OrientationAnswer
    {
        public int Id { get; set; }
        public string Body { get; set; }
        public string Attribute { get; set; }

        public virtual OrientationQuestion OrientationQuestion { get; set; }
    }
}