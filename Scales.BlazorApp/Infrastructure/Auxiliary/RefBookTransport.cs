using System.ComponentModel.DataAnnotations;

namespace Scales.BlazorApp.Infrastructure.Auxiliary
{
    public class RefBookTransport
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Brand { get; set; } = string.Empty;
        [Required(ErrorMessage = "This field is required")]
        public string CarPlate { get; set; } = string.Empty;
        [Range(2,5, ErrorMessage = "Must be more or equal 2 end less then 6")]
        public int NumberOfAxles { get; set; }
    }
}
