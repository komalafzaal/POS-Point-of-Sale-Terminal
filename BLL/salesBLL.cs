using DAL;
using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class salesBLL
    {
        public int ReadLastRecordID(salesDTO sdto)
        {
            salesDAL sdal = new salesDAL();
            return sdal.ReadLastRecordID(sdto);
          
        }
        public void newSale(salesDTO sdto)
        {
            salesDAL sdal = new salesDAL();
            sdal.newSale(sdto);
        }
        public List<itemDTO> ReadItemInfo(itemDTO dto)
        {
            salesDAL dal = new salesDAL();
            List<itemDTO> list = new List<itemDTO>();
            List<itemDTO> activeList = new List<itemDTO>();

            list = dal.ReadItemInfo(dto);
            foreach (itemDTO item in list)
            {
                activeList.Add(item);
            }
            return list;
        }
        public void addNewSaleLineItem(salesDTO sdto, itemDTO idto)
        { 
            
            salesDAL sdal = new salesDAL();
           
            sdto.Amount = subTotalPrice(idto.Price, sdto.Quantity);
            sdal.addNewSaleLineItem(sdto, idto);

            Console.WriteLine("Amount:"+ sdto.Amount);
        }

        private double subTotalPrice(double price, int quantity)
        {
            return price * quantity;
        }

        public void DeleteAllSale()
        {
            salesDAL dal = new salesDAL();
            dal.DeleteAllSale();
        }
        public void DeleteAllSaleLineItem()
        {
            salesDAL dal = new salesDAL();
            dal.DeleteAllSaleLineItem();
        }
        public void RemoveExistingItemFromSale(itemDTO idto)
        {
            salesDAL dal = new salesDAL();
            dal.RemoveExistingItemFromSale(idto);
        }

        public List<salesDTO> ReadDataFromSales(salesDTO dto)
        {
            salesDAL dal = new salesDAL();
            List<salesDTO> list = new List<salesDTO>();
            List<salesDTO> activeList = new List<salesDTO>();

            list = dal.ReadDataFromSales(dto);
            foreach (salesDTO sale in list)
            {
                activeList.Add(sale);
            }
            return list;
        }
    }
}
