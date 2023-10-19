using Microsoft.AspNetCore.Mvc;
using TreeSearch.Models;
using LabsShareLibrary;
using static LabsShareLibrary.Lab2;
using System.Security.Cryptography;

namespace TreeSearch.Controllers
{
    [ApiController]
    public class TreeSearch : ControllerBase
    {
        [Route("SearchRandomEl/[controller]")]
        [HttpGet]
        public IActionResult Show()
        {
            int[] test2 = new int[10];
            Random randNum = new Random();

            for (int i = 0; i < test2.Length; i++)
            {
                test2[i] = randNum.Next(1, 50);
            }

            RandomInput mas = new RandomInput();
            mas.input = test2;
 
            Tree tree = new Tree();
            for (int i = 0; i < mas.input.Length; i++)
            {
                tree.Insert(mas.input[i]);
            }

            int el = randNum.Next(1, 50);
            mas.searchEl = el;
            mas.result = tree.Search(el);

            return Ok(mas);
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