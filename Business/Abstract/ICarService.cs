using Core.Utilities.Results;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IDataResult<List<Car>> GetAll();
        IDataResult<List<Car>> GetAllByBrandId(int id);

        IDataResult<List<Car>> GetbyDailyPrice(int min, int max);
        IDataResult<List<CarDetailDto>> GetCarDetails();
        IResult Add(Car car);
         
    }
}
