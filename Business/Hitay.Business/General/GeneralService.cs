using System;
using System.Collections.Generic;
using Hitay.Common;
using Hitay.Common.Helpers;
using Hitay.Common.Classes;
using Hitay.Data.Model;
using System.Linq;
using Hitay.Common.Enums;

namespace Hitay.Business.General
{
    public class GeneralService : BaseService, IGeneralService
    {
        public GeneralService(HitayEntities context) : base(context) { }

        public ServiceResult<List<CoffeeTypeDto>> GetCoffeeTypeList()
        {
            var serviceResult = new ServiceResult<List<CoffeeTypeDto>>();

            try
            {
                serviceResult.Result = GetQuery<CoffeeType>().Where(a => a.IsActive && !a.IsDelete)
                                                             .Select(a => new CoffeeTypeDto
                                                             {
                                                                 Id = a.Id,
                                                                 Type = a.Type
                                                             }).ToList();
            }
            catch (Exception e)
            {
                serviceResult.Exception = e;
                serviceResult.HasError = true;
            }

            return serviceResult;
        }

        public ServiceResult<List<OrderCountDto>> GetOrderCountByStatusGroup()
        {
            var serviceResult = new ServiceResult<List<OrderCountDto>>();

            try
            {
                serviceResult.Result = (from o in GetQuery<Order>()
                                        group o by o.StatusId into or
                                        select new OrderCountDto
                                        {
                                            Count = or.Count(),
                                            StatusId = or.FirstOrDefault().StatusId
                                        }).ToList();
            }
            catch (Exception e)
            {
                serviceResult.Exception = e;
                serviceResult.HasError = true;
            }

            return serviceResult;
        }

        public ServiceResult<List<OrderDto>> GetOrderList(int statusId)
        {
            var serviceResult = new ServiceResult<List<OrderDto>>
            {
                Result = new List<OrderDto>()
            };

            try
            {
                serviceResult.Result = (from o in GetQuery<Order>()
                                        join s in GetQuery<OrderStatus>() on o.StatusId equals s.Id
                                        join ct in GetQuery<CoffeeType>() on o.CoffeeTypeId equals ct.Id
                                        join su in GetQuery<SugarType>() on o.SugarTypeId equals su.Id
                                        where o.IsActive && !o.IsDelete
                                        select new OrderDto
                                        {
                                            CoffeeType = ct.Type,
                                            CoffeeTypeId = ct.Id,
                                            Cream = o.Cream ? "Var" : "Yok",
                                            Milk = o.Milk ? "Var" : "Yok",
                                            Id = o.Id,
                                            CustomerName = o.CustomerName,
                                            Status = s.Status,
                                            StatusId = s.Id,
                                            SugarType = su.Type,
                                            SugarTypeId = su.Id
                                        }).WhereIf(statusId > decimal.Zero, a => a.StatusId == statusId)
                                        .ToList();
            }
            catch (Exception e)
            {
                serviceResult.Exception = e;
                serviceResult.HasError = true;
            }

            return serviceResult;
        }

        public ServiceResult<bool> InsertOrder(int coffeeTypeId, string customerName, bool cream, bool milk, int sugarTypeId)
        {
            var serviceResult = new ServiceResult<bool>();

            try
            {
                var order = new Order()
                {
                    StatusId = (int)OrderStatusEnum.Preparing,
                    CoffeeTypeId = coffeeTypeId,
                    IsActive = true,
                    IsDelete = false,
                    CustomerName = customerName,
                    Cream = cream,
                    Milk = milk,
                    SugarTypeId = sugarTypeId
                };
                var query = Context.Order.Add(order);
                serviceResult.Result = Context.SaveChanges().ToBoolean();
            }
            catch (Exception e)
            {
                serviceResult.Exception = e;
                serviceResult.HasError = true;
            }

            return serviceResult;
        }

        public ServiceResult<bool> UpdateOrder(int orderId)
        {
            var serviceResult = new ServiceResult<bool>();

            try
            {
                var query = Context.Order.Where(a => a.Id == orderId).FirstOrDefault();
                if (query != null)
                {
                    query.StatusId = (int)OrderStatusEnum.Delivered;
                    serviceResult.Result = Context.SaveChanges().ToBoolean();
                }
            }
            catch (Exception e)
            {
                serviceResult.Exception = e;
                serviceResult.HasError = true;
            }

            return serviceResult;
        }

        public ServiceResult<List<SugarTypeDto>> GetSugarTypeList()
        {
            var serviceResult = new ServiceResult<List<SugarTypeDto>>();

            try
            {
                serviceResult.Result = GetQuery<SugarType>().Where(a => a.IsActive && !a.IsDelete)
                                                             .Select(a => new SugarTypeDto
                                                             {
                                                                 Type = a.Type,
                                                                 Id = a.Id
                                                             }).ToList();
            }
            catch (Exception e)
            {
                serviceResult.Exception = e;
                serviceResult.HasError = true;
            }

            return serviceResult;
        }
    }
}
