using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using StoreFront.DATA.EF.Models;

namespace StoreFront.UI.MVC.Controllers
{
    public class VinylCollectionsController : Controller
    {
        private readonly StoreFrontContext _context;
        private readonly IWebHostEnvironment _webHostEnvironment;//To access wwwroot

        public VinylCollectionsController(StoreFrontContext context)
        {
            _context = context;
        }

        // GET: VinylCollections
        public async Task<IActionResult> Index()
        {
            var storeFrontContext = _context.VinylCollections.Include(v => v.Condition).Include(v => v.Genre);
            return View(await storeFrontContext.ToListAsync());
        }

        // GET: VinylCollections/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VinylCollections == null)
            {
                return NotFound();
            }

            var vinylCollection = await _context.VinylCollections
                .Include(v => v.Condition)
                .Include(v => v.Genre)
                .FirstOrDefaultAsync(m => m.CollectionId == id);
            if (vinylCollection == null)
            {
                return NotFound();
            }

            return View(vinylCollection);
        }

        // GET: VinylCollections/Create
        public IActionResult Create()
        {
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionId");
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId");
            return View();
        }

        // POST: VinylCollections/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("CollectionId,GenreId,CollectionPrice,CollectionDescription,UnitsInStock,IsDiscontinued,CollectionImage,ConditionId")] VinylCollection vinylCollection)
        {
            if (ModelState.IsValid)
            {

                // TO DO : VERIFY THIS INFO IS ACCURATE...

                //#region File Upload - CREATE
                ////Check to see if a file was uploaded
                //if (vinylCollection.Image != null)
                //{
                //    //Check the file type 
                //    //- retrieve the extension of the uploaded file
                //    string ext = Path.GetExtension(vinylCollection.Image.FileName);

                //    //- Create a list of valid extensions to check against
                //    string[] validExts = { ".jpeg", ".jpg", ".gif", ".png" };

                //    //- verify the uploaded file has an extension matching one of the extensions in the list above
                //    //- AND verify file size will work with our .NET app
                //    if (validExts.Contains(ext.ToLower()) && vinylCollection.Image.Length < 4_194_303)//underscores don't change the number, they just make it easier to read
                //    {
                //        //Generate a unique filename
                //        vinylCollection.ProductImage = Guid.NewGuid() + ext;

                //        //Save the file to the web server (here, saving to wwwroot/images)
                //        //To access wwwroot, add a property to the controller for the _webHostEnvironment (see the top of this class for our example)
                //        //Retrieve the path to wwwroot
                //        string webRootPath = _webHostEnvironment.WebRootPath;
                //        //variable for the full image path --> this is where we will save the image
                //        string fullImagePath = webRootPath + "/images/";

                //        //Create a MemoryStream to read the image into the server memory
                //        using (var memoryStream = new MemoryStream())
                //        {
                //            await vinylCollection.Image.CopyToAsync(memoryStream);//transfer file from the request to server memory
                //            using (var img = Image.FromStream(memoryStream))//add a using statement for the Image class (using System.Drawing)
                //            {
                //                //now, send the image to the ImageUtility for resizing and thumbnail creation
                //                //items needed for the ImageUtility.ResizeImage()
                //                //1) (int) maximum image size
                //                //2) (int) maximum thumbnail image size
                //                //3) (string) full path where the file will be saved
                //                //4) (Image) an image
                //                //5) (string) filename
                //                int maxImageSize = 500;//in pixels
                //                int maxThumbSize = 100;

                //                ImageUtility.ResizeImage(fullImagePath, vinylCollection.ProductImage, img, maxImageSize, maxThumbSize);
                //                //myFile.Save("path/to/folder", "filename"); - how to save something that's NOT an image

                //            }
                //        }
                //    }
                //}
                //else
                //{
                //    //If no image was uploaded, assign a default filename
                //    //Will also need to download a default image and name it 'noimage.png' -> copy it to the /images folder
                //    vinylCollection.ProductImage = "noimage.png";
                //}

                //#endregion

                _context.Add(vinylCollection);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionId", vinylCollection.ConditionId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", vinylCollection.GenreId);
            return View(vinylCollection);
        }

        // GET: VinylCollections/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VinylCollections == null)
            {
                return NotFound();
            }

            var vinylCollection = await _context.VinylCollections.FindAsync(id);
            if (vinylCollection == null)
            {
                return NotFound();
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionId", vinylCollection.ConditionId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", vinylCollection.GenreId);
            return View(vinylCollection);
        }

        // POST: VinylCollections/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("CollectionId,GenreId,CollectionPrice,CollectionDescription,UnitsInStock,IsDiscontinued,CollectionImage,ConditionId")] VinylCollection vinylCollection)
        {
            if (id != vinylCollection.CollectionId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vinylCollection);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VinylCollectionExists(vinylCollection.CollectionId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "ConditionId", "ConditionId", vinylCollection.ConditionId);
            ViewData["GenreId"] = new SelectList(_context.Genres, "GenreId", "GenreId", vinylCollection.GenreId);
            return View(vinylCollection);
        }

        // GET: VinylCollections/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VinylCollections == null)
            {
                return NotFound();
            }

            var vinylCollection = await _context.VinylCollections
                .Include(v => v.Condition)
                .Include(v => v.Genre)
                .FirstOrDefaultAsync(m => m.CollectionId == id);
            if (vinylCollection == null)
            {
                return NotFound();
            }

            return View(vinylCollection);
        }

        // POST: VinylCollections/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VinylCollections == null)
            {
                return Problem("Entity set 'StoreFrontContext.VinylCollections'  is null.");
            }
            var vinylCollection = await _context.VinylCollections.FindAsync(id);
            if (vinylCollection != null)
            {
                _context.VinylCollections.Remove(vinylCollection);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VinylCollectionExists(int id)
        {
          return (_context.VinylCollections?.Any(e => e.CollectionId == id)).GetValueOrDefault();
        }
    }
}
