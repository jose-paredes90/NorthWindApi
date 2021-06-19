using NorthWind.Dto;
using NorthWind.Dto.Request;
using System;
using System.Collections.Generic;
using System.Text;

namespace NorthWind.Interfaces.Business
{
    public interface ISupplierBiz
    {
        SupplierDto GetSupplierById(int supplierId);
        List<SupplierDto> GetCustomersByCity(string city);
        int SaveSupplier(SupplierRequest request);
        SupplierDto UpdateSupplier(int id, SupplierUpdateRequest updateRequest);
        void DeleteSupplier(int id);
    }
}
