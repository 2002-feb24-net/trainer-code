using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RestaurantReviews.WebUI.ViewModels
{
    public class RestaurantViewModel
    {
        // the HTML/tag helpers like "DisplayNameFor"
        // will use this instead of the property's name
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public IEnumerable<ReviewViewModel> Reviews { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double? Score { get; set; }
    }
}
