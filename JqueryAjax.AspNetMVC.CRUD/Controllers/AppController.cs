using JqueryAjax.AspNetMVC.CRUD.Models.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using JqueryAjax.AspNetMVC.CRUD.Models.Negocio;

namespace JqueryAjax.AspNetMVC.CRUD.Controllers
{
    public class AppController : Controller
    {
        // GET: App
        [HttpPost]
        public void Cadastrar(PessoaModel pessoa)
        {
            try
            {
                new PessoaNeg().Cadastrar(pessoa);
            }
            catch (Exception)
            {

                throw;
            }
        }

        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Listar()
        {
            var listaPessoas = new PessoaNeg().Listar();
            return Json(listaPessoas, JsonRequestBehavior.AllowGet);
        }

        public void Deletar(int id)
        {
            try
            {
                new PessoaNeg().Deletar(id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public ActionResult Editar(int id)
        {
            try
            {
                //recebemos o id da pessoa selecionada,
                //com este id, pedimos ao nosso banco fantasia,
                // que retorne a pessoa que possuir aquele id.
                var pessoa = new PessoaNeg().GetById(id);

                //para retornar ao ajax, temos que enviar nosso objeto em
                //formato JSON, e LIBERA-LO
                //Para a requisicao GET como dito anteriormente
                return Json(pessoa, JsonRequestBehavior.AllowGet);
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpPost]
        public void Atualizar(PessoaModel pessoa)
        {
            try
            {
                new PessoaNeg().Atualizar(pessoa);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }


}