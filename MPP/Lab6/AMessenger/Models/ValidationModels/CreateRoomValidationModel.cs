using System.ComponentModel.DataAnnotations;

namespace AMessenger.Models.ValidationModels
{
    public class CreateRoomValidationModel
    {
        [Required(ErrorMessage = "Name of the chat room not set.")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "Name must be more than 3 and less than 30 characters")]
        public string Text { get; set; }
    }
}