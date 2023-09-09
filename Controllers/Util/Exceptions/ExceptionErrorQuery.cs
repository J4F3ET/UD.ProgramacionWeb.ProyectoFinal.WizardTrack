namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Models.DTO
{
    public class ExceptionErrorQuery : Exception
    {
        public ExceptionErrorQuery() : base() { }
        public ExceptionErrorQuery(string mensaje) : base(mensaje) { }
        public ExceptionErrorQuery(string mensaje,Exception innerException): base(mensaje, innerException) { }
    }
}