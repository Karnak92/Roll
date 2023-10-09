using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Roll.Models
{
    public class Dados
    {
        public int D4()
        {
            Random rnd = new Random();
            int resultado = rnd.Next(1, 5);
            return resultado;
        }
        public int D6()
        {
            Random rnd = new Random();
            int resultado = rnd.Next(1, 7);
            return resultado;
        }
        public int D8()
        {
            Random rnd = new Random();
            int resultado = rnd.Next(1, 9);
            return resultado;
        }
        public int D10()
        {
            Random rnd = new Random();
            int resultado = rnd.Next(1, 11);
            return resultado;
        }
        public int D12()
        {
            Random rnd = new Random();
            int resultado = rnd.Next(1, 13);
            return resultado;
        }
        public int D20()
        {
            Random rnd = new Random();
            int resultado = rnd.Next(1, 21);
            return resultado;
        }

    }
}