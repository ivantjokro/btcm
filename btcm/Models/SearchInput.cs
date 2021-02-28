using System.ComponentModel.DataAnnotations;

namespace btcm.Models
{
    public class SearchInput
    {
        public SearchInput()
        {

        }
        [Required(ErrorMessage = "Block Number is required")]
        [RegularExpression(@"^\d+$", ErrorMessage = "Characters are not allowed.")]
        public string BlockNumber { get; set; }

        [RegularExpression(@"^0x\w{40}$", ErrorMessage = "Enter a valid address.")]
        public string Address { get; set; }

        public string ConvertHexFromBlockNumber()
        {
            int.TryParse(BlockNumber, out int number);
            string hex = number.ToString("x");
            return string.Format("{0}{1}", "0x", hex);
        }
    }
}
