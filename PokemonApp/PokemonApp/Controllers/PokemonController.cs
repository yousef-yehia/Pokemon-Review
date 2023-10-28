using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using PokemonApp.Dto;
using PokemonApp.Interfaces;
using PokemonApp.Models;

namespace PokemonApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PokemonController : Controller
    {
        private readonly IPokemonRepository pokemonRepository;
        private readonly IMapper mapper;

        public PokemonController(IPokemonRepository pokemonRepository , IMapper mapper)
        {
            this.pokemonRepository = pokemonRepository;
            this.mapper = mapper;
        }

        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Pokemon>))]
        public IActionResult GetPokemons() 
        {
            var pokemons = mapper.Map<List<PokemonDto>>(pokemonRepository.GetPokemons());
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemons);
        }

        [HttpGet("{id:int}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        public IActionResult GetPokemonByID(int id) 
        {
            if (!pokemonRepository.PokemonExists(id))
            {
                return NotFound();
            }
            var pokemon = mapper.Map<PokemonDto>(pokemonRepository.GetPokemonByID(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{name}")]
        [ProducesResponseType(200, Type = typeof(Pokemon))]
        public IActionResult GetPokemonByName(string name)
        {
            var pokemon = mapper.Map<PokemonDto>(pokemonRepository.GetPokemonByName(name));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(pokemon);
        }

        [HttpGet("{pokeID:int}/rating")]
        [ProducesResponseType(200, Type = typeof(decimal))]
        public IActionResult GetPokemonRating(int pokeID)
        {
            if (!pokemonRepository.PokemonExists(pokeID))
            {
                return NotFound();
            }
            var rating = pokemonRepository.GetPokemonRating(pokeID);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(rating);
        }


    }
}
