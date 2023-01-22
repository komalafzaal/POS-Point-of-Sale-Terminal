using System.IO;
using System;
using DTO;
using BLL;
using System.Collections.Generic;
using DAL;
using Microsoft.Data.SqlClient;
using System.Diagnostics;

namespace PL
{
    public class posView
    {
        int menuChoice;
        int itemMenuChocie;
        int cusMenuChocie;
        int saleMenu;
        bool flag;
        bool flag2;
        int customerId;

        void showMainMenu()
        {
            Console.WriteLine("***************** Main Menu ******************");
            Console.WriteLine("1- Manage Items\r\n2- Manage Customers\r\n3- Make New Sale\r\n4- Make Payment\r\n5- Exit\r\n");
            Console.WriteLine("Press 1 to 5 to select an option");

            menuChoice = int.Parse(Console.ReadLine());
        }
        private void showItemsMenu()
        {
            Console.WriteLine("***************** Items Menu ******************");
            Console.WriteLine("1- Add new Item\r\n2- Update Item details\r\n3- Find Items\r\n4- Remove Existing Item\r\n5- Back to Main Menu");
            Console.WriteLine("Press 1 to 5 to select an option");

            itemMenuChocie = int.Parse(Console.ReadLine());
        }

        private void showSalesMenu()
        {
            Console.WriteLine("***************** Items Menu ******************");
            Console.WriteLine("Press 1 to Enter New Item\r\nPress 2 to End Sale\r\nPress 3 to Remove an existing Item from the current sale\r\nPress 4 to Cancel Sale\r\n");
            Console.WriteLine("Choose from option 1 – 4:");

            saleMenu = int.Parse(Console.ReadLine());
        }

        private void showCustomerMenu()
        {
            Console.WriteLine("***************** Customers Menu ******************");
            Console.WriteLine("1- Add new Customer\r\n2- Update Customer details\r\n3- Find Customer\r\n4- Remove Existing Customer\r\n5- Back to Main Menu");
            Console.WriteLine("\nPress 1 to 5 to select an option");

            cusMenuChocie = int.Parse(Console.ReadLine());
        }
        private void addItem()
        {
            Console.WriteLine("\n**************** Add Item ****************\n");
            Console.WriteLine("Enter Description of item: ");
            string des = Console.ReadLine();
            Console.WriteLine("Enter price of item: ");
            double pr = double.Parse(Console.ReadLine());
            Console.WriteLine("Enter quantity of item: ");
            int quan = int.Parse(Console.ReadLine());

            string date = DateTime.Now.ToString("MM/dd/yyyy");

            itemDTO item = new itemDTO();
            item.Description = des;
            item.Price = pr;
            item.Quantity = quan;
            item.CreationDate = date;

            itemBLL ibll = new itemBLL();
            ibll.AddItem(item);
        }

        private void modifyItem()
        {
            Console.WriteLine("\n**************** Modify Item ****************\n");
            Console.WriteLine("Item ID: ");
            int id = int.Parse(Console.ReadLine());

            itemDTO item = new itemDTO();  
            item.Id = id;
           
            itemBLL ibll = new itemBLL();
            bool validateId = ibll.ValidateItemId(item);
            if (validateId == true)
            {
                Console.WriteLine("Display record...");
                List <itemDTO> list = new List<itemDTO>();
                itemBLL bll = new itemBLL();
                list = bll.ReadItems(item);

                foreach (itemDTO i in list)
                {
                    Console.WriteLine("----------------------------------------------------------------------------\r\n");
                    Console.WriteLine("Item ID \tDescription \tPrice \tQuantity\r\n");
                    Console.WriteLine("-----------------------------------------------------------------------------\r\n");

                    Console.Write(i.Id + "\t\t");
                    Console.Write(i.Description + "\t\t");
                    Console.Write(i.Price+ "\t\t");
                    Console.Write(i.Quantity + "\t\t\r\n");
                    Console.WriteLine("-----------------------------------------------------------------------------\r\n");
                    
                }

                Console.WriteLine("\n**************** Enter New Data ****************\n");
                Console.WriteLine("Description: ");
                string des = Console.ReadLine();
                Console.WriteLine("Price: ");
                double pr = double.Parse(Console.ReadLine());
                Console.WriteLine("Quantity ");
                int quan = int.Parse(Console.ReadLine());
                Console.WriteLine("Creation Date: ");
                string date = Console.ReadLine();
                
                itemDTO modifyItem = new itemDTO();
                modifyItem.Id = id;
                modifyItem.Description = des;
                modifyItem.Price = pr;
                modifyItem.Quantity = quan;
                modifyItem.CreationDate = date;
                itemBLL modifyibll = new itemBLL();
                modifyibll.ModifyItem(modifyItem);
            }
            else
            {
                Console.WriteLine("There is NO record against this id..");
            }
        }

        private void findItem()
        {
            Console.WriteLine("\n**************** Find Item ****************\n");
            Console.WriteLine("Item ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Description: ");
            string des = Console.ReadLine();
            Console.WriteLine("Price: ");
            double pr = double.Parse(Console.ReadLine());
            Console.WriteLine("Quantity: ");
            int quan = int.Parse(Console.ReadLine());
            Console.WriteLine("Creation Date: ");
            string date = Console.ReadLine();

            itemDTO item = new itemDTO();

            item.Id = id;
            item.Description = des;
            item.Price = pr;
            item.Quantity = quan;
            item.CreationDate = date;
            
            if(item == null)
            {
                Console.Write("There is nothing to find!");
            }
           

            itemBLL bll = new itemBLL();
            bool status = bll.FindItem(item);

            if (status)
            {
                Console.WriteLine("Data Found!..Display record...");
                List<itemDTO> list = new List<itemDTO>();
                itemBLL cbll = new itemBLL();
                list = cbll.ReadFindItems(item);
                Console.WriteLine("----------------------------------------------------------------------------\r\n");
                Console.WriteLine("Item ID \tDescription \t\tPrice \t\t\tQuantity\r\n");
                Console.WriteLine("-----------------------------------------------------------------------------\r\n");
                foreach (itemDTO i in list)
                {
                    Console.Write(i.Id + "\t\t");
                    Console.Write(i.Description + "\t\t");
                    Console.Write(i.Price + "\t\t");
                    Console.Write(i.Quantity + "\t\t\n");
                }
                Console.WriteLine("\n-----------------------------------------------------------------------------\r\n");

            }
            else
            {
                Console.WriteLine("There is NO record against this data...");
            }

        }
        private void removeItem()
        {
            Console.WriteLine("\n****************Remove Item****************\n");
            Console.WriteLine("Item ID: ");
            int id = int.Parse(Console.ReadLine());

            itemDTO item = new itemDTO();
            item.Id = id;

            itemBLL ibll = new itemBLL();
            bool status = ibll.ValidateItemId(item);
            Console.WriteLine(status);
            if (status)
            {
                ibll.RemoveExistingItem(item);
            }
            else
            {
                Console.WriteLine("There is no record against this ID");
            }
        }

        private void BacktoMainMenu()
        {
            userInput();
        }

        private void addCustomer()
        {
            Console.WriteLine("\n****************Add Customer****************\n");
            Console.WriteLine("Enter Name of customer: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Address of customer: ");
            string add = Console.ReadLine();
            Console.WriteLine("Enter Phone Number of customer: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Email of customer: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Sales Limit: ");
            double sLimit = double.Parse(Console.ReadLine());
            
            customerDTO customer = new customerDTO();
            customer.Name = name;
            customer.Address = add;
            customer.Phone = phone;
            customer.Email = email;
            customer.SalesLimit = sLimit;

            customerBLL ibll = new customerBLL();
            ibll.AddCustomer(customer);
        }
        private void modifyCustomer()
        {
            Console.WriteLine("\n****************Modify Customer****************\n");
            Console.WriteLine("Customer ID: ");
            int id = int.Parse(Console.ReadLine());

            customerDTO customer = new customerDTO();
            customer.Id = id;

            customerBLL ibll = new customerBLL();
            bool validateId = ibll.ValidateCustomerId(customer);
            if (validateId == true)
            {
                Console.WriteLine("Display record...");
                List<customerDTO> list = new List<customerDTO>();
                customerBLL bll = new customerBLL();
                list = bll.ReadCustomer(customer);

                Console.WriteLine("----------------------------------------------------------------------------\r\n");
                Console.WriteLine("Customer ID \tName \t\tEmail \t\t\tPhone \t\tSales Limit\r\n");
                Console.WriteLine("-----------------------------------------------------------------------------\r\n");
                foreach (customerDTO i in list)
                {
              
                    Console.Write(i.Id + "\t\t");
                    Console.Write(i.Name + "\t\t");
                    Console.Write(i.Email + "\t\t");
                    Console.Write(i.Phone + "\t\t");
                    Console.Write(i.SalesLimit + "\t\t\r\n");

                }
                Console.WriteLine("\n-----------------------------------------------------------------------------\r\n");

                Console.WriteLine("\n****************Enter New Data****************\n");
                Console.WriteLine("Enter Name of customer: ");
                string name = Console.ReadLine();
                Console.WriteLine("Enter Address of customer: ");
                string add = Console.ReadLine();
                Console.WriteLine("Enter Phone Number of customer: ");
                string phone = Console.ReadLine();
                Console.WriteLine("Enter Email of customer: ");
                string email = Console.ReadLine();
                Console.WriteLine("Enter Sales Limit: ");
                double sLimit = double.Parse(Console.ReadLine());

                customerDTO modifyCustomer = new customerDTO();
                modifyCustomer.Id = id;
                modifyCustomer.Name = name;
                modifyCustomer.Address = add;
                modifyCustomer.Phone = phone;
                modifyCustomer.Email = email;
                modifyCustomer.SalesLimit = sLimit;
                customerBLL modifycbll = new customerBLL();
                modifycbll.ModifyCustomer(modifyCustomer);
            }
            else
            {
                Console.WriteLine("No id found..");
            }
        }
        private void findCustomer()
        {
            Console.WriteLine("\n****************Find Customer****************\n");

            Console.WriteLine("Please specify atleast one of the following to find the customer. Leave all fields blank to return to Customers Menu: ");
            Console.WriteLine("Customer ID: ");
            int id = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter Name of customer: ");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Phone Number of customer: ");
            string phone = Console.ReadLine();
            Console.WriteLine("Enter Email of customer: ");
            string email = Console.ReadLine();
            Console.WriteLine("Enter Sales Limit: ");
            double sLimit = double.Parse(Console.ReadLine());


            customerDTO customer = new customerDTO();

            customer.Id = id;
            customer.Name = name;
            customer.Phone = phone;
            customer.Email = email;
            customer.SalesLimit = sLimit;
            customerBLL bll = new customerBLL();
            bool status = bll.FindCustomer(customer);

            if(status)
            {
                Console.WriteLine("Data Found!..Display record...");
                List<customerDTO> list = new List<customerDTO>();
                customerBLL cbll = new customerBLL();
                list = cbll.ReadFindCustomers(customer);

                Console.WriteLine("----------------------------------------------------------------------------\r\n");
                Console.WriteLine("Customer ID \tName \t\tEmail \t\t\tPhone \t\tSales Limit\r\n");
                Console.WriteLine("-----------------------------------------------------------------------------\r\n");
                foreach (customerDTO i in list)
                {
                   
                    Console.Write(i.Id + "\t\t");
                    Console.Write(i.Name + "\t\t");
                    Console.Write(i.Email + "\t\t");
                    Console.Write(i.Phone + "\t\t");
                    Console.Write(i.SalesLimit + "\t\t\r\n");
                    Console.WriteLine("\n-----------------------------------------------------------------------------\r\n");
                }
            }
            else
            {
                Console.WriteLine("There is NO record against this data...");
            }
        }
        private void removeCustomer()
        {
            Console.WriteLine("\n****************Remove Customer****************\n");
            Console.WriteLine("Customer ID: ");
            int id = int.Parse(Console.ReadLine());

            customerDTO customer = new customerDTO();
            customer.Id = id;

            customerBLL cbll = new customerBLL();
            bool status = cbll.ValidateCustomerId(customer);
            Console.WriteLine(status);
            if (status)
            {
                cbll.RemoveExistingCustomer(customer);
            }
            else
            {
                Console.WriteLine("There is no record against this ID");
            }
        }

        private int getSaleInfo()
        {
            Console.WriteLine("\n**************** Make New Sale ****************\n");
            string status;

            salesDTO sale = new salesDTO();
            
            salesBLL sbll = new salesBLL();
            int id = sbll.ReadLastRecordID(sale);

            string date = DateTime.Now.ToString("MM/dd/yyyy");

            id = id + 1;
            Console.WriteLine("Sales Id: " + id);
            Console.WriteLine("Date: " + date);

            Console.WriteLine("Customer ID: ");
            customerId = int.Parse(Console.ReadLine());
            status = "active";


            salesDTO s1 = new salesDTO();
            s1.CustomerId = customerId;
            s1.Date = date;
            s1.Status = status;
            salesBLL b1 = new salesBLL();
            b1.newSale(s1);

            return id;
        }
        private void enterNewItemSale(int salesId)
        {
            Console.WriteLine("Item ID: ");
            int id = int.Parse(Console.ReadLine());
            double price;

            itemDTO item = new itemDTO();
            item.Id = id;
            List<itemDTO> list = new List<itemDTO>();
            salesBLL bll = new salesBLL();
            list = bll.ReadItemInfo(item);


            salesDTO s1 = new salesDTO();
            itemDTO i1 = new itemDTO();

            foreach (itemDTO i in list)
            {
                 Console.WriteLine($"Description: " + i.Description);
                Console.WriteLine($"Price: " + i.Price);
                price = i.Price;
                i1.Price = price;

            }

            Console.WriteLine("Quantity: ");
            int quantity = int.Parse(Console.ReadLine());

            s1.OrderId = salesId;
            i1.Id = id;
            s1.Quantity = quantity;

            salesBLL bll1 = new salesBLL();
            bll1.addNewSaleLineItem(s1, i1);
        }

        private void cancelSale()
        {
            Console.WriteLine("\n**************** Cancel Sale ****************\n");
            salesBLL bll = new salesBLL();
            bll.DeleteAllSaleLineItem();
            bll.DeleteAllSale();

            Console.WriteLine("Sale Cancel Successfully...");
            Environment.Exit(0);
        }

        private void endSale(int salesId)
        {
            Console.WriteLine("\n**************** End Sale ****************\n");
            //salesDTO s = new salesDTO();
            salesDTO c = new salesDTO();
            Console.WriteLine(customerId);
            c.CustomerId = customerId;

            List<salesDTO> list = new List<salesDTO>();

            salesBLL sbll = new salesBLL();
            sbll.ReadDataFromSales(c);


            foreach (salesDTO i in list)
            {
                Console.WriteLine("------------------------------------------");
                Console.WriteLine($"Sales ID: " + i.OrderId);
                Console.WriteLine($"Date: " + i.Date);
                Console.WriteLine($"Customer Id: " + i.CustomerId);

            }
            Environment.Exit(0);

        }
        private void removeSale()
        { 
            Console.WriteLine("\n**************** Remove Sale ****************\n");
            Console.WriteLine("Item ID: ");
            int id = int.Parse(Console.ReadLine());

            itemDTO item = new itemDTO();
            item.Id = id;
            salesBLL bll = new salesBLL();
            bll.RemoveExistingItemFromSale(item);

            Console.WriteLine("Remove item Successfully...");
            Environment.Exit(0);
        }
        public void userInput()
        {
            showMainMenu();
            if (menuChoice == 1) //items
            {
                while (!flag)
                {
                    showItemsMenu();
                    if (itemMenuChocie == 1)
                    {
                        addItem();
                    }
                    else if (itemMenuChocie == 2)
                    {
                        modifyItem();
                    }
                    else if (itemMenuChocie == 3)
                    {
                        findItem();
                    }
                    else if (itemMenuChocie == 4)
                    {
                        removeItem();
                    }
                    else if (itemMenuChocie == 5)
                    {
                        BacktoMainMenu();
                    }
                }
            }
            else if (menuChoice == 2) //customer
            {
                while (!flag2)
                {
                    showCustomerMenu();
                    if (cusMenuChocie == 1)
                    {
                        addCustomer();
                    }
                    else if (cusMenuChocie == 2)
                    {
                        modifyCustomer();
                    }
                    else if (cusMenuChocie == 3)
                    {
                        findCustomer();
                    }
                    else if (cusMenuChocie == 4)
                    {
                        removeCustomer();
                    }
                    else if (cusMenuChocie == 5)
                    {
                        BacktoMainMenu();
                    }
                }
            }
            else if (menuChoice == 3) //Make Sale
            {
                int salesId = getSaleInfo();
                while (saleMenu != 2)
                {
                    showSalesMenu();
                    if (saleMenu == 2)
                    {
                        endSale(salesId);
                    }
                    if (saleMenu == 3)
                    {
                        removeSale();
                    }
                    else if (saleMenu == 4)
                    {
                        cancelSale();
                    }
                    enterNewItemSale(salesId);
                }

            }
            //else if(menuChoice == 4) //makepayment
            else if(menuChoice == 5)//exit
            {
                Environment.Exit(0);
            }
        }

       
    }
}