using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using Entities.Concrete;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using DataAccess.Abstract;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using System.IO;

namespace Business.Concrete
{
    public class ImageManager : IImageService
    {
        IImageDal _ımageDal;
        private string pathway;
        
        public ImageManager(IImageDal ımageDal)
        {
            _ımageDal = ımageDal;
        }
        public IResult Add(CarImages carImages,IFormFile file)
        {

            IResult result = BusinessRules.Run(TotalPictureControl(carImages.CarId),FileUploadControl(file));
            if (result!=null)
            {
                return result;
            }

            CarImages car = new CarImages
            {
              
                CarId = carImages.CarId,
                Date = DateTime.UtcNow,
                ImagePath = pathway
                
            };
            _ımageDal.Add(car);
            return new SuccessResult(Messages.CarImageAdded);

            
        }

        public IResult Delete(CarImages carImages)
        {
            IResult result=BusinessRules.Run(FindImagesForDelete(carImages.Id));
            if (result!=null)
            {
                return result;
            }
            _ımageDal.Delete(carImages);

            return new SuccessResult(Messages.CarImageDeleted);
        }

        public IDataResult<List<CarImages>> Get(int id)
        {
            
            return new SuccessDataResult<List<CarImages>>(); ;
        }

        public IDataResult<List<CarImages>> GetAll()
        {
            throw new NotImplementedException();
        }

        public IDataResult<List<CarImages>> GetAllByCarId(int carid)
        {
            throw new NotImplementedException();
        }

        public IResult Update(CarImages carImages)
        {
            _ımageDal.Update(carImages);
            return new SuccessResult();
        }
        private IResult TotalPictureControl(int CarId) {
            
            var result = _ımageDal.GetAll(c => c.CarId == CarId).Count();
            if (result > 5)
            {
                return new ErrorResult(Messages.TotalPictureMoreThanFive);
            }

            return new SuccessResult();


        }
        
        private IResult IfCarImageEmpty(string imagepath)
        {
            if (imagepath==null)
            {
                
                return new SuccessResult();

            }
            return new SuccessResult();



        }
        private IResult FileUploadControl(IFormFile file)
        {
            if (file != null && file.Length > 0)
            {
                var extensiton = Path.GetExtension(file.FileName);
                if (extensiton == ".jpg" || extensiton == ".png")
                {
                    string guid = Guid.NewGuid().ToString();
                    string Pathway = Path.Combine(@"..\Image", guid + extensiton);
                    var filestream = new FileStream(Pathway, FileMode.Create, FileAccess.Write);
                    file.CopyTo(filestream);
                    
                    pathway=Pathway;
                    return new SuccessResult();
                }


            }
            pathway = @"..\image\default.png";
            return new SuccessResult();
        }
        private IResult FindImagesForDelete(int id)
        {
            var result=_ımageDal.Get(c => c.Id == id );

            if (result.ImagePath== @"..\image\default.png")
            {
                return new SuccessResult();
            }
                File.Delete(result.ImagePath);
            return new SuccessResult();
        }
    }
}
