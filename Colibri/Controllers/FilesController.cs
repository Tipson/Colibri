using System.Net;
using Colibri.Infrastructure;
using Colibri.Models.Commands.Error;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Net.Http.Headers;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Webp;
using Colibri.Infrastructure;
using Colibri.Models.Commands.Error;
using Colibri.Utils;

namespace Colibri.Controllers;

[ApiController]
[Route("[controller]")]
public class FilesController : ControllerBase
{
    private readonly IErrorService _errorService;
    private readonly IWebHostEnvironment _webHostEnvironment;

    public FilesController(IErrorService errorService, IWebHostEnvironment webHostEnvironment)
    {
        _errorService = errorService;
        _webHostEnvironment = webHostEnvironment;
    }
    // GET

    /*[HttpPost("[action]")]
    public async Task<ActionResult> UploadFile([FromQuery] string f, CancellationToken token = default)
    {
        string ret = "";
        try
        {
            foreach (IFormFile file in Request.Form.Files)
            {
                string fName = ContentDispositionHeaderValue.Parse(file.ContentDisposition).FileName.Trim().ToString()
                    .ToLower();
                if (file.Length > 0 &&
                    (fName.EndsWith(".png") || fName.EndsWith(".jpg") || fName.EndsWith(".webp") || fName.EndsWith(".jpeg") ||
                     fName.EndsWith(".gif")))
                {
                    // get a stream

                    // and optionally write the file to disk
                    var filePath = _webHostEnvironment.WebRootPath + ("/images/" + f + "/");
                    string fileName = mainFuncs.GenerateCode(25);


                    using (Image? image = Image.Load(file.OpenReadStream()), image_mini = Image.Load(file.OpenReadStream()))
                    {
                        SixLabors.ImageSharp.Formats.ImageEncoder encoder;

                        if ((image.Width > 300 || image.Height > 300) && f == "partners")
                        {
                            var resizeOptions = new ResizeOptions
                            {
                                Size = new Size(300, 300),
                                Mode = ResizeMode.Max
                            };
                            image.Mutate(x => x.Resize(resizeOptions));
                        }

                        if ((image.Width > 1200 || image.Height > 1200) && f == "sponsorPacks")
                        {
                            var resizeOptions = new ResizeOptions
                            {
                                Size = new Size(1200, 1200),
                                Mode = ResizeMode.Max
                            };
                            image.Mutate(x => x.Resize(resizeOptions));

                            resizeOptions = new ResizeOptions
                            {
                                Size = new Size(600, 600),
                                Mode = ResizeMode.Max
                            };
                            image_mini.Mutate(x => x.Resize(resizeOptions));

                        }

                        if (f == "sponsorPacks")
                        {
                            encoder = new JpegEncoder { Quality = 80 };
                            fileName += ".jpg";
                        }
                        else
                        {
                            encoder = new WebpEncoder();
                            fileName += ".webp";
                        }

                        string pathTemp = filePath + fileName;
                        string pathTempMini = filePath + "m_" + fileName;

                        await using (var fileStream = new FileStream(pathTemp, FileMode.Create))
                        {
                            await image.SaveAsync(fileStream, encoder, token);
                        }

                        if (f == "sponsorPacks")
                        {
                            await using (var fileStream = new FileStream(pathTempMini, FileMode.Create))
                            {
                                await image_mini.SaveAsync(fileStream, encoder, token);
                            }
                        }
                    }
                    ret = fileName;
                }
            }
        }
        catch (Exception ex)
        {
            if (ex.Source != null)
                await _errorService.Create(
                    new CreateErrorCommand(ex.Message, ControllerContext.ActionDescriptor.ControllerName,
                        ControllerContext.ActionDescriptor.ActionName,
                        ex.Source),
                    token);
            Console.WriteLine(ex.ToString());
            Response.StatusCode = (int)HttpStatusCode.BadRequest;
            return Ok("Upload failed");
        }
        return Ok(ret);
    }*/
}