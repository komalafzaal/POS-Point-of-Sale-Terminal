namespace BLL;
using DAL;
using DTO;
using System.Collections.Generic;


public class itemBLL
{
    public void AddItem(itemDTO idto)
    {
        itemDAL idal = new itemDAL();
        idal.AddItem(idto);
    }

    public void ModifyItem(itemDTO idto)
    {
        itemDAL idal = new itemDAL();
        idal.ModifyItem(idto);
    }
    public bool ValidateItemId(itemDTO idto)
    {
        itemDAL idal = new itemDAL();
        bool flag = idal.ValidateItemId(idto);
        if(flag)
        {
            return true;
        }
        return false;
    }
    public bool FindItem(itemDTO idto)
    {
        itemDAL cdal = new itemDAL();
        bool flag = cdal.FindItem(idto);
        if (flag)
        {
            return true;
        }
        return false;
    }

    public void RemoveExistingItem(itemDTO idto)
    {
        itemDAL idal = new itemDAL();
        idal.RemoveExistingItem(idto);
    }

    public List<itemDTO> ReadItems(itemDTO idto)
    {
        itemDAL idal = new itemDAL();
        List<itemDTO> list = new List<itemDTO>();
        List<itemDTO> activeList = new List<itemDTO>();

        list = idal.ReadAllItems(idto);
        foreach(itemDTO item in list)
        {
            activeList.Add(item);
        }
        return list;
    }

    public List<itemDTO> ReadFindItems(itemDTO idto)
    {
        itemDAL cdal = new itemDAL();
        List<itemDTO> list = new List<itemDTO>();
        List<itemDTO> activeList = new List<itemDTO>();

        list = cdal.ReadFindItems(idto);
        foreach (itemDTO i in list)
        {
            activeList.Add(i);
        }
        return list;

    }

}