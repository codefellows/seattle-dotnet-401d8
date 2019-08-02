using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using CMSDemo.Models;
using CMSDemo.Models.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Storage.Blob;

namespace CMSDemo.Controllers
{
    public class HomeController : Controller
    {
        private IPayment _payment;
        private IImageManager _blob;

        public HomeController(IPayment payment, IImageManager imageManager)
        {
            _payment = payment;
            _blob = imageManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(bool yes = true)
        {
           string answer = _payment.Run();

            return View();
        }

        [HttpGet]
        public IActionResult Blob()
        {
            return View();
        }

        [HttpPost]
        public async Task <IActionResult> Blob(BlobViewModel blobVM)
        {
            if(ModelState.IsValid)
            {
                var filePath = Path.GetTempFileName();

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await blobVM.Image.CopyToAsync(stream);
                };

                var container = await _blob.GetContainer("products");

                // upload the image
                _blob.UploadFile(container, blobVM.Image.FileName, filePath);

                CloudBlob blob = await _blob.GetBlob(blobVM.Image.FileName, container.Name);

                var URL = blob.Uri.ToString();
            }
            return View();
        }
    }
}