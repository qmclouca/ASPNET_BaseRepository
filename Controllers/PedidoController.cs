using Microsoft.AspNetCore.Mvc;
using VendaLanches.Models;
using VendaLanches.Repositories.Interfaces;

namespace VendaLanches.Controllers
{
    public class PedidoController : Controller
    {
        private readonly CarrinhoCompra _carrinhoCompra;
        private readonly IPedidoRepository _pedidoRepository;

        public PedidoController(CarrinhoCompra carrinhoCompra, IPedidoRepository pedidoRepository)
        {
            _carrinhoCompra = carrinhoCompra;
            _pedidoRepository = pedidoRepository;
        }

        public IActionResult Checkout()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Checkout(Pedido pedido)
        {
            var items = _carrinhoCompra.GetCarrinhoCompraItens();
            _carrinhoCompra.CarrinhoCompraItens = items;

            if (_carrinhoCompra.CarrinhoCompraItens.Count == 0)
            {
                ModelState.AddModelError("", "Seu carrinho está vazio, inclua um lanche...");
            }

            if (ModelState.IsValid)
            {
                _pedidoRepository.CriarPedido(pedido);
                _carrinhoCompra.LimparCarrinho();
                return RedirectToAction("CheckoutCompleto");
            }

            return View(pedido);
        }
    }
}
