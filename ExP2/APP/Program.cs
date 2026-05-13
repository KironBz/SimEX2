// 4 clases , 3 Interfaces

// Receta normal


// Interfaces

// Interface Receta -> Contrato para Clase Receta
public interface IReceta
{
    string Nombre { get; set; }
    string Chef { get; set; }
    int TiempoMinutos { get; }  
}

// Interface gestor -> Controla al gestor
public interface IGestorRecetas
{
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

// Clases
// Clase Receta
public class Receta : IReceta
{
    public string Nombre { get; set; }
    public string Chef { get; set; }
    public int TiempoMinutos { get; set; }

    public Receta(string nombre, string chef, int tiempoMinutos)
    {
        if (tiempoMinutos <= 0)
            throw new ArgumentException("El tiempo de preparación debe ser mayor a 0.");

        Nombre = nombre;
        Chef = chef;
        TiempoMinutos = tiempoMinutos;
    }
    public override string ToString()
    {
        return $"Nombre:{Nombre} - Chef: {Chef} ({TiempoMinutos} min)";
    }
}

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












