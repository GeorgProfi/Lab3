using Microsoft.AspNetCore.Mvc;
using TreeSearch.Models;
using LabsShareLibrary;
using static LabsShareLibrary.Lab2;

namespace TreeSearch.Controllers
{
    [ApiController]
    public class TreeSearch : ControllerBase
    {
        [Route("Show/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            Result result = new Result();
            result.result = true;
            return Ok(result);
        }
    
    [Route("SearchElement/[controller]")]
    [HttpPost]
    public IActionResult Input([FromBody] Input Mas)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }
        Tree tree = new Tree();
        for (int i = 0; i < Mas.input.Length; i++)
        {
            tree.Insert(Mas.input[i]);
        }

        var result = new Result();
        result.result = tree.Search(Mas.searchEl); 
        return Ok(result);
    }
    }
}