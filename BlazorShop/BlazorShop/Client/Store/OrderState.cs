using BlazorShop.Shared.DTOs.Order;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text.Json;
using System.Threading.Tasks;
using BlazorShop.Client.Business;

namespace BlazorShop.Client.Store
{
    public class OrderState : INotifyPropertyChanged
    {
        private int customerId;
        private string payment;
        private int discountPercentage;
        private ObservableCollection<OrderProductSubmitDTO> orderProduct;

        public OrderState()
        {
            OrderProduct = new ObservableCollection<OrderProductSubmitDTO>();
        }

        public int CustomerId 
        {
            get => customerId;
            set
            {
                customerId = value;
                RaisePropertyChanged();
            }
        }

        public string Payment
        {
            get => payment;
            set
            {
                payment = value;
                RaisePropertyChanged();
            }
        }

        public int DiscountPercentage
        {
            get => discountPercentage;
            set
            {
                discountPercentage = value;
                RaisePropertyChanged();
            }
        }

        public ObservableCollection<OrderProductSubmitDTO> OrderProduct 
        {
            get => orderProduct;
            set
            {
                orderProduct = value;
                RaisePropertyChanged();
            }
        }

        public void Refresh()
        {
            RaisePropertyChanged();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public double ShippingValue
        {
            get
            {
                return Orders.CalculateShippingValue(this);
            }
        }

        public double DiscountValue
        {
            get 
            { 
                return Orders.CalculateDiscountValue(this); 
            }
        }

        public double ProductsValue
        {
            get
            {
                return Orders.CalculateProductsValue(this);
            }
        }

        public double GrandTotal
        {
            get
            {
                return ShippingValue + ProductsValue - DiscountValue;
            }
        }
    }
}
