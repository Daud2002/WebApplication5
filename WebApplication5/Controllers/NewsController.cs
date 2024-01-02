using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;


namespace YourNamespace.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NewsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public NewsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/News
        [HttpGet]
        public ActionResult<IEnumerable<News>> GetNews()
        {
            return _context.News.ToList();
        }

        // GET: api/News/5
        [HttpGet("{id}")]
        public ActionResult<News> GetNews(int id)
        {
            var news = _context.News.Find(id);

            if (news == null)
            {
                return NotFound();
            }

            return news;
        }

        // POST: api/News
        [HttpPost]
        public IActionResult PostNews(News news)
        {
            _context.News.Add(news);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetNews), new { id = news.Id }, news);
        }

        // PUT: api/News/5
        [HttpPut("{id}")]
        public IActionResult PutNews(int id, News news)
        {
            if (id != news.Id)
            {
                return BadRequest();
            }

            _context.Entry(news).State = EntityState.Modified;
            _context.SaveChanges();

            return NoContent();
        }

        // DELETE: api/News/5
        [HttpDelete("{id}")]
        public IActionResult DeleteNews(int id)
        {
            var news = _context.News.Find(id);

            if (news == null)
            {
                return NotFound();
            }

            _context.News.Remove(news);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
