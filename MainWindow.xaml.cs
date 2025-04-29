using System.Windows;
using GerenciamentoEstoque.Context;
using GerenciamentoEstoque.Model;

namespace GerenciamentoEstoque
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        ProductModel NewProduct = new ProductModel();
        ProductModel selectProduct = new ProductModel();
        public MainWindow()
        {
            InitializeComponent();
            LoadProducts();
            NovoProdutoGrid.DataContext = NewProduct;
        }

        private void VerifyUser(object s, RoutedEventArgs e)
        {
            loginAdmin login = new loginAdmin();
            login.Show();
        }
        private void LoadProducts()
        {
            using (ProductContext context = new ProductContext())
            {
                var products = context.Products.ToList();
                DataGridProdutos.ItemsSource = products;
            }
        }
        
        private void FilterBy(object s, RoutedEventArgs e)
        {
            string filter = SearchProduct.Text.ToLower();
            using (ProductContext context = new ProductContext())
            {
                var products = context.Products.Where(p => p.Name.ToLower().Contains(filter)).ToList();
                DataGridProdutos.ItemsSource = products;
            }
        }
        public void Button_Click(object s, RoutedEventArgs e)
        {
            CampNewProduct.Visibility = Visibility.Visible;
        }
        public void OpenAddUser(object s, RoutedEventArgs e)
        {
            AddUser addUser = new AddUser();
            addUser.Show();
        }
        public void AddItem(object s, RoutedEventArgs e)
        {
            if (ValidaDados(NewProduct))
            {
                using (ProductContext context = new ProductContext())
                {
                    context.Add(NewProduct);
                    context.SaveChanges();
                    LoadProducts();
                    NewProduct = new ProductModel();
                    NovoProdutoGrid.DataContext = NewProduct;
                    MessageBox.Show("Produto adicionado com sucesso!");
                    CampNewProduct.Visibility = Visibility.Hidden;
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos corretamente.");

            }
        }

        public void RemoveItem(object s, RoutedEventArgs e)
        {
            using (ProductContext context = new ProductContext())
            {
                var ProductDelete = (s as FrameworkElement).DataContext as ProductModel;
                context.Remove(ProductDelete);
                context.SaveChanges();
                LoadProducts();
            }
            
        }
        private void SelectProdutoEditar(object s, RoutedEventArgs e)
        {
            selectProduct = (s as FrameworkElement).DataContext as ProductModel;
            EditarProdutoGrid.DataContext = selectProduct;
            CampUpdateProduct.Visibility = Visibility.Visible;
        }   
        public void UpdateItem(object s, RoutedEventArgs e)
        {
            if (ValidaDados(selectProduct))
            {
                using (ProductContext context = new ProductContext())
                {
                    bool searchProduct = context.Products.Any(p => p.Equals(selectProduct));
                    if (searchProduct == false)
                    {
                        MessageBox.Show("Produto não encontrado! Por favor, verifique se o produto ainda existe na lista!");
                        return;
                    }
                    else
                    {
                        context.Update(selectProduct);
                        var ProductUpdate = (s as FrameworkElement).DataContext as ProductModel;
                        context.Update(ProductUpdate);
                        context.SaveChanges();
                        LoadProducts();
                        MessageBox.Show("Produto atualizado com sucesso!");
                        CampUpdateProduct.Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            {
                MessageBox.Show("Preencha todos os campos corretamente.");
                var ProductUpdate = (s as FrameworkElement).DataContext as ProductModel;

            }
        }

        private bool ValidaDados(ProductModel product)
        {
            if (product.Name == null | product.Price == 0 | product.InStock == 0) return false;
            return true;
        }
    
    }   
}