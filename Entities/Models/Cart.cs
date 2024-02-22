namespace Entities.Models
{
    public class Cart
    {
        public List<CartLine> Lines { get; set; }
        public Cart()
        {
            Lines = new List<CartLine>();
        }

        //ürün ekleme fonksyonu
        public virtual void AddItem(Product product, int quantity)
        {
            //sepete eklenen ürünün sepette olup olmadığı kontrol ediyor   
            CartLine? line = Lines.Where(ı=>ı.Product.ProductId.Equals(product.ProductId)).FirstOrDefault();
            //sepete eklenen ürünün sepette yok ise ekliyor
            if (line is null)   
            {
                Lines.Add(new CartLine(){
                    Product = product,
                    Quantity = quantity
                });
            }
            //sepete eklenen ürünün sepette var ise sayısını artırıyor 
            else
            {
                line.Quantity +=quantity;
            }
        }
    
        //ürün silme fonksiyonu
        public virtual void RemoveLine(Product product)=>
            //silineccek ürünün listedek herhangi bir ürünün Id's ile eşleşiyor ise o satrın temamını siliyor
            Lines.RemoveAll(ı=>ı.Product.ProductId.Equals(product.ProductId));

        //sepet tutarı hesaplama fonksiyonu
        public decimal ComputeTotalValue()=>
            Lines.Sum(e=>e.Product.Price*e.Quantity);

        //sepeti temizleme fonksiyonu
        public virtual void Clear() => Lines.Clear();


    }
}