using Business.Abstract;
using Business.Constants;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }
        public IResult Add(Rental rental)
        {
            
            var result = BusinessRules.Run(CheckIfTheCarHasBeenDelivered(rental));
            if (!result.Success) return result;

            _rentalDal.Add(rental);            
            return new SuccessResult(Messages.RentalAdded);
        }

        public IResult Deleted(Rental rental)
        {
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll());
        }

        public IDataResult<Rental> GetById(int rentalId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(c => c.RentalsId == rentalId));
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails());
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult();
        }

        private IResult CheckIfTheCarHasBeenDelivered(Rental rental)
        {
            var result = _rentalDal.Get(r => r.CarsId == rental.CarsId && r.ReturnDate == null);
            if (result != null)
                if (rental.ReturnDate == null || rental.ReturnDate > result.RentDate)
                    return new ErrorResult(Messages.TheCarHasNotBeenDeliveredYet);
            return new SuccessResult();
        }
    }
}
