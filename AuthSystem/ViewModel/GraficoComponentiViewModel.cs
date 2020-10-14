using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuthSystem.ViewModel
{
    public class GraficoComponentiViewModel
    {
        public SelectList Articoli { get; set; }

        public string[] Labels { get; set; }

        public int[] Dataset { get; set; }

        public int TempoIdeale { get; set; }




    }
}
