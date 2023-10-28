//using PokemonApp.Dto;
using PokemonApp.Models;

namespace PokemonApp.Interfaces
{
    public interface IPokemonRepository
    {
        ICollection<Pokemon> GetPokemons();
        Pokemon GetPokemonByID(int id);
        Pokemon GetPokemonByName(string name);
        bool PokemonExists(int id);
        decimal GetPokemonRating(int pokeID);
        bool CreaatePokemon(Pokemon pokemon);

    }
}
