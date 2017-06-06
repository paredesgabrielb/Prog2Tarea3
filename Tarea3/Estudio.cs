using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class Estudio
    {
        public Estudio()
        {
            Nombre = "";
            Muestras = new List<Muestra>();
        }
        public string Nombre { get; set; }
        public List<Muestra> Muestras { get; set; }

        public void PrintInFile(string path)
        {
            try
            {
                using (StreamWriter file = new StreamWriter(path,true))
                {
                    file.WriteLine(Nombre);
                    foreach (var muestra in Muestras)
                    {
                        file.WriteLine(muestra.Nombre+": "+string.Join(" ,",muestra.Datos));
                        file.WriteLine("Moda: " + string.Join(", ", muestra.Moda().Select(x => x.ToString()).ToArray()));
                        file.WriteLine("Media: " + muestra.Media());
                        file.WriteLine("Mediana: " + muestra.Mediana());
                        file.WriteLine("Varianza: " + muestra.Varianza());
                        file.WriteLine("Desviacion Estandar: " + muestra.DesviacionEstandar());
                        file.WriteLine();
                    }
                }

                Console.WriteLine("Se Guardo Correctamente");
            }
            catch (Exception e)
            {
                Console.WriteLine("Error:");
                Console.WriteLine(e);
                Console.WriteLine("Revise el archivo Resultado.txt");
            }
        }

        public static Estudio ParseStringToEstudio(string text)
        {
            var result = new Estudio();
            foreach (string muestra in text.Split('\n'))
            {
                string[] datosStrings = muestra.Split(new [] {" - "},StringSplitOptions.None)[1].Split(new[] { ", " }, StringSplitOptions.None);
                Muestra obj = new Muestra()
                {
                    Nombre = muestra.Split(new[] { " - " }, StringSplitOptions.None)[0],
                    Datos = datosStrings.Select(double.Parse).ToList()
                };
                result.Muestras.Add(obj);
            }
            
            return result;
        }
    }
}
