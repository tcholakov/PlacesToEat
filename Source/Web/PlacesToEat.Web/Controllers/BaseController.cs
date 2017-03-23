﻿namespace PlacesToEat.Web.Controllers
{
    using System.Web.Mvc;

    using Services.Web.Contracts;

    public abstract class BaseController : Controller
    {
        public ICacheService Cache { get; set; }
    }
}
