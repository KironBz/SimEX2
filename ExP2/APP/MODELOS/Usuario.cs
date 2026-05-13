namespace APP.MODELOS
{
    public class Usuario
    {
        public string Nombre { get; set; }
        Dictionary<string, List<Receta>> LibrosRecetas;

        public Usuario(string nombre)
        {
            Nombre = nombre;
            LibrosRecetas = new Dictionary<string, List<Receta>>();
        }

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
        public void EliminarLibro(string nombreLibro, Receta receta)
        {
            if (!LibrosRecetas.ContainsKey(nombreLibro))
                throw new KeyNotFoundException($"El libro '{nombreLibro}' no existe.");

            LibrosRecetas.Remove(nombreLibro);
        }
        public List<Receta> ObtenerLibro(string nombreLibro)
        {
            if (!LibrosRecetas.ContainsKey(nombreLibro))
                throw new KeyNotFoundException($"El libro '{nombreLibro}' no existe.");

            return LibrosRecetas[nombreLibro];
        }
        public int ContarRecetas(string nombreLibro)
        {
            if (!LibrosRecetas.ContainsKey(nombreLibro))
                throw new KeyNotFoundException($"El libro '{nombreLibro}' no existe.");

            return LibrosRecetas[nombreLibro].Count;
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
