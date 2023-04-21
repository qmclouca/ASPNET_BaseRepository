﻿using VendaLanches.Context;

namespace VendaLanches.Models
{
    public class CarrinhoCompra
    {
        private readonly AppDbContext _context;

        public CarrinhoCompra(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public string CarrinhoCompraId { get; set; }
        public List<CarrinhoCompraItem> CarrinhoCompraItens { get; set; }
        public static CarrinhoCompra GetCarrinho(IServiceProvider services)
        {
            ISession session = services.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            var context = services.GetService<AppDbContext>();
            string carrinhoId = session.GetString("CarrinhoId") ?? Guid.NewGuid().ToString();
            session.SetString("CarrinhoId", carrinhoId);
            return new CarrinhoCompra(context) { CarrinhoCompraId = carrinhoId };
        }
    }
}
