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


        /****************************************************************/
        public void EliminarLibro(string nombreLibro, Receta receta)
        {

        }

        public int ContarTotalRecetas()
        {
            // Suma todas las recetas de todos los libros
            return LibrosRecetas.Values.Sum(lista => lista.Count);
        }

        public void MostrarMisLibros()
        {
            Console.WriteLine($"\n--- Libros de {Nombre} ---");
            foreach (var libro in LibrosRecetas)
            {
                Console.WriteLine($"Libro: {libro.Key}");
                foreach (var receta in libro.Value)
                {
                    Console.WriteLine($"  - {receta}");
                }
            }
        }
    }
}
