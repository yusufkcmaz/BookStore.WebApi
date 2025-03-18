using BookStore.EntityLayer.Concrete;

namespace BookStore.WebApi.Dtos.ApiCategoryDto
{
    public class Categoryandproductresponsedto
    {

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }
        public List<Product> Products { get; set; }
        public List<Category> Categories { get; set; }
    }
}
