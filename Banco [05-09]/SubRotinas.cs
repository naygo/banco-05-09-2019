using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco__05_09_
{
    static class SubRotinas
    {
        public static void QtdContas(int contador)
        {
            Console.WriteLine();
            Console.WriteLine("Quantidade de contas restante é " + (10 - contador));
        }

        public static void SaldoContas(List<Conta> contas)
        {
            Conta[] vetContas = contas.ToArray();
            double saldoTotal = 0;
            for (int i = 0; i < vetContas.Length; i++)
            {
                saldoTotal += vetContas[i].getSaldo();
            }
            Console.WriteLine();
            Console.WriteLine("A soma de todos os saldos do banco é: R$" + saldoTotal);
        }

        public static bool NumContaValido(int numConta) 
        {
            if (numConta > 1 && numConta < 999)
                return true;
            return false;
        }
        
        public static bool NumContaRepetido(List<Conta> contas, int numConta)
        {
            Conta[] vetContas = contas.ToArray();
            bool numRepetido = false;

            for (int i = 0; i < vetContas.Length; i++)
            {
                if (vetContas[i].getNumConta() == numConta)
                    numRepetido = true;
            }

            return numRepetido;
        }

        public static bool VerificaNumConta(List<Conta> contas, int numConta)
        {

            if (NumContaRepetido(contas, numConta) == false && NumContaValido(numConta))
                return true;

            return false;
           
        }
       
    }
}
