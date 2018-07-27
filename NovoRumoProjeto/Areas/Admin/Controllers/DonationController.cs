using NovoRumoProjeto.Utilities;
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
            var model = new List<DonationViewModel>();
            IDonationDAL donationDAL = new DonationDAL();
            var entity = donationDAL.GetDonations();

            foreach (var item in entity)
            {
                model.Add(new DonationViewModel()
                {
                    OrderId = item.OrderID,
                    TypeId = item.TypeId,
                    UserId = item.UserId,
                    NotificationCode = item.NotificationCode,
                    PaypalGuid = item.PaypalGuid,
                    Total = item.Total,
                    RecordDate = item.RecordDate
                    
                    
                });
            }
            return View(model);
        }

        // GET: Admin/Donation/Details/5
        public ActionResult Edit(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction("Index");
            }
            IDonationDAL donationDAL = new DonationDAL();
            var entity = donationDAL.GetById(id.Value);

            var model = new DonationViewModel();
            model.OrderId = entity.OrderID;
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
