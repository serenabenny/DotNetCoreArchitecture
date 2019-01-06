using DotNetCore.AspNetCore;
using DotNetCore.Objects;
using DotNetCoreArchitecture.Application;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System;
using System.Collections.Generic;
using System.IO;

namespace DotNetCoreArchitecture.Web
{
    [ApiController]
    [RouteController]
    public class FilesController : ControllerBase
    {
        public FilesController(IHostingEnvironment environment, IFileApplication fileApplication)
        {
            Directory = Path.Combine(environment.ContentRootPath, "Files");
            FileApplication = fileApplication;
        }

        private string Directory { get; }

        private IFileApplication FileApplication { get; }

        [HttpGet("{id}")]
        public IActionResult Get(Guid id)
        {
            var file = FileApplication.Select(Directory, id);

            new FileExtensionContentTypeProvider().TryGetContentType(file.Name, out var contentType);

            return File(file.Bytes, contentType, file.Name);
        }

        [DisableRequestSizeLimit]
        [HttpPost]
        public IEnumerable<FileBinary> Post()
        {
            return FileApplication.Save(Directory, Request.Files());
        }
    }
}
