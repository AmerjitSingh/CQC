using Microsoft.AspNetCore.Mvc;

namespace MvcGDSAssessment.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHomeApplicationRepository _repository;
        private int _redirectToCheckAnswers;
        public HomeController(IHomeApplicationRepository repository)
        {

            _repository = repository;
        }


        [Route("")]
        [HttpGet]
        public IActionResult FullName(int? id)
        {
            TempData["CheckAnswers"] = (!id.HasValue ? 0 : id);
            return View("Fullname");
        }

        [HttpPost]
        public IActionResult FullName([Bind("FullName")] FullNameViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                TempData["FullName"] = viewModel.FullName;

                _redirectToCheckAnswers = (int)TempData["CheckAnswers"];

                if (_redirectToCheckAnswers == 1)
                    return RedirectToAction("CheckAnswers");

                return RedirectToAction("Email");
            }

            return View("FullNameError", viewModel);
        }

        [HttpGet]
        public IActionResult Email(int? id)
        {
            TempData["CheckAnswers"] = (!id.HasValue ? 0 : id);
            return View();
        }

        [HttpPost]
        public IActionResult Email([Bind("Email")] EmailViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                TempData["Email"] = viewModel.Email;

                _redirectToCheckAnswers = (int)TempData["CheckAnswers"];

                if (_redirectToCheckAnswers == 2)
                    return RedirectToAction("CheckAnswers");

                return RedirectToAction("Address");
            }

            return View("EmailError", viewModel);
        }

        [HttpGet]
        public IActionResult Address(int? id)
        {
            TempData["CheckAnswers"] = (!id.HasValue ? 0 : id);
            return View();
        }

        [HttpPost]
        public IActionResult Address([Bind("Address")] AddressViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                TempData["Address"] = viewModel.Address;

                _redirectToCheckAnswers = (int)TempData["CheckAnswers"];

                if (_redirectToCheckAnswers == 3)
                    return RedirectToAction("CheckAnswers");

                return RedirectToAction("Light");
            }

            return View("AddressError", viewModel);
        }

        [HttpGet]
        public IActionResult Light(int? id)
        {
            TempData["CheckAnswers"] = (!id.HasValue ? 0 : id);
            return View();
        }

        [HttpPost]
        public IActionResult Light([Bind("Light")] LightViewModel viewModel)
        {
            if (!string.IsNullOrEmpty(viewModel.Light))
            {
                TempData["Light"] = viewModel.Light;

                _redirectToCheckAnswers = (int)TempData["CheckAnswers"];

                if (_redirectToCheckAnswers == 4)
                    return RedirectToAction("CheckAnswers");

                return RedirectToAction("Brightness");
            }

            return View("LightError", viewModel);
        }


        [HttpGet]
        public IActionResult Brightness(int? id)
        {
            TempData["CheckAnswers"] = (!id.HasValue ? 0 : id);
            return View();
        }

        [HttpPost]
        public IActionResult Brightness([Bind("Brightness")] BrightnessViewModel viewModel)
        {
            TempData["Brightness"] = viewModel.Brightness;

            _redirectToCheckAnswers = (int)TempData["CheckAnswers"];

            if (_redirectToCheckAnswers == 5)
                return RedirectToAction("CheckAnswers");

            return RedirectToAction("CheckAnswers");
        }

        [HttpGet]
        public IActionResult CheckAnswers()
        {
            return View();
        }


        [HttpPost]
        public IActionResult Confirmation()
        {
            var application = new HomeApplication();

            application.FullName = (string)TempData["FullName"];
            application.Email = (string)TempData["Email"];
            application.Light = (string)TempData["Light"];
            application.Brightness = int.Parse((string)TempData["Brightness"]);

            _repository.Insert(application);


            return View("Confirmation");
        }

    }
}
