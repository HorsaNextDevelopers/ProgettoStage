using Microsoft.AspNetCore.Mvc.Rendering;

namespace AuthSystem.ViewModel
{
    public class GraficoComponentiViewModel
    {
        public SelectList Articoli { get; set; }
        public SelectList ComponentiArticolo { get; set; }
    }
}
