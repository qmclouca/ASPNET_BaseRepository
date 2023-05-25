﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using VendaLanches.Models;

namespace VendaLanches.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class AdminImagesController : Controller
    {
        private readonly ConfigurationImages _myConfig;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public AdminImagesController(IWebHostEnvironment webHostEnvironment, IOptions<ConfigurationImages> myConfiguration)
        {
            _webHostEnvironment = webHostEnvironment;
            _myConfig = myConfiguration.Value;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> UploadFiles(List<IFormFile> files)
        {
            int maxFilesByUpload = 10;
            if (files == null || files.Count == 0)
            {
                ViewData["Erro"] = "Error: Arquivo(s) não selecionado(s)";
                return View();
            }            
            if (files.Count > maxFilesByUpload)
            {
                ViewData["Erro"] = $"Error: Quantidade de arquivos excedeu o limite máximo - {maxFilesByUpload};";
            }

            long totalFileSize = files.Sum(f => f.Length);

            List<string> filesPathsNames = new List<string>();
            var filePath = Path.Combine(_webHostEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            foreach (var formFile in files)
            {
                if (formFile.FileName.Contains(".jpg") || formFile.FileName.Contains(".gif") || formFile.FileName.Contains(".png"))
                {
                    string fileNameWithPath = string.Concat(filePath, "\\", formFile.FileName);
                    filesPathsNames.Add(fileNameWithPath);
                    using (FileStream stream = new FileStream(fileNameWithPath, FileMode.Create))
                    {
                        await formFile.CopyToAsync(stream);
                    }
                }
            }

            ViewData["Resultado"] = $"{files.Count} arquivos foram enviados ao servidor, " +
                $"com tamanho total de: {totalFileSize} bytes";
            ViewBag.Arquivos = filesPathsNames;
            return View(ViewData);
        }

        public IActionResult GetImages()
        {
            FileManagerModel model = new FileManagerModel();
            var userImagesPath = Path.Combine(_webHostEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos);

            DirectoryInfo dir = new DirectoryInfo(userImagesPath);
            FileInfo[] files = dir.GetFiles();
            model.PathImagesProduto = _myConfig.NomePastaImagensProdutos;
            if (files.Length == 0)
            {
                ViewData["Erro"] = $"Nenhum arquivo encontrado na pasta {userImagesPath}";
            }
            model.Files = files;
            return View(model);
        }

        public IActionResult DeleteFile(string fname)
        {
            string _imagemParaDeletar = Path.Combine(_webHostEnvironment.WebRootPath, _myConfig.NomePastaImagensProdutos + "//", fname);
            if (System.IO.File.Exists(_imagemParaDeletar))
            {
                System.IO.File.Delete(_imagemParaDeletar);
                ViewData["Deletado"] = $"Arquivo(s) {_imagemParaDeletar} apagado com sucesso.";
            }
            return View("index");
        }
    }
}
