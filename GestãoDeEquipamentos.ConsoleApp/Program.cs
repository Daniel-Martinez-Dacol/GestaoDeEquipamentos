﻿using System;

namespace GestaoDeEquipamentos.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string menuDeOpcoes;
            int indiceDoEquipamento = 0;

            string[] listaNomeEquipamentos = new string[1000];
            decimal?[] listaPrecoEquipamentos = new decimal?[1000];
            string[] listaNumeroDeSerieEquipamentos = new string[1000];
            DateTime?[] listaDataDeFabricacaoEquipamentos = new DateTime?[1000];
            string[] listaFabricanteEquipamentos = new string[1000];

            string[] listaTitulosChamados = new string[1000];
            string[] listaDescricaoChamados = new string[1000];
            string[] listaEquipamentosChamados = new string[1000];
            DateTime?[] listaDataAberturaChamados = new DateTime?[1000];
            int indiceDoChamado = 0;

            do
            {
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.WriteLine("================== MENU DE OPÇÕES ==================\n");
                Console.WriteLine("-Digite 1: para cadatrar um novo equipamento.\n" +
                    "-Digite 2: Editar um produto do inventario.\n" +
                    "-Digite 3: Para Excluir um equipamento.\n" +
                    "-Digite 4: Para visualizar o inventário de Equipamentos.\n" +
                    "-Digite 5: Para gerenciar Chamados.\n" +
                    "-Digite 6: Para encerrar\n");
                Console.WriteLine("======================================================\n");
                Console.ResetColor();
                Console.Write("-Digite o opção desejada: ");
                menuDeOpcoes = Console.ReadLine();
                Console.Clear();

                switch (menuDeOpcoes)
                {
                    case "1":
                        indiceDoEquipamento = CriarEquipamento(listaNomeEquipamentos, listaPrecoEquipamentos, listaNumeroDeSerieEquipamentos, listaDataDeFabricacaoEquipamentos, listaFabricanteEquipamentos, indiceDoEquipamento);
                        break;

                    case "2":
                        VisualizarListaEquipamentos(listaNomeEquipamentos, listaNumeroDeSerieEquipamentos, listaFabricanteEquipamentos);
                        EditarEquipamento(listaNomeEquipamentos, listaPrecoEquipamentos, listaNumeroDeSerieEquipamentos, listaDataDeFabricacaoEquipamentos, listaFabricanteEquipamentos);
                        break;

                    case "3":
                        VisualizarListaEquipamentos(listaNomeEquipamentos, listaNumeroDeSerieEquipamentos, listaFabricanteEquipamentos);
                        ExcluirEquipamento(ref listaNomeEquipamentos, ref listaPrecoEquipamentos, ref listaNumeroDeSerieEquipamentos, ref listaDataDeFabricacaoEquipamentos, ref listaFabricanteEquipamentos, ref listaEquipamentosChamados);
                        break;

                    case "4":
                        VisualizarListaEquipamentos(listaNomeEquipamentos, listaNumeroDeSerieEquipamentos, listaFabricanteEquipamentos);
                        break;

                    case "5":
                        GerenciarChamados(listaTitulosChamados, listaDescricaoChamados, listaEquipamentosChamados, listaNomeEquipamentos, listaDataAberturaChamados, indiceDoChamado);
                        break;

                    case "6":
                        break;
                }

            } while (menuDeOpcoes != "6");
        }

        static void GerenciarChamados(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos, DateTime?[] listaDataAberturaChamados, int indiceDoChamado)
        {
            string menuChamados;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("================== MENU DE OPÇÕES DOS CHAMADOS ==================\n");
                Console.WriteLine("-Digite 1: para criar um chamado.\n" +
                    "-Digite 2: para visualizar os chamados.\n" +
                    "-Digite 3: Editar um chamado\n" +
                    "-Digite 4: Para Excluir um chamado.\n" +
                    "-Digite 5: Para encerrar.\n");
                Console.WriteLine("==================================================================\n");
                Console.ResetColor();
                Console.Write("-Digite a opção desejada: ");
                menuChamados = Console.ReadLine();
                Console.Clear();
                switch (menuChamados)
                {
                    case "1":
                        indiceDoChamado = CriarChamado(listaTitulosChamados, listaDescricaoChamados, listaEquipamentoDoChamado, listaNomeEquipamentos, listaDataAberturaChamados, indiceDoChamado);
                        break;

                    case "2":
                        VisualizarListaChamados(listaTitulosChamados, listaEquipamentoDoChamado, listaDataAberturaChamados);
                        break;

                    case "3":
                        VisualizarListaChamados(listaTitulosChamados, listaEquipamentoDoChamado, listaDataAberturaChamados);
                        EditarListaChamados(listaTitulosChamados, listaDescricaoChamados, listaEquipamentoDoChamado, listaNomeEquipamentos, listaDataAberturaChamados);
                        break;

                    case "4":
                        VisualizarListaChamados(listaTitulosChamados, listaEquipamentoDoChamado, listaDataAberturaChamados);
                        ExcluirListaChamados(listaTitulosChamados, listaDescricaoChamados, listaEquipamentoDoChamado, listaDataAberturaChamados);
                        break;

                    case "5":
                        break;
                }

            } while (menuChamados != "5");
        }

        static void ExcluirListaChamados(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado, DateTime?[] listaDataAberturaChamados)
        {
            Console.WriteLine();
            Console.WriteLine("Digite o nome do chamado que será excluído: ");
            string chamadoParaExcluir = Console.ReadLine();

            for (int i = 0; i < listaTitulosChamados.Length; i++)
            {
                if (listaTitulosChamados[i] == chamadoParaExcluir)
                {
                    listaTitulosChamados[i] = null;
                    listaDescricaoChamados[i] = null;
                    listaEquipamentoDoChamado[i] = null;
                    listaDataAberturaChamados[i] = null;
                }
            }
        }

        static void EditarListaChamados(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos, DateTime?[] listaDataAberturaChamados)
        {
            Console.WriteLine();
            Console.Write("Digite o título do Chamado que será editado: ");
            string chamadoAhSerAlterado = Console.ReadLine();

            var indiceDoChamado = BuscarIndiceChamado(listaTitulosChamados, chamadoAhSerAlterado);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("================== MENU DE OPÇÕES DA EDIÇÃO DO CHAMADO ==================\n");
            Console.WriteLine("-Digite 1: Para editar o título do chamado\n" +
                    "-Digite 2: Para editar a descrição do chamado\n" +
                    "-Digite 3: Para editar o equipamento do chamado\n" +
                    "-Digite 4: Para editar a data de abertura do chamado\n" +
                    "-Digite 5: para encerrar a edição do equipamente.\n");
            Console.WriteLine("==========================================================================\n");
            Console.ResetColor();
            Console.Write("-Digite a opção desejada: ");
            string menuEdicao = Console.ReadLine();
            Console.Clear();
            switch (menuEdicao)
            {
                case "1":
                    EditarPropriedadeChamado(listaTitulosChamados, Convert.ToInt32(indiceDoChamado), "título");
                    break;

                case "2":
                    EditarPropriedadeChamado(listaDescricaoChamados, Convert.ToInt32(indiceDoChamado), "descrição");
                    break;

                case "3":
                    EditarEquipamentoDoChamado(listaEquipamentoDoChamado, listaNomeEquipamentos, Convert.ToInt32(indiceDoChamado));
                    break;

                case "4":
                    EditarDataDeFabricacaoDoEquipamento(listaDataAberturaChamados, Convert.ToInt32(indiceDoChamado));
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO: Opção Inválida!");
                    Console.ResetColor();
                    break;
            }
        }

        static void EditarEquipamentoDoChamado(string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos, int indiceDoChamado)
        {
            bool equipamentoEncontrado = false;
            BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);
            while (equipamentoEncontrado == false)
            {
                Console.WriteLine();
                Console.WriteLine("Nenhum equipamento com este nome foi encontrado.");
                BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);
            }
            Console.WriteLine();
        }

        static void VisualizarListaChamados(string[] listaTitulosChamados, string[] listaEquipamentoDoChamado, DateTime?[] listaDataAberturaChamados)
        {
            for (int i = 0; i < listaTitulosChamados.Length; i++)
            {
                if (listaTitulosChamados[i] != null)
                {
                    var quantidadeDiasChamadoAberto = (DateTime.Now.Date - listaDataAberturaChamados[i].Value.Date).TotalDays;

                    Console.WriteLine();
                    Console.WriteLine($"Chamado: {listaTitulosChamados[i]} - Equipamento: {listaEquipamentoDoChamado[i]} - Data de Abertura do Chamado: {listaDataAberturaChamados[i]} - Dias Chamado em Aberto: {quantidadeDiasChamadoAberto}");
                    Console.WriteLine();
                }
            }
        }

        static int CriarChamado(string[] listaTitulosChamados, string[] listaDescricaoChamados, string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos, DateTime?[] listaDataAberturaChamados, int indiceDoChamado)
        {
            bool jaExisteEquipamentoLista = VerificarSeExisteEquipamentoLista(listaNomeEquipamentos);
            if (jaExisteEquipamentoLista == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: Não é possível criar um chamado, pois ainda não existem equipamentos na lista.");
                Console.ResetColor();
                return indiceDoChamado;
            }

            Console.WriteLine();
            VerificaEPreencheTituloDoChamado(listaTitulosChamados, indiceDoChamado);

            Console.WriteLine();
            VerificaEPreencheDescricaoDoChamado(listaDescricaoChamados, indiceDoChamado);

            bool equipamentoEncontrado;
            BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);
            while (equipamentoEncontrado == false)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Nenhum equipamento com este nome foi encontrado.");
                Console.ResetColor();
                BuscarEValidarNomeEquipamento(listaEquipamentoDoChamado, listaNomeEquipamentos, out equipamentoEncontrado, indiceDoChamado);
            }

            Console.WriteLine();

            Console.WriteLine();
            VerificaEPreencheDataDeAberturaChamado(listaDataAberturaChamados, indiceDoChamado);

            indiceDoChamado++;
            Console.WriteLine($"Chamado {indiceDoChamado} Registrado");

            return indiceDoChamado;
        }

        static void VerificaEPreencheDataDeAberturaChamado(DateTime?[] listaDataAberturaChamados, int indiceDoChamado)
        {
            Console.Write("Digite a data de Abertura do Chamado (formato: --/--/----):");
            string dataDeAberturaDigitada = Console.ReadLine();

            while (dataDeAberturaDigitada == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: data de fabricação inválida.");
                Console.ResetColor();
                Console.Write("Digite a data de fabricação do Equipamento (formato: --/--/----):");
                dataDeAberturaDigitada = Console.ReadLine();
            }
            listaDataAberturaChamados[indiceDoChamado] = Convert.ToDateTime(dataDeAberturaDigitada);
        }

        static bool VerificarSeExisteEquipamentoLista(string[] listaNomeEquipamentos)
        {
            for (int i = 0; i < listaNomeEquipamentos.Length; i++)
            {
                if (listaNomeEquipamentos[i] != null)
                {
                    return true;
                }
            }
            return false;
        }

        static void VerificaEPreencheDescricaoDoChamado(string[] listaDescricaoChamados, int indiceDoChamado)
        {
            Console.Write("Digite a descrição do Chamado:");
            string descricaoChamado = Console.ReadLine();

            while (descricaoChamado == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: A descrição do Chamado é obrigatória.");
                Console.ResetColor();
                Console.Write("Digite a descrição do Chamado::");
                descricaoChamado = Console.ReadLine();
            }

            listaDescricaoChamados[indiceDoChamado] = descricaoChamado;
            Console.WriteLine();
        }

        static void VerificaEPreencheTituloDoChamado(string[] listaTitulosChamados, int indiceDoChamado)
        {
            Console.Write("Digite o título do Chamado:");
            string tituloDoChamado = Console.ReadLine();
            while (tituloDoChamado == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: O título do Chamado é obrigatório.");
                Console.ResetColor();
                Console.Write("Digite o título do Chamado:");
                tituloDoChamado = Console.ReadLine();
            }
            listaTitulosChamados[indiceDoChamado] = tituloDoChamado;
            Console.WriteLine();
        }

        static void BuscarEValidarNomeEquipamento(string[] listaEquipamentoDoChamado, string[] listaNomeEquipamentos, out bool equipamentoEncontrado, int indiceDoChamado)
        {
            Console.WriteLine();
            Console.Write("Digite o nome do Equipamento que será atribuído ao chamado:");
            string nomeEquipamentoChamado = Console.ReadLine();
            equipamentoEncontrado = false;

            for (int i = 0; i < listaNomeEquipamentos.Length; i++)
            {
                if (listaNomeEquipamentos[i] == nomeEquipamentoChamado)
                {
                    listaEquipamentoDoChamado[indiceDoChamado] = nomeEquipamentoChamado;
                    equipamentoEncontrado = true;
                    break;
                }
            }
        }

        static void EditarPropriedadeChamado(string[] listaPropriedadeChamado, int indiceDoChamado, string nomePropriedade)
        {
            Console.WriteLine();
            Console.WriteLine($"Digite o novo {nomePropriedade} do Chamado");
            string novaPropriedadeChamado = Console.ReadLine();

            listaPropriedadeChamado[indiceDoChamado] = novaPropriedadeChamado;
        }

        static int? BuscarIndiceChamado(string[] listaTitulosChamados, string chamadoAhSerAlterado)
        {
            for (int i = 0; i < listaTitulosChamados.Length; i++)
            {
                if (listaTitulosChamados[i] == chamadoAhSerAlterado)
                {
                    return i;
                }
            }

            return null;
        }

        static void ExcluirEquipamento(ref string[] listaNomeDeEquipamentos, ref decimal?[] listaPrecoDeEquipamentos, ref string[] listaNumeroDeSerieDeEquipamentos, ref DateTime?[] listaDataDeFabricacaoDeEquipamentos, ref string[] listaFabricanteDeEquipamentos, ref string[] listaEquipamentosChamados)
        {
            Console.WriteLine();
            Console.WriteLine("Digite o nome do equipamento que será excluído: ");
            string equipamentoParaExcluir = Console.ReadLine();

            var indiceDoEquipamento = BuscarIndiceEquipamento(listaNomeDeEquipamentos, equipamentoParaExcluir);
            if (indiceDoEquipamento == null)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: Equipamento não encontrado.");
                Console.ResetColor();
                return;
            }

            bool equipamentoEstaVinculadoChamado = VerificaSeEquipamentoVinculadoAoChamado(listaEquipamentosChamados, equipamentoParaExcluir);
            if (equipamentoEstaVinculadoChamado)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: O equipamento não pode ser excluído, pois está vinculado a um chamado aberto.");
                Console.ResetColor();
                return;
            }
            else
            {
                listaNomeDeEquipamentos[Convert.ToInt32(indiceDoEquipamento)] = null;
                listaPrecoDeEquipamentos[Convert.ToInt32(indiceDoEquipamento)] = null;
                listaNumeroDeSerieDeEquipamentos[Convert.ToInt32(indiceDoEquipamento)] = null;
                listaDataDeFabricacaoDeEquipamentos[Convert.ToInt32(indiceDoEquipamento)] = null;
                listaFabricanteDeEquipamentos[Convert.ToInt32(indiceDoEquipamento)] = null;
            }
        }

        static bool VerificaSeEquipamentoVinculadoAoChamado(string[] listaEquipamentosChamados, string equipamentoParaExcluir)
        {
            for (int i = 0; i < listaEquipamentosChamados.Length; i++)
            {
                if (equipamentoParaExcluir == listaEquipamentosChamados[i])
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO: Este equipamento não pode ser excluído, pois possui um chamado aberto.");
                    Console.ResetColor();
                    return true;
                }
            }
            return false;
        }

        static void VisualizarListaEquipamentos(string[] listaNomeDoEquipamento, string[] listaNumeroDeSerieDeEquipamentos, string[] listaFabricanteDeEquipamentos)
        {
            for (int i = 0; i < listaNomeDoEquipamento.Length; i++)
            {
                if (listaNomeDoEquipamento[i] != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Equipamento: {listaNomeDoEquipamento[i]} - Número de Série: {listaNumeroDeSerieDeEquipamentos[i]} - Fabricante: {listaFabricanteDeEquipamentos[i]}");
                    Console.WriteLine();
                }
            }
        }

        static void EditarEquipamento(string[] listaNomeDoEquipamento, decimal?[] listaPrecoDoEquipamento, string[] listaNumeroDeSerieDoEquipamento, DateTime?[] listaDataDeFabricacaoDoEquipamento, string[] listaFabricanteDoEquipamento)
        {
            Console.WriteLine();
            Console.Write("Digite o nome do equipamento que sera editado: ");
            string equipamentoAhSerAlterado = Console.ReadLine();

            var indiceDoEquipamento = BuscarIndiceEquipamento(listaNomeDoEquipamento, equipamentoAhSerAlterado);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("================== MENU DE OPÇÕES DA EDIÇÃO DO EQUIPAMENTO ==================\n");
            Console.WriteLine("-Digite 1: Para editar o nome do equipamento\n" +
                    "-Digite 2: Para editar o preço do equipamento\n" +
                    "-Digite 3: Para editar o numero de serie do equipamento\n" +
                    "-Digite 4: Para editar a data de fabricação do equipamento\n" +
                    "-Digite 5: Para editar o fabricante\n" +
                    "-Digite 6: para encerrar a edição do equipamente.\n");
            Console.WriteLine("==============================================================================\n");
            Console.ResetColor();
            Console.Write("-Digite a opção desejada: ");
            string menuEdicao = Console.ReadLine();
            Console.Clear();

            switch (menuEdicao)
            {
                case "1":
                    EditarPropriedadeEquipamento(listaNomeDoEquipamento, Convert.ToInt32(indiceDoEquipamento), "nome");
                    break;

                case "2":
                    EditarPrecoEquipamento(listaPrecoDoEquipamento, Convert.ToInt32(indiceDoEquipamento));
                    break;

                case "3":
                    EditarPropriedadeEquipamento(listaNumeroDeSerieDoEquipamento, Convert.ToInt32(indiceDoEquipamento), "número de série");
                    break;

                case "4":
                    EditarDataDeFabricacaoDoEquipamento(listaDataDeFabricacaoDoEquipamento, Convert.ToInt32(indiceDoEquipamento));
                    break;

                case "5":
                    EditarPropriedadeEquipamento(listaFabricanteDoEquipamento, Convert.ToInt32(indiceDoEquipamento), "fabricante");
                    break;

                case "6":
                    return;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ERRO: Opção Inválida!");
                    Console.ResetColor();
                    break;
            }
        }

        static void EditarDataDeFabricacaoDoEquipamento(DateTime?[] listaDataDeFabricacaoDoEquipamento, int indiceDoEquipamento)
        {
            Console.WriteLine();
            Console.WriteLine("Digite a nova data de fabricação do Equipamento");
            DateTime novaDataDeFabricacao = Convert.ToDateTime(Console.ReadLine());

            listaDataDeFabricacaoDoEquipamento[indiceDoEquipamento] = novaDataDeFabricacao;
        }

        static void EditarPrecoEquipamento(decimal?[] listaPrecoDoEquipamento, int indiceDoEquipamento)
        {
            Console.WriteLine();
            Console.WriteLine("Digite o novo preço do Equipamento");
            decimal novoPrecoDoEquipamento = Convert.ToDecimal(Console.ReadLine());

            listaPrecoDoEquipamento[indiceDoEquipamento] = novoPrecoDoEquipamento;
        }

        static void EditarPropriedadeEquipamento(string[] listaPropriedadeEquipamento, int indiceDoEquipamento, string nomePropriedade)
        {
            Console.WriteLine();
            Console.WriteLine($"Digite o novo {nomePropriedade} do Equipamento");
            string novaPropriedadeEquipamento = Console.ReadLine();

            listaPropriedadeEquipamento[indiceDoEquipamento] = novaPropriedadeEquipamento;
        }

        static int? BuscarIndiceEquipamento(string[] nomeDoEquipamento, string equipamentoAhSerAlterado)
        {
            for (int i = 0; i < nomeDoEquipamento.Length; i++)
            {
                if (nomeDoEquipamento[i] == equipamentoAhSerAlterado)
                {
                    return i;
                }
            }

            return null;
        }

        static int CriarEquipamento(string[] listaNomeDoEquipamento, decimal?[] listaPrecoDoEquipamento, string[] listaNumeroDeSerie, DateTime?[] listaDataDeFabricacao, string[] listaFabricante, int indiceDoEquipamento)
        {
            VerificaEPreencheNomeEquipamento(listaNomeDoEquipamento, indiceDoEquipamento);
            Console.WriteLine();

            VerificaEPreenchePrecoEquipamento(listaPrecoDoEquipamento, indiceDoEquipamento);
            Console.WriteLine();

            VerificaEPreencheNumeroDeSerieEquipamento(listaNumeroDeSerie, indiceDoEquipamento);
            Console.WriteLine();

            VerificaEPreencheDataDeFabricacaoEquipamento(listaDataDeFabricacao, indiceDoEquipamento);
            Console.WriteLine();

            VerificaEPreencheFabricanteEquipamento(listaFabricante, indiceDoEquipamento);
            Console.WriteLine();

            indiceDoEquipamento++;
            Console.WriteLine($"Equipamento {indiceDoEquipamento} Registrado");
            Console.Clear();

            return indiceDoEquipamento;
        }

        static void VerificaEPreencheFabricanteEquipamento(string[] listaFabricante, int indiceDoEquipamento)
        {
            Console.Write("Digite o nome do fabricante do Equipamento:");
            string fabricanteDigitado = Console.ReadLine();
            while (fabricanteDigitado == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: O fabricante do Equipamento é obrigatório.");
                Console.ResetColor();
                Console.Write("Digite o nome do fabricante do Equipamento:");
                fabricanteDigitado = Console.ReadLine();
            }
            listaFabricante[indiceDoEquipamento] = fabricanteDigitado;
        }

        static void VerificaEPreencheDataDeFabricacaoEquipamento(DateTime?[] listaDataDeFabricacao, int indiceDoEquipamento)
        {
            Console.Write("Digite a data de fabricação do Equipamento (formato: --/--/----):");
            string dataDigitada = Console.ReadLine();

            while (dataDigitada == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: Insira uma data de fabricação válida.");
                Console.ResetColor();
                Console.Write("Digite a data de fabricação do Equipamento (formato: --/--/----):");
                dataDigitada = Console.ReadLine();
            }
            listaDataDeFabricacao[indiceDoEquipamento] = Convert.ToDateTime(dataDigitada);
        }

        static void VerificaEPreencheNumeroDeSerieEquipamento(string[] listaNumeroDeSerie, int indiceDoEquipamento)
        {
            Console.Write("Digite o número de série do Equipamento:");
            string numeroDeSerieDigitado = Console.ReadLine();
            while (numeroDeSerieDigitado == "")
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: O número de série do Equipamento é obrigatório.");
                Console.ResetColor();
                Console.Write("Digite o numero de série do Equipamento:");
                numeroDeSerieDigitado = Console.ReadLine();
            }

            bool numeroDeSerieJaExiste = VerificarSeNumeroDeSerieJaExiste(listaNumeroDeSerie, numeroDeSerieDigitado);

            while (numeroDeSerieJaExiste)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: O número de Série já existe, por favor, digite outro número.");
                Console.ResetColor();
                Console.Write("Digite o numero de série do Equipamento:");
                numeroDeSerieDigitado = Console.ReadLine();
                numeroDeSerieJaExiste = VerificarSeNumeroDeSerieJaExiste(listaNumeroDeSerie, numeroDeSerieDigitado);
            }
            listaNumeroDeSerie[indiceDoEquipamento] = numeroDeSerieDigitado;
        }

        static void VerificaEPreenchePrecoEquipamento(decimal?[] listaPrecoDoEquipamento, int indiceDoEquipamento)
        {
            Console.Write("Digite o preço do Equipamento:");
            listaPrecoDoEquipamento[indiceDoEquipamento] = Convert.ToDecimal(Console.ReadLine());
            while (listaPrecoDoEquipamento[indiceDoEquipamento] == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: O preço do equipamento não pode ser Zero.");
                Console.ResetColor();
                Console.Write("Digite o preço do Equipamento:");
                listaPrecoDoEquipamento[indiceDoEquipamento] = Convert.ToDecimal(Console.ReadLine());
            }
            while (listaPrecoDoEquipamento[indiceDoEquipamento] < 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: O preço do equipamento não pode ser um número negativo.");
                Console.ResetColor();
                Console.Write("Digite o preço do Equipamento:");
                listaPrecoDoEquipamento[indiceDoEquipamento] = Convert.ToDecimal(Console.ReadLine());
            }
        }

        static void VerificaEPreencheNomeEquipamento(string[] listaNomeDoEquipamento, int indiceDoEquipamento)
        {
            Console.Write("Digite o nome do Equipamento:");
            string nomeDoEquipamento = Console.ReadLine();
            while (nomeDoEquipamento.Length < 6)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("ERRO: O nome do equipamento deve ter pelo menos 6 caracteres.");
                Console.ResetColor();
                Console.Write("Digite o nome do Equipamento:");
                nomeDoEquipamento = Console.ReadLine();
            }
            listaNomeDoEquipamento[indiceDoEquipamento] = nomeDoEquipamento;
        }

        static bool VerificarSeNumeroDeSerieJaExiste(string[] listaNumeroDeSerie, string numeroDeSerieDigitado)
        {
            for (int i = 0; i < listaNumeroDeSerie.Length; i++)
            {
                if (listaNumeroDeSerie[i] == numeroDeSerieDigitado)
                {
                    return true;
                }
            }

            return false;
        }
    }
}
