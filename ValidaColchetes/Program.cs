using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ValidaColchetes
{
    class Program
    {
        static void Main(string[] args)
        {   

            // Sequências válidas
            string[] validas = {
            "({[(){}]})",      // Válidas
            "[({})({[]})]",    // Válidas
            "{[()()][{}]}",    // Válidas
            "[{([])}[{}]]",    // Válidas
            "{[({})]()[]}",    // Válidas
            "([{}][({})])",    // Válidas
        };

            // Sequências inválidas
            string[] invalidas = {
            "{[([)]}",          // Inválidas
            "[{(})({[]})]",     // Inválidas
            "({[})()({]})",     // Inválidas
            "[{([])}{[}]}",     // Inválidas
        };

            // Exibindo as sequências válidas
            int contador = 0;
            foreach (var itemEntrada in validas)
            {
                contador++;
                Console.WriteLine($"Resultado {contador}: {itemEntrada} Válido: {EntradaValida(itemEntrada)}");
            }
            
            // Exibindo as sequências inválidas
            foreach (var itemEntrada in invalidas)
            {
                contador++;
                Console.WriteLine($"Resultado {contador}: {itemEntrada} Válido: {EntradaValida(itemEntrada)}");
            }

            

            // Exibe uma mensagem pedindo ao usuário que insira algo
            Console.WriteLine("********************************");
            Console.WriteLine("********************************");

            Console.WriteLine("Olá, por favor insira sua sequência:");

            // Lê a entrada do usuário e armazena na variável nome
            string sequenciaUsuario = Console.ReadLine();

            bool valido = EntradaValida(sequenciaUsuario );

            string mensagem = valido ? "Válida" : "Inválida";
            Console.WriteLine($"A sequência {sequenciaUsuario} é {mensagem}");

            Console.WriteLine("********************************");
            Console.WriteLine("********************************");

            Console.WriteLine("Digite qualquer tecla para sair. Obrigado.");
            Console.ReadLine();
        }

        /// <summary>
        /// Esta é a função que determina se a sequencia de colchetes é válida (balanceada)
        /// </summary>
        /// <param name="entrada"></param>
        /// <returns></returns>
        static bool EntradaValida(string entrada)
        {
            List<char> listaAbertura = new List<char> { '(','[', '{' };
            List<char> listaFechamento = new List<char> { ')', ']', '}' };
            Dictionary<char, char> Verificador = new Dictionary<char, char>() 
            {
                {'(',')'},
                {'[',']'},
                {'{','}'}
            };
            bool retorno = false;
            Stack<char> pilha = new Stack<char>();

            for (int i = 0; i < entrada.Length; i++)
            {
                char simboloAtual = entrada[i];
                if (listaAbertura.Contains(simboloAtual))
                {
                    pilha.Push(simboloAtual);
                }
                else if(listaFechamento.Contains(simboloAtual))
                {
                    try
                    {
                        char ultimo = pilha.Peek();
                        char fechamento = Verificador[ultimo];
                        if (fechamento == simboloAtual)
                        {
                            pilha.Pop();
                        }
                        else
                        {
                            return false;
                        }
                    }
                    catch (Exception e)
                    {
                        //Se deu exception, é porque tentou desempilhar na pilha vazia;
                        return false;                        
                    }
                }

            }

            retorno = pilha.Count == 0;
            return retorno;
        }
    }
}
