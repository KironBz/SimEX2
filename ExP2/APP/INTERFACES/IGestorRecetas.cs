using APP.GESTORES;
namespace APP.INTERFACES
{
    public class IGestorRecetas
    {
        // Interface gestor -> Controla al gestor
            List<Receta> RecetasDisponibles { get; set; }

            void AgregarReceta(Receta receta);
            void EliminarReceta(Receta receta);
            void EliminarPorIndice(int indice);
            List<Receta> BuscarPorNombre(string nombre);
            void LimpiarCatalogo();
            void QuickSort(List<Receta> lista);


            Receta BuscarPorNombre(string nombre); // Implementará Búsqueda Binaria

            // Aqui hay problemas
            void OrdenarPorTiempo(); // Implementará QuickSort o MergeSort
    }
}
