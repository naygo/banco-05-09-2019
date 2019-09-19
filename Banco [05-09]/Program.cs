using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Banco__05_09_
{
    class Program
    {
        static void Continuar()
        {
            Console.Write("\nQualquer tecla para continuar...");
            Console.ReadKey();
        }

        static void Main(string[] args)
        {

            List<Conta> contas = new List<Conta>();
            int opcao = 0;

            contas.Add(new Conta(7, "Nayla", 0.50));
            contas.Add(new Conta(3, "João", 1.00));
            contas.Add(new Conta(287, "Julia BTS", 7.00));

            do
            {
                Console.Clear();
                Console.WriteLine("Aplicação bancária\n");
                Console.WriteLine("O que deseja fazer?");
                Console.Write("[1] - Cadastrar conta \n[2] - Alterar conta \n[3] - Listar contas já cadastradas \n[4] - Excluir conta " +
                    "\n[5] - Quantidade de contas disponíveis \n[6] - Saldo de todas as contas somadas \n[7] - Fechar programa \n=> ");
                opcao = int.Parse(Console.ReadLine());

                switch (opcao)
                {
                    case 1:
                        Conta.Cadastrar(contas);
                        Continuar();
                        break;

                    case 2:
                        Conta.AlterarConta(contas);
                        Continuar();
                        break;

                    case 3:
                        Conta.ListarContas(contas);
                        Continuar();
                        break;

                    case 4:
                        Conta.ExcluiConta(contas);
                        Continuar();
                        break;

                    case 5:
                        SubRotinas.QtdContas(Conta.contador);
                        Continuar();
                        break;

                    case 6:
                        SubRotinas.SaldoContas(contas);
                        Continuar();
                        break;

                }
            } while (opcao != 7);

            Console.WriteLine("");
            Console.Write("Você encerrou o programa...");
            Console.ReadKey();
        }
    }
}
