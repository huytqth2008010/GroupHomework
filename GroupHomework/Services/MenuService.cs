using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace GroupHomework.Services
{
    class MenuService
    {
        // lay data tu api va tra ve 1 object Categories
        // task 1 -- chua xong (delay, duration...) -> để đó chờ
        // task 2 --> làm task 2 kể cả task 1 chưa xong
        public async Task<Models.Categories> GetMenu()
        {
            Adapters.FoodGroup api = Adapters.FoodGroup.GetInstance();
            HttpClient hc = new HttpClient(); // shipper -> lo việc kết nối api để lấy dữ liệu
            //var rs = await hc.GetAsync("http://foodgroup.herokuapp.com/api/menu");// get_file_content -> thao tác trả hàng của shipper
            var rs = await hc.GetAsync(api.ApiMenu);// get_file_content -> thao tác trả hàng của shipper
            if (rs.StatusCode == HttpStatusCode.OK)
            {
                var stringContent = await rs.Content.ReadAsStringAsync();// chuyển thành string json
                Models.Categories categories = JsonConvert.DeserializeObject<Models.Categories>(stringContent);// convert string json thành 1 object DTO (Categories)
                return categories;
            }
            return null;
        }
        public async Task<Models.CategoryDetail> GetCategoryDetail(string id)
        {
            Adapters.FoodGroup api = Adapters.FoodGroup.GetInstance();
            HttpClient hc = new HttpClient(); // shipper -> lo việc kết nối api để lấy dữ liệu
            var rs = await hc.GetAsync(api.CategoryDetail(id));// get_file_content -> thao tác trả hàng của shipper
            if (rs.StatusCode == HttpStatusCode.OK)
            {
                var stringContent = await rs.Content.ReadAsStringAsync();// chuyển thành string json
                Models.CategoryDetail categoryDetail = JsonConvert.DeserializeObject<Models.CategoryDetail>(stringContent);
                return categoryDetail;
            }
            return null;
        }
    }
}
