﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer;

namespace DataRepositoryLayer
{
    public class DataRepository
    {
        private static DataClasses1DataContext context = new DataClasses1DataContext();

        public static List<Customer> SelectAllCustomers() {

            List<Customer> allCustomers =
                 (from customer in context.Customers
                  select customer).ToList();

            return allCustomers;
        }

        public static void AddCustomer(Customer customer) {

            context.Customers.InsertOnSubmit(customer);

            try {
                context.SubmitChanges();
            }
            catch (Exception e) { }
        }

        public static void DeleteCustomer(int customerID) {

            var matchedCustomers =
                from customers in context.Customers
                where customers.Id == customerID
                select customers;

            foreach (Customer customer in matchedCustomers) {
                context.Customers.DeleteOnSubmit(customer);
            }

            try {
                context.SubmitChanges();
            }
            catch (Exception e) { }
        }

        public static void UpdateCustomer(Customer cust) {

            var matchedCustomers =
                from customers in context.Customers
                where customers.Id == cust.Id
                select customers;

            foreach (Customer customer in matchedCustomers) {
                customer.Name = cust.Name;
                customer.Surname = cust.Surname;
                customer.Age = cust.Age;
                customer.Email = cust.Email;
            }

            try {
                context.SubmitChanges();
            }
            catch { }
        }

    }
}