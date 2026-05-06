using System.ComponentModel.DataAnnotations;

namespace BookingApp.API.DTOs
{
    public class CreateBookingRequestDto : IValidatableObject
    {
        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "UserId должен быть больше 0")]
        public int UserId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "RoomId должен быть больше 0")]
        public int RoomId { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (EndDate <= StartDate)
            {
                yield return new ValidationResult(
                    "Дата выезда должна быть позже даты заезда.",
                    new[] { nameof(EndDate) }
                );
            }
        }
    }
}
