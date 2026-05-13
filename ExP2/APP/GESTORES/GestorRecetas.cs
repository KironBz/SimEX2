namespace APP.GESTORES
{
    public class GestorRecetas : IGestorRecetas
    {
        private List<Receta> listaRecetas;

        public GestorRecetas()
        {
            listaRecetas = new List<Receta>();
        }

        public void AgregarReceta(Receta receta)
        {
            if (receta == null) throw new ArgumentNullException(nameof(receta));

            // Evitar duplicados por nombre
            if (listaRecetas.Any(r => r.Nombre.Equals(receta.Nombre, StringComparison.OrdinalIgnoreCase)))
            {
                throw new InvalidOperationException("La receta ya existe en el catálogo global.");
            }

            listaRecetas.Add(receta);
        }

        public void EliminarReceta(string nombre)
        {
            var receta = listaRecetas.FirstOrDefault(r => r.Nombre.Equals(nombre, StringComparison.OrdinalIgnoreCase));
            if (receta != null)
            {
                listaRecetas.Remove(receta);
            }
        }

        public void EliminarPorIndice(int indice)
        {
            if (indice < 0 || indice >= listaRecetas.Count)
                throw new IndexOutOfRangeException("Índice fuera de los límites del catálogo.");

            listaRecetas.RemoveAt(indice);
        }

        // Implementación de Búsqueda Binaria (Requiere que la lista esté ordenada por Nombre)
        public Receta BuscarPorNombre(string nombre)
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

        public void MostrarCatalogo()
        {
            Console.WriteLine("\n--- Catálogo Global de Recetas ---");
            foreach (var r in listaRecetas)
            {
                Console.WriteLine(r.ToString());
            }
        }
    }

}
