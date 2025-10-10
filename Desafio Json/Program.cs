using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;

class Program
{
    static async Task Main(string[] args)
    {
        Console.Write("Digite o nome do Pokémon: ");
        string nomePokemon = Console.ReadLine().ToLower();

        string url = $"https://pokeapi.co/api/v2/pokemon/{nomePokemon}";

        using (HttpClient client = new HttpClient())
        {
            try
            {
                HttpResponseMessage resposta = await client.GetAsync(url);

                if (resposta.IsSuccessStatusCode)
                {
                    string json = await resposta.Content.ReadAsStringAsync();

                    // Usa JObject (Newtonsoft.Json) para analisar os dados
                    JObject dados = JObject.Parse(json);

                    Console.WriteLine("\n=== INFORMAÇÕES DO POKÉMON ===");
                    Console.WriteLine($"Nome: {dados["name"].ToString().ToUpper()}");
                    Console.WriteLine($"ID: {dados["id"]}");
                    Console.WriteLine($"Altura: {dados["height"]} decímetros");
                    Console.WriteLine($"Peso: {dados["weight"]} hectogramas");

                    // Exibir tipos
                    Console.Write("Tipos: ");
                    foreach (var tipo in dados["types"])
                    {
                        Console.Write(tipo["type"]["name"] + " ");
                    }

                    Console.WriteLine("\nHabilidades:");
                    foreach (var habilidade in dados["abilities"])
                    {
                        Console.WriteLine($"- {habilidade["ability"]["name"]}");
                    }
                }
                else
                {
                    Console.WriteLine("Pokémon não encontrado! Verifique o nome e tente novamente.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Erro ao acessar a API: " + ex.Message);
            }
        }
    }
}

