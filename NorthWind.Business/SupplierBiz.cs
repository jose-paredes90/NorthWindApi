using AutoMapper;
using Microsoft.EntityFrameworkCore;
using NorthWind.Dto;
using NorthWind.Dto.Request;
using NorthWind.Entity.Models;
using NorthWind.Interfaces.Business;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NorthWind.Business
{
    public class SupplierBiz : ISupplierBiz
    {
        private readonly IMapper mapper;
        private readonly NorthwindContext context;

        public SupplierBiz(IMapper mapper, NorthwindContext context)
        {
            this.mapper = mapper;
            this.context = context;
        }

        public SupplierDto GetSupplierById(int supplierId)
        {
            var supplier = context.Suppliers
                .FirstOrDefault(x => x.SupplierId == supplierId);
            var response = mapper.Map<Suppliers, SupplierDto>(supplier);
            return response;
        }


        public List<SupplierDto> GetCustomersByCity(string city)
        {
            var proveedor = context.Suppliers
                .Where(x => x.City.Contains(city))
                .ToList();
            var response = mapper.Map<List<Suppliers>, List<SupplierDto>>(proveedor);
            return response;
            }

        public int SaveSupplier(SupplierRequest request)
        {
            var entity = new Suppliers()
            {
                Address = request.Address,
                CompanyName = request.CompanyName,
                ContactName = request.ContactName,
                ContactTitle = request.ContactTitle,
                Country = request.Country,
                City = request.City,
                Phone = request.Phone
            };
            context.Suppliers.Add(entity);
            context.SaveChanges();
            return entity.SupplierId;
        }

        public SupplierDto UpdateSupplier(int id, SupplierUpdateRequest updateRequest)
        {
            Suppliers supplier = context.Suppliers.FirstOrDefault(x => x.SupplierId == id);
            if (supplier == null) return null;

            supplier.ContactName = updateRequest.ContactName;
            supplier.CompanyName = updateRequest.CompanyName;
            supplier.Address = updateRequest.Address;
            supplier.Phone = updateRequest.Phone;

            context.Entry(supplier).State = EntityState.Modified;
            context.SaveChanges();

            var response = mapper.Map<Suppliers, SupplierDto>(supplier);

            return response;
        }

        public void DeleteSupplier(int id)
        {
            Suppliers supplier = context.Suppliers.FirstOrDefault(supplier => supplier.SupplierId == id);

            context.Remove(supplier).State = EntityState.Deleted;
            context.SaveChanges();      
        }
    }
}
