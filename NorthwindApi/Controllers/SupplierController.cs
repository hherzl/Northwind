using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using Northwind.Core.BusinessLayer.Contracts;
using Northwind.Core.EntityLayer;
using NorthwindApi.Responses;
using NorthwindApi.Services;

namespace NorthwindApi.Controllers
{
    public class SupplierController : ApiController
    {
        protected ISalesBusinessObject BusinessObject;

        public SupplierController(IUowService service)
        {
            BusinessObject = service.GetSalesBusinessObject();
        }

        protected override void Dispose(Boolean disposing)
        {
            if (BusinessObject != null)
            {
                BusinessObject.Release();
            }

            base.Dispose(disposing);
        }

        // GET: api/Supplier
        public async Task<HttpResponseMessage> Get()
        {
            var response = new ComposedSupplierResponse();

            try
            {
                var task = await BusinessObject.GetSuppliers();

                response.Model = task.ToList();
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // GET: api/Supplier/5
        public async Task<HttpResponseMessage> Get(Int32 id)
        {
            var response = new SingleSupplierResponse();

            try
            {
                response.Model = await BusinessObject.GetSupplier(new Supplier(id));
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // POST: api/Supplier
        public async Task<HttpResponseMessage> Post([FromBody]Supplier value)
        {
            var response = new SingleSupplierResponse();

            try
            {
                await BusinessObject.CreateSupplier(value);

                response.Model = value;
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // PUT: api/Supplier/5
        public async Task<HttpResponseMessage> Put(Int32 id, [FromBody]Supplier value)
        {
            var response = new SingleSupplierResponse();

            try
            {
                var entity = await BusinessObject.UpdateSupplier(value);

                if (entity == null)
                {
                    response.DidError = true;
                    response.ErrorMessage = String.Format("There isn't a record with id: {0}", id);
                }
                else
                {
                    response.Model = value;
                    response.Message = "Update was successfully!";
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }

        // DELETE: api/Supplier/5
        public async Task<HttpResponseMessage> Delete(Int32 id)
        {
            var response = new SingleSupplierResponse();

            try
            {
                var entity = await BusinessObject.DeleteSupplier(new Supplier(id));

                if (entity == null)
                {
                    response.DidError = true;
                    response.ErrorMessage = String.Format("There isn't a record with id: {0}", id);
                }
                else
                {
                    response.Model = entity;
                    response.Message = "Delete was successfully!";
                }
            }
            catch (Exception ex)
            {
                response.DidError = true;
                response.ErrorMessage = ex.Message;
            }

            return Request.CreateResponse(HttpStatusCode.OK, response);
        }
    }
}
