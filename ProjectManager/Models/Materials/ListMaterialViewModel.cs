
namespace ProjectManager.Models.Materials
{
    using System.Collections.Generic;

    public class ListMaterialViewModel
    {
        public int ProjectId { get; set; }

        public IEnumerable<MaterialInfoViewModel> Materials { get; set; }
    }
}
