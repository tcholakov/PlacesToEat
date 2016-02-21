namespace PlacesToEat.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Services.Data;

    public class HomeController : BaseController
    {
        private readonly IUserService users;
        private readonly IRegularUserService regularUsers;

        public HomeController(IUserService users, IRegularUserService regularUsers)
        {
            this.users = users;
            this.regularUsers = regularUsers;
        }

        public ActionResult Index()
        {
            var users = this.users.GetAll().ToList();
            var regularUsers = this.regularUsers.GetAll().ToList();

            return this.View(regularUsers);
        }
    }
}
