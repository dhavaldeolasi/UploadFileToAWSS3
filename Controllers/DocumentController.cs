using System;
using System.IO;
using System.Threading.Tasks;
using AWSS3FileUpload.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AWSS3FileUpload.Controllers
{
    [Route("api/Document")]
    [ApiController]
    public class DocumentController : ControllerBase
    {
        private readonly ILogger _logger;

        public DocumentController(ILogger logger)
        {
            _logger = logger;
        }

        //[HttpPost]
        //public async Task<ActionResult> UploadDocument(IFormFile document)
        //{
        //    try
        //    {
        //        _logger.LogInformation("UploadDocument API is invoked");
        //        bool isUploadSuccess = false;
        //        if (document != null)
        //        {
        //            Stream stream = document.OpenReadStream();
        //            DocumentService documentService = new DocumentService();
        //            isUploadSuccess = await documentService.UploadDocument(stream, document.FileName);
        //            await stream.DisposeAsync();
        //        }
        //        else
        //        {
        //            return BadRequest("Please select file to upload");
        //        }

        //        if (isUploadSuccess)
        //        {
        //            return Ok("Document uploaded successfully");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        _logger.LogError("Error occured with the message : " + ex.Message);
        //    }
        //    return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error occurred" });
        //}

        [HttpGet]
        public async Task<ActionResult> DownloadDocument(string fileName)
        {

            bool isDownloadSuccess = false;
            if (!string.IsNullOrEmpty(fileName))
            {
                DocumentService documentService = new DocumentService();
                isDownloadSuccess = await documentService.DownloadDocument(fileName);
            }
            else
            {
                return BadRequest("Please provide the file name");
            }

            if (isDownloadSuccess)
            {
                return Ok("Document downloaded successfully in D:\\AWSDocuments");
            }
            else
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "Error occurred" });
            }
        }

    }
}