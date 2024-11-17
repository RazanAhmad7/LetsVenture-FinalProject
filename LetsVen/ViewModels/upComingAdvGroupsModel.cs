using LetsVen.Models;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace LetsVen.ViewModels
{
    public class upComingAdvGroupsModel
    {
        public List<Adventure> UpComingAdventures { get; set; }

        public List<AppUser> Groups { get; set; }


    }
}
