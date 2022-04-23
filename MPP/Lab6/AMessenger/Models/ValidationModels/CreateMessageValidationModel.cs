using System.ComponentModel.DataAnnotations;

namespace AMessenger.Models.ValidationModels
{
    public class CreateMessageValidationModel
    {
        [Required(ErrorMessage = "Message text not set.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Message text must be more than 3 and less than 30 characters")]
        public string Text { get; set; }
    }
}