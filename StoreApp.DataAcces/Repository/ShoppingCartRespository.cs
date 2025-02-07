﻿using StoreApp.DataAcces.Data;
using StoreApp.DataAcces.Repository.IRepository;
using StoreApp.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreApp.DataAcces.Repository
{
    class ShoppingCartRespository : Repository<ShoppingCartModel>, IShoppingCartRepository
    {
        private ApplicationDbContext _db;
        public ShoppingCartRespository(ApplicationDbContext db) : base(db)
        {
            _db = db;
        }

        public string CreateNewCart()
        {
            var cartID = Guid.NewGuid().ToString();

            var newCart = new ShoppingCartModel() { 
                Id = 0,
                Products = [],
                ShoppingCartId = cartID
            };
            _db.ShoppingCart.Add(newCart);
            return cartID;
        }

        public void AddProductToCart(string cartID, int productId)
        {
            var cart = _db.ShoppingCart.FirstOrDefault(cart => cart.ShoppingCartId == cartID);
            if(cart == null)
            {
                return;
            }
            var product = _db.Products.FirstOrDefault(p => p.Id == productId);
            if(product == null)
            {
                return;
            }
            cart.Products.Add(product);
            return;
        }

        public void RemoveProductFromCart(string cartID, int productId)
        {
            var cart = _db.ShoppingCart.FirstOrDefault(cart => cart.ShoppingCartId == cartID);
            if (cart == null)
            {
                return;
            }
            var newProducts = cart.Products.Where(product => product.Id != productId).ToList();
            if(newProducts == null)
            {
                return;
            }
            cart.Products = newProducts;
            _db.ShoppingCart.Update(cart);
        }

        public void Update(ShoppingCartModel ShoppingCart)
        {
            throw new NotImplementedException();
        }
    }
}
