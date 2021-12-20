using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP06_B
{
    class Neurona
    {
        double[] Pesos { get; set; }

        public Neurona(double[] pesos)
        {
            Pesos = pesos;
        }

        public double Activar(double[] entradas)
        {
            double resultado = 0;
            for (int i = 0; i < entradas.Length; i++)
            {
                resultado += entradas[i] * Pesos[i];
            }
            return 1 / (1 + Math.Pow(Math.E, resultado));
        }
    }
}
