using FreelancesProject.Models;
using Microsoft.AspNetCore.Mvc;

namespace FreelancesProject.Controllers
{
    public class Freelancers : Controller
    {
        DBContext ctx = new DBContext();
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("GetFreelances")]
        public IActionResult GetFreelances()
        {
            List<Freelancer> freelancer = ctx.Freelancers.ToList();
            return Ok(freelancer);
        }

        [HttpPost("AddFreelancers")]
        public IActionResult AddFreelancers(string userName)
        {
            Freelancer freelancer = new Freelancer();
            if (userName == null)
            {
                return BadRequest("Result is null");
            }
            freelancer.RowId = Guid.NewGuid();
            freelancer.UserName = userName;
            freelancer.PhoneNum = "0100000778";
            freelancer.EmailAddress = "testing123.gmail.com";
            freelancer.Hobby = "Badminton";
            freelancer.SkillSet = "C#.net";
            ctx.Freelancers.Add(freelancer);
            ctx.SaveChanges();
            return Ok("Save Successful");
        }

        [HttpPut("UpdateFreelancer")]
        public IActionResult UpdateFreelancres(string oldName,string newName)
        {

            Freelancer freelancer = ctx.Freelancers.FirstOrDefault(m => m.UserName == oldName);
            freelancer.UserName = newName;

            ctx.Freelancers.Update(freelancer);
            ctx.SaveChanges();
            return Ok("Update Success");
        }

        [HttpDelete("DeleteFreelancers")]
        public IActionResult DeleteFreelancers(string userName)
        {
            Freelancer freelancer = ctx.Freelancers.FirstOrDefault(m => m.UserName == userName);

            ctx.Freelancers.Remove(freelancer);
            ctx.SaveChanges();
            return Ok("Delete Success");
        }
    }
}
