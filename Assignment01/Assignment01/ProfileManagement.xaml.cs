using BusinessObject.Models;
using DataAccess.Repository;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for ProfileManagement.xaml
    /// </summary>
    public partial class ProfileManagement : Window
    {
        private readonly IOrderRepository orderRepository;
        private readonly IMemberRepository memberRepository;
        private readonly IProductRepository productRepository;
        private string email;
        private string password;
        public ProfileManagement(IOrderRepository _orderRepository,IMemberRepository _memberRepository)
        {
            InitializeComponent();
            orderRepository = _orderRepository;
            memberRepository = _memberRepository;
        }
        public ProfileManagement(IProductRepository _productRepository,IOrderRepository _orderRepository, IMemberRepository _memberRepository, string _email, string _password)
        {
            InitializeComponent();
            orderRepository = _orderRepository;
            memberRepository = _memberRepository;
            productRepository = _productRepository;
            email = _email;
            password = _password;
        }


        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            this.Hide();
            Login login = new Login(productRepository, memberRepository, orderRepository);
            login.Show();
        }
        private void loadProfile()
        {
            lvOrder.ItemsSource = orderRepository.getOrderListOfUser(email);
            Member member = memberRepository.getMemberByEmail(email,password);
            txtCity.Text = member.City;
            txtCompany.Text = member.CompanyName;
            txtCountry.Text = member.Country;
        }
        private void btnLoad_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                loadProfile();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Load profile");
            }
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Member member = memberRepository.getMemberByEmail(email,password);
                member.City = txtCity.Text;
                member.CompanyName = txtCompany.Text;
                member.Country = txtCountry.Text;
                memberRepository.Update(member);
                loadProfile();
                MessageBox.Show("Your profile was update succesfully", "Update Profile");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Update profile");
            }
        }
    }
}
