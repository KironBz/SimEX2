namespace APP.INTERFACES
{
    public interface IReceta
    {
        // Interface Receta -> Contrato para Clase RecetA
            string Nombre { get; set; }
            string Chef { get; set; }
            int TiempoMinutos { get; set; }
    }
}
