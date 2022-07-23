using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Paging.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Paging.Controllers
{
    public class CustomerController : Controller
    {

        private readonly PagingDB _context;
        public CustomerController ( PagingDB context)
        { _context = context; }



        // GET: CustomerController
        public async Task <ActionResult> Index(int pageNumber=1,int pageSize=5)
        {
            var query = _context.Customers.AsNoTracking();
            var count = await query.CountAsync(); // To get total count
            var pagedCustomers = await query.Skip((pageNumber - 1) * pageSize).Take(pageSize).ToListAsync();


            var numberOfPages = (int)Math.Ceiling(count * 1d / pageSize); // * 1d does not do any thing just for prevent ambigous
                                                                          // Math ceiling accepts only double and decimal not int
                                                                          // We have provided int, then the compiler stopped us
                                                                          // we need to inform it that we have double parameter, d refers to dobule


            var list = new PagedList<Customer>
            {
                Data = pagedCustomers,
                PageNumber = pageNumber,
                PageSize = pageSize,
                TotalCount = count,
                TotalPages = numberOfPages
            };

            return View(list);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

       
       public class PagedList<T>
        {
            public IEnumerable<T> Data { get; set; }
            public int TotalCount { get; set; }
            public int PageSize { get; set; }
            public int PageNumber { get; set; }
            public int TotalPages { get; set; }
        }
    }
}
