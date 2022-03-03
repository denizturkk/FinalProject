using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Concrete.InMemory;
using Entities.Concrete;
using Entities.DTOs;
using FluentValidation;
using System;
using System.Collections.Generic;

namespace Business.Concrete
{
    /// <summary>
    /// bir iş sınıfı başka bir sınıfı new'lemez
    /// </summary>
    /// 

    //burası bussiness zamanla iş kodları ile data access kodları 
    //birbirinden ayrılabilirler bu yüzden "IEntityRepository" değil de
    // "IProductService" i inherit ettik.
    public class ProductManager : IProductService
    {
        IProductDal _productDal;

        public ProductManager(IProductDal productDal)
        {
            _productDal = productDal;
        }

        [ValidationAspect(typeof(ProductValidator))]
        public IResult Add(Product product)
        {
        
            _productDal.Add(product);
            
            return new SuccessResult(Messages.ProductAdded);
        }

        public IDataResult<List<Product>> GetAll()
        {
            if (DateTime.Now.Hour == 22)
            {
                return new ErrorDataResult<List<Product>>(Messages.MaintenanceTime);
            }

            return new SuccessDataResult<List<Product>>(_productDal.GetAll(),Messages.ProductsListed);
        }

      
        public IDataResult< List<Product>> GetAllByCategoryId(int id)
        {
            // SuccessDataResult whic work with "List<Product>" and send parameters to constructor
            return new SuccessDataResult<List<Product>>( _productDal.GetAll(p=>p.CategoryId==id));
        }

        
        public IDataResult<Product> GetById(int productId)
        {
            //SuccessDataResult whic work with "Product" and send parameters to constructor
            return new SuccessDataResult<Product>( _productDal.Get(p => p.ProductId == productId));
        }

        public IDataResult<List<Product>> GetByUnitPrice(decimal min, decimal max)
        {
            return  new SuccessDataResult<List<Product>>( _productDal.GetAll(p=>p.UnitPrice>=min && p.UnitPrice<=max));
        }

        public IDataResult<List<ProductDetailDto>> GetProductDetails()
        {
            return new SuccessDataResult<List<ProductDetailDto>> (_productDal.GetProductDetails());
        }
    }
}
