namespace APP.MODELOS
{
    public class Usuario
    {
        // Propiedades
        public string Nombre { get; set; }
        public Dictionary<string, List<Receta>> LibrosRecetas { get; set; }

        // Constructor
        public Usuario(string nombre)
        {
            Nombre = nombre;
            LibrosRecetas = new Dictionary<string, List<Receta>>();
        }

        // Metodos
        public void CrearLibroRecetas(string nombreLibro)
        {
            if (LibrosRecetas.ContainsKey(nombreLibro))
                throw new InvalidOperationException("Ya existe un libro con este nombre.");

            LibrosRecetas.Add(nombreLibro, new List<Receta>());
        }

        public void AgregarRecetaALibro(string nombreLibro, Receta receta)
        {
            if (!LibrosRecetas.ContainsKey(nombreLibro))
                throw new KeyNotFoundException($"El libro '{nombreLibro}' no existe.");

            LibrosRecetas[nombreLibro].Add(receta);
        }

        public void EliminarLibro(string nombreLibro)
        {
            /* NO LO PIDE
            if (!LibrosRecetas.ContainsKey(nombreLibro))
                throw new KeyNotFoundException($"El libro '{nombreLibro}' no existe.");
            */

            LibrosRecetas.Remove(nombreLibro);
        }

        public List<Receta> ObtenerLibro(string nombreLibro) // ------------------------------ Podria Fallar
        {
            /* NO LO PIDE
            if (!LibrosRecetas.ContainsKey(nombreLibro))
                throw new KeyNotFoundException($"El libro '{nombreLibro}' no existe.");
             */

            return LibrosRecetas[nombreLibro];
        }

        public int ContarRecetas(string nombreLibro)
        {
            /*
            if (!LibrosRecetas.ContainsKey(nombreLibro))
                throw new KeyNotFoundException($"El libro '{nombreLibro}' no existe.");
            */

            return LibrosRecetas[nombreLibro].Count;// ------------------------------ Podria Ser -1
        }
        public void MostrarLibros()
        {
            if (LibrosRecetas.Count == 0)
            {
                Console.WriteLine("No hay libros registrados.");
                return;
            }

            foreach (var libro in LibrosRecetas)
            {
                Console.WriteLine($"Libro: {libro.Key}");

                foreach (var receta in libro.Value)
                {
                    Console.WriteLine("   - " + receta.ToString());
                }
            }
        }
    }
}
