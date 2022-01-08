using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Velha
{
    class Program
    {
        // ---------------------------------------------------------- //
        // ---------------------------------------------------------- //
           public static char[] Vetor = new char[10]; // Vetor com as informações do jogo
           public static int[] Colors = new int[10];  // Com  as corres do jogo 
           public static int Game = 0, Vez = 1; // Determina de quem é a vez
           public static int A, B; // controle de telas
        // ---------------------------------------------------------- //
        // ---------------------------------------------------------- //
          public static int AI1 = 0, AI2 = 0, Empat = 0, Ngames;
        static void Main()
        {
            int W = 0, Op = 0;
            A = Console.WindowWidth;
            B = Console.WindowHeight;
            A = 60;
            Console.SetWindowSize(A, B);              // Controle do tamanho da janela
            Console.Title = "Jogo da Velha";          // Controle de Titulo
            Game = 0; 
            Vez = 1;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("          Jogo da Velha");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Jogar");
                Console.WriteLine(" 2 - Jogo Aleatorio\n 3 - Jogo Test\n 4 - Analise do Jogo\n 5 - Sair");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write    (" Codigo: ");
                try
                {
                    Op = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Main();
                }
               switch(Op)
                {
                    case 1:
                        Velha(); // To players
                        break;

                    case 2:
                        Aleatorio(); // Agente aleatorio
                        break;

                    case 3:
                        StartTest(); // Testes com angente randomico
                        break;

                    case 4:
                        Analise(); // Analises do jogo da velha
                        break;

                    case 5:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ---------------------------------------------------------- //
        // ---------------------------------------------------------- //Jo
        public static void model() // Modelo
        {
            int W = 0, Op;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    Jogo da Velha");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Repetir\n 2 - Voltar\n 3 - Sair ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                Op = Convert.ToInt32(Console.ReadLine());
                switch (Op)
                {
                    case 1:
                        model();
                        break;

                    case 2:
                        Main();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Velha ()
        {
            int W = 0, Op = 0, Play = 0, Sort, i, Cont = 0, F;             // Game controla Fim de partida   
            Loading(); // Carrega os numeros inicialmente               // Determina qual jogada foi feita
            Random Rnd = new Random(); // Gera numero randomico
            Sort = Rnd.Next(1, 10);
            if (Sort%2 == 1) // Define quem começa jogando
            {
                Vez = 2;     // Define quem começa jogando
            }
            for (i = 0; i < 10; i++)
            {
                Colors[i] = 0;
            }
            do
            {
                do
                {
                    Tela();
                    Cont = Cont + 1;
                    if (Vez == 1) // Vez do Play 1
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                            Console.Write(" Escolha sua jogada [Play 1]: ");
                            try // teste de entrada
                            {
                                Play = Convert.ToInt32(Console.ReadLine());
                                if (Play > 9 || Play < 1)
                                {
                                   Main();
                                }
                            }
                            catch
                            {
                                Main();
                            }
                            if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O')) // verifica o vetor
                            {
                              Vetor[(Play - 1)] = 'X';
                              Colors[(Play - 1)] = 1;
                              Vez = 2;
                            }
                            else
                            {
                                Vez = 1;  // Caso o usuario não possa mais fazer e tente
                            }                      
                        }
                        else
                        {
                            if (Vez == 2) // Vez do Play 2
                        {
                                Console.ForegroundColor = ConsoleColor.Green;
                                Console.Write(" Escolha sua jogada [Play 2]: ");
                                try // teste de entrada
                                {
                                    Play = Convert.ToInt32(Console.ReadLine());
                                    if (Play > 9 || Play < 1)
                                    {
                                        Main();
                                    }
                                }
                                catch
                                {
                                    Main();
                                }
                                if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O'))
                                {
                                    Vetor[(Play - 1)] = 'O';
                                    Colors[(Play - 1)] = 2;
                                    Vez = 1;
                                }
                                else
                                {
                                     Vez = 2; // Caso o usuario não possa mais fazer e tente 
                                }
                            }
                        }                     
                        Game = AnalisarPartida();
                        if ((Game == 0) && (Cont == 9))
                        {
                            Cont = 0;
                            Vez = 3;
                            Game = 1;
                        }
                } while (Game == 0);
                Tela();
                if (Vez == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" Play 2 Vence a Partida ");
                }
                else
                {
                    if (Vez == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" Play 1 Vence a Partida ");
                    }
                    else
                    {
                        if (Vez == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(" Empate Jogo em Velha ");
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Voltar\n 2 - Sair");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write    (" Codigo: ");
                try
                {
                    Op = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Main();
                }
                switch (Op)
                {
                    case 1:
                        Main();
                        break;

                    case 2:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Loading () // Carrega o vetor
        {
            Vetor[0] = '1';
            Vetor[1] = '2';
            Vetor[2] = '3';
            Vetor[3] = '4';
            Vetor[4] = '5';
            Vetor[5] = '6';
            Vetor[6] = '7';
            Vetor[7] = '8';
            Vetor[8] = '9';
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static int AnalisarPartida() // Analisa os casos onde aconteceram vitorias e muda o jogo pra ganho
        {
            if ((Vetor[0] == 'O' && Vetor[1] == 'O' && Vetor[2] == 'O') ||
                (Vetor[0] == 'X' && Vetor[1] == 'X' && Vetor[2] == 'X'))
            {
                Game = 1;
            }
            else
            {
                if ((Vetor[3] == 'O' && Vetor[4] == 'O' && Vetor[5] == 'O') ||
                   (Vetor[3] == 'X' && Vetor[4] == 'X' && Vetor[5] == 'X'))
                {
                    Game = 1;
                }
                else
                {
                    if ((Vetor[6] == 'O' && Vetor[7] == 'O' && Vetor[8] == 'O') ||
                       (Vetor[6] == 'X' && Vetor[7] == 'X' && Vetor[8] == 'X'))
                    {
                        Game = 1;
                    }
                    else
                    {
                        if ((Vetor[0] == 'O' && Vetor[3] == 'O' && Vetor[6] == 'O') ||
                           (Vetor[0] == 'X' && Vetor[3] == 'X' && Vetor[6] == 'X'))
                        {
                            Game = 1;
                        }
                        else
                        {
                            if (((Vetor[1] == 'O' && Vetor[4] == 'O' && Vetor[7] == 'O') ||
                               (Vetor[1] == 'X' && Vetor[4] == 'X' && Vetor[7] == 'X')))
                            {
                                Game = 1;
                            }
                            else
                            {
                                if ((Vetor[2] == 'O' && Vetor[5] == 'O' && Vetor[8] == 'O') ||
                                    (Vetor[2] == 'X' && Vetor[5] == 'X' && Vetor[8] == 'X'))
                                {
                                    Game = 1;
                                }
                                else
                                {
                                    if ((Vetor[0] == 'O' && Vetor[4] == 'O' && Vetor[8] == 'O') ||
                                       (Vetor[0] == 'X' && Vetor[4] == 'X' && Vetor[8] == 'X'))
                                    {
                                        Game = 1;
                                    }
                                    else
                                    {
                                        if ((Vetor[6] == 'O' && Vetor[4] == 'O' && Vetor[2] == 'O') ||
                                           (Vetor[6] == 'X' && Vetor[4] == 'X' && Vetor[2] == 'X'))
                                        {
                                            Game = 1;
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
            }
            return Game;
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Tela() // Atualiza a tela do jogo
        {           
                    Console.Clear();
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" --------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("          Jogo da Velha");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" --------------------------------\n");

                    Console.WriteLine("   -------------------------");
                    Console.Write("   |   ");
                    if (Colors[0] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        if (Colors[0] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            if (Colors[0] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                    }
                    Console.Write("" + Vetor[0]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   |   ");
                    if (Colors[1] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        if (Colors[1] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            if (Colors[1] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                    }
                    Console.Write("" + Vetor[1]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   |   ");
                    if (Colors[2] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        if (Colors[2] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            if (Colors[2] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                    }
                    Console.Write("" + Vetor[2]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   |\n");
                    Console.WriteLine("   -------------------------");
                    Console.Write("   |   ");
                    if (Colors[3] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        if (Colors[3] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            if (Colors[3] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                    }
                    Console.Write("" + Vetor[3]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   |   ");
                    if (Colors[4] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        if (Colors[4] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            if (Colors[4] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                    }
                    Console.Write("" + Vetor[4]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   |   ");
                    if (Colors[5] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        if (Colors[5] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            if (Colors[5] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                    }
                    Console.Write("" + Vetor[5]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   |\n");
                    Console.WriteLine("   -------------------------");
                    Console.Write("   |   ");
                    if (Colors[6] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        if (Colors[6] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            if (Colors[6] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                    }
                    Console.Write("" + Vetor[6]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   |   ");
                    if (Colors[7] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        if (Colors[7] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            if (Colors[7] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                    }
                    Console.Write("" + Vetor[7]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   |   ");
                    if (Colors[8] == 0)
                    {
                        Console.ForegroundColor = ConsoleColor.Yellow;
                    }
                    else
                    {
                        if (Colors[8] == 1)
                        {
                            Console.ForegroundColor = ConsoleColor.Cyan;
                        }
                        else
                        {
                            if (Colors[8] == 2)
                            {
                                Console.ForegroundColor = ConsoleColor.Green;
                            }
                        }
                    }
                    Console.Write("" + Vetor[8]);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write("   |\n");
                    Console.WriteLine("   -------------------------");

                    Console.WriteLine("");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" --------------------------------");
         }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Aleatorio ()
            {
            int W = 0, W1 = 0, Op = 0, Val = 0, Play = 0, Sort, i, Cont = 0, ContBanc = 0,  F;     // Game controla Fim de partida   
            int[] Banco = new int[10];
            Loading(); // Carrega os numeros inicialmente               // Determina qual jogada foi feita
            Random Rnd = new Random(); // Gera numero randomico
            Sort = Rnd.Next(1, 10);
            if (Sort % 2 == 1) // Define quem começa jogando
            {
                Vez = 2;     // Define quem começa jogando
            }
            for (i = 0; i < 10; i++)
            {
                Colors[i] = 0;
                Banco[i] = -1;
            }
            do
            {
                do
                {
                    Tela();
                    Cont = Cont + 1;
                    if (Vez == 1) // Vez do Play 1
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        try // teste de entrada
                        {
                            do
                            {
                                Play = Rnd.Next(1, 10);
                                    for (i=0; i <10; i++)
                                    {
                                        if (Banco[i] == Play)
                                        {
                                            Val = 1;
                                        }
                                    }
                                    if (Val == 1)
                                    {
                                      W1 = 0;
                                      Val = 0;
                                    }
                                    else
                                    {
                                         W1 = 1;
                                         Banco[ContBanc] = Play;
                                         ContBanc = ContBanc + 1;
                                    }
                            } while (W1 == 0);
                            W1 = 0;
                            Val = 0;
                            if (Play > 9 || Play < 1)
                            {
                                Vez = 1;
                            }
                            Console.Write(" Jogada [IA 1]: " + Play);
                        }
                        catch
                        {
                            Vez = 1;
                        }
                        if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O')) // verifica o vetor
                        {
                            Vetor[(Play - 1)] = 'X';
                            Colors[(Play - 1)] = 1;
                            Vez = 2;
                        }
                        else
                        {
                            Vez = 1;  // Caso o usuario não possa mais fazer e tente
                            Cont = Cont - 1;
                        }
                    }
                    else
                    {
                        if (Vez == 2) // Vez do Play 2
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            try // teste de entrada
                            {
                                do
                                {
                                    Play = Rnd.Next(1, 10);
                                    for (i = 0; i < 10; i++)
                                    {
                                        if (Banco[i] == Play)
                                        {
                                            Val = 1;
                                        }
                                    }
                                    if (Val == 1)
                                    {
                                        W1 = 0;
                                        Val = 0;
                                    }
                                    else
                                    {
                                        W1 = 1;
                                        Banco[ContBanc] = Play;
                                        ContBanc = ContBanc + 1;
                                    }

                                } while (W1 == 0);
                                W1 = 0;
                                Val = 0;
                                if (Play > 9 || Play < 1)
                                {
                                    Vez = 2;
                                }
                                Console.Write(" Jogada [IA 2]: " + Play);
                            }
                            catch
                            {
                                Vez = 2;
                            }
                            if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O'))
                            {
                                Vetor[(Play - 1)] = 'O';
                                Colors[(Play - 1)] = 2;
                                Vez = 1;
                            }
                            else
                            {
                                Vez = 2; // Caso o usuario não possa mais fazer e tente 
                                Cont = Cont - 1;
                            }
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n --------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" Loading...  ");
                    for (i = 0; i < 505550000; i++)
                    {
                        F = i * 2;
                    }
                    F = 0;
                    Game = AnalisarPartida();
                    if ((Game == 0) && (Cont == 9))
                    {
                        Cont = 0;
                        Vez = 3;
                        Game = 1;
                    }
                } while (Game == 0);
                Tela();
                if (Vez == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" IA 2 Vence a Partida ");
                }
                else
                {
                    if (Vez == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" IA 1 Vence a Partida ");
                    }
                    else
                    {
                        if (Vez == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(" Empate Jogo em Velha ");
                        }
                    }
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Voltar\n 2 - Sair");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                try
                {
                    Op = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    Main();
                }
                switch (Op)
                {
                    case 1:
                        Main();
                        break;

                    case 2:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Estatisticas ()
        {
            int W = 0, W1 = 0, Val = 0, Play = 0, Sort, i, Cont = 0, ContBanc = 0, F;     // Game controla Fim de partida   
            int[] Banco = new int[10];
            Loading(); // Carrega os numeros inicialmente               // Determina qual jogada foi feita
            Random Rnd = new Random(); // Gera numero randomico
            Sort = Rnd.Next(1, 10);
            if (Sort % 2 == 1) // Define quem começa jogando
            {
                Vez = 2;     // Define quem começa jogando
            }
            else
            {
                Vez = 1;
            }
            for (i = 0; i < 10; i++)
            {
                Colors[i] = 0;
                Banco[i] = -1;
            }
                do
                {
                    Tela();
                    Cont = Cont + 1;
                    if (Vez == 1) // Vez do Play 1
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        try // teste de entrada
                        {
                            do
                            {
                                Play = Rnd.Next(1, 10);
                                for (i = 0; i < 10; i++)
                                {
                                    if (Banco[i] == Play)
                                    {
                                        Val = 1;
                                    }
                                }
                                if (Val == 1)
                                {
                                    W1 = 0;
                                    Val = 0;
                                }
                                else
                                {
                                    W1 = 1;
                                    Banco[ContBanc] = Play;
                                    ContBanc = ContBanc + 1;
                                }
                            } while (W1 == 0);
                            W1 = 0;
                            Val = 0;
                            if (Play > 9 || Play < 1)
                            {
                                Vez = 1;
                            }
                            Console.Write(" Jogada [IA 1]: " + Play);
                        }
                        catch
                        {
                            Vez = 1;
                        }
                        if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O')) // verifica o vetor
                        {
                            Vetor[(Play - 1)] = 'X';
                            Colors[(Play - 1)] = 1;
                            Vez = 2;
                        }
                        else
                        {
                            Vez = 1;  // Caso o usuario não possa mais fazer e tente
                            Cont = Cont - 1;
                        }
                    }
                    else
                    {
                        if (Vez == 2) // Vez do Play 2
                        {
                            Console.ForegroundColor = ConsoleColor.Green;
                            try // teste de entrada
                            {
                                do
                                {
                                    Play = Rnd.Next(1, 10);
                                    for (i = 0; i < 10; i++)
                                    {
                                        if (Banco[i] == Play)
                                        {
                                            Val = 1;
                                        }
                                    }
                                    if (Val == 1)
                                    {
                                        W1 = 0;
                                        Val = 0;
                                    }
                                    else
                                    {
                                        W1 = 1;
                                        Banco[ContBanc] = Play;
                                        ContBanc = ContBanc + 1;
                                    }

                                } while (W1 == 0);
                                W1 = 0;
                                Val = 0;
                                if (Play > 9 || Play < 1)
                                {
                                    Vez = 2;
                                }
                                Console.Write(" Jogada [IA 2]: " + Play);
                            }
                            catch
                            {
                                Vez = 2;
                            }
                            if ((Vetor[(Play - 1)] != 'X') && (Vetor[(Play - 1)] != 'O'))
                            {
                                Vetor[(Play - 1)] = 'O';
                                Colors[(Play - 1)] = 2;
                                Vez = 1;
                            }
                            else
                            {
                                Vez = 2; // Caso o usuario não possa mais fazer e tente 
                                Cont = Cont - 1;
                            }
                        }
                    }
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("\n --------------------------------");
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" --------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine(" AI 1 : " + AI1);
                    Console.WriteLine(" AI 2 : " + AI2);
                    Console.WriteLine(" Empt : " + Empat);
                    Console.WriteLine(" N    : " + Ngames);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" --------------------------------");
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.Write(" Loading...  ");
                    for (i = 0; i < 5055500; i++)
                    {
                        F = i * 2;
                    }
                    F = 0;
                    Game = AnalisarPartida();
                    if ((Game == 0) && (Cont == 9))
                    {
                        Cont = 0;
                        Vez = 3;
                        Game = 1;
                    }
                } while (Game == 0);
                Game = 0;
                Tela();
                if (Vez == 1)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine(" IA 2 Vence a Partida ");
                    AI2 = AI2 + 1;
                }
                else
                {
                    if (Vez == 2)
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        Console.WriteLine(" IA 1 Vence a Partida ");
                        AI1 = AI1 + 1;
                    }
                    else
                    {
                        if (Vez == 3)
                        {
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.WriteLine(" Empate Jogo em Velha ");
                            Empat = Empat + 1;
                        }
                    }
                }
                Ngames = Ngames + 1;
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void StartTest ()
        {
            int Op = 0, W = 0, Qtd = 0, i;

            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    Jogo da Velha - Estatiscas");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write    (" Digite a Qtd de Jogos: ");
                try
                {
                   Qtd = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    StartTest();
                }
                for (i=0; i<Qtd; i++)
                {
                    Estatisticas();
                }
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" AI 1 : " + AI1);
                Console.WriteLine(" AI 2 : " + AI2);
                Console.WriteLine(" Empt : " + Empat);
                Console.WriteLine(" N    : " + Ngames);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Repetir \n 2 - Voltar \n 3 - Sair");
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                try
                {
                    Op = Convert.ToInt32(Console.ReadLine());
                }
                catch
                {
                    StartTest();
                }
                switch (Op)
                {
                    case 1:
                        W = 0;
                        break;

                    case 2:
                        Empat  = 0;
                        AI1    = 0;
                        AI2    = 0;
                        Ngames = 0;
                        Main();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;
                }

            } while (W == 0);

        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
        public static void Analise() // Modelo
        {
            int W = 0, Op, i, j, cont = 10, Total = 0, Mult = 1;
            do
            {
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("    Jogo da Velha");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow; 
                for (i=0; i<10; i++)
                {
                    cont = cont - 1; 
                    for(j=cont; j>1; j--)
                    {
                        Mult = Mult  * j;
                        Console.WriteLine(" Cont: "+cont+" e total: "+Total+" Mult: "+Mult);
                    }
                    Console.WriteLine(" Fatorial: "+Mult);
                    Total = Total + Mult;
                    Mult = 1;
                }
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" Resultado: "+Total);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" 1 - Repetir\n 2 - Voltar\n 3 - Sair ");
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine(" --------------------------------");
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(" Codigo: ");
                Op = Convert.ToInt32(Console.ReadLine());
                switch (Op)
                {
                    case 1:
                        Analise();
                        break;

                    case 2:
                        Main();
                        break;

                    case 3:
                        Environment.Exit(0);
                        break;
                }
            } while (W == 0);
        }
        // ----------------------------------------------------------- //
        // ----------------------------------------------------------- //
    }
}
