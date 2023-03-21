using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace IMDb.Pages
{
    public class QueryModel : PageModel
    {
        private readonly ILogger<QueryModel> _logger;

        public QueryModel(ILogger<QueryModel> logger)
        {
            _logger = logger;
        }

        public List<SelectListItem> FirstOptions { get; set; }
        public List<SelectListItem> SecondOptions { get; set; }

        [BindProperty] public string FirstDropdown { get; set; }
        [BindProperty] public string SecondDropdown { get; set; }
        [BindProperty] public string ThirdOptions { get; set; }

        public void OnGet()
        {
            // Populate the first dropdown with some options
            FirstOptions = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "A", Text = "Actor"},
                new SelectListItem() {Value = "B", Text = "Movie"},
                new SelectListItem() {Value = "C", Text = "Serie"}
            };

            // Populate the second dropdown with some default options
            SecondOptions = new List<SelectListItem>()
            {
                new SelectListItem() {Value = "", Text = "-- Select Second Option --"}
            };
        }

        public JsonResult OnGetSecondOptions(string firstOption)
        {
            // Return different options for the second dropdown based on the first option selected
            switch (firstOption)
            {
                case "A":
                    return new JsonResult(SecondOptions = new List<SelectListItem>()
                    {
                        new SelectListItem() {Value = "A1", Text = "Movie"},
                        new SelectListItem() {Value = "A2", Text = "Serie"},
                        new SelectListItem() {Value = "A3", Text = "Both"}
                    });
                case "B":
                    return new JsonResult(new List<SelectListItem>()
                    {
                        new SelectListItem() {Value = "B1", Text = "Option B1"},
                        new SelectListItem() {Value = "B2", Text = "Option B2"},
                        new SelectListItem() {Value = "B3", Text = "Option B3"}
                    });
                case "C":
                    return new JsonResult(new List<SelectListItem>()
                    {
                        new SelectListItem() {Value = "C1", Text = "Option C1"},
                        new SelectListItem() {Value = "C2", Text = "Option C2"},
                        new SelectListItem() {Value = "", Text = "-- No More Options --"}
                    });
                default:
                    return null;
            }
        }

        public IActionResult OnPost()
        {
            // Do something with the selected values
            return Page();
        }
    }
}