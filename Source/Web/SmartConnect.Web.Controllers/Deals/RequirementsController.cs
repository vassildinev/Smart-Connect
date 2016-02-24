namespace SmartConnect.Web.Controllers.Deals
{
    using System;
    using System.Web.Mvc;

    using Data.Models;
    using Services.Deals.Contracts;
    using ViewModels.Deals;

    public class RequirementsController : Controller
    {
        private IRequirementsService requirements;

        public RequirementsController(IRequirementsService requirements)
        {
            this.requirements = requirements;
        }

        public ActionResult Create(RequirementViewModel viewModel)
        {
            var model = new Requirement()
            {
                Name = viewModel.Name,
                DealId = viewModel.DealId,
                Priority = (RequirementPriority)Enum.Parse(typeof(RequirementPriority), viewModel.Priority)
            };

            this.requirements.Create(model);
            this.requirements.SaveChanges();

            return this.RedirectToAction("Index", "Home", new { area = "Deals" });
        }
    }
}
