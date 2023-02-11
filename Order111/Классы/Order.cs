using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
    
namespace OrderGen.Domain
{
    public class Order

    {   
        private readonly IList<OrderItem> _orderItems = new List<OrderItem>();
        private int _id;//Номер накладной
        public Order()///Конструктор 
        {
            _id = 1; //Номер накладной начинается с 1
            Created = DateTime.Today;//Запоминаем сегодняшнюю дату
        }
        public override string ToString()
        {
            return Convert.ToString(_id);
        }

        //Работа с номером накладной
        public int Id
        {
            get { return _id; }//Получаем id накладной
            set
            {
                //Проверка id накладной на положительное значение
                Contract.Requires(IsValidId(value), "Номер накладной должен быть положительным числом");
               //Установка id накладной
                _id = value;
            }
        }

        //Работа с датой
        public DateTime Created { get; set; }//Получение/установка даты накладной

        //Работа с суммой по накладной
        public decimal Total
        {
            get
            {   //Получаем общую сумму товаров по накладной
                Contract.Requires(OrderItems != null, "Коллекция записей накладной должна быть создана.");
            return _orderItems.Sum(x => x.Total_Sum);
            }
        }

        //Работа с НДС по накладной
        public decimal Total_Nds
        {
            get
            {   //Получаем общую сумму товаров по накладной с НДС
                Contract.Requires(OrderItems != null, "Коллекция записей накладной должна быть создана.");
                return _orderItems.Sum(x => x.Sum_Nds);
            }
        }

        //Получаем список товаров в накладной
        //У каждой накладной есть свой OrderItems
        public IList<OrderItem> OrderItems
        {
            get { return _orderItems; }
         
        }

        //Проверка, что номер накладной должен быть больше 0
        public static bool IsValidId(int value)
        {
            return value > 0;
        }

        //Очистка списка товаров по накладной
        public void Clear()
        {
            Contract.Requires(OrderItems != null);
            Contract.Ensures(OrderItems.Count == 0);
            OrderItems.Clear();
        }
    }
}
