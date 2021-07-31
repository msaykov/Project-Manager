namespace ProjectManager.Models.Owners
{
    using System.ComponentModel.DataAnnotations;
    using static Data.DataConstants;

    public class UpdateOwnerFormModel
    {
        [Required]
        [StringLength(OwnerNameMaxLength, MinimumLength = OwnerNameMinLength, ErrorMessage = NamesErrorMsg)]
        public string Name { get; set; }

        [Required]
        [RegularExpression(PhoneNumberRegex)]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public int ProjectId { get; set; }
    }
}
