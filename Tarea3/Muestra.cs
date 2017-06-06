using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tarea3
{
    class Muestra
    {
        public string Nombre { get; set; }
        public List<double> Datos { get; set; }

        public List<double> Moda(){
            List<double> list = new List<double>();
            int maxCount = 1;

            foreach (var item in Datos)
            {
                int count = 0;
                foreach (var elem in Datos)
                {
                    if (elem == item) ++count;
                }

                if (count > maxCount)
                {
                    list = new List<double>();
                    list.Add(item);
                    maxCount = count;
                }
                else if (count == maxCount)
                {
                    if (maxCount > 1)
                    {
                        list.Add(item);
                    }
                }
            }

            return list;
        }
        public double Media (){
            return Datos.Sum()/Datos.Count;
        }
        public double Mediana(){
            var sortedList = from number in Datos
                             orderby number
                             select number;

            int count = sortedList.Count();
            int itemIndex = count / 2;
            if (count % 2 == 0) 
                return (sortedList.ElementAt(itemIndex) +
                        sortedList.ElementAt(itemIndex - 1)) / 2;

            return sortedList.ElementAt(itemIndex); 
        }
        public double Varianza(){
            var sum = 0.0;
            foreach (var dato in Datos)
            {
                sum = sum + Math.Pow(dato - Media(),2);   
            }
            return sum / Datos.Count ;
        }
        public double DesviacionEstandar(){
            var sum = 0.0;
            foreach (var dato in Datos)
            {
                sum = sum + Math.Pow(dato - Media(), 2);
            }
            return Math.Sqrt(sum / Datos.Count-1) ;
        }
        // public double Moda(){
        //     return result.Mode;
        // };
        // public double Media (){
        //     return result.Mean;
        // };
        // public double Mediana(){
        //     return result.Median;
        // };
        // public double Varianza(){
        //     return result.Variance;
        // };
        // public double DesviacionEstandar(){
        //     return result.StdDev;
        // };
    }
}
