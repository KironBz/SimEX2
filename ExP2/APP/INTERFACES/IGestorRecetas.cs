using APP.INTERFACES;
using APP.GESTORES;
using APP.MODELOS;

namespace APP.INTERFACES
{
    public class IGestorRecetas
    {
        // Interface gestor -> Controla al gestor
            public List<Receta> RecetasDisponibles { get; set; }

            public void AgregarReceta(Receta receta);
            public void EliminarReceta(Receta receta);
            public void EliminarPorIndice(int indice);
            public List<Receta> BuscarPorNombre(string nombre);
            public void LimpiarCatalogo();
            public void QuickSort(List<Receta> lista);


            public Receta BuscarPorNombre(string nombre); // Implementará Búsqueda Binaria

            // Aqui hay problemas
            public void OrdenarPorTiempo(); // Implementará QuickSort o MergeSort
    }
}
