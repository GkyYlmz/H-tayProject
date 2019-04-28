using Hitay.Common;
using Hitay.Common.Classes;
using Hitay.Data.Model;
using System.Collections.Generic;

namespace Hitay.Business.General
{
    public interface IGeneralService
    {
        ServiceResult<List<OrderDto>> GetOrderList(int statusId);

        ServiceResult<List<CoffeeTypeDto>> GetCoffeeTypeList();

        ServiceResult<List<OrderCountDto>> GetOrderCountByStatusGroup();

        ServiceResult<bool> UpdateOrder(int orderId);

        ServiceResult<List<SugarTypeDto>> GetSugarTypeList();

        ServiceResult<bool> InsertOrder(int coffeeTypeId, string customerName, bool cream, bool milk, int sugarTypeId);
    }
}
