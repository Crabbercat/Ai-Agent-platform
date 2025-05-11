using AI_Agent_WebApp.Models.Entities;
using AI_Agent_WebApp.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace AI_Agent_WebApp.Web.Controllers
{
    public class AgentController : Controller
    {
        private readonly IAgentService _agentService;
        public AgentController(IAgentService agentService) { _agentService = agentService; }

        public IActionResult Index() => View("AgentList", _agentService.GetAllAgents());
        public IActionResult Details(int id)
        {
            var agent = _agentService.GetAgentById(id);
            if (agent == null)
                return NotFound();
            return View("AgentDetails", agent);
        }
        // Supplier actions
        public IActionResult Create() => View("CreateAgent");
        [HttpPost]
        public IActionResult Create(Agent agent) { _agentService.CreateAgent(agent); return RedirectToAction("MyAgents"); }
        public IActionResult Edit(int id) => View("EditAgent", _agentService.GetAgentById(id));
        [HttpPost]
        public IActionResult Edit(Agent agent) { _agentService.UpdateAgent(agent); return RedirectToAction("MyAgents"); }
        public IActionResult Delete(int id) { _agentService.DeleteAgent(id); return RedirectToAction("MyAgents"); }
        public IActionResult MyAgents() => View("MyAgents", _agentService.GetAllAgents()); // Filter by supplier in real impl
        // Registered User actions
        public IActionResult Follow(int id) { /* logic */ return RedirectToAction("MyFollowed"); }
        public IActionResult Unfollow(int id) { /* logic */ return RedirectToAction("MyFollowed"); }
        public IActionResult MyFollowed() => View("FollowedAgents");
        // Staff actions
        public IActionResult ManageAll() => View("AllAgents", _agentService.GetAllAgents());
        public IActionResult ToggleStatus(int id) { _agentService.ToggleStatus(id); return RedirectToAction("ManageAll"); }
    }
}
