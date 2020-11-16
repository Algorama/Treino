namespace Exercicios.Domain
{
    public interface IPet
    {
        string Nome { get; set; }
        Sexo Sexo { get; set; }
        string Foto { set; get; }
        Dono Dono { set; get; }        
        string QuantoDevoComer(int pesoKg);
        void Validar();
    }
}