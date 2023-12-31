using Commons.Enums;
using Generics.Entities;
using Microsoft.AspNetCore.Mvc;
using Quavidog.Models;

namespace Quavidog.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Add(UserAddressModel model, IFormFile image)
        {
            try
            {
                var address = new AddressModel(model);
                var user = new UserModel(model);

                var id = Address.Add(address);
                user.Address = Address.ReadOne(id);
                user.AccessType = AccessType.Client;

                byte[] convertedMedia;
                string mediaName;

                if(image != null && image.Length > 0)
                {
                    using(MemoryStream memoryStream = new MemoryStream())
                    {
                        image.CopyTo(memoryStream);
                        convertedMedia = memoryStream.ToArray();
                        mediaName = image.FileName;

                        user.Media = convertedMedia;
                        user.MediaName = mediaName;
                    }
                }

                Generics.Entities.User.Add(user);
                return RedirectToAction("Index", "Login");
                
            }
            catch
            {
                return RedirectToAction("Error", "User");
            }
        }
    }
}
