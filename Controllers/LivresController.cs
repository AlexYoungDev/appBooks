using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


[ApiController]
[Route("[controller]")]
public class LivresController : ControllerBase
{
    private readonly IRepository<Media> _repository;

    public LivresController(IRepository<Media> repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<ActionResult<IEnumerable<Media>>> GetAll(
        [FromQuery] string? author,
        [FromQuery] string? title,
        [FromQuery] string? sort)
    {
        var livres = await _repository.GetAllAsync();

        
        if (!string.IsNullOrEmpty(author))
            livres = livres.Where(l => l.Author.Contains(author, StringComparison.OrdinalIgnoreCase));
        if (!string.IsNullOrEmpty(title))
            livres = livres.Where(l => l.Title.Contains(title, StringComparison.OrdinalIgnoreCase));

        
        if (sort == "author")
            livres = livres.OrderBy(l => l.Author);
        else if (sort == "title")
            livres = livres.OrderBy(l => l.Title);

        return Ok(livres);
    }

    [HttpGet("{id}")]
    public async Task<ActionResult<Media>> GetById(int id)
    {
        var livre = await _repository.GetByIdAsync(id);
        if (livre == null)
            return NotFound();

        return Ok(livre);
    }
}
