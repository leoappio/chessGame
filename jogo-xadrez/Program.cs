﻿using System;
using tabuleiro;
using xadrez;

namespace jogo_xadrez
{
    class Program
    {
        static void Main(string[] args)
        {

            try
            {

                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    try
                    {
                        Console.Clear();
                        Tela.imprimirPartida(partida);        

                        Console.WriteLine();
                        Console.Write("Origem: ");
                        Posicao origem = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeOrigem(origem);

                        bool[,] posicoesPossiveis = partida.tab.getPeca(origem).movimentosPossiveis();

                        Console.Clear();
                        Tela.ImprimirTabuleiro(partida.tab, posicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("Destino: ");
                        Posicao destino = Tela.lerPosicaoXadrez().toPosicao();
                        partida.validarPosicaoDeDestino(origem, destino);

                        partida.realizaJogada(origem, destino);

                    }
                    catch(ExcecoesTabuleiro erro)
                    {
                        Console.WriteLine(erro.Message);
                        Console.ReadLine();
                    }

                }

                Console.Clear();
                Tela.imprimirPartida(partida);
            }
            catch (ExcecoesTabuleiro e)
            {
                Console.WriteLine(e.Message);
            }

            Console.ReadLine();
        }
    }
}
