namespace Demo
{
    public class Calculadora
    {
        public double Somar(double n1, double n2)
        {
            return n1 + n2;
        }

        public double Dividir(double n1, double n2)
        {
            if (n2 == 0)
            {
                throw new DivideByZeroException();
            }

            return n1 / n2;
        }
    }
}
