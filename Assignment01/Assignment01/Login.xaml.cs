using BusinessObject.Models;
using DataAccess.Repository;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SalesWPFApp
{
    /// <summary>
    /// Interaction logic for Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        private readonly IProductRepository productRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IOrderRepository orderRepository;
        public Login(IProductRepository _productRepository, IMemberRepository _memberRepository, IOrderRepository _orderRepository)
        {
            InitializeComponent();
            productRepository = _productRepository;
            memberRepository = _memberRepository;
            orderRepository = _orderRepository;
        }
        public Login(IMemberRepository _memberRepository, IOrderRepository _orderRepository)
        {
            InitializeComponent();
           
            memberRepository = _memberRepository;
            orderRepository = _orderRepository;
        }



        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string email = txtEmail.Text;
            string password = txtPass.Text;
            var a = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build().GetSection("account");
            if (!String.IsNullOrEmpty(email) && !String.IsNullOrEmpty(password))
            {
                if (email == a["email"] && password == a["password"])
                {
                    this.Hide();
                    ProductManagement p = new ProductManagement(orderRepository, memberRepository, productRepository);
                    p.Show();

                }
                else
                {
                    Member member = memberRepository.getMemberByEmail(email,password);
                    if(member != null)
                    {
                        this.Hide();
                        ProfileManagement p = new ProfileManagement(productRepository,orderRepository, memberRepository, email, password);
                        p.Show();
                    }else

                        MessageBox.Show("Wrong email or password. Try again!");
                }
            }
            else
            {
                MessageBox.Show("Please enter email and password");
            }

        }
    }
}
