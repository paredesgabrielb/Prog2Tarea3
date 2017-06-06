using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Tarea3
{
    class Program
    {
        //Tu vas a tener un archivo entrada que va a tener el siguiente formato

        //Estudio numero
        //Muestra 1 - dato1, dato2
        //Muestra 2- dato1, dato2, dato3, dato4
        //Muestra 3 - dato

        //Y vas a leer eso con el programa, sacarle la moda mediana varianza etc y printearlo en otro archivo con el formato

        //Estudio numero
        //Muestra 1 - dato1, dato2
        //Moda
        //Mediana
        //Etc
        //Muestra 2- dato1, dato2, dato3, dato4
        //Moda
        //Mediana
        //Etc
        //Muestra 3 - dato

        //Usando listas y clase
        static void Main(string[] args)
        {
            string sourcePath = @"../../Muestras.txt";
            string outPath = @"../../Resultado.txt";

            if (File.Exists(sourcePath))
            {
                string text = File.ReadAllText(sourcePath);
                List<Estudio> estudios = new List<Estudio>();
                foreach (var item in text.Split(new[] {"\n\n"}, StringSplitOptions.None))
                {
                    Estudio newEstudio = Estudio.ParseStringToEstudio(item.Replace(item.Split('\n')[0]+"\n",""));
                    newEstudio.Nombre = item.Split('\n')[0];
                    estudios.Add(newEstudio);
                }

                if (File.Exists(outPath))
                {
                    foreach (var item in estudios)
                    {
                        item.PrintInFile(outPath);     
                    }
                }
                else
                {
                    Console.WriteLine("El Archivo Resultado.txt no existe. Favor Verificar");
                }
            }
            else
            {
                Console.WriteLine("El Archivo Muestras.txt no existe. Favor Verificar");
            }
            Console.Read();
        }
    }
}
