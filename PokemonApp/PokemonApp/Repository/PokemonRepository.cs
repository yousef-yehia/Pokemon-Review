using PokemonApp.Interfaces;
using PokemonApp.Models;
using PokemonApp.Data;

namespace PokemonApp.Repository
{
    public class PokemonRepository : IPokemonRepository
    {
        private readonly DataContext _context;

        public PokemonRepository(DataContext context)
        {
            _context = context;
        }

        public bool CreaatePokemon(Pokemon pokemon)
        {
            throw new NotImplementedException();
        }

        public Pokemon GetPokemonByID(int id)
        {
            return _context.Pokemon.Where(p => p.Id == id).FirstOrDefault();
        }

        public Pokemon GetPokemonByName(string name)    
        {
            return _context.Pokemon.Where(p => p.Name == name).FirstOrDefault();
        }

        public decimal GetPokemonRating(int pokeID)
        {
            var review = _context.Reviews.Where(R => R.Pokemon.Id == pokeID);

            if (review.Count() <= 0 )
            {
                return 0;
            }

            return ( (decimal) review.Sum(r => r.Rating) / review.Count() );  
        }

        public ICollection<Pokemon> GetPokemons()
        {
            return _context.Pokemon.OrderBy(p => p.Id).ToList();
        }

        public bool PokemonExists(int id)
        {
            return _context.Pokemon.Any(p => p.Id == id);
        }
    }
}
