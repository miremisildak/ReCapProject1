using Core.Utilities.Results;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarImageService
    {
        IResult Add(int carId, IFormFile file);
        IResult Update(int id, IFormFile file);
        IResult Delete(int id);
        IDataResult<List<CarImage>> GetByCarId(int carId);
        IDataResult<List<CarImage>> GetAll();
    }
}
