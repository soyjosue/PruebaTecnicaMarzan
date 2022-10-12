using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using PruebaTecnicaMarzan.Data.Contracts;
using PruebaTecnicaMarzan.Models;
using PruebaTecnicaMarzan.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace PruebaTecnicaMarzan.Controllers
{
    public class OrderController : Controller
    {
        IOrderRepository _orderRepository;
        ICustomerRepository _customerRepository;
        IProductRepository _productRepository;
        IMapper _mapper;
        public OrderController(IOrderRepository orderRepository,
            ICustomerRepository customerRepository,
            IProductRepository productRepository,
            IMapper mapper)
        {
            _orderRepository = orderRepository;
            _customerRepository = customerRepository;
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public async Task<IActionResult> Index(string SearchText)
        {
            var orders = await _orderRepository.GetAllAsync();

            if(!string.IsNullOrEmpty(SearchText))
            {
                orders = orders.Where(i => i.Customer.Name.Contains(SearchText) || i.ID.ToString() == SearchText);
            }

            return View(_mapper.Map<IEnumerable<OrderViewModel>>(orders));
        }

        public async Task<IActionResult> Create()
        {
            var viewModel = new OrderCreateViewModel();
            var customers = await _customerRepository.GetAllAsync();
            var products = await _productRepository.GetAllAsync();

            viewModel.Order = new Order();
            viewModel.Customers = customers.Select(i => new SelectListItem { Value = i.ID.ToString(), Text = i.Name });
            viewModel.OrderDetails = new List<OrderDetail>() { new OrderDetail { } };
            viewModel.Products = products.Select(i => new SelectListItem { Value = i.ID.ToString(), Text = i.Name });

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(OrderCreateViewModel model)
        {
            ViewData["ErrorMessage"] = null;
            model.Order.CreatedAt = DateTime.Now;
            if (!ModelState.IsValid)
            {
                return View();
            }

            try
            {
                model.Order.OrderDetails = model.OrderDetails;
                var result = await _orderRepository.CreateAsync(model.Order);

                if (!result)
                {
                    ViewData["ErrorMessage"] = "La orden no pudo ser creada.";
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(model);
            }
        }

        public async Task<IActionResult> Edit(int id)
        {
            if (id == 0)
            {
                return NotFound();
            }

            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
                return NotFound();

            var customers = await _customerRepository.GetAllAsync();
            var products = await _productRepository.GetAllAsync();

            return View(new OrderCreateViewModel
            {
                Order = order,
                Customers = customers.Select(i => new SelectListItem { Value = i.ID.ToString(), Text = i.Name }),
                Products = products.Select(i => new SelectListItem { Value = i.ID.ToString(), Text = i.Name }),
                OrderDetails = new List<OrderDetail>(order.OrderDetails)
            });
        }

        [HttpPost]
        public async Task<IActionResult> Edit(OrderCreateViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            try
            {
                var order = await _orderRepository.GetByIdAsync(model.Order.ID);

                if(order == null)
                {
                    return NotFound();
                }

                order.CustomerID = model.Order.CustomerID;
                order.CreatedAt = model.Order.CreatedAt;
                order.OrderDetails = model.OrderDetails;

                var result = await _orderRepository.EditAsync(order);

                if(!result)
                {
                    ViewData["ErrorMessage"] = "No se pudo editar la orden";
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(model);
            }
        }

        public async Task<IActionResult> Delete(int id)
        {
            if(id == 0)
            {
                return NotFound();
            }

            var order = await _orderRepository.GetByIdAsync(id);

            if(order == null)
            {
                return NotFound();
            }

            return View(order);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Order model)
        {
            try
            {
                var order = await _orderRepository.GetByIdAsync(model.ID);

                if (order == null) return NotFound();

                var result = await _orderRepository.RemoveAsync(order);

                if (!result)
                {
                    ViewData["ErrorMessage"] = "La orden no pudo ser eliminar.";
                    return View(model);
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ViewData["ErrorMessage"] = ex.Message;
                return View(model);
            }
        }

        public async Task<IActionResult> Details(int id)
        {
            if (id == 0)
                return NotFound();

            var order = await _orderRepository.GetByIdAsync(id);

            if (order == null)
                return NotFound();

            return View(order);
        }
    }
}
