using BlazorShop.Shared.DTOs;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

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

        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
