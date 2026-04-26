// Index.cshtml.cs
using HeroEngine.Core.Classes;
using HeroEngine.Core.Data;
using HeroEngine.Core.Models;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace HeroEngine.Web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly HeroRepository _repo;
        public int HeroCount { get; set; }
        public List<AHeroes> Heroes { get; set; }

        public IndexModel(HeroRepository repo) => _repo = repo;

        public void OnGet()
        {
            Heroes = _repo.LoadAll();
            HeroCount = Heroes.Count;
        }
    }
}