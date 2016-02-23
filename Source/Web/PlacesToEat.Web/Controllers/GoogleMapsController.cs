namespace PlacesToEat.Web.Controllers
{
    using System.Web.Mvc;

    public class GoogleMapsController : BaseController
    {
        public ActionResult GoogleMapsAddressPartial(string address)
        {
            return this.PartialView("_GoogleMapsAddressPartial", (object)address);
        }
    }
}
