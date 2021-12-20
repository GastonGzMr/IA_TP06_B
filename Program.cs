using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IA_TP06_B
{
    class Program
    {
        static void Main(string[] args)
        {
            Random random = new Random();
            double FACTOR_DE_APRENDIZAJE = 0.5;
            int cantidadDePasos;
            double[][] puntos = new double[][]
            {
                new double[]{ 1, 1 },
                new double[]{ 1, 0 },
                new double[]{ 0, 1 }
            };

            double[] pesosActuales = new double[] { random.Next(-6, 6) / 2, random.Next(-6, 6) / 2 };

            Neurona neurona = new Neurona(pesosActuales);

            double error = Math.Abs(neurona.Activar(puntos[0]) - Funcion(puntos[0]));

            foreach (double[] punto in puntos)
            {
                cantidadDePasos = 0;
                while (Math.Round(error,3) > 0)
                {
                    cantidadDePasos++;
                    pesosActuales = new double[]
                    {
                        pesosActuales[0] - FACTOR_DE_APRENDIZAJE * error * neurona.Activar(punto) *
                        (1 - neurona.Activar(punto)) * punto[0],
                        pesosActuales[1] - FACTOR_DE_APRENDIZAJE * error * neurona.Activar(punto) *
                        (1 - neurona.Activar(punto)) * punto[1]
                    };
                    neurona = new Neurona(pesosActuales);
                    error = Math.Abs(neurona.Activar(punto) - Funcion(punto));
                }
                Console.WriteLine("Pesos encontrados en " + cantidadDePasos + " pasos:");
                Escribir(pesosActuales);
            }
            Console.ReadLine();

        }

        static double Funcion(double[] punto)
        {
            if ((3 * punto[0] + 2 * punto[1]) > 2)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }

        static void Escribir(double[] array)
        {
            foreach (double numero in array)
            {
                Console.Write(numero + " ");
            }
        }
    }
}
