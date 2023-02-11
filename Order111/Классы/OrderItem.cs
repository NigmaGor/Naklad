using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderGen.Domain
{
    public class OrderItem
    {
        private string sepecification;//Название
        private decimal count;//Количество
        private decimal price;//Цена        
        private decimal nds; // НДС        
        private decimal total_sum;//Сумма
        private decimal rubl_nds;//НДС в рублях     
        private decimal sum_nds;//Сумма с НДС


        ///////////Работа с переменной Название (sepecification)
        public string Sepecification//Получение/Установка названия
        {
            //Получить название
            get { return sepecification; }
            //Установить название
            set
            {
                //Проверка строки на пустоту (IsValidSpecification)
                Contract.Requires(IsValidSepecification(value));
                //Проверка записалось ли значение
                Contract.Ensures(sepecification == value);

                //Установить название
                sepecification = value;
            }
        }
        //Проверка строки на пустоту
        public static bool IsValidSepecification(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }

        ///////////Работа с переменной Количество (count)
        public decimal Count//Получение/Установка Количества
        {
            //Получить количество
            get { return count; }
            //Установить количество
            set
            {
                //Проверка количества (IsValidCount)
                Contract.Requires(IsValidCount(value));
                //Проверка записалось ли значение
                Contract.Ensures(count == value);
                //Установка значения
                count = value;
            }
        }
        //Проверка количества (не может быть <= 0)
        public static bool IsValidCount(decimal value)
        {
            return value >= 0.0M;
        }

        ///////////Работа с переменной Цена (price)
        public decimal Price//Получение/Установка цены
        {
            //Получить цену
            get { return price; }
            //Установить цену
            set
            {
                //Проверка цены (IsValidCount)
                Contract.Requires(IsValidPrice(value));
                //Проверка записалось ли значение
                Contract.Ensures(price == value);
                //Установка значения
                price = value;
            }
        }
        //Проверка цены (не может быть < 0)
        public static bool IsValidPrice(decimal value)
        {
            return value >= 0.0M;
        }

        ///////////Работа с переменной НДС (nds)
        public decimal Nds
        {
            get { return nds; }
            set
            {
                Contract.Requires(IsValidNds(value));
                Contract.Ensures(nds == value);

                nds = value;
            }
        }
        //Проверка НДС (Не может быть <0 )
        public static bool IsValidNds(decimal value)
        {
            return value >= 0.0M;
        }

        ///////////Работа с переменной Сумма (total_sum)
        public decimal Total_Sum
        {
            get { return total_sum; }
            set
            {
                Contract.Ensures(total_sum == Count * Price);

                total_sum = Count * Price;
            }
        }

        ///////////Работа с переменной НДС в рублях (rubl_nds)
        public decimal Rubl_Nds
        {
            get { return rubl_nds; }
            set
            {
                Contract.Ensures(rubl_nds == Total_Sum / 100 * Nds);
                rubl_nds = Total_Sum / 100 * Nds;
            }
        }

        ///////////Работа с переменной Сумма с НДС (sum_nds)
        public decimal Sum_Nds
        {
            get { return sum_nds; }
            set
            {
                Contract.Ensures(sum_nds == Total_Sum + Rubl_Nds);
                sum_nds = Total_Sum + Rubl_Nds;
            }
        }









        /*
        /// <summary>
        /// Получает сумму по записи в накладной
        /// </summary>
        public decimal Total//Общая цена за количество товара
        {
            get { return _count * _price; }
        }
        /// <summary>
        /// Получает цену за единицу товара в записи накладной
        /// </summary>
        public decimal Price//Получить/установить цену единицы товара
        {
            get { return _price; }
            set
            {
                Contract.Requires(IsValidPrice(value));
                Contract.Ensures(_price == value);
                _price = value;
            }
        }
        /// <summary>
        /// Получает название товара в накладной
        /// </summary>
        public string Specification//Получить/установить название товара
        {
            get { return _sepecification; }
            set
            {
                Contract.Requires(IsValidSpecification(value));
                Contract.Ensures(_sepecification == value);
                _sepecification = value;
            }
        }
        /// <summary>
        /// Получает количество единиц товара в записи накладной
        /// </summary>
        public decimal Count//Получить/установить количество единиц товара
        {
            get { return _count; }
            set
            {
                Contract.Requires(IsValidCount(value));
                Contract.Ensures(_count == value);
                _count = value;
            }
        }
        public int nds//Получить/Установить значение НДС
        {
            get { return _nds; }
            set 
            {
                Contract.Requires(_nds > 0);
                _nds = value;

            }
        }
        /// <summary>
        /// Сумма НДС
        /// </summary>
        public decimal ndsSum//Получить сумму товара вместе с НДС
        {
            get 
            {
                Contract.Requires(_nds > 0);
                return Total * _nds; 
            }

        }
        /// <summary>
        /// Общая цена с НДС
        /// </summary>
        public decimal ndsTotal
        {
            get { return Total + ndsSum; }
        }
        /// <summary>
        /// Возвращает признак того, что аргумент является корректной ценой
        /// </summary>
        /// <param name="value">Цена</param>
        /// <returns>Истина, если аргумент является корректной ценой</returns>
            public static bool IsValidPrice(decimal value)
            {
                return value > 0.0M;
            }
        /// <summary>
        /// Возвращает признак того, что аргумент является корректным количеством
        /// </summary>
        /// <param name="value">Цена</param>
        /// <returns>Истина, если аргумент является корректным количеством</returns>
        public static bool IsValidCount(decimal value)
        {
            return value > 0.0M;
        }
        /// <summary>
        /// Возвращает признак того, что аргумент является корректной строкойспецификацией товара
        /// </summary>
        /// <param name="value">Строка-спецификация</param>
        /// <returns>Истина, если аргумент является корректной строкой-спецификацией товара
        /// </returns>
        public static bool IsValidSpecification(string value)
        {
            return !string.IsNullOrWhiteSpace(value);
        }
        */
    }
}
