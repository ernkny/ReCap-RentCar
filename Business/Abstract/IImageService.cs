using Business.Concrete;
using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IImageService
    {
        IDataResult<List<CarImages>> GetAll();
        IDataResult<List<CarImages>> GetAllByCarId(int carid);
        IDataResult<List<CarImages>> Get(int id);
        
        IResult Add(CarImages carImages,IFormFile file);
        IResult Delete(CarImages carImages);
        IResult Update(CarImages carImages);
    }
}
