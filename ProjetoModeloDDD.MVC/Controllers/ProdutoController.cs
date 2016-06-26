﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using ProjetoModeloDDD.Application.Interface;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.Controllers
{
    public class ProdutoController : Controller
    {


        private readonly IProdutoAppService _produtoApp;
        private readonly IClienteAppService _clienteApp;

        public ProdutoController(IClienteAppService clienteApp, IProdutoAppService produtoApp)
        {
            _clienteApp = clienteApp;
            _produtoApp = produtoApp;
        }


        // GET: Produto
        public ActionResult Index()
        {
            var produtoViewModel = Mapper.Map<IEnumerable<Produto>, IEnumerable<ProdutoViewModel>>(_produtoApp.GetAll());
            return View(produtoViewModel);
        }

        // GET: Produto/Details/5
        public ActionResult Details(int id)
        {
            var produto = _produtoApp.GetByID(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);
            return View(produtoViewModel);
        }

        // GET: Produto/Create
        public ActionResult Create()
        {
            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome");
            return View();
        }

        // POST: Produto/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Add(produtoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);
            return View(produto);
        }

        // GET: Produto/Edit/5
        public ActionResult Edit(int id)
        {
            var produto = _produtoApp.GetByID(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produtoViewModel.ClienteId);

            return View(produtoViewModel);
        }

        // POST: Produto/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProdutoViewModel produto)
        {
            if (ModelState.IsValid)
            {
                var produtoDomain = Mapper.Map<ProdutoViewModel, Produto>(produto);
                _produtoApp.Update(produtoDomain);

                return RedirectToAction("Index");
            }

            ViewBag.ClienteId = new SelectList(_clienteApp.GetAll(), "ClienteId", "Nome", produto.ClienteId);

            return View(produto);

        }

        // GET: Produto/Delete/5
        public ActionResult Delete(int id)
        {
            var produto = _produtoApp.GetByID(id);
            var produtoViewModel = Mapper.Map<Produto, ProdutoViewModel>(produto);

            return View(produtoViewModel);
        }

        // POST: Produto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var produto = _produtoApp.GetByID(id);
            _produtoApp.Remove(produto);

            return View("Index");
            
        }
    }
}
