﻿using NovoRumoProjeto.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using NovoRumoProjeto.Areas.Admin.Models;
using NovoRumoProjeto.DAL.Donation;

namespace NovoRumoProjeto.Areas.Admin.Controllers
{
    [Authorize(Roles = Consts.ADMIN_ROLE)]
    public class DonationController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
          
            return View();
        }

        // GET: Admin/Donation/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Donation/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Donation/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Donation/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Donation/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Admin/Donation/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Donation/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}