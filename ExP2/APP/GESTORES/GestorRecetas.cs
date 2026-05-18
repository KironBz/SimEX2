using APP.INTERFACES.IGESTORRECETAS;
namespace APP.GESTORES
{
    public class GestorRecetas : IGestorRecetas
    {
        // Propiedades
        public List<Receta> RecetasDisponibles { get; set; }

        // Constructor
        public GestorRecetas()
        {
            RecetasDisponibles = new List<Receta>();
        }

        // Metodos 
        public void AgregarReceta(Receta receta)
        {
            if (receta == null) throw new ArgumentNullException(nameof(receta));

            // Evita duplicados por nombre
            if (RecetasDisponibles.Any(r => r.Nombre.Equals(receta.Nombre, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("La receta ya existe en el catálogo global.");
            }

            RecetasDisponibles.Add(receta);
        }

        public void EliminarReceta(string nombre)
        {
            var receta = RecetasDisponibles.FirstOrDefault(r => r.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (receta != null)
            {
                RecetasDisponibles.Remove(receta);
            }
        }

        public void EliminarPorIndice(int indice)
        {
            /*
            if (indice < 0 || indice >= RecetasDisponibles.Count)
                throw new IndexOutOfRangeException("Índice fuera de los límites del catálogo.");
            */

            RecetasDisponibles.RemoveAt(indice);
        }

        public List<Receta> BusquedaPorNombre(string nombre)
        {
            return RecetasDisponibles.Where(r => r.Nombre.Contains(nombre, StringComparison.OrdinalIgnoreCase)).ToList();
        }

        public void LimpiarCatalogo()
        {

        }










        public Receta BusquedaBinaria(string nombre)
        {
            // Primero ordenamos por nombre para que la búsqueda binaria funcione
            listaRecetas = listaRecetas.OrderBy(r => r.Nombre).ToList();

            int bajo = 0;
            int alto = listaRecetas.Count - 1;

            while (bajo <= alto)
            {
                int medio = (bajo + alto) / 2;
                int comparacion = string.Compare(listaRecetas[medio].Nombre, nombre, StringComparison.OrdinalIgnoreCase);

                if (comparacion == 0) return listaRecetas[medio];
                if (comparacion < 0) bajo = medio + 1;
                else alto = medio - 1;
            }

            return null; // No encontrado
        }


        // Implementación de Ordenamiento (Usando el método Sort de List que usa QuickSort/IntroSort)
        public void OrdenarPorTiempo()
        {
            // Ordena de menor a mayor tiempo
            listaRecetas.Sort((x, y) => x.TiempoMinutos.CompareTo(y.TiempoMinutos));
        }

    }
}