using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco__05_09_
{
    class Conta
    {
        public static int contador = 0;
        int numConta;
        string titular;
        double saldo;
        Conta[] contas = new Conta[Conta.contador];

        //metodos de acesso (get e set):
        public int getNumConta() { return numConta; }
        public void setNumConta(int _numConta) { this.numConta = _numConta; }

        public string getTitular() { return this.titular; }
        public void setTitular(string _titular) { this.titular = _titular; }

        public double getSaldo() { return this.saldo; }
        public void setSaldo(double _saldo) { this.saldo = _saldo; }


        public Conta(int _numConta, string _titular, double _saldo)
        {
            if (contador < 10 && SubRotinas.NumContaValido(_numConta) == true)
            {
                contador++;
                this.numConta = _numConta;
                this.titular = _titular;
                this.saldo = _saldo;
                MessagemSucesso();
            }
            else
                if (SubRotinas.NumContaValido(_numConta) == false)
                Console.WriteLine("Número de conta inválido");
            else
                Console.WriteLine("Total de 10 intâncias atingido...");
        }

        public static void Cadastrar(List<Conta> contas)
        {
            Console.Clear();
            Console.WriteLine("CADASTRANDO CONTAS: \n");
            if (contador < 10)
            {
                Console.Write("Número conta: ");
                int numConta = int.Parse(Console.ReadLine());

                while (SubRotinas.VerificaNumConta(contas, numConta) == false)
                {
                    Console.Write("Número já cadastrado, tente outro: ");
                    numConta = int.Parse(Console.ReadLine());
                }

                Console.Write("Nome do titular: ");
                string nome = Console.ReadLine();

                Console.Write("Saldo: R$");
                double saldo = double.Parse(Console.ReadLine());

                contas.Add(new Conta(numConta, nome, saldo));
            }
            else
                Console.WriteLine("Total de 10 intâncias atingido...");
        }

        public static void ListarContas(List<Conta> contas)
        {
            Console.Clear();
            Conta[] vetContas = contas.ToArray();
            Console.WriteLine("LISTANDO CONTAS: \n");
            for (int i = 0; i < vetContas.Length; i++)
            {
                Console.WriteLine($"Número: {vetContas[i].getNumConta()}");
                Console.WriteLine($"Titular: {vetContas[i].getTitular()}");
                Console.WriteLine($"Saldo: {vetContas[i].getSaldo()}");
                Console.WriteLine("");
            }
        }

        public static void AlterarConta(List<Conta> contas)
        {
            ListarContas(contas);
            Conta[] vetConta = contas.ToArray();

            Console.Write("Digite o número da conta que deseja ALTERAR: ");
            int numAlt = int.Parse(Console.ReadLine());

            if (SubRotinas.NumContaRepetido(contas, numAlt) == true)
            {

                for (int i = 0; i < vetConta.Length; i++)
                {
                    if (numAlt == vetConta[i].getNumConta())
                    {
                        Console.Write("Novo número: ");
                        int numero = int.Parse(Console.ReadLine());
                        while (SubRotinas.VerificaNumConta(contas, numero) == false)
                        {
                            Console.Write("Número já cadastrado ou inválido, tente outro: ");
                            numero = int.Parse(Console.ReadLine());
                        }
                        vetConta[i].setNumConta(numero);
                        Console.Write("Novo titular: ");
                        vetConta[i].setTitular(Console.ReadLine());
                        Console.Write("Novo saldo: R$");
                        vetConta[i].setSaldo(double.Parse(Console.ReadLine()));
                    }
                }
            }
            else
                Console.WriteLine("Conta inexistente!");
        }


        public static void ExcluiConta(List<Conta> contas)
        {
            Console.Clear();
            ListarContas(contas);
            Console.Write("Insira o número da conta que deseja DELETAR: ");
            int numContaDel = int.Parse(Console.ReadLine());

            Conta[] vetContas = contas.ToArray();

            if (SubRotinas.NumContaRepetido(contas, numContaDel))
            {
                for (int i = 0; i < vetContas.Length; i++)
                {
                    if (vetContas[i].getNumConta() == numContaDel)
                    {
                        Conta deletar = vetContas[i];
                        contas.Remove(deletar);
                        contador--;
                        MessagemSucesso();
                    }
                }
            }
            else
                Console.WriteLine("Conta inexistente!");
        }


        public static void MessagemSucesso()
        {
            Console.WriteLine();
            Console.WriteLine("Sucesso!");
        }

        ~Conta()
        {
            contador--;
        }

    }
}
