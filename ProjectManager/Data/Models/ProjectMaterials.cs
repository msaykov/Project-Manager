namespace ProjectManager.Data.Models
{
    public class ProjectMaterials
    {
        public int ProjectId { get; set; }

        public Project Project { get; set; }

        public int MaterialId { get; set; }

        public Material Material { get; set; }
    }
}
