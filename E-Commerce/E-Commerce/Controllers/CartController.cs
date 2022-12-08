using E_Commerce.Models;
using E_Commerce.Models.EntityClasses;
using E_Commerce.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.Remoting.Messaging;
using System.Security.Policy;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace E_Commerce.Controllers
{
    public class CartController : Controller
    {
        CartDbAccessService accessService;
        OrderDbAccess OrderDbAccess;
        ProductDBAccess productDBAccess;
        public CartController()
        {
            accessService = new CartDbAccessService();
            OrderDbAccess = new OrderDbAccess();
            productDBAccess = new ProductDBAccess();
        }
        public ActionResult Index()
        {
            return View();
        }

        // GET: Cart
        public async Task<ActionResult> GetAllProductsOnCart()
        {
            try
            {
                var userId = Session["UserId"];
                var cartdetails = await accessService.GetCarts();
                TempData["Quantity"] = cartdetails;
                var productOnCart = await accessService.GetProductsOnCart(Convert.ToInt32(userId));
                return View(productOnCart);
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }

        public async Task<ActionResult> AddProductsToCart(int id)
        {
            try
            {
                var Userid = Convert.ToInt32(Session["UserId"]);
                var ProductsInCart = await accessService.GetProductsOnCart(Userid);
                var isProductAlreadyExists = from prod in ProductsInCart
                                             where prod.ProductId == id
                                             select prod.ProductId;
                if (isProductAlreadyExists.Count() != 0)
                {
                    var cartdetails = await accessService.GetCarts();
                    TempData["Quantity"] = cartdetails;
                    await accessService.AddQuantity(Convert.ToInt32(isProductAlreadyExists.FirstOrDefault()));
                    return RedirectToAction("GetAllProductsOnCart", "Cart");
                }
                else
                {
                    var cartItem = new Cart()
                    {
                        ProductId = id,
                        UserId = Userid,
                        CartSatus = "Active",
                        ProductCount = 1
                    };
                    if (cartItem.UserId == 0)
                    {
                        return RedirectToAction("Login", "Account");
                    }
                    var isAddedToCart = accessService.AddToCart(cartItem);
                    if (isAddedToCart)
                    {
                        ModelState.AddModelError("", "Item Added Succesfully");
                        return RedirectToAction("Index", "Home");
                    }
                }
                return View();
            }
            catch (Exception)
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }


        public async Task<ActionResult> RemoveProducts(int id)
        {
            try
            {
                var quantity =await accessService.GetProdQuantity(id);
                if (quantity.ProductCount > 1)
                {
                    var cartdetails = await accessService.GetCarts();
                    TempData["Quantity"] = cartdetails;
                    await accessService.ReduceQuantity(id);
                    return RedirectToAction("GetAllProductsOnCart", "Cart");
                }
                var removed = accessService.RemoveProdsFormCart(id);
                return RedirectToAction("GetAllProductsOnCart");
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }



        public async Task<ActionResult> GetPayment(int userId)
        {
            try
            {
                var paymentDetails = await accessService.getPayment(userId);
                Session["payment"] = paymentDetails;
                return PartialView("GetPayment", paymentDetails);
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }


        public async Task<ActionResult> PaymentPage(int ship)
        {
            try
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                if (Session["ProductId"]!= null)
                {
                    int productid = (int)Session["ProductId"];
                    Session.Remove("ProductId");
                    List<Product> product = new List<Product>();
                    product.Add(await productDBAccess.GetById(productid));
                    await OrderDbAccess.Insert(product, userId, ship);
                    return View();
                }
                var prodsOnCart = await accessService.GetProductsOnCart(userId);
                await OrderDbAccess.Insert(prodsOnCart, userId, ship);
                return View();
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }


        public async Task<ActionResult> PayemtSuccess()
        {
            try
            {
                int userId = Convert.ToInt32(Session["UserId"]);
                var removeProds = await accessService.RemoveProdsFromCartByUserID(userId);
                return View();
            }
            catch (Exception )
            {
                return RedirectToAction("ErrorPage", "Home");
            }
        }
    }
}