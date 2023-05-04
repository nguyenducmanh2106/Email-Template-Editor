using IIG.Core.Framework.Email.Infrastructure.EntityFramework.Datatables;
using IIG.Core.Framework.Email.Infrastructure.EntityFramework.Repositories;
using IIG.Core.Framework.Email.Infrastructure.Utils;
using Microsoft.AspNetCore.Http;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IIG.Core.Framework.Email.Business.Application
{
    public class ApplicationHandler : IApplicationHandler
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public ApplicationHandler(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public ResponseData Bootstrap()
        {
            try
            {
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);

                return new ResponseData(Code.Success, "");
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return new ResponseDataError(Code.ServerError, e.Message);
            }
        }

        public ResponseData Create(ApplicationModel model)
        {
            try
            {
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                model.Id = Guid.NewGuid();
                unitOfWork.Repository<SysApplication>().Insert(new SysApplication()
                {
                    Code = model.Code,
                    Description = model.Description,
                    Id = Guid.NewGuid(),
                    IsDeleted = model.IsDeleted,
                    IsLocked = model.IsLocked,
                    Name = model.Name
                });
                unitOfWork.Save();
                return new ResponseData(Code.Success, "Success");
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return new ResponseDataError(Code.ServerError, e.Message);
            }
        }

        public ResponseData Delete(Guid id)
        {
            try
            {
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                var existApp = unitOfWork.Repository<SysApplication>().GetById(id);
                if (existApp != null)
                {
                    existApp.IsDeleted = true;
                    unitOfWork.Repository<SysApplication>().Update(existApp);
                    unitOfWork.Save();
                    return new ResponseData(Code.Success, "");
                }
                return new ResponseDataError(Code.NotFound, "Not found");
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return new ResponseDataError(Code.ServerError, e.Message);
            }
        }

        public ResponseData Get()
        {
            try
            {
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                var data = unitOfWork.Repository<SysApplication>().Get().Where(x => !x.IsDeleted);
                List<ApplicationModel> result = new();
                foreach (var item in data)
                {
                    result.Add(new ApplicationModel()
                    {
                        Code = item.Code,
                        Description = item.Description,
                        Id = item.Id,
                        IsDeleted = item.IsDeleted,
                        IsLocked = item.IsLocked,
                        Name = item.Name
                    });
                }
                return new ResponseDataObject<List<ApplicationModel>>(result, Code.Success, "Success");
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return new ResponseDataError(Code.ServerError, e.Message);
            }
        }

        public ResponseData GetById(Guid id)
        {
            try
            {
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                var exitsData = unitOfWork.Repository<SysApplication>().GetById(id);
                if (exitsData == null)
                    return new ResponseDataError(Code.NotFound, "Id not found");
                else
                    return new ResponseDataObject<ApplicationModel>(new ApplicationModel()
                    {
                        Code = exitsData.Code,
                        Description = exitsData.Description,
                        Id = exitsData.Id,
                        Name = exitsData.Name
                    }, Code.Success, "");
            }
            catch (Exception exception)
            {
                Log.Error(exception, exception.Message);
                return new ResponseDataError(Code.ServerError, exception.Message);
            }
        }

        public ResponseData Update(Guid id, ApplicationModel model)
        {
            try
            {
                using var unitOfWork = new UnitOfWork(_httpContextAccessor);
                var existApp = unitOfWork.Repository<SysApplication>().GetById(id);
                if (existApp != null)
                {
                    existApp.Code = model.Code;
                    existApp.Description = model.Description;
                    existApp.IsDeleted = model.IsDeleted;
                    existApp.IsLocked = model.IsLocked;
                    existApp.Name = model.Name;
                    unitOfWork.Repository<SysApplication>().Update(existApp);
                    unitOfWork.Save();
                    return new ResponseData(Code.Success, "Success");
                }
                return new ResponseDataError(Code.NotFound, "Not found");
            }
            catch (Exception e)
            {
                Log.Error(e, e.Message);
                return new ResponseDataError(Code.ServerError, e.Message);
            }
        }
    }
}
