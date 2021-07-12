namespace ProjectManager.Data.Models
{
    
    public class ProjectsMaterial
    {
        public int Id { get; private set; }

        public int ProjectId { get; private set; }

        public Project Project { get; private set; }

        public int MaterialId { get; private set; }

        public Material Material { get; private set; }
    }
}
