namespace APP.INTERFACES
{
    public interface IReceta
    {
        // Interface Receta -> Contrato para Clase RecetA
        // Contrato con propiedades
            string Nombre { get; set; }
            string Chef { get; set; }
            int TiempoMinutos { get; set; }
    }
}
