using Newtonsoft.Json;
using ProjetoSisDistribuidos.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ProjetoSisDistribuidos.Controllers
{
    public class VooController : Controller
    {
        private List<Voo> voo = new List<Voo>();
        // GET: Voo
        public ActionResult Index()
        {
            voo = BuscarJson();
            ViewBag.ListaCodigo = voo.FirstOrDefault().Codigo;
            return View("Voos", voo);
        }
        [HttpPost]
        public JsonResult EnviarJson(string codigo)
        {
            voo = BuscarJson();
            Voo aux = voo.Where(x => x.Codigo == codigo).FirstOrDefault();
            EscreverArquivo(aux);
            return Json("Gravo arquivo json!", JsonRequestBehavior.AllowGet);
        }
        private List<Voo> BuscarJson()
        {
            string entrada;
            using (StreamReader lido = new StreamReader("C:\\Users\\FCAMARA\\Desktop\\voos.json"))
            {
                entrada = lido.ReadToEnd().Trim();
            }
            return JsonConvert.DeserializeObject<List<Voo>>(entrada);
        }
        private void EscreverArquivo(Voo _voo)
        {
            string nomeArquivo = @"c:\LogDeVoo\log-" + DateTime.Now.ToString("yyyyMMddHHmmss") + ".txt";
            StreamWriter writer = new StreamWriter(nomeArquivo);
            string output = JsonConvert.SerializeObject(_voo);
            writer.WriteLine(output);
            writer.Close();
        }
    }
}