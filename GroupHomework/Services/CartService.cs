using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GroupHomework.Models;
using GroupHomework.Adapters;
using SQLitePCL;
namespace GroupHomework.Services
{
    interface ICartService
    {
        List<CartItem> GetCart();
        bool AddToCart(CartItem item);
        bool RemoveItem(CartItem item);
        bool UpdateItem(CartItem item, int qty);
        bool ClearCart();
    }

    class CartService : ICartService
    {
        public bool AddToCart(CartItem item)
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "insert into Cart(Id,Name,Image,Price,Qty) values(?,?,?,?,?)";
                var statement = connection.Prepare(sql_txt);
                statement.Bind(1, item.Id);
                statement.Bind(2, item.Name);
                statement.Bind(3, item.ImageProduct);
                statement.Bind(4, item.Price);
                statement.Bind(5, item.Qty);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch (Exception e)
            {
                return false;
            }

        }

        public bool ClearCart()
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "delete from Cart";
                var statement = connection.Prepare(sql_txt);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public List<CartItem> GetCart()
        {
            List<CartItem> list = new List<CartItem>();
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "select * from Cart";
                var statement = connection.Prepare(sql_txt);
                while (SQLiteResult.ROW == statement.Step())
                {
                    CartItem item = new CartItem()
                    {
                        Id = Convert.ToInt32(statement[0]),
                        Name = statement[1] as string,
                        ImageProduct = statement[2] as string,
                        Price = Convert.ToInt32(statement[3]),
                        Qty = Convert.ToInt32(statement[4]),
                    };
                    list.Add(item);
                }
            }
            catch (Exception e)
            {

            }
            return list;
        }

        public bool RemoveItem(CartItem item)
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "delete from Cart where Id = ?";
                var statement = connection.Prepare(sql_txt);
                statement.Bind(1, item.Id);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch (Exception e)
            {
                return false;
            }
        }

        public bool UpdateItem(CartItem item, int qty)
        {
            try
            {
                SQLiteConnection connection = SQLiteHelper.GetInstance()._sQLiteConnection;
                string sql_txt = "update Cart set Qty=? where Id = ?";
                var statement = connection.Prepare(sql_txt);
                statement.Bind(1, qty);
                statement.Bind(2, item.Id);
                var rs = statement.Step();
                return rs == SQLiteResult.OK;
            }
            catch (Exception e)
            {
                return false;
            }
        }
        }
    }
