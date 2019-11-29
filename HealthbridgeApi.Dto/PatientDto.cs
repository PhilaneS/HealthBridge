using System.ComponentModel.DataAnnotations;

namespace HealthbridgeApi.Dto
{
    public class PatientDto
    {
        public long PatientId { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "You must provide charecters not exceeding 50 charecters")]
        public string FirstName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(50, MinimumLength = 1, ErrorMessage = "You must provide charecters not exceeding 50 charecters")]
        public string LastName { get; set; }

        [Required(AllowEmptyStrings = false)]
        [StringLength(13, MinimumLength = 13, ErrorMessage = "You must provide charecters not exceeding 13 charecters")]
        public string IdNumber { get; set; }
    }
}
