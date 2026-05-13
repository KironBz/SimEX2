namespace APP.MODELOS
{
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
}
