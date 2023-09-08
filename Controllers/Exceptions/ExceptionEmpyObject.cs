namespace UD.ProgramacionWeb.ProyectoFinal.WizardTrack.Controllers.Exceptions
{
    public class ExceptionEmpyObject: Exception
    {
        // base() llama al contructor de Exception(de la clase que hereda)
        public ExceptionEmpyObject() : base() { }
        public ExceptionEmpyObject(string mensaje) : base(mensaje) { }
        public ExceptionEmpyObject(string mensaje,Exception innerException): base(mensaje, innerException) { }
    }
}
