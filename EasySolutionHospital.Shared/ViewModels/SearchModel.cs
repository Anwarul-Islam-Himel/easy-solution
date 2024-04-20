using System.ComponentModel.DataAnnotations;

namespace EasySolutionHospital.Shared.ViewModels
{
    public class SearchModel
    {
        [EmailAddress]
        public string SearchKey { get; set; }
    }
}
