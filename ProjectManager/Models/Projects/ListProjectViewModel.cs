namespace ProjectManager.Models.Projects
{
    using static Data.DataConstants;

    public class ListProjectViewModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Type { get; set; }

        public string Owner { get; set; }

        public string Town { get; set; }

        public string EndDate { get; set; }

        public string Status { get; set; }
    }
}
