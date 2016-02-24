namespace SmartConnect.Web.Controllers.Contacts
{
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;
    using Contracts;
    using Data.Models;
    using Infrastructure.Mappings;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using Services.Users.Contracts;
    using Services.Contacts.Contracts;
    using ViewModels.Contacts;
    using Infrastructure.CustomAttributes;

    public class ContactsAjaxController :
        KendoGridController<Contact, ContactViewModel, int>,
        IKendoGridController<Contact, ContactViewModel, int>
    {
        private IMessagesService messages;

        public ContactsAjaxController(IUsersService users, IContactsService data, IMessagesService messages)
            : base(users, data)
        {
            this.messages = messages;
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public override ActionResult Read([DataSourceRequest]DataSourceRequest request)
        {
            string userId = this.User.Identity.GetUserId();
            var data = (this.Data as IContactsService)
                .GetByUserId(userId)
                .ProjectTo<ContactViewModel>(StandardMapperObjectsProvider.MapperConfiguration);
            return this.CollectionGridResult(request, data);
        }

        [AjaxOnly]
        public ActionResult GetById(int contactId)
        {
            Contact contact = this.Data.GetById(contactId);
            ContactViewModel model = this.Mapper.Map<ContactViewModel>(contact);

            return this.PartialView("~/Views/Contacts/Home/_ConversationPartial.cshtml", model);
        }
    }
}
